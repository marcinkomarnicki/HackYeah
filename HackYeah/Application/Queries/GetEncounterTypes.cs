using Dapper;
using HackYeah.Application.Queries.Models;
using HackYeah.DAL;
using MediatR;

namespace HackYeah.Application.Queries
{
    public class GetEncounterTypes : IRequest<List<GetEncounterTypesResult>>
    {
    }

    public class GetEncounterTypesHandler : IRequestHandler<GetEncounterTypes, List<GetEncounterTypesResult>>
    {
        private readonly HackYeahDbConnection _dbConnection;

        public GetEncounterTypesHandler(HackYeahDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetEncounterTypesResult>> Handle(GetEncounterTypes request,
            CancellationToken cancellationToken)
        {
            var result =
                await _dbConnection.QueryAsync<GetEncounterTypesResult>("select et.id, et.code from encounter_type et");
            return result.ToList();
        }
    }
}