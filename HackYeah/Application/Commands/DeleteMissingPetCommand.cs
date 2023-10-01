using HackYeah.DAL;
using HackYeah.DAL.Models;
using MediatR;

namespace HackYeah.Application.Commands;

public class DeleteMissingPetCommand : IRequest<Guid>
{
    public Guid MissingPetReportId { get; set; }
}

public class DeleteMissingPetCommandHandler : IRequestHandler<DeleteMissingPetCommand, Guid>
{
    private readonly HackYeahDbContext _dbContext;

    public DeleteMissingPetCommandHandler(HackYeahDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(DeleteMissingPetCommand request, CancellationToken cancellationToken)
    {

        var entityToRemove = _dbContext.MissingPetsReports.FirstOrDefault(e => e.Id == request.MissingPetReportId);

        _dbContext.MissingPetsReports.Remove(entityToRemove);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entityToRemove.Id;
    }
}