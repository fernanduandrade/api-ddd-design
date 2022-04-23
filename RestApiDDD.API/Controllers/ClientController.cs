using Microsoft.AspNetCore.Mvc;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Domain.Core.Interfaces.Services;

namespace RestApiDDD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientServiceApplication _clientService;

    public ClientController(IClientServiceApplication clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<string>), 200)]
    [ProducesResponseType(typeof(List<ClientDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.GetAll();
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(ClientDTO), 200)]
    public async Task<ActionResult> GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseDTO), 400)]
    [ProducesResponseType(typeof(ResponseDTO), 201)]
    public async Task<ActionResult> Create(ClientDTO client)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.Add(client);
        return Created("", result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult>  Update(ClientDTO client)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.Update(client);
        return Ok(result);
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> Delete(ClientDTO client)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.Remove(client);
        return Ok(result);
    }
}