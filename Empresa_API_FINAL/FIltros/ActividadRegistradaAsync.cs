using Microsoft.AspNetCore.Mvc.Filters;
using SharedModels;
using System.Globalization;

namespace Empresa_API_FINAL.FIltros
{
    public class ActividadRegistradaAsync : Attribute, IAsyncActionFilter
    {
        private readonly string _usuario;
        private readonly List<ActividadRegistrada> _actividades;

        public ActividadRegistradaAsync(string usuario)
        {
            _usuario = usuario;
            _actividades = new List<ActividadRegistrada>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           
            var entidad = ObtenerEntidad(context);
            var accion = ObtenerAccion(context);

            var actividad = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = accion,
                endpoint = context.HttpContext.Request.Path,
                entidad = entidad,
                usuario = _usuario
            };

            _actividades.Add(actividad);

            await next();

            var entidad2 = ObtenerEntidad(context);
            var accion2 = ObtenerAccion(context);

            var actividad2 = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = $"{accion2} terminada",
                endpoint = context.HttpContext.Request.Path,
                entidad = entidad2,
                usuario = _usuario
            };


        }

        private string ObtenerAccion(ActionExecutingContext context)
        {
           
            var metodoHttp = context.HttpContext.Request.Method.ToUpper();

            switch (metodoHttp)
            {
                case "GET":
                    return "Consulta";
                case "POST":
                    return "Creación";
                case "PUT":
                    return "Actualización";
                case "DELETE":
                    return "Eliminación";
                default:
                    return "Otra acción";
            }
        }

        private string ObtenerEntidad(ActionExecutingContext context)
        {
            var endpoint = context.ActionDescriptor.DisplayName;

            if (endpoint.Contains("Empleado"))
            {
                return "empleados";
            }
            else if (endpoint.Contains("Ingresos"))
            {
                return "ingresos";
            }
            else if (endpoint.Contains("Deducciones"))
            {
                return "deducciones";
            }
            else if (endpoint.Contains("Nomina"))
            {
                return "nomina";
            }
            else
            {
                return "otra entidad";
            }
        }



    }
}
