using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Application.Interfaces.Mapper;

public interface IUserMapper
{
    User MapperDtoToEntity(UserDTO userDto);
    IEnumerable<UserDTO> MapperListUsersDTO(IEnumerable<User> users);
    UserDTO MapperEntityToDto(User user);
}