using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetMissingPetsQuery : IRequest<List<GetMissingPetResult>>
    {
    }

    public class GetMissingPetsQueryHandler : IRequestHandler<GetMissingPetsQuery, List<GetMissingPetResult>>
    {
        private readonly HackYeahDbContext _dbContext;

        public GetMissingPetsQueryHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetMissingPetResult>> Handle(GetMissingPetsQuery request,
            CancellationToken cancellationToken)
        {
            var dataFromDb = _dbContext.MissingPetsReports
                .Include(encounter => encounter.EncounterType)
                .ToList();

            var result = dataFromDb.Select(e => new GetMissingPetResult()
            {
                EncounterTypeId = e.EncounterTypeId,
                EncounterTypeName = e.EncounterType.Code,
                Color = e.Color,
                Rase = e.Rase,
                HasCollar = e.HasCollar,
                LatitudeReport = e.LatitudeReport,
                LongitudeReport = e.LongitudeReport,
                PetName = e.PetName,
                PetSize = e.PetName,
                ReporterName = e.ReporterName,
                SpecialFeatures = e.SpecialFeatures,
                TelephoneNumber = e.TelephoneNumber
            }).ToList();

            return result;
        }
    }
}