using HackYeah.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HackYeah.API.Filters;

public class ApiExceptionsFIlters : IExceptionFilter
{
    private static readonly IDictionary<Type, Action<ExceptionContext>> ExceptionHandlers =
        new Dictionary<Type, Action<ExceptionContext>>()
        {
            { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(BaseException), HandleDefaultException }
        };


    public void OnException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (ExceptionHandlers.TryGetValue(type, out var handler))
        {
            handler.Invoke(context);
        }
        else
        {
            HandleDefaultException(context);
        }
    }

    private static void HandleUnauthorizedAccessException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized - Keep out off the grass, please.",
            Detail = context.Exception.Message,
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status401Unauthorized
        };
        context.ExceptionHandled = true;
    }

    private static void HandleNotFoundException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Not found - There are not the droids you're looking for.",
            Detail = context.Exception.Message,
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status404NotFound
        };
        context.ExceptionHandled = true;
    }

    private static void HandleDefaultException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Something went terribly wrong",
            Detail = context.Exception.Message,
        };


        if (context.Exception is BaseException baseException)
        {
            details.Extensions.Add("innerExceptionCode", (int)baseException.InnerCode);
            details.Extensions.Add("innerExceptionName", baseException.InnerCode.ToString());
        }

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };


        context.ExceptionHandled = true;
    }
}