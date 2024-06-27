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
        public int Id { get; set; }
        public int EmpleadoId { set; get; }

        public decimal SalarioBase { set; get; }

    

        public decimal Comisiones { set; get; }
        public int HorasExtra { set; get; }
        public decimal Bonificaciones {  set; get; }
        public decimal DepreciacionVehiculo { set; get; }

        //viaticos
        public decimal ViaticoCombustible { set; get; }
        public decimal ViaticoAlimenticio { set; get; }
        
        //Extraordinarios
        public decimal RiesgoLaboral { set; get; }

        public decimal OtrosIngresos { set; get; }
        //por si acaso el constructor
        public Ingresos(int id, int empleado, decimal comisiones,
            int horasExtra, decimal bonificaciones, decimal depreciacionVehiculo,
            decimal viaticoCombustible, decimal viaticoAlimenticio, decimal riesgoLaboral, decimal otrosIngresos)
        {
            Id = id;
            EmpleadoId = empleado;
            Comisiones = comisiones;
            HorasExtra = horasExtra;
            Bonificaciones = bonificaciones;
            DepreciacionVehiculo = depreciacionVehiculo;
            ViaticoCombustible = viaticoCombustible;
            ViaticoAlimenticio = viaticoAlimenticio;
            RiesgoLaboral = riesgoLaboral;
            OtrosIngresos = otrosIngresos;
        }

    }
}
