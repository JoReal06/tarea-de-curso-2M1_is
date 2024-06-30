using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Nomina
    {
        public int Id { set; get; }
        public int EmpleadoId { set; get; }
        public string NombreDeEmpleado { set; get; }
        public string apellidoDeEmpleado { set; get; }
        public decimal? inns { set; get; }
        public decimal? ir { set; get; }
        public decimal? SalarioFinal { set; get; }

    }
}
