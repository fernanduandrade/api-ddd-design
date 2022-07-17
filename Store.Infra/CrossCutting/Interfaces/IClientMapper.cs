using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Infra.CrossCutting.Interfaces;

public interface IClientMapper
{
    Client MapperDtoToEntity(ClientDTO clientDto);
    IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients);
    ClientDTO MapperEntityToDto(Client client);
}