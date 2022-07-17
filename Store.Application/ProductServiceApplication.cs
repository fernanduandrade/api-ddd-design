using Store.Application.DTOs;
using Store.Application.Interfaces;
using Store.Application.Interfaces.Mapper;
using Store.Domain.Core.Interfaces.Services;
using Store.Domain.Enums;

namespace Store.Application;

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
        if(productDto.Id == 0)
        {
            return new ResponseDTO
            {
                Type = ResponseTypeEnum.Error,
                Message = $"Não foi possível realizar a operação",
                DataResult = false,
            };
        }
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