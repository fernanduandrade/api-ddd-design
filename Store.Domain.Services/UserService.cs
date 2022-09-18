using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Core.Interfaces.Services;
using Store.Domain.Entities;

namespace Store.Domain.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUser(string email)
    {
        return await _userRepository.GetUser(email);
    }
}