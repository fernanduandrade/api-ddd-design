using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Mapper;

public class ClientMapper : IClientMapper
{
    public Client MapperDtoToEntity(ClientDTO clientDto)
    {
        return new Client()
        {
            Id = clientDto.Id,
            Name = clientDto.Name,
            LastName = clientDto.LastName,
            Phone = clientDto.Phone,
            Debt = clientDto.Debt,
            Credit = clientDto.Credit
        };
        
    }

    public IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients)
    {
        return clients.Select(client => new ClientDTO()
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Phone = client.Phone,
            Debt = client.Debt,
            Credit = client.Credit
        });
    }

    public ClientDTO MapperEntityToDto(Client client)
    {
        return new ClientDTO()
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Phone = client.Phone,
            Debt = client.Debt,
            Credit = client.Credit
        };
    }
}