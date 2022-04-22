using RestApiDDD.Application.DTOs;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Interfaces.Mapper;

public interface IProductMapper
{
    Product MapperDtoToEntity(ProductDTO productDto);
    IEnumerable<ProductDTO> MapperListClientsDTO(IEnumerable<Product> products);
    ProductDTO MapperEntityToDto(Product product);
}