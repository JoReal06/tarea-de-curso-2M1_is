using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class EmpleadoReadDto
    {
        public int EmpleadoId { get; set; }
        [StringLength(50)]
        public string? primerNombre { set; get; }
        [StringLength(50)]
        public string? segundoApellido { set; get; }

        [Required]
        public bool estado { get; set; }

    }
}
