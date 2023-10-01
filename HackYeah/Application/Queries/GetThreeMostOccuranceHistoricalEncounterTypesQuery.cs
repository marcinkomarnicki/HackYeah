using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetThreeMostOccuranceHistoricalEncounterTypesQuery : IRequest<List<string>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MinLatitude { get; set; }
        public decimal MaxLatitude { get; set; }
        public decimal MinLongitude { get; set; }
        public decimal MaxLongitude { get; set; }
    }

    public class GetHistoricalEncountersQueryHandler : IRequestHandler<GetThreeMostOccuranceHistoricalEncounterTypesQuery, List<string>>
    {
        private readonly HackYeahDbContext _dbContext;

        public GetHistoricalEncountersQueryHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> Handle(GetThreeMostOccuranceHistoricalEncounterTypesQuery request, CancellationToken cancellationToken)
        {
            var dataFromDb = _dbContext.Encounters
                .Where(e => e.TimeUtc > request.StartDate &&
                            e.TimeUtc < request.EndDate &&
                            e.Latitude < request.MaxLatitude &&
                            e.Latitude > request.MinLatitude &&
                            e.Longitude < request.MaxLongitude &&
                            e.Longitude > request.MinLongitude)
                .Include(encounter => encounter.EncounterType)
                .Where(p => p.EncounterType.IsSearchable == false)
                .ToList();

            var types = dataFromDb.Select(e => e.EncounterType.Code);

            var result = types
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => g.Key)
                .ToList();

            return result;
        }
    }
}
