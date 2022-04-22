using RestApiDDD.Application.DTOs;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.CrossCutting.Interfaces;

public interface IProductMapper
{
    Product MapperDtoToEntity(ProductDTO productDto);
    IEnumerable<ProductDTO> MapperListClientsDTO(IEnumerable<Product> products);
    ProductDTO MapperEntityToDto(Product product);
}