
namespace Capa_Vista_Seguridad
{
    partial class Frm_asignacion_aplicacion_usuario
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
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Gbp_datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Permisos)).BeginInit();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_titulo
            // 
            this.Lbl_titulo.AutoSize = true;
            this.Lbl_titulo.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_titulo.Location = new System.Drawing.Point(156, 92);
            this.Lbl_titulo.Name = "Lbl_titulo";
            this.Lbl_titulo.Size = new System.Drawing.Size(649, 44);
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
            this.Gbp_datos.Location = new System.Drawing.Point(32, 169);
            this.Gbp_datos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gbp_datos.Name = "Gbp_datos";
            this.Gbp_datos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gbp_datos.Size = new System.Drawing.Size(878, 149);
            this.Gbp_datos.TabIndex = 1;
            this.Gbp_datos.TabStop = false;
            this.Gbp_datos.Text = "Datos";
            // 
            // Btn_agregar
            // 
            this.Btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_agregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_agregar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_agregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_agregar.Image = global::Capa_Vista_Seguridad.Properties.Resources.add_insert_new_plus_button_icon_142943;
            this.Btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_agregar.Location = new System.Drawing.Point(688, 56);
            this.Btn_agregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_agregar.Name = "Btn_agregar";
            this.Btn_agregar.Size = new System.Drawing.Size(143, 65);
            this.Btn_agregar.TabIndex = 5;
            this.Btn_agregar.Text = "Agregar";
            this.Btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_agregar.UseVisualStyleBackColor = false;
            this.Btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click_1);
            // 
            // Cbo_Aplicaciones
            // 
            this.Cbo_Aplicaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_Aplicaciones.FormattingEnabled = true;
            this.Cbo_Aplicaciones.Location = new System.Drawing.Point(465, 76);
            this.Cbo_Aplicaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_Aplicaciones.Name = "Cbo_Aplicaciones";
            this.Cbo_Aplicaciones.Size = new System.Drawing.Size(193, 28);
            this.Cbo_Aplicaciones.TabIndex = 4;
            this.Cbo_Aplicaciones.SelectedIndexChanged += new System.EventHandler(this.Cbo_Aplicaciones_SelectedIndexChanged);
            // 
            // Cbo_Modulos
            // 
            this.Cbo_Modulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_Modulos.FormattingEnabled = true;
            this.Cbo_Modulos.Location = new System.Drawing.Point(225, 76);
            this.Cbo_Modulos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_Modulos.Name = "Cbo_Modulos";
            this.Cbo_Modulos.Size = new System.Drawing.Size(193, 28);
            this.Cbo_Modulos.TabIndex = 3;
            // 
            // Cbo_Usuarios
            // 
            this.Cbo_Usuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_Usuarios.FormattingEnabled = true;
            this.Cbo_Usuarios.Location = new System.Drawing.Point(17, 76);
            this.Cbo_Usuarios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_Usuarios.Name = "Cbo_Usuarios";
            this.Cbo_Usuarios.Size = new System.Drawing.Size(168, 28);
            this.Cbo_Usuarios.TabIndex = 2;
            // 
            // Lbl_aplicaciones
            // 
            this.Lbl_aplicaciones.AutoSize = true;
            this.Lbl_aplicaciones.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_aplicaciones.Location = new System.Drawing.Point(476, 36);
            this.Lbl_aplicaciones.Name = "Lbl_aplicaciones";
            this.Lbl_aplicaciones.Size = new System.Drawing.Size(128, 22);
            this.Lbl_aplicaciones.TabIndex = 1;
            this.Lbl_aplicaciones.Text = "Aplicaciones";
            // 
            // Lbl_Usuarios
            // 
            this.Lbl_Usuarios.AutoSize = true;
            this.Lbl_Usuarios.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Usuarios.Location = new System.Drawing.Point(47, 36);
            this.Lbl_Usuarios.Name = "Lbl_Usuarios";
            this.Lbl_Usuarios.Size = new System.Drawing.Size(89, 22);
            this.Lbl_Usuarios.TabIndex = 0;
            this.Lbl_Usuarios.Text = "Usuarios";
            // 
            // Lbl_modulos
            // 
            this.Lbl_modulos.AutoSize = true;
            this.Lbl_modulos.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_modulos.Location = new System.Drawing.Point(269, 36);
            this.Lbl_modulos.Name = "Lbl_modulos";
            this.Lbl_modulos.Size = new System.Drawing.Size(89, 22);
            this.Lbl_modulos.TabIndex = 0;
            this.Lbl_modulos.Text = "Modulos";
            // 
            // Dgv_Permisos
            // 
            this.Dgv_Permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Permisos.Location = new System.Drawing.Point(32, 336);
            this.Dgv_Permisos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dgv_Permisos.Name = "Dgv_Permisos";
            this.Dgv_Permisos.RowHeadersWidth = 51;
            this.Dgv_Permisos.RowTemplate.Height = 24;
            this.Dgv_Permisos.Size = new System.Drawing.Size(641, 269);
            this.Dgv_Permisos.TabIndex = 2;
            this.Dgv_Permisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Permisos_CellContentClick);
            // 
            // Btn_quitar
            // 
            this.Btn_quitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_quitar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_quitar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_quitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_quitar.Image = global::Capa_Vista_Seguridad.Properties.Resources.delete_remove_trash_icon_177304;
            this.Btn_quitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_quitar.Location = new System.Drawing.Point(722, 395);
            this.Btn_quitar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_quitar.Name = "Btn_quitar";
            this.Btn_quitar.Size = new System.Drawing.Size(143, 65);
            this.Btn_quitar.TabIndex = 6;
            this.Btn_quitar.Text = "Quitar";
            this.Btn_quitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_quitar.UseVisualStyleBackColor = false;
            this.Btn_quitar.Click += new System.EventHandler(this.Btn_quitar_Click);
            // 
            // Btn_finalizar
            // 
            this.Btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_finalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_finalizar.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_finalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_finalizar.Image = global::Capa_Vista_Seguridad.Properties.Resources.add_insert_new_plus_button_icon_142943;
            this.Btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_finalizar.Location = new System.Drawing.Point(720, 468);
            this.Btn_finalizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_finalizar.Name = "Btn_finalizar";
            this.Btn_finalizar.Size = new System.Drawing.Size(143, 65);
            this.Btn_finalizar.TabIndex = 7;
            this.Btn_finalizar.Text = "Insertar";
            this.Btn_finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_finalizar.UseVisualStyleBackColor = false;
            this.Btn_finalizar.Click += new System.EventHandler(this.Btn_finalizar_Click);
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_salir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_salir.Image = global::Capa_Vista_Seguridad.Properties.Resources.sign_emergency_code_sos_61_icon_icons_com_57216;
            this.Btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_salir.Location = new System.Drawing.Point(720, 540);
            this.Btn_salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(143, 65);
            this.Btn_salir.TabIndex = 8;
            this.Btn_salir.Text = "  Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(951, 55);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(909, 0);
            this.Pic_Cerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(42, 55);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Buscar.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Buscar.Location = new System.Drawing.Point(720, 325);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(143, 65);
            this.Btn_Buscar.TabIndex = 96;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Buscar.UseVisualStyleBackColor = false;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Frm_asignacion_aplicacion_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(951, 665);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.Btn_quitar);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_finalizar);
            this.Controls.Add(this.Dgv_Permisos);
            this.Controls.Add(this.Gbp_datos);
            this.Controls.Add(this.Lbl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_asignacion_aplicacion_usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion de Aplicación a Usuario";
            this.Gbp_datos.ResumeLayout(false);
            this.Gbp_datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Permisos)).EndInit();
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
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
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
        private System.Windows.Forms.Button Btn_Buscar;
    }
}