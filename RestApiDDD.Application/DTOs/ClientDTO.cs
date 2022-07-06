namespace RestApiDDD.Application.DTOs;

public record ClientDTO
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
}