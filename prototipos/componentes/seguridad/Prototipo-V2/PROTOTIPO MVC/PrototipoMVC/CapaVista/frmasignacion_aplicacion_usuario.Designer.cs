
namespace CapaVista
{
    partial class frmasignacion_aplicacion_usuario
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
            this.Lbl_titulo = new System.Windows.Forms.Label();
            this.Gbp_datos = new System.Windows.Forms.GroupBox();
            this.Btn_agregar = new System.Windows.Forms.Button();
            this.Cbo_Aplicaciones = new System.Windows.Forms.ComboBox();
            this.Cbo_Modulos = new System.Windows.Forms.ComboBox();
            this.Cbo_Usuarios = new System.Windows.Forms.ComboBox();
            this.Lbl_aplicaciones = new System.Windows.Forms.Label();
            this.Lbl_Usuarios = new System.Windows.Forms.Label();
            this.Lbl_modulos = new System.Windows.Forms.Label();
            this.Dgv_Permisos = new System.Windows.Forms.DataGridView();
            this.Btn_quitar = new System.Windows.Forms.Button();
            this.Btn_finalizar = new System.Windows.Forms.Button();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Gbp_datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Permisos)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(136, 28);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(540, 38);
            this.Lbl_titulo.TabIndex = 0;
            this.Lbl_titulo.Text = "Asignacion de Aplicación a Usuario";
            // 
            // Gbp_datos
            // 
            this.Gbp_datos.Controls.Add(this.Btn_agregar);
            this.Gbp_datos.Controls.Add(this.Cbo_Aplicaciones);
            this.Gbp_datos.Controls.Add(this.Cbo_Modulos);
            this.Gbp_datos.Controls.Add(this.Cbo_Usuarios);
            this.Gbp_datos.Controls.Add(this.Lbl_aplicaciones);
            this.Gbp_datos.Controls.Add(this.Lbl_Usuarios);
            this.Gbp_datos.Controls.Add(this.Lbl_modulos);
            this.Gbp_datos.Location = new System.Drawing.Point(25, 89);
            this.Gbp_datos.Name = "Gbp_datos";
            this.Gbp_datos.Size = new System.Drawing.Size(736, 119);
            this.Gbp_datos.TabIndex = 1;
            this.Gbp_datos.TabStop = false;
            this.Gbp_datos.Text = "Datos";
            // 
            // Btn_agregar
            // 
            this.Btn_agregar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_agregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_agregar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_agregar.Location = new System.Drawing.Point(612, 44);
            this.Btn_agregar.Name = "Btn_agregar";
            this.Btn_agregar.Size = new System.Drawing.Size(96, 41);
            this.Btn_agregar.TabIndex = 5;
            this.Btn_agregar.Text = "Agregar";
            this.Btn_agregar.UseVisualStyleBackColor = false;
            this.Btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click_1);
            // 
            // Cbo_Aplicaciones
            // 
            this.Cbo_Aplicaciones.FormattingEnabled = true;
            this.Cbo_Aplicaciones.Location = new System.Drawing.Point(413, 61);
            this.Cbo_Aplicaciones.Name = "Cbo_Aplicaciones";
            this.Cbo_Aplicaciones.Size = new System.Drawing.Size(172, 24);
            this.Cbo_Aplicaciones.TabIndex = 4;
            // 
            // Cbo_Modulos
            // 
            this.Cbo_Modulos.FormattingEnabled = true;
            this.Cbo_Modulos.Location = new System.Drawing.Point(200, 61);
            this.Cbo_Modulos.Name = "Cbo_Modulos";
            this.Cbo_Modulos.Size = new System.Drawing.Size(172, 24);
            this.Cbo_Modulos.TabIndex = 3;
            // 
            // Cbo_Usuarios
            // 
            this.Cbo_Usuarios.FormattingEnabled = true;
            this.Cbo_Usuarios.Location = new System.Drawing.Point(15, 61);
            this.Cbo_Usuarios.Name = "Cbo_Usuarios";
            this.Cbo_Usuarios.Size = new System.Drawing.Size(150, 24);
            this.Cbo_Usuarios.TabIndex = 2;
            // 
            // Lbl_aplicaciones
            // 
            this.Lbl_aplicaciones.AutoSize = true;
            this.Lbl_aplicaciones.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_aplicaciones.Location = new System.Drawing.Point(423, 29);
            this.Lbl_aplicaciones.Name = "Lbl_aplicaciones";
            this.Lbl_aplicaciones.Size = new System.Drawing.Size(111, 20);
            this.Lbl_aplicaciones.TabIndex = 1;
            this.Lbl_aplicaciones.Text = "Aplicaciones";
            // 
            // Lbl_Usuarios
            // 
            this.Lbl_Usuarios.AutoSize = true;
            this.Lbl_Usuarios.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Usuarios.Location = new System.Drawing.Point(42, 29);
            this.Lbl_Usuarios.Name = "Lbl_Usuarios";
            this.Lbl_Usuarios.Size = new System.Drawing.Size(78, 20);
            this.Lbl_Usuarios.TabIndex = 0;
            this.Lbl_Usuarios.Text = "Usuarios";
            // 
            // Lbl_modulos
            // 
            this.Lbl_modulos.AutoSize = true;
            this.Lbl_modulos.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_modulos.Location = new System.Drawing.Point(239, 29);
            this.Lbl_modulos.Name = "Lbl_modulos";
            this.Lbl_modulos.Size = new System.Drawing.Size(77, 20);
            this.Lbl_modulos.TabIndex = 0;
            this.Lbl_modulos.Text = "Modulos";
            // 
            // Dgv_Permisos
            // 
            this.Dgv_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Permisos.Location = new System.Drawing.Point(25, 223);
            this.Dgv_Permisos.Name = "Dgv_Permisos";
            this.Dgv_Permisos.RowHeadersWidth = 51;
            this.Dgv_Permisos.RowTemplate.Height = 24;
            this.Dgv_Permisos.Size = new System.Drawing.Size(570, 215);
            this.Dgv_Permisos.TabIndex = 2;
            // 
            // Btn_quitar
            // 
            this.Btn_quitar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_quitar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_quitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_quitar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_quitar.Location = new System.Drawing.Point(637, 241);
            this.Btn_quitar.Name = "Btn_quitar";
            this.Btn_quitar.Size = new System.Drawing.Size(96, 41);
            this.Btn_quitar.TabIndex = 6;
            this.Btn_quitar.Text = "Quitar";
            this.Btn_quitar.UseVisualStyleBackColor = false;
            // 
            // Btn_finalizar
            // 
            this.Btn_finalizar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_finalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_finalizar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_finalizar.Location = new System.Drawing.Point(637, 311);
            this.Btn_finalizar.Name = "Btn_finalizar";
            this.Btn_finalizar.Size = new System.Drawing.Size(96, 41);
            this.Btn_finalizar.TabIndex = 7;
            this.Btn_finalizar.Text = "Finalizar";
            this.Btn_finalizar.UseVisualStyleBackColor = false;
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_salir.Location = new System.Drawing.Point(637, 379);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(96, 41);
            this.Btn_salir.TabIndex = 8;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // frmasignacion_aplicacion_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_finalizar);
            this.Controls.Add(this.Btn_quitar);
            this.Controls.Add(this.Dgv_Permisos);
            this.Controls.Add(this.Gbp_datos);
            this.Controls.Add(this.Lbl_titulo);
            this.Name = "frmasignacion_aplicacion_usuario";
            this.Text = "Asignacion de Aplicación a Usuario";
            this.Gbp_datos.ResumeLayout(false);
            this.Gbp_datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Permisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_titulo;
        private System.Windows.Forms.GroupBox Gbp_datos;
        private System.Windows.Forms.Button Btn_agregar;
        private System.Windows.Forms.ComboBox Cbo_Aplicaciones;
        private System.Windows.Forms.ComboBox Cbo_Modulos;
        private System.Windows.Forms.ComboBox Cbo_Usuarios;
        private System.Windows.Forms.Label Lbl_aplicaciones;
        private System.Windows.Forms.Label Lbl_Usuarios;
        private System.Windows.Forms.Label Lbl_modulos;
        private System.Windows.Forms.DataGridView Dgv_Permisos;
        private System.Windows.Forms.Button Btn_quitar;
        private System.Windows.Forms.Button Btn_finalizar;
        private System.Windows.Forms.Button Btn_salir;
    }
}