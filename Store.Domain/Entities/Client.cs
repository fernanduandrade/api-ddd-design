namespace Store.Domain.Entities;

public class Client : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public string Phone { get; set; }
    public decimal Debt { get; set; }
    public decimal Credit { get; set; }
}