﻿using AutoMapper;
using Empresa_API_FINAL.FIltros;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using SharedModels.Dto.DeduccionesDto;

namespace Empresa_API_FINAL.Controllers
{
    [ActividadRegistradaFiltro]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeduccionesController : ControllerBase
    {
        private readonly IDeduccionesRepository _deduccionesRepository;
        private readonly ILogger<DeduccionesController> _logger;
        private readonly IMapper _mapper;

        public DeduccionesController(IDeduccionesRepository deduccionesRepository, ILogger<DeduccionesController> logger,
           IMapper mapper)
        {
            _deduccionesRepository = deduccionesRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<DeduccionesReadDto>>> GetDeducciones()
        {
            try
            {
                _logger.LogInformation("Obteniendo las deducciones");

                var deducciones = await _deduccionesRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<DeduccionesReadDto>>(deducciones));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las deducciones: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener las deducciones.");
            }
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionesReadDto>> GetDeduccion(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID de la deduccion no es válido: {id}");
                return BadRequest("ID de la deduccion no es válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo deduccion con ID: {id}");

                var deduccion = await _deduccionesRepository.GetById(id);

                if (deduccion == null)
                {
                    _logger.LogWarning($"No se encontró ninguna deduccion con este ID: {id}");
                    return NotFound("Deduccion no encontrada.");
                }

                return Ok(_mapper.Map<DeduccionesReadDto>(deduccion));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la deduccion con el ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener las deduccion.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeduccionesReadDto>> PostDeduccion(DeduccionesCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió una deduccion nula en la solicitud.");
                return BadRequest("la deduccion no puede ser nula.");
            }

            try
            {
                _logger.LogInformation($"Creando una nueva deduccion para el empleado {createDto.nombreDeEmpleado}");

                var ExistenciaDeDuduccion = await _deduccionesRepository
                    .GetAsync(s => s.empleadoId == createDto.empleadoId);

                if (ExistenciaDeDuduccion != null)
                {
                    _logger.LogWarning($"La deduccion que se quiere realizar al empleado {createDto.nombreDeEmpleado} ya existe");
                    ModelState.AddModelError("Deduccion ya realizada", "ya existe esta deduccion");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de la deduccion no es válida.");
                    return BadRequest(ModelState);
                }
                var nuevaDeducion = _mapper.Map<Deducciones>(createDto);

                await _deduccionesRepository.CreateAsync(nuevaDeducion);

                _logger.LogInformation($"Nueva deduccion al empleado '{createDto.nombreDeEmpleado}' creado con ID: " +
                    $"{nuevaDeducion.deduccionesId}");
                return CreatedAtAction(nameof(GetDeduccion), new { id = nuevaDeducion.deduccionesId }, nuevaDeducion);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear una nueva deduccion: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo empleado.");
            }
        }

        [HttpPut("{id}")]
       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutDeduccion(int id, DeduccionesUpdateDto updateDto)
        {
            if (updateDto == null )
            {
                return BadRequest("Los datos de entrada no son válidos o " +
                    "el ID de la deduccion no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando deducion del empleado con ID: {updateDto.nombreDeEmpleado}");

                var existenciaDeDeduccion = await _deduccionesRepository.GetById(id);
                if (existenciaDeDeduccion == null)
                {
                    _logger.LogInformation($"No se encontró ninguna deduccion para el empleado: {updateDto.nombreDeEmpleado}");
                    return NotFound("la deduccion no existe.");
                }

                _mapper.Map(updateDto, existenciaDeDeduccion);

                await _deduccionesRepository.SaveChangesAsync();

                _logger.LogInformation($"la deduccion con el  ID {id} se actualizo correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _deduccionesRepository.ExistsAsync(s => s.deduccionesId == id))
                {
                    _logger.LogWarning($"No se encontró ningúna deduccion con el ID: {id}");
                    return NotFound("la deduccion no se encontró durante la actualización");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar la deduccion" +
                        $"con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar el empleado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la deduccion {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar el estudiante.");
            }
        }

        [HttpDelete("{id}")]
  
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDeduccion(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando deduccion con el ID: {id}");

                var deduccion = await _deduccionesRepository.GetById(id);
                if (deduccion == null)
                {
                    _logger.LogInformation($"La deduccion con el : {id} no se encontro");
                    return NotFound("deducion no encontrado.");
                }

                await _deduccionesRepository.DeleteAsync(deduccion);

                _logger.LogInformation($"la deduccion con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la deduccion con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el empleado.");
            }
        }

    }
}
