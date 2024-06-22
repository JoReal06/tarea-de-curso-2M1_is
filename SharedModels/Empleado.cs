using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Empleado
    {
        private int Id { get; set; }
        private int numEmpleado { set; get; }
        private string numCedula {set; get;}
        private int numInss  {set; get;}
        private int numRuc {set; get;}
        public string primerNombre{set; get;}
        private string? segundoNombre { set; get; }
        private string primerApellido { set; get; }
        private string segundoApellido { set; get;}
        private DateOnly fechaDeNacimiento { set; get;  }
        private string sexo { set; get; }
        private string estadoCivil { set; get; }
        private string direccion { set; get; }
        private int? telefono { set; get; }
        private int? celular { set; get; }
        private DateOnly fechaDeContratacion { set; get; }
        private DateOnly fechaDeCierreDeContrato { set; get; }
        private decimal salarioOrdinario { set; get; }
        private bool estado { set; get; }
        private bool riesgoLaboral { set; get; }
        private bool nocturnidad {  set; get; }
    }
}
