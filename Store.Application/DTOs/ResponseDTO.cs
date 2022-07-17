using Store.Domain.Enums;

namespace Store.Application.DTOs;

public record ResponseDTO
{
    public ResponseTypeEnum Type { get; init; }
    public string? Message { get; init; }
    public dynamic? DataResult { get; init; }
}

public record ResponseDTO<T>
{
    public ResponseTypeEnum Type { get; init; }
    public string? Message { get; init; }
    public T? DataResult { get; init; }
}