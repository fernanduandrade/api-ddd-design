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
}