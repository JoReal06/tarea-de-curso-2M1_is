using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace tarea_de_curso_2M1_is
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.Principal_Resize);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnIzquierdo_Click(object sender, EventArgs e)
        {
            if (panelIzquierdo.Width == 250)
            {
                panelIzquierdo.Width = 119;
            }
            else
            {
                panelIzquierdo.Width = 250;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                btnRestaurar.Visible = true;
                btnMaximizar.Visible = false;
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnRestaurar.Visible = false;
                btnMaximizar.Visible = true;
            }
        }

        private void btnPestaña_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormInPanel(object FormRegistro)
        {
            try
            {
                if (this.panelContenedor.Controls.Count > 0)
                    this.panelContenedor.Controls.RemoveAt(0);
                Form fh1 = FormRegistro as Form;
                fh1.TopLevel = false;
                fh1.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh1);
                this.panelContenedor.Tag = fh1;
                fh1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Registro());
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            // Ajustar la visibilidad de los botones de restaurar y maximizar según el estado del formulario
            if (this.WindowState == FormWindowState.Maximized)
            {
                btnRestaurar.Visible = true;
                btnMaximizar.Visible = false;
            }
            else
            {
                btnRestaurar.Visible = false;
                btnMaximizar.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Nominas());
        }
    }
}
