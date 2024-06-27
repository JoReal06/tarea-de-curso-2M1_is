using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class NominaCreateDto
    {
        [Required]
        public int NominaId { get; set; }
        [Required]
        public int EmpleadoId { set; get; }

        public int horasExtras { set; get; }

        public decimal salarioBase { set; get; }
        public decimal? comisiones { set; get; }
        public decimal? bonificaciones { set; get; }
        public decimal? depreciacionVehiculo { set; get; }
        public decimal? viaticoCobustible { set; get; }
        public decimal inns { set; get; }
        public decimal ir { set; get; }
        public decimal? viaticoAlimenticioFijo { set; get; }
        public decimal? viaticoAlimenticio { set; get; }
        public decimal? riesgoLaboral { set; get; }
        public decimal? otrosIngresos { set; get; }
        public decimal? prestamoBancario { set; get; }
        public decimal? prestamoEmpresario { set; get; }
        public decimal? pensionAlimenticia { set; get; }
        public decimal? deduccionPorDaños { set; get; }
        public decimal? viaticoPorHospedaje { set; get; }
    }
}
