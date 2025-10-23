
namespace Capa_Vista_Reporteador
{
    partial class Frm_Reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reportes));
            this.Lbl_reportes = new System.Windows.Forms.Label();
            this.Dgv_reportes = new System.Windows.Forms.DataGridView();
            this.Txt_reportes_ruta = new System.Windows.Forms.TextBox();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_ver_reporte = new System.Windows.Forms.Button();
            this.Btn_ruta_reporte = new System.Windows.Forms.Button();
            this.Txt_Titulo = new System.Windows.Forms.TextBox();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Btn_refrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_reportes)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_reportes
            // 
            this.Lbl_reportes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Lbl_reportes.AutoSize = true;
            this.Lbl_reportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_reportes.Location = new System.Drawing.Point(400, 36);
            this.Lbl_reportes.Name = "Lbl_reportes";
            this.Lbl_reportes.Size = new System.Drawing.Size(144, 36);
            this.Lbl_reportes.TabIndex = 1;
            this.Lbl_reportes.Text = "Reportes";
            this.Lbl_reportes.Click += new System.EventHandler(this.Lbl_reportes_Click);
            // 
            // Dgv_reportes
            // 
            this.Dgv_reportes.AllowUserToAddRows = false;
            this.Dgv_reportes.AllowUserToDeleteRows = false;
            this.Dgv_reportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_reportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_reportes.Location = new System.Drawing.Point(25, 255);
            this.Dgv_reportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dgv_reportes.Name = "Dgv_reportes";
            this.Dgv_reportes.ReadOnly = true;
            this.Dgv_reportes.RowHeadersWidth = 51;
            this.Dgv_reportes.RowTemplate.Height = 24;
            this.Dgv_reportes.Size = new System.Drawing.Size(880, 194);
            this.Dgv_reportes.TabIndex = 2;
            this.Dgv_reportes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_reportes_CellClick);
            this.Dgv_reportes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_reportes_CellContentClick);
            // 
            // Txt_reportes_ruta
            // 
            this.Txt_reportes_ruta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_reportes_ruta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_reportes_ruta.Location = new System.Drawing.Point(25, 129);
            this.Txt_reportes_ruta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_reportes_ruta.Name = "Txt_reportes_ruta";
            this.Txt_reportes_ruta.ReadOnly = true;
            this.Txt_reportes_ruta.Size = new System.Drawing.Size(582, 22);
            this.Txt_reportes_ruta.TabIndex = 3;
            this.Txt_reportes_ruta.TextChanged += new System.EventHandler(this.Txt_reportes_ruta_TextChanged);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.White;
            this.Btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_guardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_guardar.Image")));
            this.Btn_guardar.Location = new System.Drawing.Point(25, 201);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(53, 46);
            this.Btn_guardar.TabIndex = 4;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.BackColor = System.Drawing.Color.White;
            this.Btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.Location = new System.Drawing.Point(84, 201);
            this.Btn_eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(53, 46);
            this.Btn_eliminar.TabIndex = 5;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.Color.White;
            this.Btn_modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_modificar.Image")));
            this.Btn_modificar.Location = new System.Drawing.Point(143, 201);
            this.Btn_modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(53, 46);
            this.Btn_modificar.TabIndex = 6;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_ver_reporte
            // 
            this.Btn_ver_reporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ver_reporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_ver_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ver_reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ver_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_ver_reporte.Location = new System.Drawing.Point(620, 166);
            this.Btn_ver_reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_ver_reporte.Name = "Btn_ver_reporte";
            this.Btn_ver_reporte.Size = new System.Drawing.Size(285, 37);
            this.Btn_ver_reporte.TabIndex = 7;
            this.Btn_ver_reporte.Text = "Ver reporte";
            this.Btn_ver_reporte.UseVisualStyleBackColor = false;
            this.Btn_ver_reporte.Click += new System.EventHandler(this.Btn_ver_reporte_Click);
            // 
            // Btn_ruta_reporte
            // 
            this.Btn_ruta_reporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ruta_reporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_ruta_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ruta_reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ruta_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_ruta_reporte.Location = new System.Drawing.Point(620, 123);
            this.Btn_ruta_reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_ruta_reporte.Name = "Btn_ruta_reporte";
            this.Btn_ruta_reporte.Size = new System.Drawing.Size(285, 37);
            this.Btn_ruta_reporte.TabIndex = 8;
            this.Btn_ruta_reporte.Text = "Ruta";
            this.Btn_ruta_reporte.UseVisualStyleBackColor = false;
            this.Btn_ruta_reporte.Click += new System.EventHandler(this.Btn_ruta_reporte_Click);
            // 
            // Txt_Titulo
            // 
            this.Txt_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Titulo.Location = new System.Drawing.Point(103, 169);
            this.Txt_Titulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Titulo.Name = "Txt_Titulo";
            this.Txt_Titulo.Size = new System.Drawing.Size(504, 22);
            this.Txt_Titulo.TabIndex = 9;
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Titulo.Location = new System.Drawing.Point(20, 166);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(74, 29);
            this.Lbl_Titulo.TabIndex = 10;
            this.Lbl_Titulo.Text = "Título";
            // 
            // Btn_refrescar
            // 
            this.Btn_refrescar.BackColor = System.Drawing.Color.White;
            this.Btn_refrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_refrescar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_refrescar.Image")));
            this.Btn_refrescar.Location = new System.Drawing.Point(201, 201);
            this.Btn_refrescar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_refrescar.Name = "Btn_refrescar";
            this.Btn_refrescar.Size = new System.Drawing.Size(53, 46);
            this.Btn_refrescar.TabIndex = 11;
            this.Btn_refrescar.UseVisualStyleBackColor = false;
            this.Btn_refrescar.Click += new System.EventHandler(this.Btn_refrescar_Click);
            // 
            // Frm_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(931, 474);
            this.Controls.Add(this.Btn_refrescar);
            this.Controls.Add(this.Lbl_Titulo);
            this.Controls.Add(this.Txt_Titulo);
            this.Controls.Add(this.Btn_ruta_reporte);
            this.Controls.Add(this.Btn_ver_reporte);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Txt_reportes_ruta);
            this.Controls.Add(this.Dgv_reportes);
            this.Controls.Add(this.Lbl_reportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_reportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_reportes;
        private System.Windows.Forms.DataGridView Dgv_reportes;
        private System.Windows.Forms.TextBox Txt_reportes_ruta;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_ver_reporte;
        private System.Windows.Forms.Button Btn_ruta_reporte;
        private System.Windows.Forms.TextBox Txt_Titulo;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Button Btn_refrescar;
    }
}