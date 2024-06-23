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
        private int EmpleadoId { set; get; }
        public decimal SalarioBase { set; get; }

        //Aguinaldo depende de la fecha de entrada 
        public decimal Aguinaldo { set; get; }

        public decimal Comisiones { set; get; }
        public int HorasExtra { set; get; }
        public decimal Bonificaciones { set; get; }
        public decimal DepreciacionVehiculo { set; get; }

        //viaticos
        public decimal ViaticoCombustible { set; get; }
        public decimal ViaticoAlimenticio { set; get; }
        public decimal ViaticoPorHospedaje { set; get; }

        //Extraordinarios
        public decimal RiesgoLaboral { set; get; }

        public decimal OtrosIngresos { set; get; }
        //por si acaso el constructor
        public Ingresos(int id, int empleado, decimal aguinaldo, decimal comisiones,
            int horasExtra, decimal bonificaciones, decimal depreciacionVehiculo,
            decimal viaticoCombustible, decimal viaticoAlimenticio, decimal riesgoLaboral, decimal otrosIngresos, decimal viaticoPorHospedaje)
        {
            Id = id;
            EmpleadoId = empleado;
            Aguinaldo = aguinaldo;
            Comisiones = comisiones;
            HorasExtra = horasExtra;
            Bonificaciones = bonificaciones;
            DepreciacionVehiculo = depreciacionVehiculo;
            ViaticoCombustible = viaticoCombustible;
            ViaticoAlimenticio = viaticoAlimenticio;
            RiesgoLaboral = riesgoLaboral;
            OtrosIngresos = otrosIngresos;
            ViaticoPorHospedaje = viaticoPorHospedaje;
        }






    }
}
