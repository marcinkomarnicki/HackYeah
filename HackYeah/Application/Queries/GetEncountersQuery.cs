using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;
using HackYeah.Infrastructure.Providers;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

namespace HackYeah.Application.Queries
{
    public class GetEncountersQuery : IRequest<List<EncounterResult>>
    {
        public decimal MinLatitude { get; set; }
        public decimal MaxLatitude { get; set; }
        public decimal MinLongitude { get; set; }
        public decimal MaxLongitude { get; set; }
        public string EncounterType { get; set; }
        public bool IsWild { get; set; }
    }

    public class GetEncountersQueryHandler : IRequestHandler<GetEncountersQuery, List<EncounterResult>>
    {
        private readonly HackYeahDbContext _dbContext;
        private readonly HostProvider _hostProvider;

        public GetEncountersQueryHandler(HackYeahDbContext dbContext, HostProvider hostProvider)
        {
            _dbContext = dbContext;
            _hostProvider = hostProvider;
        }

        public async Task<List<EncounterResult>> Handle(GetEncountersQuery request, CancellationToken cancellationToken)
        {
            var timeNow = DateTime.UtcNow;
            var minTime = timeNow.AddHours(-10);

            var dataFromDb = _dbContext.Encounters
                .Where(e =>
                    (string.IsNullOrWhiteSpace(request.EncounterType) ||
                     e.EncounterType.Code == request.EncounterType) &&
                    e.Latitude < request.MaxLatitude &&
                    e.Latitude > request.MinLatitude &&
                    e.Longitude < request.MaxLongitude &&
                    e.Longitude > request.MinLongitude)
                .Include(encounter => encounter.EncounterType)
                .Include(encounter => encounter.EncounterProperties)
                .ThenInclude(propType => propType.EncounterTypeProperty)
                .Where(p => p.EncounterType.IsSearchable != request.IsWild
                            && (!request.IsWild || p.TimeUtc > minTime))
                .ToList();

            var result = dataFromDb.Select(e => new EncounterResult()
            {
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                IsWild = !e.EncounterType.IsSearchable,
                EncounterType = e.EncounterType.Code,
                TimeUtc = e.TimeUtc,
                PropabilityOfOccurance = 100 - (int)(((timeNow - e.TimeUtc).TotalMinutes / 180.0) * 100.0),
                Properties = e.EncounterProperties.Select(p => new EncounterResultProperties
                {
                    Name = p.EncounterTypeProperty.Name,
                    ValueType = p.EncounterTypeProperty.ValueType.ToString(),
                    Value = p.Value
                }).ToList(),
                Images = GetImages(e.Id)
            }).ToList();

            return result;
        }

        private List<string> GetImages(Guid encounterId)
        {
            var scheme = _hostProvider.Scheme;
            var host = _hostProvider.Host;

            return _dbContext.EncounterImages
                .Where(image => image.EncounterId == encounterId)
                .ToList()
                .Select(image => $"{scheme}://{host}/Encounter/Image/{image.Id}")
                .ToList();
        }
    }
}