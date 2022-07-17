using Store.Application.DTOs;
using Store.Application.Interfaces.Mapper;
using Store.Domain.Entities;

namespace Store.Application.Mapper;

public class UserMapper : IUserMapper
{
    public User MapperDtoToEntity(UserDTO userDto)
    {
        return new User()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
        };
    }

    public IEnumerable<UserDTO> MapperListUsersDTO(IEnumerable<User> users)
    {
        return users.Select(user => new UserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        });
    }

    public UserDTO MapperEntityToDto(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        };
    }
}