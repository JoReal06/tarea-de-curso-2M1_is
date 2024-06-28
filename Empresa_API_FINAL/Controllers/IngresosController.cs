using AutoMapper;
using Empresa_API_FINAL.FIltros;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using Empresa_API_FINAL.FIltros;

namespace Empresa_API_FINAL.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IIngresosRepository _ingresosRepository;
        private readonly ILogger<NominaController> _logger;
        private readonly IMapper _mapper;

        public IngresosController(IEmpleadoRepository empleadoRepository,
            IIngresosRepository ingresosrepo,
            ILogger<NominaController> logger,
            IMapper mapper)
        {
            _ingresosRepository = ingresosrepo;
            _empleadoRepository = empleadoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ActividadRegistradaAsync("AllIngresos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IngresosReadDto>>> GetIngresos()
        {
            try
            {
                _logger.LogInformation("Obteniendo las ingresos");

                var ingresos = await _ingresosRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<NominaReadDto>>(ingresos));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los ingresos: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los ingresos.");
            }
        }

        [HttpGet("{id}")]
        [ActividadRegistradaAsync("AllIngresos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresosReadDto>> GetIngreso(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID del ingreso no válido: {id}");
                return BadRequest("ID del ingreso no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo ingreso con ID: {id}");

                var ingreso = await _ingresosRepository.GetById(id);

                if (ingreso == null)
                {
                    _logger.LogWarning($"No se encontró ningun ingreso con ese ID: {id}");
                    return NotFound("ingreso no encontrado.");
                }

                return Ok(_mapper.Map<NominaReadDto>(ingreso));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener la ingreso.");
            }
        }

        [HttpPost]
        [ActividadRegistradaAsync("AllIngresos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresosReadDto>> PostIngreso(IngresosCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió un ingresos nulo en la solicitud.");
                return BadRequest("el ingreso no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo ingreso para el empleado " +
                    $"de ID: {createDto.EmpleadoId}");

                var empleadoExiste = await _empleadoRepository.ExistsAsync(
                    s => s.EmpleadoId == createDto.EmpleadoId);

                if (!empleadoExiste)
                {
                    _logger.LogWarning($"El empleado con ID '{createDto.EmpleadoId}' no existe.");
                    ModelState.AddModelError("Empleado no existe", "¡El empleado  no existe!");
                    return BadRequest(ModelState);
                }


                var existeIngreso = await _ingresosRepository
                    .GetAsync(a => a.IngresosId == createDto.IngresoId);


                if (existeIngreso != null)
                {
                    _logger.LogWarning($"El ingreso para el empleado con ID '{createDto.EmpleadoId}");
                    ModelState.AddModelError("ingreso ya existente",
                        "¡El ingreso ya existe!");
                    return BadRequest(ModelState);
                }

                // Verificar la validez del modelo
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de ingreso no es válido.");
                    return BadRequest(ModelState);
                }

                var nuevoIngreso = _mapper.Map<Ingresos>(createDto);

                await _ingresosRepository.CreateAsync(nuevoIngreso);

                _logger.LogInformation($"Nuevo ingreso creado con ID: " +
                    $"{nuevoIngreso.Id}");
                return CreatedAtAction(nameof(GetIngreso),
                    new { id = nuevoIngreso.IngresosId }, nuevoIngreso);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo ingreso: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo ingreso.");
            }
        }

        [HttpPut("{id}")]
        [ActividadRegistradaAsync("AllIngresos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutIngresos(int id,
            IngresosUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.IngresoId)
            {
                return BadRequest("Los datos de entrada no son válidos o " +
                    "el ID del ingreso no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando el ingreso con el ID: {id}");

                var existeIngreso = await _ingresosRepository.GetById(id);
                if (existeIngreso == null)
                {
                    _logger.LogInformation($"No se encontró ningun ingreso con ID: {id}");
                    return NotFound("el ingreso no existe.");
                }
                var empleadoExiste = await _empleadoRepository.ExistsAsync(
                    s => s.EmpleadoId == updateDto.EmpleadoId);

                if (!empleadoExiste)
                {
                    _logger.LogWarning($"el ingreso con ID '{updateDto.IngresoId}' no existe.");
                    ModelState.AddModelError("el ingreso no existe", "¡el ingreso no existe!");
                    return BadRequest(ModelState);
                }

                // Actualizar solo las propiedades necesarias del empleado existente
                _mapper.Map(updateDto, existeIngreso);

                await _ingresosRepository.SaveChangesAsync();

                _logger.LogInformation($"ingreso con ID {id} actualizada correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _ingresosRepository.ExistsAsync(a => a.IngresosId == id))
                {
                    _logger.LogWarning($"No se encontró ningun ingreso con ID: {id}");
                    return NotFound("el ingreso no se encontró durante la actualización");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar los ingresos " +
                        $"con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar los ingresos.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar los ingresos: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar los ingresos.");
            }
        }

        [HttpDelete("{id}")]
        [ActividadRegistradaAsync("AllIngresos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando ingreso con ID: {id}");

                var Ingreso = await _ingresosRepository.GetById(id);
                if (Ingreso == null)
                {
                    _logger.LogInformation($"Eliminando ingreso con ID: {id}");
                    return NotFound("Ingreso no encontrado.");
                }

                await _ingresosRepository.DeleteAsync(Ingreso);

                _logger.LogInformation($"Ingreso con el ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el ingreso.");
            }
        }
    }
}
