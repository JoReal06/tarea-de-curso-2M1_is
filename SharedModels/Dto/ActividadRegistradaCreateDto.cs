using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class ActividadRegistradaCreateDto
    {

        public DateTime diaDeActividad { get; set; }
        public string Accion { get; set; }
        public string endpoint { get; set; }
        public string entidad { get; set; }
        public string usuario { get; set; }
    }
}
