using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Deducciones
    {
        public int Id { set; get; }
        public int empleadoId { set; get; }
        public Empleado empleado { set; get; }

        //seguro
        public decimal Inns { set; get; }

        //En caso de tener convenio con el banco o se llega a un acuerdo para que deduzcan el pago del prestamo mediante tu nomina
        public decimal PrestamoBancario { set; get; }

        //En caso de prestarle a la empresa donde trabaja
        public decimal PrestamoEmpresario { set; get; }

        public decimal PensionAlimenticia { set; get; }

        //En caso de romper algo en la empresa o que haya una perdida se paga
        //luego de impuestos y la empresa lo deduce en el pago de la nomina
        public decimal DeduccionPorDaños { set; get; }

        public Deducciones(int id, decimal inns, decimal prestamoBancario,
            decimal prestamoEmpresario, decimal pensionAlimenticia,
            decimal deduccionPorDaños)
        {
            Id = id;
            Inns = inns;
            PrestamoBancario = prestamoBancario;
            PrestamoEmpresario = prestamoEmpresario;
            PensionAlimenticia = pensionAlimenticia;
            DeduccionPorDaños = deduccionPorDaños;
        }

    }
}
