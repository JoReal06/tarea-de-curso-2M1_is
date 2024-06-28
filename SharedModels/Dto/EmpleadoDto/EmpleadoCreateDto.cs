using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.EmpleadoDto
{
    public class EmpleadoCreateDto
    {

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
        [Required]
        public int numInss { set; get; }
        [Required]
        public int numRuc { set; get; }
        [Required]
        public string sexo { set; get; }
        public string? estadoCivil { set; get; }
        [StringLength(100)]
        public string? direccion { set; get; }
        public int? telefono { set; get; }
        public int? celular { set; get; }
        [Required]
        public DateOnly fechaDeNacimiento { set; get; }
        [Required]
        public DateOnly fechaDeContratacion { set; get; }
        [Required]
        public DateOnly fechaDeCierreDeContrato { set; get; }
        [Required]
        public bool estado { set; get; }

    }
}
