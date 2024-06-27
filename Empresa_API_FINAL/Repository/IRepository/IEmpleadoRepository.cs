using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface IEmpleadoRepository:IRepository<Empleado>
    {
        Task<Empleado> UpdateAsync(Empleado entity);
    }
}
