using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.NominaDto
{
    public class NominaUpdateDto
    {
        [Required]
        public int NominaId { get; set; }
        [Required]
        public int EmpleadoId { set; get; }
        public string NombreDeEmpleado { set; get; }
        public string ApellidoDeEmpleado { set; get; }      
        public decimal? inns { set; get; }    
        public decimal? ir { set; get; } 
        public decimal? SalarioFinal { set; get; }

    }
}
