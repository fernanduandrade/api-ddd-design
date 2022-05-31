using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RestApiDDD.Application.DTOs;

namespace RestApiDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private IConfiguration _config;
        public AuthenticationController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            if (user == null)
            {
                return BadRequest("Request do cliente inválido");
            }
            if (user.UserName == "user" && user.Password == "adm")
            {
                var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var _issuer = _config["Jwt:Issuer"];
                var _audience = _config["Jwt:Audience"];

                var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new { Token = tokenString });

            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
