using RestApiDDD.Application.DTOs;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.CrossCutting.Interfaces;

public interface IClientMapper
{
    Client MapperDtoToEntity(ClientDTO clientDto);
    IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients);
    ClientDTO MapperEntityToDto(Client client);
}