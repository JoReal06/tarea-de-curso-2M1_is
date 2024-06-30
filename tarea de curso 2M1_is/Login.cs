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
    public partial class Login : Form
    {
        private readonly ApiClient apiClient;

        public Login()
        {
            InitializeComponent();
            lb_aviso.Visible = false;
            apiClient = new ApiClient();
            picture_load.Visible = false;
        }

        private void txt_nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_contraseña.Focus();
        }

        private void txt_contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_incio_Click(sender, e);

        }


        private async Task LoginAsync()
        {
            string username = txt_nombre.Text;
            string password = txt_contraseña.Text;

            var token = await apiClient.LoginUsers.AuthenticateUserAsync(username, password);
            
            if (!string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Inicio de sesion correcto","Inicio de sesion correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);

                apiClient.SetAuthToken(token);

                Hide();
                var mainForm = new Principal(apiClient);
                mainForm.Show();
            }
            else
            {
                lb_aviso.Visible = true;
            }
        }

        private async void btn_incio_Click(object sender, EventArgs e)
        {
            picture_load.Visible = true;
            await LoginAsync();
            picture_load.Visible = false;
        }
    }
}
