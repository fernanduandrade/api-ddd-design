using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Application.Interfaces.Mapper;

public interface IClientMapper
{
    Client MapperDtoToEntity(ClientDTO clientDto);
    IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients);
    ClientDTO MapperEntityToDto(Client client);
}