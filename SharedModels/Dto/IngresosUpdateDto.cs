using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class IngresosUpdateDto
    {
        [Required]
        public int IngresoId { get; set; }
        [Required]
        public int EmpleadoId { set; get; }
        public decimal SalarioBase { set; get; }
        public decimal? Comisiones { set; get; }
        public int HorasExtra { set; get; }
        public decimal? Bonificaciones { set; get; }
        public decimal? DepreciacionVehiculo { set; get; }
        public decimal? ViaticoCombustible { set; get; }
        public decimal? ViaticoAlimenticio { set; get; }
        public decimal? RiesgoLaboral { set; get; }
        public decimal OtrosIngresos { set; get; }
    }
}
