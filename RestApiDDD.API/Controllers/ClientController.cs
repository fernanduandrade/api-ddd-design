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
    public IActionResult GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = _clientService.GetAll();
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(ClientDTO), 200)]
    public IActionResult GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        return Ok(_clientService.GetById(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(ClientDTO), 201)]
    public async Task<ActionResult> Create(ClientDTO client)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _clientService.Add(client);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult Update(ClientDTO client)
    {
        if (client.Id == null) return BadRequest();
        _clientService.Update(client);
        return Ok("Cliente atualizado com sucesso.");
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult Delete(ClientDTO client)
    {
        if (client.Id == null) return BadRequest();
        _clientService.Remove(client);
        return Ok("Cliente removido com sucesso.");
    }
}