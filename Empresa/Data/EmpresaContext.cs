using Microsoft.EntityFrameworkCore;
using SharedModels;


namespace Empresa.Data
{
    public class EmpresaContext: DbContext
    {
        DbSet<Empleado> empleados { set; get; }
        DbSet<Ingresos> ingresos { set; get; }
        DbSet<Deducciones> deducciones { set; get; }
        
        DbSet<Nomina> nominas { set; get; }

        public EmpresaContext(DbContextOptions<EmpresaContext> options) :
         base(options)
        {

        }
    }
}
