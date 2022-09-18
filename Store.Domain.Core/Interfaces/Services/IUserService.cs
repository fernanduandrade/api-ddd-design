using Store.Domain.Entities;

namespace Store.Domain.Core.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
    Task<User> GetUser(string email);
}