using RestApiDDD.Application.DTOs;

namespace RestApiDDD.Application.Interfaces;

public interface IClientServiceApplication
{
    Task<ResponseDTO> Add(ClientDTO clientDTO);
    Task<ResponseDTO> Update(ClientDTO clientDto);
    Task<ResponseDTO> Remove(ClientDTO clientDto);
    Task<ResponseDTO> GetAll();
    Task<ResponseDTO> GetById(int id);
}