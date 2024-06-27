namespace tarea_de_curso_2M1_is
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panelIzquierdo = new Panel();
            btnNominas = new Button();
            btnOpcional = new Button();
            btnRegistro = new Button();
            pictureBox1 = new PictureBox();
            panelTitulo = new Panel();
            btnRestaurar = new PictureBox();
            btnExit = new PictureBox();
            btnMaximizar = new PictureBox();
            btnPestaña = new PictureBox();
            btnIzquierdo = new PictureBox();
            panelContenedor = new Panel();
            panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnPestaña).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnIzquierdo).BeginInit();
            SuspendLayout();
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.BackColor = Color.Indigo;
            panelIzquierdo.Controls.Add(btnNominas);
            panelIzquierdo.Controls.Add(btnOpcional);
            panelIzquierdo.Controls.Add(btnRegistro);
            panelIzquierdo.Controls.Add(pictureBox1);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new Size(250, 650);
            panelIzquierdo.TabIndex = 0;
            // 
            // btnNominas
            // 
            btnNominas.Cursor = Cursors.Hand;
            btnNominas.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48);
            btnNominas.FlatStyle = FlatStyle.Flat;
            btnNominas.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNominas.ForeColor = Color.Thistle;
            btnNominas.ImageAlign = ContentAlignment.MiddleLeft;
            btnNominas.Location = new Point(12, 355);
            btnNominas.Name = "btnNominas";
            btnNominas.Size = new Size(220, 45);
            btnNominas.TabIndex = 4;
            btnNominas.Text = "Nominas";
            btnNominas.UseVisualStyleBackColor = true;
            btnNominas.Click += button1_Click;
            // 
            // btnOpcional
            // 
            btnOpcional.Cursor = Cursors.Hand;
            btnOpcional.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48);
            btnOpcional.FlatStyle = FlatStyle.Flat;
            btnOpcional.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold);
            btnOpcional.ForeColor = Color.Thistle;
            btnOpcional.Location = new Point(12, 459);
            btnOpcional.Name = "btnOpcional";
            btnOpcional.Size = new Size(220, 45);
            btnOpcional.TabIndex = 3;
            btnOpcional.Text = "button3";
            btnOpcional.UseVisualStyleBackColor = true;
            // 
            // btnRegistro
            // 
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48);
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.ForeColor = Color.Thistle;
            btnRegistro.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistro.Location = new Point(12, 259);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(220, 45);
            btnRegistro.TabIndex = 1;
            btnRegistro.Text = "Registro";
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.freepik_gradient_developers_coding_logo_20240622195010Qks8;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = SystemColors.ControlLight;
            panelTitulo.Controls.Add(btnRestaurar);
            panelTitulo.Controls.Add(btnExit);
            panelTitulo.Controls.Add(btnMaximizar);
            panelTitulo.Controls.Add(btnPestaña);
            panelTitulo.Controls.Add(btnIzquierdo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(250, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1000, 65);
            panelTitulo.TabIndex = 1;
            panelTitulo.MouseDown += panelTitulo_MouseDown;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestaurar.Cursor = Cursors.Hand;
            btnRestaurar.Image = (Image)resources.GetObject("btnRestaurar.Image");
            btnRestaurar.Location = new Point(885, 12);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(50, 40);
            btnRestaurar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnRestaurar.TabIndex = 1;
            btnRestaurar.TabStop = false;
            btnRestaurar.Visible = false;
            btnRestaurar.Click += btnMinimizar_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Cursor = Cursors.Hand;
            btnExit.Image = Properties.Resources.Exit;
            btnExit.Location = new Point(941, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(50, 40);
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExit.TabIndex = 0;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.Cursor = Cursors.Hand;
            btnMaximizar.Image = Properties.Resources.Maximizar;
            btnMaximizar.Location = new Point(885, 12);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(50, 40);
            btnMaximizar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnMaximizar.TabIndex = 3;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnPestaña
            // 
            btnPestaña.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPestaña.Cursor = Cursors.Hand;
            btnPestaña.Image = Properties.Resources.Dejar;
            btnPestaña.Location = new Point(829, 12);
            btnPestaña.Name = "btnPestaña";
            btnPestaña.Size = new Size(50, 40);
            btnPestaña.SizeMode = PictureBoxSizeMode.StretchImage;
            btnPestaña.TabIndex = 2;
            btnPestaña.TabStop = false;
            btnPestaña.Click += btnPestaña_Click;
            // 
            // btnIzquierdo
            // 
            btnIzquierdo.Cursor = Cursors.Hand;
            btnIzquierdo.Image = Properties.Resources.Opciones;
            btnIzquierdo.Location = new Point(15, 12);
            btnIzquierdo.Name = "btnIzquierdo";
            btnIzquierdo.Size = new Size(47, 40);
            btnIzquierdo.SizeMode = PictureBoxSizeMode.StretchImage;
            btnIzquierdo.TabIndex = 0;
            btnIzquierdo.TabStop = false;
            btnIzquierdo.Click += btnIzquierdo_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(250, 65);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1000, 585);
            panelContenedor.TabIndex = 2;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 650);
            Controls.Add(panelContenedor);
            Controls.Add(panelTitulo);
            Controls.Add(panelIzquierdo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Principal";
            Text = "Principal";
            panelIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnPestaña).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnIzquierdo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIzquierdo;
        private Panel panelTitulo;
        private Panel panelContenedor;
        private PictureBox btnExit;
        private PictureBox btnMaximizar;
        private PictureBox btnPestaña;
        private PictureBox btnRestaurar;
        private PictureBox btnIzquierdo;
        private PictureBox pictureBox1;
        private Button btnOpcional;
        //private Button btnListas;
        private Button btnRegistro;
        private Button btnNominas;
    }
}