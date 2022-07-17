using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Infra.CrossCutting.Interfaces;

public interface IProductMapper
{
    Product MapperDtoToEntity(ProductDTO productDto);
    IEnumerable<ProductDTO> MapperListClientsDTO(IEnumerable<Product> products);
    ProductDTO MapperEntityToDto(Product product);
}