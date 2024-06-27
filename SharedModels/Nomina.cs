using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Nomina
    {
        private int id, idEmpleado, horasExtras;
        private decimal salarioBase, aguinaldo, comisiones, bonificaciones, depreciacionVehiculo, viaticoCobustible, inns,
            viaticoAlimenticioFijo, viaticoAlimenticio, riesgoLaboral, otrosIngresos,
            prestamoBancario, prestamoEmpresario, pensionAlimenticia, deduccionPorDaños, viaticoPorHospedaje;


        public decimal CalcularSalarioNeto(decimal IngresoNeto, decimal HorasExtraNetas)
        {
            //Ingresos totales
            decimal salarioXHora = (salarioBase / 30) / 8;
            HorasExtraNetas = (horasExtras * 2) * salarioXHora;
            IngresoNeto = salarioBase + comisiones + viaticoAlimenticioFijo + riesgoLaboral + otrosIngresos + HorasExtraNetas;

            //Deducciones
            inns = (IngresoNeto * 0.07M);
            decimal ir = (IngresoNeto - inns) * 12;
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

        //hola rene


    }
}
