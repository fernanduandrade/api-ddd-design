using RestApiDDD.Application.DTOs;

namespace RestApiDDD.Application.Interfaces;

public interface IUserServiceApplication
{
    Task<ResponseDTO> Add(UserDTO userDTO);
    Task<ResponseDTO> Update(UserDTO userDto);
    Task<ResponseDTO> Remove(UserDTO userDto);
    Task<ResponseDTO> GetAll();
    Task<ResponseDTO> GetById(int id);
    Task<ResponseDTO> GetUser(string email, string password);
}