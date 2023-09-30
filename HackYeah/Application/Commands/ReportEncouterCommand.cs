using HackYeah.DAL;
using HackYeah.DAL.Models;
using MediatR;

namespace HackYeah.Application.Commands;

public class ReportEncounterCommand : IRequest<Guid>
{
    public decimal Longitude { get; init; }
    public decimal Latitude { get; init; }
    public Guid EncounterTypeId { get; set; }

    public Dictionary<Guid, string> Properties { get; set; }
}

public class ReportEncounterCommandHandler : IRequestHandler<ReportEncounterCommand, Guid>
{
    private readonly HackYeahDbContext _dbContext;

    public ReportEncounterCommandHandler(HackYeahDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(ReportEncounterCommand request, CancellationToken cancellationToken)
    {
        var encounter = new Encounter
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            EncounterType = null,
            EncounterTypeId = request.EncounterTypeId,
            TimeUtc = DateTime.UtcNow,
            EncounterProperties = request.Properties.Select(x => new EncounterProperty
            {
                EncounterTypePropertyId = x.Key,
                Value = x.Value
            }).ToList()
        };

        _dbContext.Add(encounter);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return encounter.Id;
    }
}