using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Enums;

namespace RestApiDDD.Application;

public class UserServiceApplication : IUserServiceApplication
{
    private readonly IUserService _userService;
    private readonly IUserMapper _userMapper;
    public UserServiceApplication(IUserService userService, IUserMapper userMapper)
    {
        _userService = userService;
        _userMapper = userMapper;
    }
    public async Task<ResponseDTO> Add(UserDTO userDTO)
    {
        var user = _userMapper.MapperDtoToEntity(userDTO);
        await _userService.Add(user);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Usuário adicionado com sucesso.",
        };
    }

    public async Task<ResponseDTO> Update(UserDTO userDTO)
    {
        var user = _userMapper.MapperDtoToEntity(userDTO);
        await _userService.Update(user);
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Informações do usuário atualizados."
        };
    }

    public async Task<ResponseDTO> Remove(UserDTO userDTO)
    {
        if (userDTO.Id == 0)
        {
            return new ResponseDTO
            {
                Type = ResponseTypeEnum.Error,
                Message = $"Não foi possível realizar a operação",
                DataResult = false,
            };
        }
        var user = _userMapper.MapperDtoToEntity(userDTO);
        await _userService.Remove(user);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"O usuário {userDTO.Name} foi removido.",
        };
    }

    public async Task<ResponseDTO> GetAll()
    {
        var users = await _userService.GetAll();
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"Usuários encontrados: {users.Count()}",
            DataResult = users,
        };
    }

    public async Task<ResponseDTO> GetById(int id)
    {
        var user = await _userService.GetById(id);
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Operação concluida com sucesso.",
            DataResult = user!
        };
    }
}