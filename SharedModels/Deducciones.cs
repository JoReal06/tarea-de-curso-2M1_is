using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Deducciones
    {
        public int deduccionesId { set; get; }
        public int empleadoId { set; get; }
        public string nombreDeEmpleado { set; get; }
        public string ApellidoDeEmpleado { set; get; }
        public decimal? PrestamoBancario { set; get; }  
        public decimal? PrestamoEmpresario { set; get; }
        public decimal? PensionAlimenticia { set; get; }
        public decimal? DeduccionPorDaños { set; get; }
        public decimal? despreciacionVehiculo { set; get; }

       

    }
}
