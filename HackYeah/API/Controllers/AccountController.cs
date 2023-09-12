using HackYeah.Application.Commands;
using HackYeah.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand model)
        {
            await _mediator.Send(model);

            return Ok();
        }

        [HttpPost]
        [Route("Token/Generate")]
        public async Task<IActionResult> GenerateToken(GetUserTokenQuery model)
        {
            return Ok(await _mediator.Send(model));
        }
    }
}
