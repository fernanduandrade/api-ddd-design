using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.Data.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly LocalContext _context;

    public ProductRepository(LocalContext context) : base(context)
    {
        _context = context;
    }
}