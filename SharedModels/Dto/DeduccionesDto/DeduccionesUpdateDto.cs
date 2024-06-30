using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.DeduccionesDto
{
    public class DeduccionesUpdateDto
    {
        [Key]
        public int DeduccionId { set; get; }
        [Required]
        public int empleadoId { set; get; }
        [Required]
        [StringLength(50)]
        public string nombreDeEmpleado { set; get; }
        [Required]
        [StringLength(50)]
        public string ApellidoDeEmpleado { set; get; }
        public decimal? PrestamoBancario { set; get; }
        public decimal? PrestamoEmpresario { set; get; }
        public decimal? PensionAlimenticia { set; get; }
        public decimal? DeduccionPorDaños { set; get; }
        public decimal? despreciacionVehiculo { set; get; }
    }
}
