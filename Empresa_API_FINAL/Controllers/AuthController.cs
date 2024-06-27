using AutoMapper;
using Empresa_API_FINAL.Repository.IRepository;
using Empresa_API_FINAL.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedModels;
using SharedModels.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Empresa_API_FINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository userRepo,
           IMapper mapper,
           IConfiguration configuration)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrosUsuariosDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuario = _mapper.Map<Usuario>(model);

                await _userRepo.RegisterUserAsync(usuario, model.contraseña);
                return Ok("Usuario registrado exitosamente");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = await _userRepo.GetUserByUserNameAsync(model.nombreUsurio);

            if (usuario == null || !await _userRepo.ValidateUserAsync(model.nombreUsurio, model.Contraseña))
                return Unauthorized("DATOS NO VALIDOS");

            var token = GenerateJwtToken(usuario);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Nombre),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.nombreDeUsuario),
                    // Agregar cualquier otro claim necesario
                }),
                Issuer = jwtSettings.GetValue<string>("Issuer"),
                Audience = jwtSettings.GetValue<string>("Audience"),
                Expires = DateTime.UtcNow.AddHours(1), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
