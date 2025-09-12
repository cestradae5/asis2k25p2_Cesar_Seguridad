
namespace CapaVista
{
    partial class Consulta
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
            this.Dgv_registros = new System.Windows.Forms.DataGridView();
            this.Btn_Consulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_registros)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_registros
            // 
            this.Dgv_registros.AllowUserToAddRows = false;
            this.Dgv_registros.AllowUserToDeleteRows = false;
            this.Dgv_registros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_registros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_registros.Location = new System.Drawing.Point(30, 181);
            this.Dgv_registros.Name = "Dgv_registros";
            this.Dgv_registros.ReadOnly = true;
            this.Dgv_registros.RowHeadersWidth = 51;
            this.Dgv_registros.RowTemplate.Height = 24;
            this.Dgv_registros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_registros.Size = new System.Drawing.Size(726, 257);
            this.Dgv_registros.TabIndex = 0;
            // 
            // Btn_Consulta
            // 
            this.Btn_Consulta.Location = new System.Drawing.Point(312, 21);
            this.Btn_Consulta.Name = "Btn_Consulta";
            this.Btn_Consulta.Size = new System.Drawing.Size(189, 97);
            this.Btn_Consulta.TabIndex = 1;
            this.Btn_Consulta.Text = "Consultar";
            this.Btn_Consulta.UseVisualStyleBackColor = true;
            this.Btn_Consulta.Click += new System.EventHandler(this.Btn_Consulta_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Consulta);
            this.Controls.Add(this.Dgv_registros);
            this.Name = "Consulta";
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_registros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_registros;
        private System.Windows.Forms.Button Btn_Consulta;
    }
}