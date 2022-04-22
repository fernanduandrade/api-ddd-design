using RestApiDDD.Application.DTOs;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Interfaces.Mapper;

public interface IClientMapper
{
    Client MapperDtoToEntity(ClientDTO clientDto);
    IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients);
    ClientDTO MapperEntityToDto(Client client);
}