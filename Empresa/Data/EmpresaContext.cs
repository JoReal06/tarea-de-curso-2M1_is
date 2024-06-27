using Microsoft.EntityFrameworkCore;
using SharedModels;


namespace Empresa.Data
{
    public class EmpresaContext: DbContext
    {
        public DbSet<Empleado> empleados { set; get; }
        public DbSet<Ingresos> ingresosDeEmpleados { set; get; }
        public DbSet<Deducciones> deduccionesDeEmpleados { set; get; }
        public DbSet<Nomina> nominas { set; get; }
        public DbSet<Usuario> usuarios { set; get; }

        public EmpresaContext(DbContextOptions<EmpresaContext> options) :
         base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
