using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Empresa_API_FINAL.Seguridad
{
    public class AutentificacionBasica : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserRepository _userRepo;
        public AutentificacionBasica(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserRepository userRepo)
           : base(options, logger, encoder, clock)
        {
            _userRepo = userRepo;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Falta el encabezado de Autorización");

            }

            try
            {
                var encabezadoAutorizacion = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credenciales = Encoding.UTF8.GetString(Convert.FromBase64String(encabezadoAutorizacion.Parameter)).Split(':');
                var nombreUsuario = credenciales[0];
                var contraseña = credenciales[1];

                var usuarioValido = await _userRepo.ValidateUserAsync(nombreUsuario, contraseña);

                if (!usuarioValido)
                {
                    return AuthenticateResult.Fail("Nombre de usuario o contraseña son incorrectas");
                }
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, nombreUsuario),
                new Claim(ClaimTypes.Name, nombreUsuario),
            };
                var identidad = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identidad);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch 
            {
                return AuthenticateResult.Fail("Autorizacion invalido");
            }



        }
    }
}
