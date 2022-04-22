namespace RestApiDDD.Domain.Entities;

public class Client : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}