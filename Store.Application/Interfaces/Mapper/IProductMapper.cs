using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Application.Interfaces.Mapper;

public interface IProductMapper
{
    Product MapperDtoToEntity(ProductDTO productDto);
    IEnumerable<ProductDTO> MapperListProductsDTO(IEnumerable<Product> products);
    ProductDTO MapperEntityToDto(Product product);
}