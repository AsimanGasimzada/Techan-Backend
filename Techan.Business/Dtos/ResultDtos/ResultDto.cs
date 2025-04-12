using Techan.Core.Abstractions;

namespace Techan.Business.Dtos;

public class ResultDto : IDto
{
    public string Message { get; set; } = "Successfully";
    public bool IsSuccess { get; set; } = true;
    public int StatusCode { get; set; } = 200;

    public ResultDto() { }

    public ResultDto(string message)
    {
        Message = message;
    }

    public ResultDto(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public ResultDto(string message, bool isSuccess)
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public ResultDto(string message, bool isSuccess, int statusCode)
    {
        Message = message;
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }
}

public class ResultDto<T> : ResultDto
{
    public T Data { get; set; }

    public ResultDto(T data)
    {
        Data = data;
    }

    public ResultDto(string message, T data) : base(message)
    {
        Data = data;
    }

    public ResultDto(string message, bool isSuccess, T data) : base(message, isSuccess)
    {
        Data = data;
    }

    public ResultDto(string message, bool isSuccess, int statusCode, T data) : base(message, isSuccess, statusCode)
    {
        Data = data;
    }

    public ResultDto(string message, int statusCode, T data) : base(message, statusCode)
    {
        Data = data;
    }
}
