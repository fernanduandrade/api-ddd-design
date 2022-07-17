using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Entities;

namespace Store.Infra.Data.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly LocalContext _context;

    public ProductRepository(LocalContext context) : base(context)
    {
        _context = context;
    }
}