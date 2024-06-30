using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface IActividadRegistradaRepository:IRepository<ActividadRegistrada>
    {
        Task RegistrarActividadAsync(ActividadRegistrada actividad);
        Task<List<ActividadRegistrada>> ObtenerActividadesAsync();
    }
}
