using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.Repository
{
    public class DeduccionesRepository : Repository<Deducciones>, IDeduccionesRepository
    {
        private readonly EmpresaContext _context;
        public DeduccionesRepository(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Deducciones> UpdateAsync(Deducciones entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
