using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Mapper;

public class ProductMapper : IProductMapper
{
    public Product MapperDtoToEntity(ProductDTO productDto)
    {
        return new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name!,
            Value = productDto.Value,
            Quantity = productDto.Quantity
        };
    }

    public IEnumerable<ProductDTO> MapperListProductsDTO(IEnumerable<Product> products)
    {
        return products.Select(product => new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Value = product.Value,
            Quantity = product.Quantity
        });
    }

    public ProductDTO MapperEntityToDto(Product product)
    {
        return new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Value = product.Value,
            Quantity = product.Quantity
        };
    }
}