using HackYeah.Application.Commands;
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

    [HttpPost]
    public async Task<int>Image([FromForm] ReportImageEncounterCommand input)
    {
        var type = await _mediator.Send(input);

        return type;
    }
}