namespace tarea_de_curso_2M1_is
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            txt_nombre = new TextBox();
            txt_contraseña = new TextBox();
            label3 = new Label();
            btn_incio = new Button();
            lb_aviso = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(95, 9);
            label1.Name = "label1";
            label1.Size = new Size(193, 30);
            label1.TabIndex = 0;
            label1.Text = "INICIO DE SESION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 54);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de usuario:";
            // 
            // txt_nombre
            // 
            txt_nombre.Location = new Point(142, 51);
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(196, 23);
            txt_nombre.TabIndex = 2;
            txt_nombre.KeyDown += txt_nombre_KeyDown;
            // 
            // txt_contraseña
            // 
            txt_contraseña.Location = new Point(142, 80);
            txt_contraseña.Name = "txt_contraseña";
            txt_contraseña.Size = new Size(196, 23);
            txt_contraseña.TabIndex = 4;
            txt_contraseña.KeyDown += txt_contraseña_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 83);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // btn_incio
            // 
            btn_incio.Location = new Point(283, 152);
            btn_incio.Name = "btn_incio";
            btn_incio.Size = new Size(82, 30);
            btn_incio.TabIndex = 5;
            btn_incio.Text = "Enviar";
            btn_incio.UseVisualStyleBackColor = true;
            btn_incio.Click += btn_incio_Click;
            // 
            // lb_aviso
            // 
            lb_aviso.AutoSize = true;
            lb_aviso.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_aviso.ForeColor = Color.Red;
            lb_aviso.Location = new Point(27, 117);
            lb_aviso.Name = "lb_aviso";
            lb_aviso.Size = new Size(318, 17);
            lb_aviso.TabIndex = 6;
            lb_aviso.Text = "LA CONTRASEÑA O EL USUARIO SON INCORRECTOS";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 206);
            Controls.Add(lb_aviso);
            Controls.Add(btn_incio);
            Controls.Add(txt_contraseña);
            Controls.Add(label3);
            Controls.Add(txt_nombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txt_nombre;
        private TextBox txt_contraseña;
        private Label label3;
        private Button btn_incio;
        private Label lb_aviso;
    }
}