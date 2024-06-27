using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface IDeduccionesRepository:IRepository<Deducciones>
    {
        Task<Deducciones> UpdateAsync(Deducciones entity);
    }
}
