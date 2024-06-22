using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Ingresos
    {
        // esta clase tiene que guardar todo lo vienen siendo lo ingresos de dinero del empleado 
        // al igual que la dedecciones vas a registrar todos los  atributos y datos necesarios que se consideren como ingresos
        // como  el salario base, los viaticos y etc...
        private int Id { get; set; }
        private int empleadoId { set; get; }
        private decimal? viaticoAlimentacion { set; get; }
        private decimal? viaticoCombustible { set; get; }
        private decimal? salarioOrdinario { set; get; }


        



    }
}
