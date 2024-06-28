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
        public int Id { set; get; }
        public int EmpleadoId { set; get; }
        public string NombreDeEmpleado { set; get; }
        public string apellidoDeEmpleado { set; get; }
        public decimal? inns { set; get; }
        public decimal? ir { set; get; }
        decimal? SalarioFinal { set; get; }


        public async Task<decimal?> CalcularSalarioNetoAsync(decimal? deduccionPorDaños, decimal? pensionAlimenticia, decimal? prestamoEmpresario, decimal? prestamoBancario, decimal? viaticoPorHospedaje, decimal? viaticoAlimenticio, decimal? bonificaciones, decimal? viaticoCobustible, decimal? depreciacionVehiculo, 
            decimal? otrosIngresos,decimal? riesgoLaboral,decimal? viaticoAlimenticioFijo, decimal? comisiones,
            decimal? horasExtras,decimal salarioBase,decimal? IngresoNeto, decimal? HorasExtraNetas, decimal diasTrabajados)
        {
            decimal?[] nullableValues = new decimal?[]
            {
                deduccionPorDaños, pensionAlimenticia, prestamoEmpresario, prestamoBancario,
                viaticoPorHospedaje, viaticoAlimenticio, bonificaciones, viaticoCobustible,
                depreciacionVehiculo, otrosIngresos, riesgoLaboral, viaticoAlimenticioFijo,
                comisiones, horasExtras
            };
            decimal[] values = new decimal[nullableValues.Length];

            Parallel.For(0, nullableValues.Length, i =>
            {
                values[i] = nullableValues[i] ?? 0M;
            });

            deduccionPorDaños = values[0];
            pensionAlimenticia = values[1];
            prestamoEmpresario = values[2];
            prestamoBancario = values[3];
            viaticoPorHospedaje = values[4];
            viaticoAlimenticio = values[5];
            bonificaciones = values[6];
            viaticoCobustible = values[7];
            depreciacionVehiculo = values[8];
            otrosIngresos = values[9];
            riesgoLaboral = values[10];
            viaticoAlimenticioFijo = values[11];
            comisiones = values[12];
            horasExtras = values[13];



            //Ingresos totales
            decimal salarioXHora = (salarioBase / 30) / 8;
            decimal SalarioXDia = salarioBase / 30;
            HorasExtraNetas = (horasExtras * 2) * salarioXHora;
            IngresoNeto = (SalarioXDia * diasTrabajados) + comisiones + viaticoAlimenticioFijo + riesgoLaboral + otrosIngresos + HorasExtraNetas;

            //Deducciones
            inns = (IngresoNeto * 0.07M);
            ir = (IngresoNeto - inns) * 12;
            decimal? irMensual = 0M;

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

           SalarioFinal = 0M;
            return  SalarioFinal = IngresoNeto + depreciacionVehiculo + viaticoCobustible + bonificaciones + viaticoAlimenticio + viaticoPorHospedaje - inns - irMensual - prestamoBancario - prestamoEmpresario - pensionAlimenticia - deduccionPorDaños;
        }



    }
}
