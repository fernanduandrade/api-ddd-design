using RestApiDDD.Application.DTOs;

namespace RestApiDDD.Application.Interfaces;

public interface IProductServiceApplication
{
    void Add(ProductDTO productDTO);
    void Update(ProductDTO productDTO);
    void Remove(ProductDTO productDTO);
    IEnumerable<ProductDTO> GetAll();
    ProductDTO GetById(int id);
}