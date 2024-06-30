using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace Empresa_API_FINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadRegistradaController : ControllerBase
    {
        private readonly IActividadRegistradaRepository _actividadRegistradaRepository;

        public ActividadRegistradaController(IActividadRegistradaRepository actividadRegistradaRepository)
        {
            _actividadRegistradaRepository = actividadRegistradaRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<ActividadRegistrada>>> GetActividades()
        {
            var actividades = await _actividadRegistradaRepository.ObtenerActividadesAsync();
            return Ok(actividades);
        }
    }
}
