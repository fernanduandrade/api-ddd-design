using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Domain.Core.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
    Task<User> GetUser(string email, string password);
}