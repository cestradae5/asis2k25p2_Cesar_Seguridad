namespace Capa_Vista_Polizas
{
    partial class Frm_CierreAño
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
            this.Lbl_Actualizacion = new System.Windows.Forms.Label();
            this.Gpb_AñoContable = new System.Windows.Forms.GroupBox();
            this.Lbl_Modo = new System.Windows.Forms.Label();
            this.Lbl_ModoCont = new System.Windows.Forms.Label();
            this.Cbo_AñoContable = new System.Windows.Forms.ComboBox();
            this.Lbl_AñoContable = new System.Windows.Forms.Label();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Gpb_AñoContable.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Actualizacion
            // 
            this.Lbl_Actualizacion.AutoSize = true;
            this.Lbl_Actualizacion.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Actualizacion.Location = new System.Drawing.Point(204, 59);
            this.Lbl_Actualizacion.Name = "Lbl_Actualizacion";
            this.Lbl_Actualizacion.Size = new System.Drawing.Size(383, 33);
            this.Lbl_Actualizacion.TabIndex = 0;
            this.Lbl_Actualizacion.Text = "Cierre de Anual de Polizas";
            // 
            // Gpb_AñoContable
            // 
            this.Gpb_AñoContable.Controls.Add(this.Lbl_Modo);
            this.Gpb_AñoContable.Controls.Add(this.Lbl_ModoCont);
            this.Gpb_AñoContable.Controls.Add(this.Cbo_AñoContable);
            this.Gpb_AñoContable.Controls.Add(this.Lbl_AñoContable);
            this.Gpb_AñoContable.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_AñoContable.Location = new System.Drawing.Point(67, 154);
            this.Gpb_AñoContable.Name = "Gpb_AñoContable";
            this.Gpb_AñoContable.Size = new System.Drawing.Size(699, 199);
            this.Gpb_AñoContable.TabIndex = 1;
            this.Gpb_AñoContable.TabStop = false;
            this.Gpb_AñoContable.Text = "Seleccionar Año Contable Activo";
            // 
            // Lbl_Modo
            // 
            this.Lbl_Modo.AutoSize = true;
            this.Lbl_Modo.Location = new System.Drawing.Point(203, 139);
            this.Lbl_Modo.Name = "Lbl_Modo";
            this.Lbl_Modo.Size = new System.Drawing.Size(56, 20);
            this.Lbl_Modo.TabIndex = 5;
            this.Lbl_Modo.Text = "Modo";
            // 
            // Lbl_ModoCont
            // 
            this.Lbl_ModoCont.AutoSize = true;
            this.Lbl_ModoCont.Location = new System.Drawing.Point(45, 139);
            this.Lbl_ModoCont.Name = "Lbl_ModoCont";
            this.Lbl_ModoCont.Size = new System.Drawing.Size(61, 20);
            this.Lbl_ModoCont.TabIndex = 4;
            this.Lbl_ModoCont.Text = "Modo:";
            // 
            // Cbo_AñoContable
            // 
            this.Cbo_AñoContable.FormattingEnabled = true;
            this.Cbo_AñoContable.Location = new System.Drawing.Point(211, 62);
            this.Cbo_AñoContable.Name = "Cbo_AñoContable";
            this.Cbo_AñoContable.Size = new System.Drawing.Size(216, 28);
            this.Cbo_AñoContable.TabIndex = 1;
            // 
            // Lbl_AñoContable
            // 
            this.Lbl_AñoContable.AutoSize = true;
            this.Lbl_AñoContable.Location = new System.Drawing.Point(45, 65);
            this.Lbl_AñoContable.Name = "Lbl_AñoContable";
            this.Lbl_AñoContable.Size = new System.Drawing.Size(123, 20);
            this.Lbl_AñoContable.TabIndex = 0;
            this.Lbl_AñoContable.Text = "Año Contable";
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Aceptar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(210, 410);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(149, 38);
            this.Btn_Aceptar.TabIndex = 2;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Location = new System.Drawing.Point(456, 410);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(149, 38);
            this.Btn_Salir.TabIndex = 3;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Frm_CierreAño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.Gpb_AñoContable);
            this.Controls.Add(this.Lbl_Actualizacion);
            this.Name = "Frm_CierreAño";
            this.Text = "3040 - Cierre Anual de Polizas";
            this.Load += new System.EventHandler(this.Frm_CierreAño_Load);
            this.Gpb_AñoContable.ResumeLayout(false);
            this.Gpb_AñoContable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Actualizacion;
        private System.Windows.Forms.GroupBox Gpb_AñoContable;
        private System.Windows.Forms.ComboBox Cbo_AñoContable;
        private System.Windows.Forms.Label Lbl_AñoContable;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Label Lbl_Modo;
        private System.Windows.Forms.Label Lbl_ModoCont;
    }
}