using HackYeah.Application.Commands;
using HackYeah.Application.Enums;
using HackYeah.Application.Queries;
using HackYeah.Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EncounterTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EncounterTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<GetEncounterTypesResult>> GetList()
    {
        var result = await _mediator.Send(new GetEncounterTypes());

        return result;
    }
}

