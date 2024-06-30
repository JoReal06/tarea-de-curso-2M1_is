using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class DeduccionesComboboxDto
    {
        public decimal PrestamoBancario { set; get; }
        public decimal PrestamoEmpresario { set; get; }
        public decimal PensionAlimenticia { set; get; }
        public decimal DeduccionPorDaños { set; get; }
    }
}
