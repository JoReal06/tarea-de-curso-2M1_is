using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class DeduccionesCreateDto
    {
        [Required]
        public int deduccionId { set; get; }
        [Required]
        public int empeladoId { set; get; }
        [Required]
        public decimal Inns { set; get; }
        [Required]
        public decimal Ir { set; get; }
        public string nombreEmpleado { set;get;}
        public decimal PrestamoBancario { set; get; }
        public decimal PrestamoEmpresario { set; get; }
        public decimal PensionAlimenticia { set; get; }
        public decimal DeduccionPorDaños { set; get; }
    }
}
