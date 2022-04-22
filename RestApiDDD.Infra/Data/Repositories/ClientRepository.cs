using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.Data.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly LocalContext _context;

    public ClientRepository(LocalContext context) : base(context)
    {
        _context = context;
    }
}