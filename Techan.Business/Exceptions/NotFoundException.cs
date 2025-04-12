namespace Techan.Business.Exceptions;
internal class NotFoundException(string message, int statusCode = 404) : Exception(message), IBaseException
{
    public int StatusCode { get; set; } = statusCode;
}
