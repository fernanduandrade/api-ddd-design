using Store.Domain.Entities;

namespace Store.Domain.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(string email);
    }
}
