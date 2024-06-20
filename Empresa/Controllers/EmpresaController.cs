using Microsoft.AspNetCore.Mvc;

namespace Empresa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository
    }
}
