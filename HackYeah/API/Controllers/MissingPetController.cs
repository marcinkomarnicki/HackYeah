using HackYeah.Application.Commands;
using HackYeah.Application.Queries;
using HackYeah.Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MissingPetController : ControllerBase
{
    private readonly IMediator _mediator;

    public MissingPetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<Guid> PutReport(AddMissingPetCommand input )
    {
        var result = await _mediator.Send(input);

        return result;
    }
    
    [HttpPost]
    public async Task<List<GetMissingPetResult>> GetMissingEncounter( )
    {
        var result = await _mediator.Send(new GetMissingPetsQuery());

        return result;
    }
    
    [HttpPost]
    [Route("/{id}")]
    public async Task<GetMissingPetResult> GetMissingEncounter([FromRoute] Guid id )
    {
        var result = await _mediator.Send(new GetMissingPetQuery
        {
            MissingPetReportId = id
        });

        return result;
    }
}