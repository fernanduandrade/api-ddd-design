using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Enums;

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
    public async Task<ResponseDTO> Add(ClientDTO clientDto)
    {
        if (string.IsNullOrEmpty(clientDto.Name))
        {
            return new ResponseDTO
            {
                Type = ResponseTypeEnum.Error,
                Message = "Error ao cadastrar o cliente, nome do cliente não enviado.",
            };
        }
        var client = _clientMapper.MapperDtoToEntity(clientDto);
        await _clientService.Add(client);
        
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Cliente cadastrado com sucesso.",
        };
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