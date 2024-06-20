using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Empleado
    {
        public int Id { get; set; }
        public int numEmpleado { set; get; }
        public string numCedula {set; get;}
        public int numInss  {set; get;}
        public int numRuc {set; get;}
        public string primerNombre{set; get;}
        public string? segundoNombre { set; get; }
        public string primerApellido { set; get; }
        public string segundoApellido { set; get;}
        public DateOnly fechaDeNacimiento { set; get;  }
        public string sexo { set; get; }
        public string estadoCivil { set; get; }
        public string direccion { set; get; }
        public int? telefono { set; get; }
        public int? celular { set; get; }
        public DateOnly fechaDeContratacion { set; get; }
        public DateOnly fechaDeCierreDeContrato { set; get; }
        public decimal salarioOrdinario { set; get; }
        public bool estado { set; get; }
    }
}
