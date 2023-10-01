using HackYeah.API.Models;
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

    [HttpPost]
    public async Task<List<EncounterResult>> GetEncounters(GetEncountersQuery input)
    {
        return await _mediator.Send(input);
    }

    [HttpPost]
    [Route("/history")]
    public async Task<List<string>> GetHistoricalEncounterTypes(GetThreeMostOccuranceHistoricalEncounterTypesQuery input)
    {
        return await _mediator.Send(input);
    }

    [HttpPost]
    [Route("/type-count")]
    public async Task<TypeCounterResult> GetEncounterTypesCount(GetHistoricalEncounterTypesCountQuery input)
    {
        return await _mediator.Send(input);
    }

    [HttpPost("/encounter-type-by-image")]
    public async Task<Guid?> GetEncounterType([FromForm] ReportImageEncounterCommand input)
    {
        var type = await _mediator.Send(input);

        return type;
    }

    [HttpPost]
    [Route("{id}/Image")]
    public async Task AddImage([FromRoute] Guid id, [FromForm] AddEncounterImageInput input)
    {
        var command = new AddEncounterImageCommand
        {
            EncounterId = id,
            ImageFile = input.ImageFile
        };

        await _mediator.Send(command);
    }

    [HttpGet]
    [Route("Image/{id}")]
    public async Task<IActionResult> GetImage([FromRoute] Guid id)
    {
        var query = new GetEncounterImageQuery
        {
            Id = id
        };

        var result = await _mediator.Send(query);

        return File(result.ImageStream, result.MimeType);
    }
}