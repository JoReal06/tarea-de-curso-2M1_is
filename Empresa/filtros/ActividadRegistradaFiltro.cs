using Microsoft.AspNetCore.Mvc.Filters;
using SharedModels;

namespace Empresa_API.filtros
{
    public class ActividadRegistradaFiltro : Attribute, IActionFilter
    {
        private readonly string _entidadesInvolucradas;
        private static readonly List<ActividadRegistrada> _actividadesRealizadas;

        public ActividadRegistradaFiltro(string entidad)
        {
            _entidadesInvolucradas = entidad;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var registro = new ActividadRegistrada
            {
                diaDeActividad = DateTime.Now,
                Accion = "Ejecutado",
                 endpoint = $"endpoint realizado: {context.HttpContext.Request.Method} en la ruta: {context.HttpContext.Request.Path}",
                 entidadesInvolucradas = _entidadesInvolucradas,
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
                entidadesInvolucradas = _entidadesInvolucradas,
                usuario = context.HttpContext.User.Identity.Name ?? "no se pudo obetener el nombre de usuario",
            }; _actividadesRealizadas.Add(registro);

        }

        public List<ActividadRegistrada> GetActivities()
        {
            return _actividadesRealizadas;
        }
    }
}
