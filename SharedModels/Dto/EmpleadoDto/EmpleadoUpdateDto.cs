using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.EmpleadoDto
{
    public class EmpleadoUpdateDto
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required]
        [StringLength(50)]
        public string? primerNombre { set; get; }

        [StringLength(50)]
        public string? segundoNombre { set; get; }

        [StringLength(50)]
        public string? primerApellido { set; get; }

        [StringLength(50)]
        public string? segundoApellido { set; get; }
        [Required]
        public int numCedula { set; get; }
        public int numInss { set; get; }
        public int numRuc { set; get; }
        [Required]
        public string sexo { set; get; }
        public string? estadoCivil { set; get; }
        public string? direccion { set; get; }
        public int? telefono { set; get; }
        public int? celular { set; get; }
        [Required]
        public DateOnly fechaDeNacimiento { set; get; }
        public DateOnly fechaDeContratacion { set; get; }
        public DateOnly fechaDeCierreDeContrato { set; get; }
        public bool estado { set; get; }

    }
}
