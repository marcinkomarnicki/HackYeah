using HackYeah.DAL;
using HackYeah.DAL.Models;
using MediatR;

namespace HackYeah.Application.Commands;

public class AddMissingPetCommand : IRequest<Guid>
{
    public Guid EncounterTypeId { get; set; }
    public string Rase { get; set; }
    public string PetName { get; set; }
    public string ReporterName { get; set; }
    public string TelephoneNumber { get; set; }
    public decimal LongitudeReport { get; set; }
    public decimal LatitudeReport { get; set; }
    public bool HasCollar { get; set; }
    public string SpecialFeatures { get; set; }
    public string Color { get; set; }
    public string PetSize { get; set; }
}

public class AddMissingPetCommandHandler : IRequestHandler<AddMissingPetCommand, Guid>
{
    private readonly HackYeahDbContext _dbContext;

    public AddMissingPetCommandHandler(HackYeahDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(AddMissingPetCommand request, CancellationToken cancellationToken)
    {
        var report = new MissingPetReport()
        {
            EncounterTypeId = request.EncounterTypeId,
            Rase = request.Rase,
            TelephoneNumber = request.TelephoneNumber,
            LongitudeReport = request.LongitudeReport,
            LatitudeReport = request.LatitudeReport,
            HasCollar = request.HasCollar,
            SpecialFeatures = request.SpecialFeatures,
            Color = request.Color,
            PetSize = request.PetSize,
            PetName = request.PetName,
            ReporterName = request.ReporterName,
            EncounterType = null
        };

        _dbContext.Add(report);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return report.Id;
    }
}