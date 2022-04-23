using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Enums;

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
    public async Task<ResponseDTO> Add(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        await _productService.Add(product);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Produto adicionado com sucesso.",
        };
    }

    public async Task<ResponseDTO> Update(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        await _productService.Update(product);
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Informações do produto atualizados."
        };
    }

    public async Task<ResponseDTO> Remove(ProductDTO productDto)
    {
        var product = _productMapper.MapperDtoToEntity(productDto);
        await _productService.Remove(product);

        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"O produto {productDto.Name} foi removido.",
        };
    }

    public async Task<ResponseDTO> GetAll()
    {
        var products = await _productService.GetAll();
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = $"Quantidade de produtos encontrados: {products.Count()}",
            DataResult = products,
        };
    }

    public async Task<ResponseDTO> GetById(int id)
    {
        var product = await _productService.GetById(id);
        return new ResponseDTO
        {
            Type = ResponseTypeEnum.Success,
            Message = "Operação concluida com sucesso.",
            DataResult = product!
        };
    }
}