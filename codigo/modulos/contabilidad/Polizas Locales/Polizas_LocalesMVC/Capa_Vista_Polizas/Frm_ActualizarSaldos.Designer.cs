namespace Capa_Vista_Polizas
{
    partial class Frm_ActualizarSaldos
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
            this.Gpb_Rangofechas = new System.Windows.Forms.GroupBox();
            this.Lbl_FechaHasta = new System.Windows.Forms.Label();
            this.Dtp_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaDesde = new System.Windows.Forms.Label();
            this.Dtp_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Actualizacion = new System.Windows.Forms.Label();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Gpb_Rangofechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gpb_Rangofechas
            // 
            this.Gpb_Rangofechas.Controls.Add(this.Lbl_FechaHasta);
            this.Gpb_Rangofechas.Controls.Add(this.Dtp_FechaHasta);
            this.Gpb_Rangofechas.Controls.Add(this.Lbl_FechaDesde);
            this.Gpb_Rangofechas.Controls.Add(this.Dtp_FechaDesde);
            this.Gpb_Rangofechas.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Rangofechas.Location = new System.Drawing.Point(60, 144);
            this.Gpb_Rangofechas.Name = "Gpb_Rangofechas";
            this.Gpb_Rangofechas.Size = new System.Drawing.Size(709, 218);
            this.Gpb_Rangofechas.TabIndex = 4;
            this.Gpb_Rangofechas.TabStop = false;
            this.Gpb_Rangofechas.Text = "Rango de Fechas";
            this.Gpb_Rangofechas.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Lbl_FechaHasta
            // 
            this.Lbl_FechaHasta.AutoSize = true;
            this.Lbl_FechaHasta.Location = new System.Drawing.Point(15, 148);
            this.Lbl_FechaHasta.Name = "Lbl_FechaHasta";
            this.Lbl_FechaHasta.Size = new System.Drawing.Size(65, 20);
            this.Lbl_FechaHasta.TabIndex = 3;
            this.Lbl_FechaHasta.Text = "Hasta: ";
            // 
            // Dtp_FechaHasta
            // 
            this.Dtp_FechaHasta.CalendarFont = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_FechaHasta.Location = new System.Drawing.Point(142, 148);
            this.Dtp_FechaHasta.Name = "Dtp_FechaHasta";
            this.Dtp_FechaHasta.Size = new System.Drawing.Size(339, 29);
            this.Dtp_FechaHasta.TabIndex = 2;
            // 
            // Lbl_FechaDesde
            // 
            this.Lbl_FechaDesde.AutoSize = true;
            this.Lbl_FechaDesde.Location = new System.Drawing.Point(15, 51);
            this.Lbl_FechaDesde.Name = "Lbl_FechaDesde";
            this.Lbl_FechaDesde.Size = new System.Drawing.Size(71, 20);
            this.Lbl_FechaDesde.TabIndex = 1;
            this.Lbl_FechaDesde.Text = "Desde: ";
            // 
            // Dtp_FechaDesde
            // 
            this.Dtp_FechaDesde.CalendarFont = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_FechaDesde.Location = new System.Drawing.Point(142, 51);
            this.Dtp_FechaDesde.Name = "Dtp_FechaDesde";
            this.Dtp_FechaDesde.Size = new System.Drawing.Size(339, 29);
            this.Dtp_FechaDesde.TabIndex = 0;
            // 
            // Lbl_Actualizacion
            // 
            this.Lbl_Actualizacion.AutoSize = true;
            this.Lbl_Actualizacion.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Actualizacion.Location = new System.Drawing.Point(140, 54);
            this.Lbl_Actualizacion.Name = "Lbl_Actualizacion";
            this.Lbl_Actualizacion.Size = new System.Drawing.Size(483, 38);
            this.Lbl_Actualizacion.TabIndex = 3;
            this.Lbl_Actualizacion.Text = "Actualización de Saldos Polizas";
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Aceptar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(212, 413);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(129, 41);
            this.Btn_Aceptar.TabIndex = 5;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Location = new System.Drawing.Point(446, 413);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(129, 41);
            this.Btn_Salir.TabIndex = 6;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Frm_ActualizarSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Gpb_Rangofechas);
            this.Controls.Add(this.Lbl_Actualizacion);
            this.Name = "Frm_ActualizarSaldos";
            this.Text = "3020 - Actualización de Saldos Contables";
            this.Gpb_Rangofechas.ResumeLayout(false);
            this.Gpb_Rangofechas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_Rangofechas;
        private System.Windows.Forms.Label Lbl_FechaDesde;
        private System.Windows.Forms.DateTimePicker Dtp_FechaDesde;
        private System.Windows.Forms.Label Lbl_Actualizacion;
        private System.Windows.Forms.Label Lbl_FechaHasta;
        private System.Windows.Forms.DateTimePicker Dtp_FechaHasta;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
    }
}