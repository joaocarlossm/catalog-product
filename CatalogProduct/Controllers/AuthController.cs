using CatalogProduct.Commands;
using CatalogProduct.Handlers;
using CatalogProduct.Models;
using CatalogProduct.Queries;
using CatalogProduct.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace CatalogProduct.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUserCommandHandler _registerHandler;
        private readonly GetUserByUsernameQueryHandler _getUserHandler;
        private readonly JwtSettings _jwtSettings;

        public AuthController(
            RegisterUserCommandHandler registerHandler,
            GetUserByUsernameQueryHandler getUserHandler,
            Microsoft.Extensions.Options.IOptions<JwtSettings> jwtSettings)
        {
            _registerHandler = registerHandler;
            _getUserHandler = getUserHandler;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var command = new RegisterUserCommand(user.Username, user.Password);
            await _registerHandler.Handle(command);
            return Ok("Usuário registrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var query = new GetUserByUsernameQuery(user.Username);
            var foundUser = await _getUserHandler.Handle(query);

           if (foundUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password))
           {
                return Unauthorized("Usuário ou senha incorretos.");
           }

            // Gerar token JWT usando o método atualizado
            var token = GenerateJwtToken(foundUser);
            return Ok(new { Token = token });
        }

        // Método para gerar o token JWT com a chave secreta injetada
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}