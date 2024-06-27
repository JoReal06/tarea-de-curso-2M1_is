using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class DeduccionesReadDto
    {
        [Required]
        public int DeduccionId { set; get; }
        [Required]
        public int EmpleadoId { set; get; }
        public decimal Inns { set; get; }
        public decimal Ir { set; get; }
        public decimal? PrestamoBancario { set; get; }
        public decimal? PrestamoEmpresario { set; get; }
        public decimal? PensionAlimenticia { set; get; }
        public decimal? DeduccionPorDaños { set; get; }
    }
}
