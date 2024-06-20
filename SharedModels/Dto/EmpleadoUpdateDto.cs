using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class EmpleadoUpdateDto
    {
        [Required]
        public int empleadoId { set; get; }

        [Required]
        public int nominaId { set; get; }

        [Required]
        public bool estado { set; get; }

    }
}
