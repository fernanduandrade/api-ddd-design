namespace RestApiDDD.Application.DTOs;

// nunca igual a entidade original, nunca passando toda entidade do dominio
public class ClientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}