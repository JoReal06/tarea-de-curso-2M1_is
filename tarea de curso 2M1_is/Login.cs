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
        public Login()
        {
            InitializeComponent();
            lb_aviso.Visible = false;
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

        private void btn_incio_Click(object sender, EventArgs e)
        {
            // hacer condcion de verificacion de usuario y de contraseña
            
            // si da error meter como resultado a ejecutar
            // lb_aviso.visible = true;
            Principal principal = new Principal();

        }
    }
}
