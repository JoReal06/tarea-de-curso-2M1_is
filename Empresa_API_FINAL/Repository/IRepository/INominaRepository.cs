using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface INominaRepository: IRepository<Nomina>
    {
        Task<Nomina> UpdateAsync(Nomina entity);
    }
}
