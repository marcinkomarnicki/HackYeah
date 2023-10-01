using Dapper;
using HackYeah.Application.Enums;
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
            var queryResult =
                await _dbConnection.QueryAsync<GetEncounterTypesQueryResult>(
                    "select et.id, et.code, etp.name, et.is_searchable \"IsSearchable\", etp.value_type \"ValueType\", etp.id \"PropertyId\"\nfrom encounter_type et\njoin encounter_type_properties_encounter_types etpet on etpet.encounter_type_id = et.id\njoin encounter_type_property etp on etpet.encounter_type_property_id = etp.id\n");

            var groups = queryResult.GroupBy(x => new { x.Id, x.Code, x.IsSearchable });


            var result = groups.Select(x => new GetEncounterTypesResult
            {
                Id = x.Key.Id,
                Code = x.Key.Code,
                IsWild = !x.Key.IsSearchable,
                Properties = x.Select(z => new GetEncounterTypesResultProperties
                {
                    Id = z.PropertyId,
                    Name = z.Name,
                    ValueType = z.ValueType.ToString()
                }).ToList()
            });


            return result.ToList();
        }
    }
}

public class GetEncounterTypesQueryResult
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public bool IsSearchable { get; set; }
    public string Name { get; set; }
    public EValueType ValueType { get; set; }
    public Guid PropertyId { get; set; }
}