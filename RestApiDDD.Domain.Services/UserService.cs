using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Domain.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUser(string email, string password)
    {
        return await _userRepository.GetUser(email, password);
    }
}