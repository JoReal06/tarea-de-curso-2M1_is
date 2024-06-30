using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string? primerNombre{set; get;}
        public string? segundoNombre { set; get; }
        public string? primerApellido { set; get; }
        public string? segundoApellido { set; get;}
        public string numCedula {set; get;}
        public long numInss  {set; get;}
        public long numRuc {set; get;}
        public string sexo { set; get; }
        public string? estadoCivil { set; get; }
        public string? direccion { set; get; }
        public long? telefono { set; get; }
        public long? celular { set; get; }
        public DateOnly fechaDeNacimiento { set; get;  }
        public DateOnly fechaDeContratacion { set; get; }
        public DateOnly fechaDeCierreDeContrato { set; get; }
        public bool estado { set; get; }
        
        
    }
}
