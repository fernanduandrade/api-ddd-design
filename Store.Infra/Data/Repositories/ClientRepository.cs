using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Entities;

namespace Store.Infra.Data.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly LocalContext _context;

    public ClientRepository(LocalContext context) : base(context)
    {
        _context = context;
    }
}