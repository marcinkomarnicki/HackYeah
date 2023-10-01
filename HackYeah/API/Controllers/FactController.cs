using HackYeah.Application.Commands;
using HackYeah.Application.Queries;
using HackYeah.Application.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FactController : ControllerBase
{
    private readonly IMediator _mediator;

    public FactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<string> GetFact([FromQuery]string animalType)
    {
        var query = new FactQuery()
        {
            AnimalType = animalType
        };

        return await _mediator.Send(query);
    }
}