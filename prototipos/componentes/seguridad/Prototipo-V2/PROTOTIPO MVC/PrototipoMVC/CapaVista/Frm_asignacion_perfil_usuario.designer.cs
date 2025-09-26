
namespace Capa_Vista_Seguridad
{
    partial class Frm_asignacion_perfil_usuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.Gbp_consulta = new System.Windows.Forms.GroupBox();
            this.Cbo_usuario = new System.Windows.Forms.ComboBox();
            this.Lbl_usuario = new System.Windows.Forms.Label();
            this.Dgv_consulta = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dgv_asignaciones = new System.Windows.Forms.DataGridView();
            this.Cbo_perfil = new System.Windows.Forms.ComboBox();
            this.Lbl_perfiles = new System.Windows.Forms.Label();
            this.Lbl_usuario2 = new System.Windows.Forms.Label();
            this.Cbo_usuarios2 = new System.Windows.Forms.ComboBox();
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_agregar = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.Btn_eliminar_asignacion = new System.Windows.Forms.Button();
            this.Btn_eliminar_consulta = new System.Windows.Forms.Button();
            this.Gbp_consulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_consulta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_asignaciones)).BeginInit();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignacion de Perfiles ";
            // 
            // Gbp_consulta
            // 
            this.Gbp_consulta.Controls.Add(this.Cbo_usuario);
            this.Gbp_consulta.Controls.Add(this.Lbl_usuario);
            this.Gbp_consulta.Controls.Add(this.Btn_eliminar_consulta);
            this.Gbp_consulta.Controls.Add(this.Dgv_consulta);
            this.Gbp_consulta.Location = new System.Drawing.Point(21, 145);
            this.Gbp_consulta.Margin = new System.Windows.Forms.Padding(4);
            this.Gbp_consulta.Name = "Gbp_consulta";
            this.Gbp_consulta.Padding = new System.Windows.Forms.Padding(4);
            this.Gbp_consulta.Size = new System.Drawing.Size(560, 443);
            this.Gbp_consulta.TabIndex = 1;
            this.Gbp_consulta.TabStop = false;
            this.Gbp_consulta.Text = "Consulta de Pefiles a Usuarios";
            // 
            // Cbo_usuario
            // 
            this.Cbo_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_usuario.FormattingEnabled = true;
            this.Cbo_usuario.Location = new System.Drawing.Point(110, 44);
            this.Cbo_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_usuario.Name = "Cbo_usuario";
            this.Cbo_usuario.Size = new System.Drawing.Size(334, 28);
            this.Cbo_usuario.TabIndex = 3;
            this.Cbo_usuario.SelectedIndexChanged += new System.EventHandler(this.Cbo_usuario_SelectedIndexChanged);
            // 
            // Lbl_usuario
            // 
            this.Lbl_usuario.AutoSize = true;
            this.Lbl_usuario.Location = new System.Drawing.Point(8, 52);
            this.Lbl_usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_usuario.Name = "Lbl_usuario";
            this.Lbl_usuario.Size = new System.Drawing.Size(78, 20);
            this.Lbl_usuario.TabIndex = 2;
            this.Lbl_usuario.Text = "Usuarios";
            // 
            // Dgv_consulta
            // 
            this.Dgv_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_consulta.Location = new System.Drawing.Point(0, 133);
            this.Dgv_consulta.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_consulta.Name = "Dgv_consulta";
            this.Dgv_consulta.RowHeadersWidth = 51;
            this.Dgv_consulta.RowTemplate.Height = 24;
            this.Dgv_consulta.Size = new System.Drawing.Size(418, 276);
            this.Dgv_consulta.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_agregar);
            this.groupBox1.Controls.Add(this.btn_finalizar);
            this.groupBox1.Controls.Add(this.Btn_eliminar_asignacion);
            this.groupBox1.Controls.Add(this.Dgv_asignaciones);
            this.groupBox1.Controls.Add(this.Cbo_perfil);
            this.groupBox1.Controls.Add(this.Lbl_perfiles);
            this.groupBox1.Controls.Add(this.Lbl_usuario2);
            this.groupBox1.Controls.Add(this.Cbo_usuarios2);
            this.groupBox1.Location = new System.Drawing.Point(640, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 465);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asingacion de Perfiles a Usuarios";
            // 
            // Dgv_asignaciones
            // 
            this.Dgv_asignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_asignaciones.Location = new System.Drawing.Point(7, 171);
            this.Dgv_asignaciones.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_asignaciones.Name = "Dgv_asignaciones";
            this.Dgv_asignaciones.RowHeadersWidth = 51;
            this.Dgv_asignaciones.RowTemplate.Height = 24;
            this.Dgv_asignaciones.Size = new System.Drawing.Size(291, 238);
            this.Dgv_asignaciones.TabIndex = 4;
            // 
            // Cbo_perfil
            // 
            this.Cbo_perfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_perfil.FormattingEnabled = true;
            this.Cbo_perfil.Location = new System.Drawing.Point(216, 65);
            this.Cbo_perfil.Name = "Cbo_perfil";
            this.Cbo_perfil.Size = new System.Drawing.Size(196, 28);
            this.Cbo_perfil.TabIndex = 6;
            // 
            // Lbl_perfiles
            // 
            this.Lbl_perfiles.AutoSize = true;
            this.Lbl_perfiles.Location = new System.Drawing.Point(279, 42);
            this.Lbl_perfiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_perfiles.Name = "Lbl_perfiles";
            this.Lbl_perfiles.Size = new System.Drawing.Size(69, 20);
            this.Lbl_perfiles.TabIndex = 5;
            this.Lbl_perfiles.Text = "Perfiles";
            // 
            // Lbl_usuario2
            // 
            this.Lbl_usuario2.AutoSize = true;
            this.Lbl_usuario2.Location = new System.Drawing.Point(30, 42);
            this.Lbl_usuario2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_usuario2.Name = "Lbl_usuario2";
            this.Lbl_usuario2.Size = new System.Drawing.Size(78, 20);
            this.Lbl_usuario2.TabIndex = 4;
            this.Lbl_usuario2.Text = "Usuarios";
            // 
            // Cbo_usuarios2
            // 
            this.Cbo_usuarios2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_usuarios2.FormattingEnabled = true;
            this.Cbo_usuarios2.Location = new System.Drawing.Point(6, 65);
            this.Cbo_usuarios2.Name = "Cbo_usuarios2";
            this.Cbo_usuarios2.Size = new System.Drawing.Size(196, 28);
            this.Cbo_usuarios2.TabIndex = 0;
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(1137, 44);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(1100, 0);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(37, 44);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // Btn_agregar
            // 
            this.Btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_agregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_agregar.Image = global::Capa_Vista_Seguridad.Properties.Resources.add_insert_new_plus_button_icon_142943;
            this.Btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_agregar.Location = new System.Drawing.Point(162, 100);
            this.Btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_agregar.Name = "Btn_agregar";
            this.Btn_agregar.Size = new System.Drawing.Size(118, 46);
            this.Btn_agregar.TabIndex = 8;
            this.Btn_agregar.Text = "Agregar";
            this.Btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_agregar.UseVisualStyleBackColor = false;
            this.Btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.btn_finalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.btn_finalizar.Image = global::Capa_Vista_Seguridad.Properties.Resources.asignar;
            this.btn_finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_finalizar.Location = new System.Drawing.Point(319, 351);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(118, 58);
            this.btn_finalizar.TabIndex = 7;
            this.btn_finalizar.Text = "asignar";
            this.btn_finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // Btn_eliminar_asignacion
            // 
            this.Btn_eliminar_asignacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_eliminar_asignacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_eliminar_asignacion.Image = global::Capa_Vista_Seguridad.Properties.Resources.cancelar_32px;
            this.Btn_eliminar_asignacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_eliminar_asignacion.Location = new System.Drawing.Point(319, 181);
            this.Btn_eliminar_asignacion.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_eliminar_asignacion.Name = "Btn_eliminar_asignacion";
            this.Btn_eliminar_asignacion.Size = new System.Drawing.Size(116, 58);
            this.Btn_eliminar_asignacion.TabIndex = 6;
            this.Btn_eliminar_asignacion.Text = "cancelar";
            this.Btn_eliminar_asignacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_eliminar_asignacion.UseVisualStyleBackColor = false;
            this.Btn_eliminar_asignacion.Click += new System.EventHandler(this.Btn_eliminar_asignacion_Click_1);
            // 
            // Btn_eliminar_consulta
            // 
            this.Btn_eliminar_consulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_eliminar_consulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_eliminar_consulta.Image = global::Capa_Vista_Seguridad.Properties.Resources.cancelar_32px;
            this.Btn_eliminar_consulta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_eliminar_consulta.Location = new System.Drawing.Point(436, 171);
            this.Btn_eliminar_consulta.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_eliminar_consulta.Name = "Btn_eliminar_consulta";
            this.Btn_eliminar_consulta.Size = new System.Drawing.Size(116, 58);
            this.Btn_eliminar_consulta.TabIndex = 3;
            this.Btn_eliminar_consulta.Text = "cancelar";
            this.Btn_eliminar_consulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_eliminar_consulta.UseVisualStyleBackColor = false;
            this.Btn_eliminar_consulta.Click += new System.EventHandler(this.Btn_eliminar_consulta_Click);
            // 
            // frmasignacion_perfil_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1137, 648);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Gbp_consulta);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmasignacion_perfil_usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignaciones Perfil a Usuario";
            this.Load += new System.EventHandler(this.frmasignacion_perfil_usuario_Load);
            this.Gbp_consulta.ResumeLayout(false);
            this.Gbp_consulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_consulta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_asignaciones)).EndInit();
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Gbp_consulta;
        private System.Windows.Forms.ComboBox Cbo_usuario;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.DataGridView Dgv_consulta;
        private System.Windows.Forms.Button Btn_eliminar_consulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button Btn_eliminar_asignacion;
        private System.Windows.Forms.DataGridView Dgv_asignaciones;
        private System.Windows.Forms.ComboBox Cbo_perfil;
        private System.Windows.Forms.Label Lbl_perfiles;
        private System.Windows.Forms.Label Lbl_usuario2;
        private System.Windows.Forms.ComboBox Cbo_usuarios2;
        private System.Windows.Forms.Button Btn_agregar;
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
    }
}