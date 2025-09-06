
namespace Capa_Vista_Reporteador
{
    partial class Reportes
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
            this.Txt_reportes = new System.Windows.Forms.Label();
            this.Dgv_reportes = new System.Windows.Forms.DataGridView();
            this.Txt_reportes_ruta = new System.Windows.Forms.TextBox();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_ver_reporte = new System.Windows.Forms.Button();
            this.Btn_ruta_reporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_reportes)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_reportes
            // 
            this.Txt_reportes.AutoSize = true;
            this.Txt_reportes.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_reportes.Location = new System.Drawing.Point(400, 36);
            this.Txt_reportes.Name = "Txt_reportes";
            this.Txt_reportes.Size = new System.Drawing.Size(148, 38);
            this.Txt_reportes.TabIndex = 1;
            this.Txt_reportes.Text = "Reportes";
            // 
            // Dgv_reportes
            // 
            this.Dgv_reportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_reportes.Location = new System.Drawing.Point(25, 255);
            this.Dgv_reportes.Name = "Dgv_reportes";
            this.Dgv_reportes.RowHeadersWidth = 51;
            this.Dgv_reportes.RowTemplate.Height = 24;
            this.Dgv_reportes.Size = new System.Drawing.Size(880, 195);
            this.Dgv_reportes.TabIndex = 2;
            // 
            // Txt_reportes_ruta
            // 
            this.Txt_reportes_ruta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_reportes_ruta.Location = new System.Drawing.Point(25, 129);
            this.Txt_reportes_ruta.Name = "Txt_reportes_ruta";
            this.Txt_reportes_ruta.Size = new System.Drawing.Size(582, 22);
            this.Txt_reportes_ruta.TabIndex = 3;
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_guardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_guardar.Location = new System.Drawing.Point(25, 209);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(285, 37);
            this.Btn_guardar.TabIndex = 4;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.BackColor = System.Drawing.Color.IndianRed;
            this.Btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_eliminar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_eliminar.Location = new System.Drawing.Point(322, 209);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(285, 37);
            this.Btn_eliminar.TabIndex = 5;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.Color.Khaki;
            this.Btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_modificar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_modificar.Location = new System.Drawing.Point(620, 209);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(285, 37);
            this.Btn_modificar.TabIndex = 6;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_ver_reporte
            // 
            this.Btn_ver_reporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_ver_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ver_reporte.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ver_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_ver_reporte.Location = new System.Drawing.Point(620, 166);
            this.Btn_ver_reporte.Name = "Btn_ver_reporte";
            this.Btn_ver_reporte.Size = new System.Drawing.Size(285, 37);
            this.Btn_ver_reporte.TabIndex = 7;
            this.Btn_ver_reporte.Text = "Ver reporte";
            this.Btn_ver_reporte.UseVisualStyleBackColor = false;
            this.Btn_ver_reporte.Click += new System.EventHandler(this.Btn_ver_reporte_Click);
            // 
            // Btn_ruta_reporte
            // 
            this.Btn_ruta_reporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_ruta_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ruta_reporte.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ruta_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_ruta_reporte.Location = new System.Drawing.Point(620, 123);
            this.Btn_ruta_reporte.Name = "Btn_ruta_reporte";
            this.Btn_ruta_reporte.Size = new System.Drawing.Size(285, 37);
            this.Btn_ruta_reporte.TabIndex = 8;
            this.Btn_ruta_reporte.Text = "Ruta";
            this.Btn_ruta_reporte.UseVisualStyleBackColor = false;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 474);
            this.Controls.Add(this.Btn_ruta_reporte);
            this.Controls.Add(this.Btn_ver_reporte);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Txt_reportes_ruta);
            this.Controls.Add(this.Dgv_reportes);
            this.Controls.Add(this.Txt_reportes);
            this.Name = "Reportes";
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_reportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Txt_reportes;
        private System.Windows.Forms.DataGridView Dgv_reportes;
        private System.Windows.Forms.TextBox Txt_reportes_ruta;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_ver_reporte;
        private System.Windows.Forms.Button Btn_ruta_reporte;
    }
}