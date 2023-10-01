using HackYeah.Application.Queries.Models;
using MediatR;
using HackYeah.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackYeah.Application.Queries
{
    public class GetMissingPetQuery : IRequest<GetMissingPetResult>
    {
        public Guid MissingPetReportId { get; set; }
    }

    public class GetMissingPetQueryHandler : IRequestHandler<GetMissingPetQuery, GetMissingPetResult>
    {
        private readonly HackYeahDbContext _dbContext;

        public GetMissingPetQueryHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMissingPetResult> Handle(GetMissingPetQuery request,
            CancellationToken cancellationToken)
        {
            var report = _dbContext.MissingPetsReports
                .Include(encounter => encounter.EncounterType)
                .FirstOrDefault(x => x.Id == request.MissingPetReportId);

            var result = new GetMissingPetResult()
            {
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

            return result;
        }
    }
}