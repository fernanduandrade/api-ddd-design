using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Domain.Core.Interfaces.Services;

namespace RestApiDDD.Application;

public class ClientServiceApplication : IClientServiceApplication
{
    private readonly IClientService _clientService;
    private readonly IClientMapper _clientMapper;
    public ClientServiceApplication(IClientService clientService, IClientMapper clientMapper)
    {
        _clientService = clientService;
        _clientMapper = clientMapper;
    }
    public void Add(ClientDTO clientDto)
    {
        var client = _clientMapper.MapperDtoToEntity(clientDto);
        _clientService.Add(client);
    }

    public void Update(ClientDTO clientDto)
    {
        var client = _clientMapper.MapperDtoToEntity(clientDto);
        _clientService.Update(client);
    }

    public void Remove(ClientDTO clientDto)
    {
        var client = _clientMapper.MapperDtoToEntity(clientDto);
        _clientService.Remove(client);
    }

    public IEnumerable<ClientDTO> GetAll()
    {
        var clients = _clientService.GetAll();
        return _clientMapper.MapperListClientsDTO(clients);
    }

    public ClientDTO GetById(int id)
    {
        var client = _clientService.GetById(id);
        return _clientMapper.MapperEntityToDto(client);
    }
}