using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
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

    public async Task<ResponseDTO> Update(ClientDTO clientDto)
    {
        var client = _clientMapper.MapperDtoToEntity(clientDto);
        await _clientService.Update(client);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Cliente atualizado com sucesso.",
        };
    }

    public async Task<ResponseDTO> Remove(ClientDTO clientDto)
    {
        if (clientDto.Id == 0)
        {
            return new ResponseDTO
            {
                Type = ResponseTypeEnum.Error,
                Message = $"Não foi possível realizar a operação",
                DataResult = false,
            };
        }

        var client = _clientMapper.MapperDtoToEntity(clientDto);
        await _clientService.Remove(client);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"Cliente foi removido!",
            DataResult = true,
        };
    }

    public async Task<ResponseDTO> GetAll()
    {
        var clients = await _clientService.GetAll();
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"Quantidade de registros encontrados: {clients.Count()}",
            DataResult = clients.ToList(),
        };
    }

    public async Task<ResponseDTO> GetById(int id)
    {
        var client = await _clientService.GetById(id);
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Operação concluida com sucesso.",
            DataResult = client!
        };
    }
}