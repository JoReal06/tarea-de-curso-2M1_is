using SharedModels;
using SharedModels.Dto.DeduccionesDto;
using SharedModels.Dto.EmpleadoDto;
using SharedModels.Dto.IngresosDto;
using SharedModels.Dto.NominaDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea_de_curso_2M1_is
{
    public partial class Nominas : Form
    {
        private Principal _formPrincipal;
        private readonly ApiClient _apiclient;
        public Nominas(Principal formPrincipal, ApiClient apiclient)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            btnAgregar.Enabled = true;
            _apiclient = apiclient;
            CargarEmpleados();
        }

        private async Task<string> Buscar(int id, string FILTRO)
        {
            EmpleadoReadDto em = await _apiclient.empleados.GetByIdAsync(id);

            if (FILTRO == "nombre")
            {
                string? nombreCompleto = em.primerNombre;
                return nombreCompleto;
            }
            else
            {
                string apellido = em.primerApellido;
                return apellido;
            }

        }

        private async void CargarEmpleados()
        {
            try
            {
                cmbEmpleados.DataSource = await _apiclient.empleados.GetAllAsync();
                cmbEmpleados.DisplayMember = "nombreCompleto";
                cmbEmpleados.ValueMember = "EmpleadoId";
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se puedieron cargar los empleados en la caja para seleccionar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FechaHora_Tick(object sender, EventArgs e)
        {

            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFcha.Text = DateTime.Now.ToLongDateString();
        }

        private void ValidarNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool TodosCamposLlenosCorrectamente()
        {
            bool estado = true;

            return estado;
        }


        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {

                    EmpleadoReadDto selectedEmpleado = cmbEmpleados.SelectedItem as EmpleadoReadDto;
                    int id = selectedEmpleado?.EmpleadoId ?? 0;

                    var Ingreso = new IngresosCreateDto
                    {
                        EmpleadoId = id,
                        SalarioBase = decimal.Parse(txtSalarioBase.Text),
                        HorasExtra = int.Parse(txtHorasExtra.Text),
                        Comisiones = decimal.Parse(txtCOmsiones.Text),
                        RiesgoLaboral = decimal.Parse(txtRiesgoLaboral.Text),
                        OtrosIngresos = decimal.Parse(txtOtrosIngresos.Text),
                        ViaticoAlimenticio = decimal.Parse(txtViaticoAlimeticio.Text),
                        ViaticoCombustible = decimal.Parse(txtViaticoCombustible.Text),
                        Bonificaciones = decimal.Parse(txtBonificaciones.Text),
                        DepreciacionVehiculo = decimal.Parse(txtDepreciacionVehiculo.Text),
                        NombreDeEmpleado = await Buscar(id, "nombre"),
                        ApellidoDeEmpleado = await Buscar(id, "apellido"),
                    };
                    var verificar = await _apiclient.ingresos.ExistsAsync(id);
                    if (verificar)
                    {
                        MessageBox.Show("El Empleado el cual usted quiere registrar deducciones eh ingresos, ya  posee sus ingresos y deducciones, caso " +
                            "de querer modificarlas, por favor vaya al apartado de ver tablas ", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var hecho = await _apiclient.ingresos.CreateAsync(Ingreso);


                    var deduccion = new DeduccionesCreateDto
                    {
                        empleadoId = id,
                        PrestamoBancario = decimal.Parse(txtPrestamoBancario.Text),
                        PrestamoEmpresario = decimal.Parse(txtPrestamoEmpresario.Text),
                        PensionAlimenticia = decimal.Parse(txtPensionAlimenticia.Text),
                        DeduccionPorDaños = decimal.Parse(txtDaños.Text),
                        nombreDeEmpleado = await Buscar(id, "nombre"),
                        ApellidoDeEmpleado = await Buscar(id, "apellido"),
                    };
                    var verificar2 = await _apiclient.deducciones.ExistsAsync(id);
                    if (verificar2)
                    {
                        MessageBox.Show("El Empleado el cual usted quiere registrar deducciones eh ingresos, ya  posee sus ingresos y deducciones, caso" +
                            "de querer modificarlas, por favor vaya al apartado de ver tablas ");
                        return;
                    }

                    var hecho2 = await _apiclient.deducciones.CreateAsync(deduccion);

                    decimal? ingresoNeto = CalcularIngreso(decimal.Parse(txtSalarioBase.Text),decimal.Parse(txtCOmsiones.Text),decimal.Parse(txtViaticoAlimeticio.Text),decimal.Parse(txtRiesgoLaboral.Text), decimal.Parse(txtOtrosIngresos.Text),decimal.Parse(txtHorasExtra.Text));

                    var nomina = new NominaCreateDto
                    {
                        EmpleadoId = id,
                        NombreDeEmpleado = await Buscar(id, "nombre"),
                        ApellidoDeEmpleado = await Buscar(id, "apellido"),
                        inns = calcular(ingresoNeto, "inss"),
                        ir = calcular(ingresoNeto, "ir"),
                        SalarioFinal = await CalcularSalarioNetoAsync(decimal.Parse(txtDaños.Text), decimal.Parse(txtPensionAlimenticia.Text), decimal.Parse(txtPrestamoEmpresario.Text),
                        decimal.Parse(txtPrestamoBancario.Text), decimal.Parse(txtViaticoPorHospedaje.Text), decimal.Parse(txtViaticoAlimeticio.Text), decimal.Parse(txtBonificaciones.Text),
                        decimal.Parse(txtViaticoCombustible.Text), decimal.Parse(txtDepreciacionVehiculo.Text), decimal.Parse(txtOtrosIngresos.Text),decimal.Parse(txtRiesgoLaboral.Text),
                        decimal.Parse(txtCOmsiones.Text),
                        decimal.Parse(txtHorasExtra.Text),decimal.Parse(txtSalarioBase.Text))
                    };
                    var hecho3 = await _apiclient.nominas.CreateAsync(nomina);

                    MessageBox.Show("Los datos fueron enviados existosamente", "Avison",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("sucedio un erro al momento de crear los ingresos y deducciones del empleado  de empleado", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Por favor complete correctamente todos los campos.");
            }
        }
        private bool ValidarCampos()
        {

            return TodosCamposLlenosCorrectamente();
        }


        private void LimpiarCampos()
        {
            txtSalarioBase.Clear();
            txtDepreciacionVehiculo.Clear();
            txtCOmsiones.Clear();
            txtBonificaciones.Clear();
            txtHorasExtra.Clear();
            txtOtrosIngresos.Clear();
            txtPensionAlimenticia.Clear();
            txtPrestamoBancario.Clear();
            txtPrestamoEmpresario.Clear();
            txtRiesgoLaboral.Clear();
            txtViaticoAlimeticio.Clear();
            txtViaticoCombustible.Clear();
            cmbEmpleados.SelectedIndex = -1;
            txtDaños.Clear();
            txtHorasExtra.Clear();
            txtOtrosIngresos.Clear();
            txtViaticoPorHospedaje.Clear();
            txtDiasTrabajdos.Clear();

        }
        public decimal? calcular(decimal? ingresosneto, string tipo)
        {
            decimal? inns = (ingresosneto * 0.07M);
            if (tipo == "inss")
            {

                return inns;
            }
            else
            {
                decimal? ir = (ingresosneto - inns) * 12;
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
                return irMensual;
            }
        }
        public decimal? CalcularIngreso(decimal? salarioBase, decimal? comisiones, decimal? viaticoAlimenticio, decimal? riesgoLaboral, decimal? otrosIngresos, decimal? horasExtras)
        {
            decimal? salarioXHora = (salarioBase / 30) / 8;
            decimal? SalarioXDia = salarioBase / 30;
            decimal? HorasExtraNetas = (horasExtras * 2) * salarioXHora;
            decimal? IngresoNeto = (salarioBase * SalarioXDia) + comisiones + viaticoAlimenticio + riesgoLaboral + otrosIngresos + HorasExtraNetas;
            return IngresoNeto;
        }


        public async Task<decimal?> CalcularSalarioNetoAsync(decimal? deduccionPorDaños, decimal? pensionAlimenticia, 
            decimal? prestamoEmpresario, decimal? prestamoBancario,
            decimal? viaticoPorHospedaje, decimal? viaticoAlimenticio, decimal? bonificaciones, decimal? viaticoCobustible,
            decimal? depreciacionVehiculo,
           decimal? otrosIngresos, decimal? riesgoLaboral, decimal? comisiones,
           decimal? horasExtras, decimal? salarioBase)
        {
            deduccionPorDaños ??= 0M;
            pensionAlimenticia ??= 0M;
            prestamoEmpresario ??= 0M;
            prestamoBancario ??= 0M;
            viaticoPorHospedaje ??= 0M;
            viaticoAlimenticio ??= 0M;
            bonificaciones ??= 0M;
            viaticoCobustible ??= 0M;
            depreciacionVehiculo ??= 0M;
            otrosIngresos ??= 0M;
            riesgoLaboral ??= 0M;
            comisiones ??= 0M;
            horasExtras ??= 0M;
            salarioBase ??= 0M;

            decimal? IngresoNeto = CalcularIngreso(salarioBase, comisiones, viaticoAlimenticio, riesgoLaboral, otrosIngresos, horasExtras);

            //Deducciones
            decimal? inns = (IngresoNeto * 0.07M);
            decimal? ir = (IngresoNeto - inns) * 12;
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

            decimal? SalarioFinal = IngresoNeto + depreciacionVehiculo + viaticoCobustible + bonificaciones + viaticoAlimenticio + viaticoPorHospedaje - inns - irMensual - prestamoBancario - prestamoEmpresario - pensionAlimenticia - deduccionPorDaños;
            return SalarioFinal;
        }



    }
}
