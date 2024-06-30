﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.EmpleadoDto
{
    public class EmpleadoReadDto
    {
        [Key]
        public int EmpleadoId { get; set; }
        [StringLength(50)]
        public string? primerNombre { set; get; }
        [StringLength(50)]
        public string? segundoNombre { set; get; }
        [StringLength(50)]
        public string? primerApellido { set; get; }
        [StringLength(50)]
        public string? segundoApellido { set; get; }
        public string numCedula { set; get; }
        public long numInss { set; get; }
        public long numRuc { set; get; }
        [Required]
        public string sexo { set; get; }
        public string? estadoCivil { set; get; }
        [StringLength(100)]
        public string? direccion { set; get; }
        public long? telefono { set; get; }
        public long? celular { set; get; }
        [Required]
        public DateOnly fechaDeNacimiento { set; get; }
        public DateOnly fechaDeContratacion { set; get; }
        public DateOnly fechaDeCierreDeContrato { set; get; }
        public bool estado { set; get; }
        public string nombreCompleto => $"{primerNombre} {primerApellido}";
    }
}
