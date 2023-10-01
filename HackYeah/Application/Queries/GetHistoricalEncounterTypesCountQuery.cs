using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetHistoricalEncounterTypesCountQuery : IRequest<TypeCounterResult>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MinLatitude { get; set; }
        public decimal MaxLatitude { get; set; }
        public decimal MinLongitude { get; set; }
        public decimal MaxLongitude { get; set; }
        public string EncounterType { get; set; }
    }

    public class GetHistoricalEncounterTypesCOuntQueryHandler : IRequestHandler<GetHistoricalEncounterTypesCountQuery, TypeCounterResult>
    {
        private readonly HackYeahDbContext _dbContext;

        public GetHistoricalEncounterTypesCOuntQueryHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TypeCounterResult> Handle(GetHistoricalEncounterTypesCountQuery request, CancellationToken cancellationToken)
        {
            var dataFromDb = _dbContext.Encounters
                .Where(e => e.EncounterType.Code == request.EncounterType &&
                            e.TimeUtc > request.StartDate &&
                            e.TimeUtc < request.EndDate &&
                            e.Latitude < request.MaxLatitude &&
                            e.Latitude > request.MinLatitude &&
                            e.Longitude < request.MaxLongitude &&
                            e.Longitude > request.MinLongitude)
                .Include(encounter => encounter.EncounterType)
                .Where(p => p.EncounterType.IsSearchable == false)
                .ToList();

            var count = dataFromDb.Count;
            var lastOccurance = dataFromDb.Select(e => e.TimeUtc).Max();

            var result = new TypeCounterResult()
            {
                EncounterType = request.EncounterType,
                LastOccurance = lastOccurance,
                OccuranceCount = count
            };

            return result;
        }
    }
}
