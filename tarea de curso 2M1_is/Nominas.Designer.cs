namespace tarea_de_curso_2M1_is
{
    partial class Nominas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            txtDepreciacionVehiculo = new TextBox();
            txtCOmsiones = new TextBox();
            txtOtrosIngresos = new TextBox();
            txtPrestamoBancario = new TextBox();
            txtPrestamoEmpresario = new TextBox();
            txtRiesgoLaboral = new TextBox();
            txtHorasExtra = new TextBox();
            txtViaticoCombustible = new TextBox();
            txtBonificaciones = new TextBox();
            txtViaticoAlimeticio = new TextBox();
            panel1 = new Panel();
            txtSalarioBase = new TextBox();
            label18 = new Label();
            lblFcha = new Label();
            lblHora = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            btnIngresar = new Button();
            label13 = new Label();
            textBox1 = new TextBox();
            txtPensionAlimenticia = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            LblComisiones = new Label();
            label1 = new Label();
            cbxId = new ComboBox();
            label2 = new Label();
            FechaHora = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.bordeopcion;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1000, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtDepreciacionVehiculo
            // 
            txtDepreciacionVehiculo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDepreciacionVehiculo.BackColor = Color.Silver;
            txtDepreciacionVehiculo.Font = new Font("Century Gothic", 10.2F);
            txtDepreciacionVehiculo.Location = new Point(233, 203);
            txtDepreciacionVehiculo.Name = "txtDepreciacionVehiculo";
            txtDepreciacionVehiculo.Size = new Size(135, 28);
            txtDepreciacionVehiculo.TabIndex = 1;
            txtDepreciacionVehiculo.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtCOmsiones
            // 
            txtCOmsiones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCOmsiones.BackColor = Color.Silver;
            txtCOmsiones.Font = new Font("Century Gothic", 10.2F);
            txtCOmsiones.Location = new Point(139, 118);
            txtCOmsiones.Name = "txtCOmsiones";
            txtCOmsiones.Size = new Size(135, 28);
            txtCOmsiones.TabIndex = 2;
            txtCOmsiones.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtOtrosIngresos
            // 
            txtOtrosIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtOtrosIngresos.BackColor = Color.Silver;
            txtOtrosIngresos.Font = new Font("Century Gothic", 10.2F);
            txtOtrosIngresos.Location = new Point(819, 114);
            txtOtrosIngresos.Name = "txtOtrosIngresos";
            txtOtrosIngresos.Size = new Size(135, 28);
            txtOtrosIngresos.TabIndex = 3;
            txtOtrosIngresos.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtPrestamoBancario
            // 
            txtPrestamoBancario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrestamoBancario.BackColor = Color.Silver;
            txtPrestamoBancario.Font = new Font("Century Gothic", 10.2F);
            txtPrestamoBancario.Location = new Point(187, 307);
            txtPrestamoBancario.Name = "txtPrestamoBancario";
            txtPrestamoBancario.Size = new Size(135, 28);
            txtPrestamoBancario.TabIndex = 4;
            txtPrestamoBancario.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtPrestamoEmpresario
            // 
            txtPrestamoEmpresario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrestamoEmpresario.BackColor = Color.Silver;
            txtPrestamoEmpresario.Font = new Font("Century Gothic", 10.2F);
            txtPrestamoEmpresario.Location = new Point(500, 307);
            txtPrestamoEmpresario.Name = "txtPrestamoEmpresario";
            txtPrestamoEmpresario.Size = new Size(135, 28);
            txtPrestamoEmpresario.TabIndex = 6;
            txtPrestamoEmpresario.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtRiesgoLaboral
            // 
            txtRiesgoLaboral.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRiesgoLaboral.BackColor = Color.Silver;
            txtRiesgoLaboral.Font = new Font("Century Gothic", 10.2F);
            txtRiesgoLaboral.Location = new Point(500, 114);
            txtRiesgoLaboral.Name = "txtRiesgoLaboral";
            txtRiesgoLaboral.Size = new Size(156, 28);
            txtRiesgoLaboral.TabIndex = 7;
            txtRiesgoLaboral.TextChanged += textBox7_TextChanged;
            txtRiesgoLaboral.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtHorasExtra
            // 
            txtHorasExtra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHorasExtra.BackColor = Color.Silver;
            txtHorasExtra.Font = new Font("Century Gothic", 10.2F);
            txtHorasExtra.Location = new Point(818, 60);
            txtHorasExtra.Name = "txtHorasExtra";
            txtHorasExtra.Size = new Size(135, 28);
            txtHorasExtra.TabIndex = 8;
            txtHorasExtra.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtViaticoCombustible
            // 
            txtViaticoCombustible.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtViaticoCombustible.BackColor = Color.Silver;
            txtViaticoCombustible.Font = new Font("Century Gothic", 10.2F);
            txtViaticoCombustible.Location = new Point(551, 165);
            txtViaticoCombustible.Name = "txtViaticoCombustible";
            txtViaticoCombustible.Size = new Size(135, 28);
            txtViaticoCombustible.TabIndex = 9;
            txtViaticoCombustible.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtBonificaciones
            // 
            txtBonificaciones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBonificaciones.BackColor = Color.Silver;
            txtBonificaciones.Font = new Font("Century Gothic", 10.2F);
            txtBonificaciones.Location = new Point(819, 165);
            txtBonificaciones.Name = "txtBonificaciones";
            txtBonificaciones.Size = new Size(135, 28);
            txtBonificaciones.TabIndex = 10;
            txtBonificaciones.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtViaticoAlimeticio
            // 
            txtViaticoAlimeticio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtViaticoAlimeticio.BackColor = Color.Silver;
            txtViaticoAlimeticio.Font = new Font("Century Gothic", 10.2F);
            txtViaticoAlimeticio.Location = new Point(190, 165);
            txtViaticoAlimeticio.Name = "txtViaticoAlimeticio";
            txtViaticoAlimeticio.Size = new Size(178, 28);
            txtViaticoAlimeticio.TabIndex = 11;
            txtViaticoAlimeticio.KeyPress += ValidarNumerico_KeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(txtSalarioBase);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(lblFcha);
            panel1.Controls.Add(lblHora);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(txtPensionAlimenticia);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(LblComisiones);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbxId);
            panel1.Controls.Add(txtPrestamoEmpresario);
            panel1.Controls.Add(txtRiesgoLaboral);
            panel1.Controls.Add(txtOtrosIngresos);
            panel1.Controls.Add(txtViaticoAlimeticio);
            panel1.Controls.Add(txtDepreciacionVehiculo);
            panel1.Controls.Add(txtBonificaciones);
            panel1.Controls.Add(txtPrestamoBancario);
            panel1.Controls.Add(txtViaticoCombustible);
            panel1.Controls.Add(txtCOmsiones);
            panel1.Controls.Add(txtHorasExtra);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 523);
            panel1.TabIndex = 12;
            // 
            // txtSalarioBase
            // 
            txtSalarioBase.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSalarioBase.BackColor = Color.Silver;
            txtSalarioBase.Font = new Font("Century Gothic", 10.2F);
            txtSalarioBase.Location = new Point(500, 64);
            txtSalarioBase.Name = "txtSalarioBase";
            txtSalarioBase.Size = new Size(156, 28);
            txtSalarioBase.TabIndex = 37;
            txtSalarioBase.KeyPress += ValidarNumerico_KeyPress;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(383, 63);
            label18.Name = "label18";
            label18.Size = new Size(100, 20);
            label18.TabIndex = 36;
            label18.Text = "Salario Base:";
            // 
            // lblFcha
            // 
            lblFcha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFcha.AutoSize = true;
            lblFcha.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFcha.ForeColor = Color.Gray;
            lblFcha.Location = new Point(679, 463);
            lblFcha.Name = "lblFcha";
            lblFcha.Size = new Size(62, 18);
            lblFcha.TabIndex = 35;
            lblFcha.Text = "label15";
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.Teal;
            lblHora.Location = new Point(732, 436);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(81, 23);
            lblHora.TabIndex = 34;
            lblHora.Text = "label15";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(175, 258);
            label17.Name = "label17";
            label17.Size = new Size(795, 20);
            label17.TabIndex = 32;
            label17.Text = "-----------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(139, 23);
            label16.Name = "label16";
            label16.Size = new Size(831, 20);
            label16.TabIndex = 31;
            label16.Text = "-----------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.LightSteelBlue;
            label15.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(45, 258);
            label15.Name = "label15";
            label15.Size = new Size(124, 22);
            label15.TabIndex = 30;
            label15.Text = "Deducciones";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.LightSteelBlue;
            label14.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(45, 21);
            label14.Name = "label14";
            label14.Size = new Size(88, 22);
            label14.TabIndex = 29;
            label14.Text = "Ingresos";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.SlateGray;
            btnIngresar.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = SystemColors.InactiveBorder;
            btnIngresar.Location = new Point(416, 408);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(151, 51);
            btnIngresar.TabIndex = 28;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(46, 356);
            label13.Name = "label13";
            label13.Size = new Size(156, 20);
            label13.TabIndex = 27;
            label13.Text = "Deduccion por Daños:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.BackColor = Color.Silver;
            textBox1.Font = new Font("Century Gothic", 10.2F);
            textBox1.Location = new Point(208, 352);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 28);
            textBox1.TabIndex = 26;
            textBox1.KeyPress += ValidarNumerico_KeyPress;
            // 
            // txtPensionAlimenticia
            // 
            txtPensionAlimenticia.BackColor = Color.Silver;
            txtPensionAlimenticia.Location = new Point(819, 304);
            txtPensionAlimenticia.Name = "txtPensionAlimenticia";
            txtPensionAlimenticia.Size = new Size(125, 27);
            txtPensionAlimenticia.TabIndex = 25;
            txtPensionAlimenticia.KeyPress += ValidarNumerico_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(672, 311);
            label12.Name = "label12";
            label12.Size = new Size(141, 20);
            label12.TabIndex = 24;
            label12.Text = "Pension Alimenticia:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(344, 311);
            label11.Name = "label11";
            label11.Size = new Size(153, 20);
            label11.TabIndex = 23;
            label11.Text = "Prestamo Empresario:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(45, 311);
            label10.Name = "label10";
            label10.Size = new Size(136, 20);
            label10.TabIndex = 22;
            label10.Text = "Prestamo Bancario:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(705, 118);
            label9.Name = "label9";
            label9.Size = new Size(107, 20);
            label9.TabIndex = 21;
            label9.Text = "Otros Ingresos:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(383, 118);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 20;
            label8.Text = "Riesgo Laboral:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 169);
            label7.Name = "label7";
            label7.Size = new Size(138, 20);
            label7.TabIndex = 19;
            label7.Text = "Viatico Alimenticio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(374, 169);
            label6.Name = "label6";
            label6.Size = new Size(173, 20);
            label6.TabIndex = 18;
            label6.Text = "Viatico por Combustible:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 207);
            label5.Name = "label5";
            label5.Size = new Size(181, 20);
            label5.TabIndex = 17;
            label5.Text = "Depreciacion de Vehiculo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(705, 169);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 16;
            label4.Text = "Bonificaciones:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(715, 64);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 15;
            label3.Text = "Horas Extra:";
            // 
            // LblComisiones
            // 
            LblComisiones.AutoSize = true;
            LblComisiones.Location = new Point(45, 122);
            LblComisiones.Name = "LblComisiones";
            LblComisiones.Size = new Size(88, 20);
            LblComisiones.TabIndex = 14;
            LblComisiones.Text = "Comisiones:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 64);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 13;
            label1.Text = "Nombre Empleado:";
            // 
            // cbxId
            // 
            cbxId.BackColor = Color.Silver;
            cbxId.FormattingEnabled = true;
            cbxId.Location = new Point(217, 60);
            cbxId.Name = "cbxId";
            cbxId.Size = new Size(151, 28);
            cbxId.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkBlue;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.AliceBlue;
            label2.Location = new Point(383, 19);
            label2.Name = "label2";
            label2.Size = new Size(279, 27);
            label2.TabIndex = 13;
            label2.Text = "Ingresos y Deducciones";
            // 
            // FechaHora
            // 
            FechaHora.Enabled = true;
            FechaHora.Tick += FechaHora_Tick;
            // 
            // Nominas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 585);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Nominas";
            Text = "Nominas";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtDepreciacionVehiculo;
        private TextBox txtCOmsiones;
        private TextBox txtOtrosIngresos;
        private TextBox txtPrestamoBancario;
        private TextBox txtPrestamoEmpresario;
        private TextBox txtRiesgoLaboral;
        private TextBox txtHorasExtra;
        private TextBox txtViaticoCombustible;
        private TextBox txtBonificaciones;
        private TextBox txtViaticoAlimeticio;
        private Panel panel1;
        private Label LblComisiones;
        private Label label1;
        private ComboBox cbxId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private Label label10;
        private Button btnIngresar;
        private Label label13;
        private TextBox textBox1;
        private TextBox txtPensionAlimenticia;
        private Label label12;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label17;
        private Label lblHora;
        private Label lblFcha;
        private System.Windows.Forms.Timer FechaHora;
        private Label label18;
        private TextBox txtSalarioBase;
    }
}