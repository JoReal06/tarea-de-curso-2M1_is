using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.Repository
{
    public class IngresosRepository : Repository<Ingresos>, IIngresosRepository
    {
        private readonly EmpresaContext _context;
        public IngresosRepository(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ingresos> UpdateAsync(Ingresos entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
