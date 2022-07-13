namespace RestApiDDD.Application.DTOs;

public record ClientDTO
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? LastName { get; init; }
    public string? Phone { get; init; }
    public decimal Debt { get; init; }
    public decimal Credit { get; init; }
}