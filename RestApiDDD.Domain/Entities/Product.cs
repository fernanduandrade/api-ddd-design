namespace RestApiDDD.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedOn { get; set; }
    public int Quantity { get; set; }
}