namespace RestApiDDD.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public bool IsAvailable { get; set; }
}