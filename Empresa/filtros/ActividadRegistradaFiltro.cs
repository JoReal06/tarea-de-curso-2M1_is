using Microsoft.AspNetCore.Mvc.Filters;
using SharedModels;

namespace Empresa_API.filtros
{
    public class ActividadRegistradaFiltro : Attribute, IAsyncActionFilter
    { 
        private readonly string _entidad;
        private static readonly List<ActividadRegistrada> _actividadesRealizadas;

        public ActividadRegistradaFiltro(string entidad)
        {
            _entidad = entidad;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var registro = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = "Ejecutado",
                 endpoint = $"endpoint realizado: {context.HttpContext.Request.Method} en la ruta: {context.HttpContext.Request.Path}",
                 entidad = _entidad,
                  usuario = context.HttpContext.User.Identity.Name ?? "no se pudo obtener el nombre del usuario que ejecuto el endpoint"
            };
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var registro = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = "Ejecutandose",
                endpoint = $"endpoint realizandose: {context.HttpContext.Request.Method} en la ruta: {context.HttpContext.Request.Path}",
                entidad = _entidad,
                usuario = context.HttpContext.User.Identity.Name ?? "no se pudo obetener el nombre de usuario",
            }; _actividadesRealizadas.Add(registro);

        }

        public List<ActividadRegistrada> GetActivities()
        {
            return _actividadesRealizadas;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var registro = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = "Ejecutandose",
                endpoint = $"endpoints en accion: {context.HttpContext.Request.Method} en la rutas: {context.HttpContext.Request.Path}",
                entidad =  _entidad,
                usuario = context.HttpContext.User.Identity.Name ?? "no se pudo obtener el nombre del usario",
              
            };
            _actividadesRealizadas.Add(registro);

            await next();
            var registro2 = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = "Ejecutada",
                endpoint = $"endpoints en realizados: {context.HttpContext.Request.Method} en la rutas: {context.HttpContext.Request.Path}",
                entidad = _entidad,

            };
        }
    }
}
