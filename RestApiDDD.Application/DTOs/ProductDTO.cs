namespace RestApiDDD.Application.DTOs;

public record ProductDTO
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Value { get; init; }
    public bool IsAvailable { get; init; }
    public int Quantity { get; init; }
}