namespace Techan.Business.Exceptions;
public class LoginException(string message, int statusCode = 406) : Exception(message), IBaseException
{
    public int StatusCode { get; set; } = statusCode;
}
