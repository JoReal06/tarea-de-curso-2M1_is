using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.DATA
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Empleado> empleados { set; get; }
        public DbSet<Deducciones> deducciones { set; get; }
        public DbSet<Ingresos> ingresos { set; get; }
        public DbSet<Nomina> nominas { set; get; }
        public DbSet<Usuario> usuarios { set; get; }
        public DbSet<ActividadRegistrada> actividadRegistradas { set; get; }
        public EmpresaContext(DbContextOptions<EmpresaContext> options) :
                base(options)
        {

        }
    }
}
