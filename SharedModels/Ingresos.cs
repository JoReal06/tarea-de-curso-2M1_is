using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Ingresos
    {

        public int IngresosId { get; set; }
        public int EmpleadoId { set; get; }
        public string? nombreDeEmpleado { set; get; }
        public string? ApellidoDeEmpleado { set; get; }
        public decimal? SalarioBase { set; get; }
        public decimal? Comisiones { set; get; }
        public int? HorasExtra { set; get; }
        public decimal? Bonificaciones {  set; get; }
        public decimal? DepreciacionVehiculo { set; get; }
        public decimal? ViaticoCombustible { set; get; }
        public decimal? ViaticoAlimenticio { set; get; }
        public decimal? ViaticoPorHospedaje { set; get; }
        public decimal? RiesgoLaboral { set; get; }
        public decimal?   OtrosIngresos { set; get; }
       

    }
}
