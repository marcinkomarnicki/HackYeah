using HackYeah.Application.Exceptions;
using HackYeah.Application.Exceptions.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HackYeah.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    [Route("InnerExceptionCodes")]
    public Dictionary<int, string> ShowInnerCOdes()
    {
        return Enum.GetValues(typeof(EInnerExceptionCodes))
            .Cast<EInnerExceptionCodes>()
            .ToDictionary(x => (int)x, x => x.ToString());
    }

    [HttpGet]
    [Route("Unauthorized")]
    public void ShowUnauthorized()
    {
        throw new UnauthorizedAccessException();
    }

    [HttpGet]
    [Route("NotFound")]
    public void ShowNotFound()
    {
        throw new NotFoundException("No nie za bardzo coś jest.");
    }

    [HttpGet]
    [Route("Default")]
    public void ShowDefault()
    {
        throw new BaseException("To jest default z wewnętrznym kodem", EInnerExceptionCodes.Testo);
    }
}