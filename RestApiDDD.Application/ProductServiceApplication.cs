using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Services;

namespace RestApiDDD.Application;

public class ProductServiceApplication : IProductServiceApplication
{
    private readonly IProductService _productService;
    private readonly IProductMapper _productMapper;
    public ProductServiceApplication(IProductService productService, IProductMapper productMapper)
    {
        _productService = productService;
        _productMapper = productMapper;
    }
    public void Add(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        _productService.Add(product);
    }

    public void Update(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        _productService.Update(product);
    }

    public void Remove(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        _productService.Remove(product);
    }

    public IEnumerable<ProductDTO> GetAll()
    {
        var products = _productService.GetAll();
        return _productMapper.MapperListClientsDTO(products);
    }

    public ProductDTO GetById(int id)
    {
        var product = _productService.GetById(id);
        return _productMapper.MapperEntityToDto(product);
    }
}