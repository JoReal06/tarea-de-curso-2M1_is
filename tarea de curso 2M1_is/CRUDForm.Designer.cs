namespace tarea_de_curso_2M1_is
{
    partial class CRUDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUDForm));
            label1 = new Label();
            cmb_tablas = new ComboBox();
            dtgvTablas = new DataGridView();
            txt_cambio = new TextBox();
            btnModificar = new Button();
            cmb_elemntos = new ComboBox();
            label2 = new Label();
            btnBorrar = new Button();
            picture_load = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dtgvTablas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picture_load).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 31);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccion tabla:";
            // 
            // cmb_tablas
            // 
            cmb_tablas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_tablas.FormattingEnabled = true;
            cmb_tablas.Items.AddRange(new object[] { "tabla de empleados", "tabla de Ingresos", "tabla de Deducciones", "tabla de nominas", "tabla de Actividades de los usuarios." });
            cmb_tablas.Location = new Point(119, 31);
            cmb_tablas.Name = "cmb_tablas";
            cmb_tablas.Size = new Size(177, 23);
            cmb_tablas.TabIndex = 1;
            cmb_tablas.SelectedIndexChanged += cmb_tablas_SelectedIndexChanged;
            // 
            // dtgvTablas
            // 
            dtgvTablas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvTablas.Dock = DockStyle.Bottom;
            dtgvTablas.Location = new Point(0, 169);
            dtgvTablas.Name = "dtgvTablas";
            dtgvTablas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvTablas.Size = new Size(814, 275);
            dtgvTablas.TabIndex = 2;
            // 
            // txt_cambio
            // 
            txt_cambio.Location = new Point(531, 59);
            txt_cambio.Name = "txt_cambio";
            txt_cambio.Size = new Size(145, 23);
            txt_cambio.TabIndex = 3;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(440, 105);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(91, 23);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // cmb_elemntos
            // 
            cmb_elemntos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_elemntos.FormattingEnabled = true;
            cmb_elemntos.Location = new Point(333, 59);
            cmb_elemntos.Name = "cmb_elemntos";
            cmb_elemntos.Size = new Size(172, 23);
            cmb_elemntos.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 31);
            label2.Name = "label2";
            label2.Size = new Size(230, 15);
            label2.TabIndex = 5;
            label2.Text = "Seleccion elemento a modificar de la tabla";
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(333, 105);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(91, 23);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += txtBorrar_Click;
            // 
            // picture_load
            // 
            picture_load.Image = (Image)resources.GetObject("picture_load.Image");
            picture_load.Location = new Point(138, 60);
            picture_load.Name = "picture_load";
            picture_load.Size = new Size(107, 92);
            picture_load.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_load.TabIndex = 8;
            picture_load.TabStop = false;
            // 
            // CRUDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 444);
            Controls.Add(picture_load);
            Controls.Add(btnBorrar);
            Controls.Add(cmb_elemntos);
            Controls.Add(label2);
            Controls.Add(btnModificar);
            Controls.Add(txt_cambio);
            Controls.Add(dtgvTablas);
            Controls.Add(cmb_tablas);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CRUDForm";
            Text = "CRUDForm";
            ((System.ComponentModel.ISupportInitialize)dtgvTablas).EndInit();
            ((System.ComponentModel.ISupportInitialize)picture_load).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmb_tablas;
        private DataGridView dtgvTablas;
        private TextBox txt_cambio;
        private Button btnModificar;
        private ComboBox cmb_elemntos;
        private Label label2;
        private Button btnBorrar;
        private PictureBox picture_load;
    }
}