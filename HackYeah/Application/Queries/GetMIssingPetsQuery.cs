using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;
using HackYeah.Infrastructure.Providers;

namespace HackYeah.Application.Queries
{
    public class GetMissingPetsQuery : IRequest<List<GetMissingPetResult>>
    {
    }

    public class GetMissingPetsQueryHandler : IRequestHandler<GetMissingPetsQuery, List<GetMissingPetResult>>
    {
        private readonly HackYeahDbContext _dbContext;
        private readonly HostProvider _hostProvider;

        public GetMissingPetsQueryHandler(HackYeahDbContext dbContext, HostProvider hostProvider)
        {
            _dbContext = dbContext;
            _hostProvider = hostProvider;
        }

        public async Task<List<GetMissingPetResult>> Handle(GetMissingPetsQuery request,
            CancellationToken cancellationToken)
        {
            var scheme = _hostProvider.Scheme;
            var host = _hostProvider.Host;

            var dataFromDb = _dbContext.MissingPetsReports
                .Include(encounter => encounter.EncounterType)
                .ToList();

            var result = dataFromDb.Select(e => new GetMissingPetResult()
            {
                Id = e.Id,
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

            foreach (var missingPet in result) 
            {
                var images = _dbContext.MissingPetsReportImages
                    .Where(image => image.MissingPetReportId == missingPet.Id)
                    .ToList();

                foreach (var image in images)
                {
                    missingPet.Images.Add($"{scheme}://{host}/MissingPet/Image/{image.Id}");
                }
            }

            return result;
        }
    }
}