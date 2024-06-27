using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface IIngresosRepository:IRepository<Ingresos>
    {
        Task<Ingresos> UpdateAsync(Ingresos entity);
    }
}
