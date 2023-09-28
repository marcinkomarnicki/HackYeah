using Dapper;
using HackYeah.Application.Commands.Models;
using HackYeah.DAL;
using HackYeah.Infrastructure.Providers;
using MediatR;
using System.Text.Json;

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
        private readonly HttpClient _httpClient;

        public AddRenaultCommandHandler(HackYeahDbContext dbContext, 
            CurrentUserProvider currentUserProvider, 
            HackYeahDbConnection dbConnection,
            HttpClient httpClient)
        {
            _dbContext = dbContext;
            _currentUserProvider = currentUserProvider;
            _dbConnection = dbConnection;
            _httpClient = httpClient;
        }

        public async Task Handle(AddRenaultCommand request, CancellationToken cancellationToken)
        {
            var userName = _currentUserProvider.UserName;

            var count = await _dbConnection.ExecuteScalarAsync<int>("select count(*) from demos");

            var response = await _httpClient.GetAsync("https://catfact.ninja/fact", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var catFact = JsonSerializer.Deserialize<CatFact>(responseContent);
            }

            throw new NotImplementedException();
        }
    }
}
