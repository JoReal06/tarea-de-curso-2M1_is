using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly EmpresaContext _context;
        public EmpleadoRepository(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Empleado> UpdateAsync(Empleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
