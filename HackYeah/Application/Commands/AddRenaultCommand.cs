using Dapper;
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
        private readonly HackYeahDbConnection _dbConnection;
        private readonly CurrentUserProvider _currentUserProvider;

        public AddRenaultCommandHandler(HackYeahDbContext dbContext, CurrentUserProvider currentUserProvider, HackYeahDbConnection dbConnection)
        {
            _dbContext = dbContext;
            _currentUserProvider = currentUserProvider;
            _dbConnection = dbConnection;
        }

        public async Task Handle(AddRenaultCommand request, CancellationToken cancellationToken)
        {
            var userName = _currentUserProvider.UserName;

            var count = await _dbConnection.ExecuteScalarAsync<int>("select count(*) from demos");

            throw new NotImplementedException();
        }
    }
}
