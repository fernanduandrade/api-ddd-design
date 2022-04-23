using RestApiDDD.Domain.Enums;

namespace RestApiDDD.Application.DTOs;

public class ResponseDTO
{
    public ResponseTypeEnum Type { get; set; }
    public string Message { get; set; }
    public dynamic DataResult { get; set; }
}

public class ResponseDTO<T>
{
    public ResponseTypeEnum Type { get; set; }
    public string Message { get; set; }
    public T DataResult { get; set; }
}