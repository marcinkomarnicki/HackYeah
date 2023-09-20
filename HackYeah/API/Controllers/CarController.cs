using HackYeah.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, AddRenaultCommand car)
        {
            car.Id = id;

            await _mediator.Send(car);

            return Ok();
        }
    }
}
