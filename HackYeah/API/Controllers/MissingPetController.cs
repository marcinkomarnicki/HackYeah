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

    [HttpPost]
    public async Task<Guid> GetMissingEncounter(ReportEncounterCommand input)
    {
        var id = await _mediator.Send(input);

        return id;
    }
}