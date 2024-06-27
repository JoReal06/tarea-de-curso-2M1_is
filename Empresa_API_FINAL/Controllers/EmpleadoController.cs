using AutoMapper;
using Empresa_API_FINAL.FIltros;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using SharedModels.Dto;

namespace Empresa_API_FINAL.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadorepository;
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoRepository empleadoRepository, ILogger<EmpleadoController> logger,
            IMapper mapper)
        {
            _empleadorepository = empleadoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ActividadRegistradaAsync("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmpleadoReadDto>>> GetEmpleados()
        {
            try
            {
                _logger.LogInformation("Obteniendo los empelados");

                var empeleados = await _empleadorepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<EmpleadoReadDto>>(empeleados));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los empleados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los empleados.");
            }
        }

        [HttpGet("{id}")]
        [ActividadRegistradaAsync("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadoReadDto>> GetEmpleado(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID de empleado no válido: {id}");
                return BadRequest("ID de empleado no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo empleado con ID: {id}");

                var empleado = await _empleadorepository.GetById(id);

                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("empleado no encontrado.");
                }

                return Ok(_mapper.Map<EmpleadoReadDto>(empleado));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener el empleado.");
            }
        }

        [HttpPost]
        [ActividadRegistradaAsync("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadoReadDto>> PostEmpleado(EmpleadoCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió un empleado nulo en la solicitud.");
                return BadRequest("El empleado no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo empleado con nombre: {createDto.primerNombre}");

                // Verificar si el estudiante ya existe
                var existeEmpleado = await _empleadorepository
                    .GetAsync(s => s.primerNombre == createDto.primerNombre);

                if (existeEmpleado != null)
                {
                    _logger.LogWarning($"El empleado con nombre '{createDto.primerNombre}' ya existe.");
                    ModelState.AddModelError("NombreExiste", "¡El empleado con ese nombre ya existe!");
                    return BadRequest(ModelState);
                }

                // Verificar la validez del modelo
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de empleado no es válido.");
                    return BadRequest(ModelState);
                }

                // Crear el nuevo estudiante
                var nuevoEmpleado = _mapper.Map<Empleado>(createDto);

                await _empleadorepository.CreateAsync(nuevoEmpleado);

                _logger.LogInformation($"Nuevo empleado '{createDto.primerNombre}' creado con ID: " +
                    $"{nuevoEmpleado.Id}");
                return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo empleado.");
            }
        }

        [HttpPut("{id}")]
        [ActividadRegistradaAsync("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.empleadoId)
            {
                return BadRequest("Los datos de entrada no son válidos o " +
                    "el ID del empleado no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando empleado con ID: {id}");

                var existeEmpleado = await _empleadorepository.GetById(id);
                if (existeEmpleado == null)
                {
                    _logger.LogInformation($"No se encontró ningún empleado con este ID: {id}");
                    return NotFound("El empleado no existe.");
                }

                // actualizar solo las propiedades necesarias del empleado existente
                _mapper.Map(updateDto, existeEmpleado);

                await _empleadorepository.SaveChangesAsync();

                _logger.LogInformation($"Empleado con ID {id} actualizado correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _empleadorepository.ExistsAsync(s => s.Id == id))
                {
                    _logger.LogWarning($"No se encontró ningún empleado con este ID: {id}");
                    return NotFound("El empleado no se encontró durante la actualización");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar el empleado " +
                        $"con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar el empleado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar el empleado.");
            }
        }

        [HttpDelete("{id}")]
        [ActividadRegistradaAsync("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando Empleado con ID: {id}");

                var empleado = await _empleadorepository.GetById(id);
                if (empleado == null)
                {
                    _logger.LogInformation($"Eliminando empleado con ID: {id}");
                    return NotFound("empleado no encontrado.");
                }

                await _empleadorepository.DeleteAsync(empleado);

                _logger.LogInformation($"empleado con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el empleado.");
            }
        }

        [HttpPatch("{id}")]
        [ActividadRegistradaAsync("AllEmpleados")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEmpleado(int id,
            JsonPatchDocument<EmpleadoUpdateDto> patchDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID de empleado no válido.");
            }

            try
            {
                _logger.LogInformation($"Aplicando el parche al empleado con ID: {id}");

                var empleado = await _empleadorepository.GetById(id);
                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("El empleado no se encontró");
                }

                var empleadoDto = _mapper.Map<EmpleadoUpdateDto>(empleado);

                patchDto.ApplyTo(empleadoDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo del empleado después de aplicar el parche" +
                        " no es válido.");
                    return BadRequest(ModelState);
                }

                _mapper.Map(empleadoDto, empleado); // Aplicar cambios al objeto original

                using (var transaction = await _empleadorepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _empleadorepository.SaveChangesAsync();
                        transaction.Commit();
                        _logger.LogInformation($"Parche aplicado correctamente al empleado " +
                            $"con ID: {id}");
                        return NoContent();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!await _empleadorepository.ExistsAsync(s => s.Id == id))
                        {
                            _logger.LogWarning($"No se encontró ningún empleando con ID: {id}");
                            return NotFound();
                        }
                        else
                        {
                            _logger.LogError($"Error de concurrencia al aplicar el parche al empleado " +
                                $"con ID: {id}. Detalles: {ex.Message}");
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error interno del servidor al aplicar el parche al empleado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error al aplicar el parche al empleado con ID {id}: " +
                            $"{ex.Message}");
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error interno del servidor al aplicar el parche al empleado.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche al empleado con ID {id}: " +
                           $"{ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche al empleado.");

            }
        }
    }
}
