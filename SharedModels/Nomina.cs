using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Nomina
    {
        private int id;
        private int idEmpleado;
        private int horasExtras;

        private decimal salarioBase;
        private decimal comisiones;
        private decimal bonificaciones;
        private decimal depreciacionVehiculo;
        private decimal viaticoCobustible;
        private decimal inns = 0M;
        private decimal ir= 0M;
        private decimal viaticoAlimenticioFijo;
        private decimal viaticoAlimenticio;
        private decimal riesgoLaboral;
        private decimal otrosIngresos;
        private decimal prestamoBancario;
        private decimal prestamoEmpresario;
        private decimal pensionAlimenticia;
        private decimal deduccionPorDaños;
        private decimal viaticoPorHospedaje;

        public decimal CalcularSalarioNeto(decimal IngresoNeto, decimal HorasExtraNetas, decimal diasTrabajados)
        {
            //Ingresos totales
            decimal salarioXHora = (salarioBase / 30) / 8;
            decimal SalarioXDia = salarioBase / 30;
            HorasExtraNetas = (horasExtras * 2) * salarioXHora;
            IngresoNeto = (SalarioXDia * diasTrabajados) + comisiones + viaticoAlimenticioFijo + riesgoLaboral + otrosIngresos + HorasExtraNetas;

            //Deducciones
            inns = (IngresoNeto * 0.07M);
            ir = (IngresoNeto - inns) * 12;
            decimal irMensual = 0M;

            if (ir > 100000.01M && ir <= 200000M)
            {
                irMensual = ((ir - 100000) * 0.15M) / 12;
            }
            else if (ir > 200000.01M && ir <= 350000M)
            {
                irMensual = (((ir - 200000M) * 0.20M) + 15000M) / 12;
            }
            else if (ir > 350000.01M && ir <= 500000M)
            {

                irMensual = (((ir - 350000M) * 0.25M) + 45000M) / 12;
            }
            else if (ir > 500000.01M)
            {
                irMensual = (((ir - 500000M) * 0.30M) + 82500M) / 12;
            }

            decimal SalarioFinal = 0M;
            return SalarioFinal = IngresoNeto + depreciacionVehiculo + viaticoCobustible + bonificaciones + viaticoAlimenticio + viaticoPorHospedaje
                - inns - irMensual - prestamoBancario - prestamoEmpresario - pensionAlimenticia - deduccionPorDaños;
        }

    }
}
