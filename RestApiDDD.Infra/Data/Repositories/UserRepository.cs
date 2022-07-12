using Microsoft.EntityFrameworkCore;
using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly LocalContext _context;

    public UserRepository(LocalContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(string email, string password)
    {
        try
        {
            return await _context
                .Set<User>()
                .FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}