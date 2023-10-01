using HackYeah.API.Models;
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
    [Route("{id}/Image")]
    public async Task AddImage([FromRoute] Guid id, [FromForm] AddMissingPetInput input)
    {
        var command = new AddMissingPetImageCommand
        {
            MissingPetReportId = id,
            ImageFile = input.ImageFile
        };

        await _mediator.Send(command);
    }

    [HttpGet]
    [Route("Image/{id}")]
    public async Task<IActionResult> GetImage([FromRoute] Guid id)
    {
        var query = new GetMissingPetImageQuery
        {
            Id = id
        };

        var result = await _mediator.Send(query);
        
        return File(result.ImageStream, result.MimeType);
    }

    [HttpPost]
    public async Task<List<GetMissingPetResult>> GetMissingPets(GetMissingPetsQuery input)
    {
        var result = await _mediator.Send(input);

        return result;
    }
    
    [HttpPost]
    [Route("{id}")]
    public async Task<GetMissingPetResult> GetMissingPet([FromRoute] Guid id )
    {
        var result = await _mediator.Send(new GetMissingPetQuery
        {
            MissingPetReportId = id
        });

        return result;
    }
}