using HackYeah.DAL;
using HackYeah.Infrastructure.Providers;
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
        private readonly CurrentUserProvider _currentUserProvider;

        public AddRenaultCommandHandler(HackYeahDbContext dbContext, CurrentUserProvider currentUserProvider)
        {
            _dbContext = dbContext;
            _currentUserProvider = currentUserProvider;
        }

        public Task Handle(AddRenaultCommand request, CancellationToken cancellationToken)
        {
            var userName = _currentUserProvider.UserName;

            throw new NotImplementedException();
        }
    }
}
