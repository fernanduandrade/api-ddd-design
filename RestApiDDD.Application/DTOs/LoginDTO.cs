namespace RestApiDDD.Application.DTOs
{
    public record LoginDTO
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
