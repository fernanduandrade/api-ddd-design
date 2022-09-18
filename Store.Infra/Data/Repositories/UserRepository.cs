using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Entities;

namespace Store.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly LocalContext _context;

    public UserRepository(LocalContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(string email)
    {
        try
        {
            return await _context
                .Set<User>()
                .FirstOrDefaultAsync(user => user.Email == email);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}