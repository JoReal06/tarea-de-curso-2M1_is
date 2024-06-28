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
    public partial class CRUDForm : Form
    {

        public CRUDForm()
        {
            InitializeComponent();
        }

        private void cmb_tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tablas.SelectedIndex == 0)
            {
                //tabla de empleados

            }
            else if (cmb_tablas.SelectedIndex == 1)
            {
                //tabla de ingresos
            }
            else if (cmb_tablas.SelectedIndex == 2)
            {
                //tabla de deducciones
            }
            else if (cmb_tablas.SelectedIndex == 3)
            { 
                //tabla de nominas
            }
        }
    }
}
