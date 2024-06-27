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
        public Registro()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();
            txtPrimerNombre.TextChanged += new EventHandler(ValidarNombre);
            txtSegundoNombre.TextChanged += new EventHandler(ValidarNombre);
            txtPrimerApellido.TextChanged += new EventHandler(ValidarNombre);
            txtSegundoApellido.TextChanged += new EventHandler(ValidarNombre);
            txtTelefono.TextChanged += new EventHandler(ValidarTelefono);
            txtNumeroCelular.TextChanged += new EventHandler(ValidarCelular);
            txtNumeroDeCedula.TextChanged += new EventHandler(ValidarCedula);
            txtDireccion.TextChanged += new EventHandler(ValidarDireccion);
            txtNumeroDeInss.TextChanged += new EventHandler(ValidarNumeroInss);
            txtNumeroRuc.TextChanged += new EventHandler(ValidarNumeroRuc);
            txtFechaNacimiento.TextChanged += new EventHandler(ValidarFechaNacimiento);
            txtFechaContratacion.TextChanged += new EventHandler(ValidarFechaContratacion);
            txtFechaCierreContrato.TextChanged += new EventHandler(ValidarFechaCierreContrato);
            btnGuardar.Click += new EventHandler(GuardarRegistro);

        }
        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFcha.Text = DateTime.Now.ToLongDateString();
        }




        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^[a-zA-Z]{1,15}$"))
            {
                errorProvider1.SetError(textBox, "Solo letras, máximo 15 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^\d{8}$"))
            {
                errorProvider1.SetError(textBox, "Debe ser un número de 8 dígitos.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarCelular(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^\d{8}$"))
            {
                errorProvider1.SetError(textBox, "Debe ser un número de celular de 8 dígitos.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarCedula(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^\d{3}-\d{6}-\d{4}[A-Za-z]$"))
            {
                errorProvider1.SetError(textBox, "Formato incorrecto. Ejemplo: 004-080809-1416V");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarDireccion(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 85)
            {
                errorProvider1.SetError(textBox, "Máximo 85 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarNumeroInss(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^\d+$"))
            {
                errorProvider1.SetError(textBox, "Solo números.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarNumeroRuc(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Regex.IsMatch(textBox.Text, @"^\d+$"))
            {
                errorProvider1.SetError(textBox, "Solo números.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidarFechaNacimiento(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (DateTime.TryParse(textBox.Text, out DateTime fecha))
            {
                if (fecha > DateTime.Now.AddYears(-100))
                {
                    errorProvider1.SetError(textBox, "Fecha de nacimiento no puede ser mayor a 100 años.");
                }
                else
                {
                    errorProvider1.SetError(textBox, string.Empty);
                }
            }
            else
            {
                errorProvider1.SetError(textBox, "Formato de fecha incorrecto.");
            }
        }

        private void ValidarFechaContratacion(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (DateTime.TryParse(textBox.Text, out DateTime fecha))
            {
                if (fecha > DateTime.Now.AddYears(-70))
                {
                    errorProvider1.SetError(textBox, "Fecha de contratación no puede ser mayor a 70 años.");
                }
                else
                {
                    errorProvider1.SetError(textBox, string.Empty);
                }
            }
            else
            {
                errorProvider1.SetError(textBox, "Formato de fecha incorrecto.");
            }
        }

        private void ValidarFechaCierreContrato(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (DateTime.TryParse(textBox.Text, out DateTime fecha))
            {
                if (fecha < DateTime.Now)
                {
                    errorProvider1.SetError(textBox, "Fecha de cierre de contrato no puede ser antes de la fecha actual.");
                }
                else
                {
                    errorProvider1.SetError(textBox, string.Empty);
                }
            }
            else
            {
                errorProvider1.SetError(textBox, "Formato de fecha incorrecto.");
            }
        }

        private void GuardarRegistro(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                // Lógica para guardar el registro
                MessageBox.Show("Registro guardado correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, corrige los errores en el formulario.");
            }
        }

        private bool ValidarFormulario()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrEmpty(errorProvider1.GetError(textBox)))
                {
                    return false;
                }
            }
            return true;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
