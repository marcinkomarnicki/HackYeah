using HackYeah.Application.Commands;
using HackYeah.Application.Queries;
using HackYeah.Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EncounterController : ControllerBase
{
    private readonly IMediator _mediator;

    public EncounterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<Guid> PutEncounter(ReportEncounterCommand input)
    {
        var id = await _mediator.Send(input);

        return id;
    }

    [HttpGet]
    public async Task<List<EncounterResult>> GetEncounters(GetEncountersQuery input)
    {
        return await _mediator.Send(input);
    }
}