using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.Repository
{
    public class NominaRepository : Repository<Nomina>, INominaRepository
    {
        private readonly EmpresaContext _context;
        public NominaRepository(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Nomina> UpdateAsync(Nomina entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
