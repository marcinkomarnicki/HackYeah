using HackYeah.DAL;
using MediatR;

namespace HackYeah.Application.Commands
{
    public class AddRenaultCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class AddRenaultCommandHandler : IRequestHandler<AddRenaultCommand>
    {
        private readonly HackYeahDbContext _dbContext;

        public AddRenaultCommandHandler(HackYeahDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Handle(AddRenaultCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
