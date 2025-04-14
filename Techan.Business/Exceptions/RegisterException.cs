namespace Techan.Business.Exceptions;

public class RegisterException(string message, int statusCode = 409) : Exception(message), IBaseException
{
    public int StatusCode { get; set; } = statusCode;
}