using RestApiDDD.Application.DTOs;

namespace RestApiDDD.Application.Interfaces;

public interface IProductServiceApplication
{
    Task<ResponseDTO> Add(ProductDTO productDTO);
    Task<ResponseDTO> Update(ProductDTO productDTO);
    Task<ResponseDTO> Remove(ProductDTO productDTO);
    Task<ResponseDTO> GetAll();
    Task<ResponseDTO> GetById(int id);
}