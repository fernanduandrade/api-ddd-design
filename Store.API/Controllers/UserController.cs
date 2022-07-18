using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs;
using Store.Application.Interfaces;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServiceApplication _userService;
    private readonly Microsoft.Extensions.Logging.ILogger _logger;
    public UserController(IUserServiceApplication userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), 200)]
    [ProducesResponseType(typeof(List<UserDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _userService.GetAll();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(UserDTO), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(UserDTO), 201)]
    public async Task<ActionResult> Create(UserDTO user)
    {
        _logger.LogInformation("Início da chamada para criação do usuário");
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Add(user);
        Log.Information("Fim da chamada");
        return Created("", result);
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(UserDTO), 200)]
    public async Task<ActionResult> Update(UserDTO user)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Update(user);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> Delete(UserDTO user)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Remove(user);
        return Ok(result);
    }
}