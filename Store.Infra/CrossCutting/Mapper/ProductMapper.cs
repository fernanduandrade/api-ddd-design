using Store.Application.DTOs;
using Store.Domain.Entities;
using Store.Infra.CrossCutting.Interfaces;

namespace Store.Infra.CrossCutting.Mapper;

public class ProductMapper : IProductMapper
{
    public Product MapperDtoToEntity(ProductDTO productDto)
    {
        return new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Value = productDto.Value,
        };
    }

    public IEnumerable<ProductDTO> MapperListClientsDTO(IEnumerable<Product> products)
    {
        return products.Select(product => new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Value = product.Value,
        });
    }

    public ProductDTO MapperEntityToDto(Product product)
    {
        return new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Value = product.Value,
        };
    }
}