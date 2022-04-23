using RestApiDDD.Application.DTOs;

namespace RestApiDDD.Application.Interfaces;

public interface IClientServiceApplication
{
    Task<ResponseDTO> Add(ClientDTO clientDTO);
    void Update(ClientDTO clientDto);
    void Remove(ClientDTO clientDto);
    IEnumerable<ClientDTO> GetAll();
    ClientDTO GetById(int id);
}