using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Core.Interfaces.Services;
using Store.Domain.Entities;

namespace Store.Domain.Services;

public class ProductService : BaseService<Product>, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) : base(productRepository)
    {
        _productRepository = productRepository;
    }
}