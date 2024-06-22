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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int ancho = int.Parse(textBox1.Text);
            int largo = int.Parse(textBox2.Text);

            panel1.Width = ancho;
            panel1.Height = largo;


        }
    }
}
