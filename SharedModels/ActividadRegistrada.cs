using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class ActividadRegistrada
    {
        public DateTime diaDeActividad { set; get; }
        public string Accion { set; get; }
        public string endpoint { set; get; }
        public string entidadesInvolucradas { set; get; }
        public string usuario { get; set; }
    }
}
