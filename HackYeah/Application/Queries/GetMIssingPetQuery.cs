using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;
using HackYeah.Infrastructure.Providers;

namespace HackYeah.Application.Queries
{
    public class GetMissingPetQuery : IRequest<GetMissingPetResult>
    {
        public Guid MissingPetReportId { get; set; }
    }

    public class GetMissingPetQueryHandler : IRequestHandler<GetMissingPetQuery, GetMissingPetResult>
    {
        private readonly HackYeahDbContext _dbContext;
        private readonly HostProvider _hostProvider;

        public GetMissingPetQueryHandler(HackYeahDbContext dbContext, HostProvider hostProvider)
        {
            _dbContext = dbContext;
            _hostProvider = hostProvider;
        }

        public async Task<GetMissingPetResult> Handle(GetMissingPetQuery request,
            CancellationToken cancellationToken)
        {
            var report = _dbContext.MissingPetsReports
                .Include(encounter => encounter.EncounterType)
                .FirstOrDefault(x => x.Id == request.MissingPetReportId);

            var result = new GetMissingPetResult()
            {
                Id = report.Id,
                EncounterTypeId = report.EncounterTypeId,
                EncounterTypeName = report.EncounterType.Code,
                Color = report.Color,
                Rase = report.Rase,
                HasCollar = report.HasCollar,
                LatitudeReport = report.LatitudeReport,
                LongitudeReport = report.LongitudeReport,
                PetName = report.PetName,
                PetSize = report.PetName,
                ReporterName = report.ReporterName,
                SpecialFeatures = report.SpecialFeatures,
                TelephoneNumber = report.TelephoneNumber
            };

            var images = _dbContext.MissingPetsReportImages
                .Where(image => image.MissingPetReportId == report.Id)
                .ToList();

            var scheme = _hostProvider.Scheme;
            var host = _hostProvider.Host;

            foreach (var image in images)
            {
                result.Images.Add($"{scheme}://{host}/MissingPet/Image/{image.Id}");
            }

            return result;
        }
    }
}