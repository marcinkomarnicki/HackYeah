using HackYeah.Application.Exceptions.Enums;

namespace HackYeah.Application.Exceptions;

public class BaseException : Exception
{
    public EInnerExceptionCodes InnerCode { get; init; }

    public BaseException(string message, EInnerExceptionCodes innerCode = 0) : base(message)
    {
        InnerCode = innerCode;
    }
}