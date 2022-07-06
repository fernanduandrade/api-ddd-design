using RestApiDDD.Application.DTOs;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Interfaces.Mapper;

public interface IUserMapper
{
    User MapperDtoToEntity(UserDTO userDto);
    IEnumerable<UserDTO> MapperListUsersDTO(IEnumerable<User> users);
    UserDTO MapperEntityToDto(User user);
}