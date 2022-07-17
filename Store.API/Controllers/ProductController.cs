using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs;
using Store.Application.Interfaces;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductServiceApplication _productService;

    public ProductController(IProductServiceApplication productService)
    {
        _productService = productService;
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), 200)]
    [ProducesResponseType(typeof(List<ProductDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = await _productService.GetAll();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(ProductDTO), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _productService.GetById(id);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(ProductDTO), 201)]
    public async Task<ActionResult> Create(ProductDTO product)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _productService.Add(product);
        return Created("", result);
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult> Update(ProductDTO product)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _productService.Update(product);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> Delete(ProductDTO product)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _productService.Remove(product);
        return Ok(result);
    }
}