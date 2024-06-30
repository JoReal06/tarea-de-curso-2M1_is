﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class ActividadRegistrada
    {
        [Key]
        public int ActividadId { set; get; }
        public DateTime diaDeActividad { get; set; }
        public string Accion { get; set; }
        public string endpoint { get; set; }
        public string entidad { get; set; }
        public string usuario { get; set; }
    }
}
