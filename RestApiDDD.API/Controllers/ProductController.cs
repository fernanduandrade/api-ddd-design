using Microsoft.AspNetCore.Mvc;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;

namespace RestApiDDD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductServiceApplication _productService;

    public ProductController(IProductServiceApplication productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), 200)]
    [ProducesResponseType(typeof(List<ProductDTO>), 200)]
    public IActionResult GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = _productService.GetAll();
        if (result.Any()) return NoContent();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(ProductDTO), 200)]
    public IActionResult GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        return Ok(_productService.GetById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(ProductDTO), 201)]
    public ActionResult Create(ProductDTO product)
    {
        if (!ModelState.IsValid) return BadRequest();
        _productService.Add(product);
        return Ok("Cliente cadastrado com sucesso.");
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult Update(ProductDTO product)
    {
        if (product.Id == null) return BadRequest();
        _productService.Update(product);
        return Ok("Cliente atualizado com sucesso.");
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult Delete(ProductDTO product)
    {
        if (product.Id == null) return BadRequest();
        _productService.Remove(product);
        return Ok("Cliente removido com sucesso.");
    }
}