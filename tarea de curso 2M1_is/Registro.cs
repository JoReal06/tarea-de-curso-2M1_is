using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea_de_curso_2M1_is
{
    public partial class Registro : Form
    {
        private Principal _formPrincipal;
        public Registro(Principal formPrincipal)
        {

            InitializeComponent();
            _formPrincipal = formPrincipal;
            btnSiguiente.Enabled = false;

        }
        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFcha.Text = DateTime.Now.ToLongDateString();
        }



        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Validación exitosa. Avanzar al siguiente paso.");

                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor complete correctamente todos los campos.");
            }
            _formPrincipal.AbrirFormInPanel(new Nominas(_formPrincipal));
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener exactamente 8 dígitos.");
                txtTelefono.Focus();
            }
        }

        private void txtNumeroCelular_Leave(object sender, EventArgs e)
        {
            if (txtNumeroCelular.Text.Length != 8)
            {
                MessageBox.Show("El número de celular debe tener exactamente 8 dígitos.");
                txtNumeroCelular.Focus();
            }
        }

        private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNumeroDeCedula_Leave(object sender, EventArgs e)
        {
            string pattern = @"^\d{3}-\d{6}-\d{4}[A-Za-z]$";
            if (!Regex.IsMatch(txtNumeroDeCedula.Text, pattern))
            {
                MessageBox.Show("El formato del número de cédula no es válido. Debe ser 004-080807-1418B.");
                txtNumeroDeCedula.Focus();
            }
        }

        private void txtNumeroDeCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }
        private void txtNumeroRuc_Leave(object sender, EventArgs e)
        {
            if (txtNumeroRuc.Text.Length != 11)
            {
                MessageBox.Show("El número de RUC debe tener exactamente 11 dígitos.");
                txtNumeroRuc.Focus();
            }
        }

        private void txtNumeroRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNumeroDeInss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNumeroDeInss_Leave(object sender, EventArgs e)
        {
            if (txtNumeroRuc.Text.Length != 11)
            {
                MessageBox.Show("El número de RUC debe tener exactamente 11 dígitos.");
                txtNumeroRuc.Focus();
            }
        }
        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            string patternDireccion = @"^[A-Za-z0-9\s]+$";
            if (!Regex.IsMatch(txtDireccion.Text, patternDireccion))
            {
                errorProvider1.SetError(txtDireccion, "La dirección solo puede contener números y letras.");
            }
            else
            {
                errorProvider1.SetError(txtDireccion, "");
            }
        }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (txtTelefono.Text.Length != 8)
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener exactamente 8 dígitos.");
                camposValidos = false;
            }
            else
            {
                errorProvider1.SetError(txtTelefono, "");
            }


            if (txtNumeroCelular.Text.Length != 8)
            {
                errorProvider1.SetError(txtNumeroCelular, "El número de celular debe tener exactamente 8 dígitos.");
                camposValidos = false;
            }
            else
            {
                errorProvider1.SetError(txtNumeroCelular, "");
            }


            if (txtNumeroDeInss.Text.Length != 11)
            {
                errorProvider1.SetError(txtNumeroDeInss, "El número de INSS debe tener exactamente 11 dígitos.");
                camposValidos = false;
            }
            else
            {
                errorProvider1.SetError(txtNumeroDeInss, "");
            }

            string patternCedula = @"^\d{3}-\d{6}-\d{4}[A-Za-z]$";
            if (!Regex.IsMatch(txtNumeroDeCedula.Text, patternCedula))
            {
                errorProvider1.SetError(txtNumeroDeCedula, "El formato del número de cédula no es válido. Debe ser 004-080807-1418B.");
                camposValidos = false;
            }
            else
            {
                errorProvider1.SetError(txtNumeroDeCedula, "");
            }


            if (txtNumeroRuc.Text.Length != 11)
            {
                errorProvider1.SetError(txtNumeroRuc, "El número de RUC debe tener exactamente 11 dígitos.");
                camposValidos = false;
            }
            else
            {
                errorProvider1.SetError(txtNumeroRuc, "");
            }

            if (dateTimePickerFContratacion.Value < new DateTime(1960, 1, 1) || dateTimePickerFContratacion.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de contratación debe estar entre 1960 y la fecha actual.");
                camposValidos = false;
            }

            if (dateTimePickerFCierreContra.Value < dateTimePickerFCierreContra.Value || dateTimePickerFCierreContra.Value > new DateTime(2060, 12, 31))
            {
                MessageBox.Show("La fecha de cierre de contrato debe ser posterior a la fecha de contratación y no mayor al año 2060.");
                camposValidos = false;
            }

            if (comboBoxSolteroCasado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una opción en el estado civil.");
                camposValidos = false;
            }

            string patternDireccion = @"^[A-Za-z0-9\s]+$";
            if (!Regex.IsMatch(txtDireccion.Text, patternDireccion))
            {
                MessageBox.Show("La dirección solo puede contener números y letras.");
                camposValidos = false;
            }

            return camposValidos;
        }

        // limpiar todos los campos de textoo
        private void LimpiarCampos()
        {
            txtTelefono.Clear();
            txtNumeroCelular.Clear();
            txtNumeroDeInss.Clear();
            txtNumeroDeCedula.Clear();
            txtNumeroRuc.Clear();
            comboBoxSolteroCasado.SelectedIndex = -1;
            txtDireccion.Clear();
            // ñimpiar errores del errorProvider
            errorProvider1.Clear();
        }

        // evento del botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Datos guardados correctamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor complete correctamente todos los campos.");
            }
        }

        //------------
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
