using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class EmpleadoCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? primerNombre { get; set; }
        [Required]
        [StringLength(50)]
        public string? segundoNombre { get; set; }
        [Required]
        [StringLength(50)]
        public string? primerApellido { get; set; }
        [Required]
        [StringLength(50)]
        public string? segundoApellido { get; set; }
        [Required] 
        public bool estado { get; set; }


    }
}
