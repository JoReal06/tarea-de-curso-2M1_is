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
            label1 = new Label();
            cmb_tablas = new ComboBox();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            cmb_elemntos = new ComboBox();
            label2 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            cmb_tablas.Items.AddRange(new object[] { "tabla de empleados", "tabla de Ingresos", "tabla de Deducciones", "tabla de nominas" });
            cmb_tablas.Location = new Point(119, 31);
            cmb_tablas.Name = "cmb_tablas";
            cmb_tablas.Size = new Size(157, 23);
            cmb_tablas.TabIndex = 1;
            cmb_tablas.SelectedIndexChanged += cmb_tablas_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 134);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(688, 224);
            dataGridView1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(531, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(440, 105);
            button1.Name = "button1";
            button1.Size = new Size(91, 23);
            button1.TabIndex = 4;
            button1.Text = "modificar";
            button1.UseVisualStyleBackColor = true;
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
            // button2
            // 
            button2.Location = new Point(333, 105);
            button2.Name = "button2";
            button2.Size = new Size(91, 23);
            button2.TabIndex = 7;
            button2.Text = "Borrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // CRUDForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 358);
            Controls.Add(button2);
            Controls.Add(cmb_elemntos);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(cmb_tablas);
            Controls.Add(label1);
            Name = "CRUDForm";
            Text = "CRUDForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmb_tablas;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button button1;
        private ComboBox cmb_elemntos;
        private Label label2;
        private Button button2;
    }
}