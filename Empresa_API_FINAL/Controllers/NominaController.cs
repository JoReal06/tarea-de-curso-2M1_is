using AutoMapper;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using SharedModels.Dto;

namespace Empresa_API_FINAL.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {

        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly INominaRepository _nominarepositosy;
        private readonly ILogger<NominaController> _logger;
        private readonly IMapper _mapper;

        public NominaController(IEmpleadoRepository empleadorepo,
            INominaRepository nominarepo,
            ILogger<NominaController> logger,
            IMapper mapper)
        {
            _nominarepositosy = nominarepo;
            _empleadoRepository = empleadorepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NominaReadDto>>> GetNominas()
        {
            try
            {
                _logger.LogInformation("Obteniendo las Nominas");

                var Nominas = await _nominarepositosy.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<NominaReadDto>>(Nominas));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las nominas: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener las asistencias.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NominaReadDto>> GetNomina(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID de nomina no válido: {id}");
                return BadRequest("ID de nomina no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo nomina con ID: {id}");

                var nomina = await _nominarepositosy.GetById(id);

                if (nomina == null)
                {
                    _logger.LogWarning($"No se encontró ninguna nomina con ese ID: {id}");
                    return NotFound("Nomina no encontrada.");
                }

                return Ok(_mapper.Map<NominaReadDto>(nomina));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener nomina con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener la nomina.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NominaReadDto>> PostNomina(NominaCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió una Nomina nula en la solicitud.");
                return BadRequest("La asistencia no puede ser nula.");
            }

            try
            {
                _logger.LogInformation($"Creando una nueva nomina para el empleado " +
                    $"de ID: {createDto.EmpleadoId}");

                // Verificar si el estudiante existe
                var empleadoExiste = await _empleadoRepository.ExistsAsync(
                    s => s.Id == createDto.EmpleadoId);

                if (!empleadoExiste)
                {
                    _logger.LogWarning($"El empleado con ID '{createDto.EmpleadoId}' no existe.");
                    ModelState.AddModelError("Empleado no existe", "¡El empleado  no existe!");
                    return BadRequest(ModelState);
                }

                
                var existeNomina = await _nominarepositosy
                    .GetAsync(a => a.Id == createDto.EmpleadoId);


                if (existeNomina != null)
                {
                    _logger.LogWarning($"La nomina para el empleado con ID '{createDto.EmpleadoId}");
                    ModelState.AddModelError("Nomina ya existente",
                        "¡La nomina ya existe!");
                    return BadRequest(ModelState);
                }

                // Verificar la validez del modelo
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de nomina no es válido.");
                    return BadRequest(ModelState);
                }

                // Crear la nueva asistencia
                var NuevaNomina = _mapper.Map<Nomina>(createDto);

                await _nominarepositosy.CreateAsync(NuevaNomina);

                _logger.LogInformation($"Nueva nomina creada con ID: " +
                    $"{NuevaNomina.Id}");
                return CreatedAtAction(nameof(GetNomina),
                    new { id = NuevaNomina.Id }, NuevaNomina);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear una nueva nomina: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear una nueva nomina.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutNomina(int id,
            NominaUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.NominaId)
            {
                return BadRequest("Los datos de entrada no son válidos o " +
                    "el ID de la nomina no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando la nomina con el ID: {id}");

                var existenomina = await _nominarepositosy.GetById(id);
                if (existenomina == null)
                {
                    _logger.LogInformation($"No se encontró ninguna nomina con ID: {id}");
                    return NotFound("La nomina no existe.");
                }

                // Verificar si el estudiante existe
                var empleadoExiste = await _empleadoRepository.ExistsAsync(
                    s => s.Id == updateDto.EmpleadoId);

                if (!empleadoExiste)
                {
                    _logger.LogWarning($"la nomina con ID '{updateDto.NominaId}' no existe.");
                    ModelState.AddModelError("la nomina no existe", "¡la nomina no existe!");
                    return BadRequest(ModelState);
                }

                // Actualizar solo las propiedades necesarias del estudiante existente
                _mapper.Map(updateDto, existenomina);

                await _nominarepositosy.SaveChangesAsync();

                _logger.LogInformation($"Nomina con ID {id} actualizada correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _nominarepositosy.ExistsAsync(a => a.Id == id))
                {
                    _logger.LogWarning($"No se encontró ninguna nomina con ID: {id}");
                    return NotFound("La nomina no se encontró durante la actualización");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar la nomina " +
                        $"con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar la asistencia.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la nomina: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar la nomina.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Deletenomina(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando nomina con ID: {id}");

                var nomina = await _nominarepositosy.GetById(id);
                if (nomina == null)
                {
                    _logger.LogInformation($"Eliminando nomina con ID: {id}");
                    return NotFound("nomina no encontrada.");
                }

                await _nominarepositosy.DeleteAsync(nomina);

                _logger.LogInformation($"nomina con ID {id} eliminada correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la nomina con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar la nomina.");
            }
        }
        
    }
}
