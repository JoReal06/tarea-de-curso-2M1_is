using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class IngresosComboxDto
    {
        public decimal SalarioBase { set; get; }
        public decimal Comisiones { set; get; }
        public int HorasExtra { set; get; }
        public decimal Bonificaciones { set; get; }
        public decimal DepreciacionVehiculo { set; get; }
        public decimal ViaticoCombustible { set; get; }
        public decimal ViaticoAlimenticio { set; get; }
        public decimal RiesgoLaboral { set; get; }
        public decimal OtrosIngresos { set; get; }
    }
}
