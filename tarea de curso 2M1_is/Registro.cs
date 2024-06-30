using SharedModels;
using SharedModels.Dto;
using SharedModels.Dto.EmpleadoDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace tarea_de_curso_2M1_is
{
    public partial class Registro : Form
    {
        private Principal _formPrincipal;
        private readonly ApiClient _apiclient;
        public Registro(Principal formPrincipal, ApiClient apiClient)
        {

            InitializeComponent();
            _formPrincipal = formPrincipal;
            _apiclient = apiClient;

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
                MessageBox.Show("Validación exitosa. Avanzando en la nomina");

                LimpiarCampos();
                _formPrincipal.AbrirFormInPanel(new Nominas(_formPrincipal, _apiclient));
            }
            else
            {
                MessageBox.Show("Por favor complete correctamente todos los campos.");
            }
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

  

        private void txtNumeroCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

       

        private void txtNumeroDeCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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

        private void LimpiarCampos()
        {
            txtTelefono.Clear();
            txtNumeroCelular.Clear();
            txtNumeroDeInss.Clear();
            txtNumeroDeCedula.Clear();
            txtNumeroRuc.Clear();
            comboBoxSolteroCasado.SelectedIndex = -1;
            txtDireccion.Clear();
            errorProvider1.Clear();
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool aux = ValidarCampos();

                if (aux == false)
                {
                    MessageBox.Show("Por favor de revisar lo que esta registrados", "Aviso");
                    return;
                }

                var Empleado = new EmpleadoCreateDto
                {
                    primerNombre = txtPrimerNombre.Text,
                    segundoNombre = txtSegundoNombre.Text,
                    primerApellido = txtPrimerApellido.Text,
                    segundoApellido = txtSegundoApellido.Text,
                    numCedula = txtNumeroDeCedula.Text,
                    numInss = long.Parse(txtNumeroDeInss.Text),
                    numRuc = long.Parse(txtNumeroRuc.Text),
                    sexo = (rbtnMasculno.Checked) ? "Masculino" : (rbtnFemenino.Checked) ? "Femenino" : "no se seleciono genero",
                    estadoCivil = comboBoxSolteroCasado.SelectedIndex == 0 ? "solero" : (comboBoxSolteroCasado.SelectedIndex == 1) ? "casado" : (comboBoxSolteroCasado.SelectedIndex == 2) ? "Viudo" : (comboBoxSolteroCasado.SelectedIndex == 3) ? "Es complicado" : "No se selecciono nada",
                    direccion = txtDireccion.Text,
                    telefono = int.Parse(txtTelefono.Text),
                    celular = int.Parse(txtNumeroCelular.Text),
                    fechaDeNacimiento = DateOnly.FromDateTime(dateTimePickerFnacimiento.Value),
                    fechaDeCierreDeContrato = DateOnly.FromDateTime(dateTimePickerFCierreContra.Value),
                    fechaDeContratacion = DateOnly.FromDateTime(dateTimePickerFContratacion.Value),
                    estado = (rdbtSi.Checked) ? true : false,
                };
                var hecho = await _apiclient.empleados.CreateAsync(Empleado);

                MessageBox.Show("Empleado Creado existosamente","Confirnacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al momento de subir un nuevo empleado ","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }


    }  
  
}
