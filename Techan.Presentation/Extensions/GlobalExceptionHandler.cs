using Techan.Business.Dtos;
using Techan.Core.Abstractions;

namespace Techan.Presentation.Extensions;

public class GlobalExceptionHandler
{

    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }


    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        int statusCode = 500;
        string message = "Internal Server Error!";

        if (e is IBaseException baseException)
        {
            statusCode = baseException.StatusCode;
            message = e.Message;
        }

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(new ResultDto(message, false, statusCode));

    }
}
