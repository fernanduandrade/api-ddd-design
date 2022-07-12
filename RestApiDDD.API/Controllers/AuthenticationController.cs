using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;

namespace RestApiDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserServiceApplication _userService;
        public AuthenticationController(IConfiguration Configuration, IUserServiceApplication userService)
        {
            _userService = userService;
            _config = Configuration;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userService.GetUser(request.Email!, request.Password!);
            if (user == null)
            {
                return BadRequest("Request do cliente inválido");
            }
            if(user != null)
            {
                return Ok(user);
            }
            //if (user.UserName == "user" && user.Password == "adm")
            //{
            //    var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //    var _issuer = _config["Jwt:Issuer"];
            //    var _audience = _config["Jwt:Audience"];

                //    var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

                //    var tokeOptions = new JwtSecurityToken(
                //        issuer: _issuer,
                //        audience: _audience,
                //        claims: new List<Claim>(),
                //        expires: DateTime.Now.AddHours(4),
                //        signingCredentials: signinCredentials);

                //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                //    return Ok(new { Token = tokenString });
                //}
            else
            {
                return Unauthorized();
            }
        }
    }
}
