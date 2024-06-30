using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedModels;
using System.Linq.Expressions;

namespace Empresa_API_FINAL.Repository
{
    public class ActividadRegistradaRepository : IActividadRegistradaRepository
    {
        public readonly EmpresaContext _context;

        public ActividadRegistradaRepository(EmpresaContext context)
        {
            _context = context;
        }


        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(ActividadRegistrada entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ActividadRegistrada entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<ActividadRegistrada, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<ActividadRegistrada>> GetAllAsync(Expression<Func<ActividadRegistrada, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadRegistrada> GetAsync(Expression<Func<ActividadRegistrada, bool>>? filter = null, bool tracked = true)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadRegistrada> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActividadRegistrada>> ObtenerActividadesAsync()
        {
            return await _context.actividadRegistradas.ToListAsync();
        }

        public async Task RegistrarActividadAsync(ActividadRegistrada actividad)
        {
            _context.actividadRegistradas.Add(actividad);
            await _context.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
