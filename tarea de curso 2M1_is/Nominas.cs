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
        public Nominas(Principal formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            btnIngresar.Enabled = false;
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

        private void ActualizarEstadoBoton()
        {

            btnIngresar.Enabled = TodosCamposLlenosCorrectamente();
        }


        private bool TodosCamposLlenosCorrectamente()
        {
            return !string.IsNullOrWhiteSpace(txtDepreciacionVehiculo.Text) &&
                   !string.IsNullOrWhiteSpace(txtCOmsiones.Text);

        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Datos ingresados correctamente.");

                LimpiarCampos();
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

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
