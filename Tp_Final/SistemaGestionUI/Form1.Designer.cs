namespace SistemaGestionUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSistemaGestionUI = new DataGridView();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSistemaGestionUI).BeginInit();
            SuspendLayout();
            // 
            // dgvSistemaGestionUI
            // 
            dgvSistemaGestionUI.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSistemaGestionUI.Location = new Point(59, 129);
            dgvSistemaGestionUI.Name = "dgvSistemaGestionUI";
            dgvSistemaGestionUI.Size = new Size(682, 287);
            dgvSistemaGestionUI.TabIndex = 0;
            dgvSistemaGestionUI.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Producto", "Producto Vendido", "Usuario", "Venta Data" });
            comboBox1.Location = new Point(61, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(dgvSistemaGestionUI);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSistemaGestionUI).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSistemaGestionUI;
        private ComboBox comboBox1;
    }
}
