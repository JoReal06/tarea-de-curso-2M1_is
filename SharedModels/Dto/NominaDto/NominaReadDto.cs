﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto.NominaDto
{
    public class NominaReadDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmpleadoId { set; get; }
        [Required]
        [StringLength(50)]
        public string NombreDeEmpleado { set; get; }
        [Required]
        [StringLength(50)]
        public string ApellidoDeEmpleado { set; get; }
        [Required]
        public decimal? inns { set; get; }
        [Required]
        public decimal? ir { set; get; }
        [Required]
        public decimal? SalarioFinal { set; get; }
    }
}
