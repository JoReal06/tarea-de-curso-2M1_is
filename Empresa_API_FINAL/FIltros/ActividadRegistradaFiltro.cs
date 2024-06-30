using AutoMapper;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedModels;
using SharedModels.Dto;
using SharedModels.Dto.DeduccionesDto;
using System.Diagnostics;
using System.Globalization;

namespace Empresa_API_FINAL.FIltros
{
    public class ActividadRegistradaFiltro : TypeFilterAttribute
    {
        public ActividadRegistradaFiltro() : base(typeof(ActividadRegistradaAsyncFilterImpl))
        {
        }

        private class ActividadRegistradaAsyncFilterImpl : IAsyncActionFilter
        {
            private readonly IActividadRegistradaRepository actividadRegistradaRepository;
            private readonly IMapper _mapper;

            public ActividadRegistradaAsyncFilterImpl(IActividadRegistradaRepository actividadRegistradaService, IMapper mapper)
            {
                actividadRegistradaRepository = actividadRegistradaService;
                _mapper = mapper;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // Execute the action
                var resultContext = await next();

                var usuario = ObtenerUsuario(context);
                var accion = ObtenerAccion(context);
                var entidad = ObtenerEntidad(context);
                var endpoint = context.ActionDescriptor.DisplayName;

                var actividadDto = new ActividadRegistradaCreateDto
                {
                    diaDeActividad = DateTime.UtcNow,
                    Accion = accion,
                    endpoint = endpoint,
                    entidad = entidad,
                    usuario = usuario
                };

                var actividad = _mapper.Map<ActividadRegistrada>(actividadDto);
                await actividadRegistradaRepository.RegistrarActividadAsync(actividad);
            }

            private string ObtenerUsuario(ActionExecutingContext context)
            {
                return context.HttpContext.User.Identity?.Name ?? "usuario desconocido";
            }

            private string ObtenerAccion(ActionExecutingContext context)
            {
                var metodoHttp = context.HttpContext.Request.Method.ToUpper();
                return metodoHttp switch
                {
                    "GET" => "Consulta",
                    "POST" => "Creación",
                    "PUT" => "Actualización",
                    "DELETE" => "Eliminación",
                    _ => "Otra acción",
                };
            }

            private string ObtenerEntidad(ActionExecutingContext context)
            {
                var endpoint = context.ActionDescriptor.DisplayName;
                if (endpoint.Contains("Empleado")) return "empleados";
                if (endpoint.Contains("Ingresos")) return "ingresos";
                if (endpoint.Contains("Deducciones")) return "deducciones";
                if (endpoint.Contains("Nomina")) return "nomina";
                return "otra entidad";
            }
        }


    }
}
