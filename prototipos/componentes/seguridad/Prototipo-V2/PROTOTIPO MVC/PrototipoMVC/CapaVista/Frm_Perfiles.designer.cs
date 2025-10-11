
namespace Capa_Vista_Seguridad
{
    partial class Frm_Perfiles
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
            this.Gpb_buscarperfiles = new System.Windows.Forms.GroupBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Cbo_perfiles = new System.Windows.Forms.ComboBox();
            this.Gpb_datosperfil = new System.Windows.Forms.GroupBox();
            this.Cbo_tipoperfil = new System.Windows.Forms.ComboBox();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_descripcion = new System.Windows.Forms.Label();
            this.Gbp_estado = new System.Windows.Forms.GroupBox();
            this.Rdb_inhabilitado = new System.Windows.Forms.RadioButton();
            this.Rdb_Habilitado = new System.Windows.Forms.RadioButton();
            this.Lbl_tipoperfil = new System.Windows.Forms.Label();
            this.Txt_puesto = new System.Windows.Forms.TextBox();
            this.Lbl_puesto = new System.Windows.Forms.Label();
            this.Txt_idperfil = new System.Windows.Forms.TextBox();
            this.Lbl_idpuesto = new System.Windows.Forms.Label();
            this.Gbp_opc = new System.Windows.Forms.GroupBox();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Gpb_buscarperfiles.SuspendLayout();
            this.Gpb_datosperfil.SuspendLayout();
            this.Gbp_estado.SuspendLayout();
            this.Gbp_opc.SuspendLayout();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // Gpb_buscarperfiles
            // 
            this.Gpb_buscarperfiles.Controls.Add(this.Btn_buscar);
            this.Gpb_buscarperfiles.Controls.Add(this.Cbo_perfiles);
            this.Gpb_buscarperfiles.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_buscarperfiles.Location = new System.Drawing.Point(25, 102);
            this.Gpb_buscarperfiles.Name = "Gpb_buscarperfiles";
            this.Gpb_buscarperfiles.Size = new System.Drawing.Size(919, 125);
            this.Gpb_buscarperfiles.TabIndex = 0;
            this.Gpb_buscarperfiles.TabStop = false;
            this.Gpb_buscarperfiles.Text = "Buscar Perfiles ";
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_buscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_buscar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_buscar.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons1;
            this.Btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_buscar.Location = new System.Drawing.Point(561, 41);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(143, 54);
            this.Btn_buscar.TabIndex = 1;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_buscar.UseVisualStyleBackColor = false;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Cbo_perfiles
            // 
            this.Cbo_perfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_perfiles.FormattingEnabled = true;
            this.Cbo_perfiles.Location = new System.Drawing.Point(32, 55);
            this.Cbo_perfiles.Name = "Cbo_perfiles";
            this.Cbo_perfiles.Size = new System.Drawing.Size(474, 28);
            this.Cbo_perfiles.TabIndex = 0;
            // 
            // Gpb_datosperfil
            // 
            this.Gpb_datosperfil.Controls.Add(this.Cbo_tipoperfil);
            this.Gpb_datosperfil.Controls.Add(this.Txt_descripcion);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_descripcion);
            this.Gpb_datosperfil.Controls.Add(this.Gbp_estado);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_tipoperfil);
            this.Gpb_datosperfil.Controls.Add(this.Txt_puesto);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_puesto);
            this.Gpb_datosperfil.Controls.Add(this.Txt_idperfil);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_idpuesto);
            this.Gpb_datosperfil.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_datosperfil.Location = new System.Drawing.Point(25, 246);
            this.Gpb_datosperfil.Name = "Gpb_datosperfil";
            this.Gpb_datosperfil.Size = new System.Drawing.Size(733, 488);
            this.Gpb_datosperfil.TabIndex = 2;
            this.Gpb_datosperfil.TabStop = false;
            this.Gpb_datosperfil.Text = "Datos";
            // 
            // Cbo_tipoperfil
            // 
            this.Cbo_tipoperfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_tipoperfil.FormattingEnabled = true;
            this.Cbo_tipoperfil.Location = new System.Drawing.Point(125, 213);
            this.Cbo_tipoperfil.Name = "Cbo_tipoperfil";
            this.Cbo_tipoperfil.Size = new System.Drawing.Size(525, 28);
            this.Cbo_tipoperfil.TabIndex = 2;
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_descripcion.Location = new System.Drawing.Point(125, 157);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(525, 27);
            this.Txt_descripcion.TabIndex = 8;
            // 
            // Lbl_descripcion
            // 
            this.Lbl_descripcion.AutoSize = true;
            this.Lbl_descripcion.Location = new System.Drawing.Point(6, 164);
            this.Lbl_descripcion.Name = "Lbl_descripcion";
            this.Lbl_descripcion.Size = new System.Drawing.Size(104, 20);
            this.Lbl_descripcion.TabIndex = 7;
            this.Lbl_descripcion.Text = "Descripcion";
            // 
            // Gbp_estado
            // 
            this.Gbp_estado.Controls.Add(this.Rdb_inhabilitado);
            this.Gbp_estado.Controls.Add(this.Rdb_Habilitado);
            this.Gbp_estado.Location = new System.Drawing.Point(26, 288);
            this.Gbp_estado.Name = "Gbp_estado";
            this.Gbp_estado.Size = new System.Drawing.Size(595, 120);
            this.Gbp_estado.TabIndex = 6;
            this.Gbp_estado.TabStop = false;
            this.Gbp_estado.Text = "Estado";
            // 
            // Rdb_inhabilitado
            // 
            this.Rdb_inhabilitado.AutoSize = true;
            this.Rdb_inhabilitado.Location = new System.Drawing.Point(363, 54);
            this.Rdb_inhabilitado.Name = "Rdb_inhabilitado";
            this.Rdb_inhabilitado.Size = new System.Drawing.Size(123, 24);
            this.Rdb_inhabilitado.TabIndex = 2;
            this.Rdb_inhabilitado.TabStop = true;
            this.Rdb_inhabilitado.Text = "Inhabilitado";
            this.Rdb_inhabilitado.UseVisualStyleBackColor = true;
            // 
            // Rdb_Habilitado
            // 
            this.Rdb_Habilitado.AutoSize = true;
            this.Rdb_Habilitado.Location = new System.Drawing.Point(115, 54);
            this.Rdb_Habilitado.Name = "Rdb_Habilitado";
            this.Rdb_Habilitado.Size = new System.Drawing.Size(110, 24);
            this.Rdb_Habilitado.TabIndex = 1;
            this.Rdb_Habilitado.TabStop = true;
            this.Rdb_Habilitado.Text = "Habilitado";
            this.Rdb_Habilitado.UseVisualStyleBackColor = true;
            // 
            // Lbl_tipoperfil
            // 
            this.Lbl_tipoperfil.AutoSize = true;
            this.Lbl_tipoperfil.Location = new System.Drawing.Point(28, 221);
            this.Lbl_tipoperfil.Name = "Lbl_tipoperfil";
            this.Lbl_tipoperfil.Size = new System.Drawing.Size(44, 20);
            this.Lbl_tipoperfil.TabIndex = 5;
            this.Lbl_tipoperfil.Text = "Tipo";
            // 
            // Txt_puesto
            // 
            this.Txt_puesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_puesto.Location = new System.Drawing.Point(125, 95);
            this.Txt_puesto.Name = "Txt_puesto";
            this.Txt_puesto.Size = new System.Drawing.Size(525, 27);
            this.Txt_puesto.TabIndex = 3;
            // 
            // Lbl_puesto
            // 
            this.Lbl_puesto.AutoSize = true;
            this.Lbl_puesto.Location = new System.Drawing.Point(22, 98);
            this.Lbl_puesto.Name = "Lbl_puesto";
            this.Lbl_puesto.Size = new System.Drawing.Size(62, 20);
            this.Lbl_puesto.TabIndex = 2;
            this.Lbl_puesto.Text = "Puesto";
            // 
            // Txt_idperfil
            // 
            this.Txt_idperfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_idperfil.Location = new System.Drawing.Point(125, 49);
            this.Txt_idperfil.Name = "Txt_idperfil";
            this.Txt_idperfil.Size = new System.Drawing.Size(525, 27);
            this.Txt_idperfil.TabIndex = 1;
            // 
            // Lbl_idpuesto
            // 
            this.Lbl_idpuesto.AutoSize = true;
            this.Lbl_idpuesto.Location = new System.Drawing.Point(6, 52);
            this.Lbl_idpuesto.Name = "Lbl_idpuesto";
            this.Lbl_idpuesto.Size = new System.Drawing.Size(113, 20);
            this.Lbl_idpuesto.TabIndex = 0;
            this.Lbl_idpuesto.Text = "Codigo Perfil";
            // 
            // Gbp_opc
            // 
            this.Gbp_opc.Controls.Add(this.Btn_Eliminar);
            this.Gbp_opc.Controls.Add(this.Btn_salir);
            this.Gbp_opc.Controls.Add(this.Btn_nuevo);
            this.Gbp_opc.Controls.Add(this.Btn_cancelar);
            this.Gbp_opc.Controls.Add(this.Btn_modificar);
            this.Gbp_opc.Controls.Add(this.Btn_guardar);
            this.Gbp_opc.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbp_opc.Location = new System.Drawing.Point(764, 262);
            this.Gbp_opc.Name = "Gbp_opc";
            this.Gbp_opc.Size = new System.Drawing.Size(227, 472);
            this.Gbp_opc.TabIndex = 3;
            this.Gbp_opc.TabStop = false;
            this.Gbp_opc.Text = "Opciones";
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Eliminar.Image = global::Capa_Vista_Seguridad.Properties.Resources.delete_remove_trash_icon_177304;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Eliminar.Location = new System.Drawing.Point(30, 241);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(143, 54);
            this.Btn_Eliminar.TabIndex = 5;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_salir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_salir.Image = global::Capa_Vista_Seguridad.Properties.Resources.sign_emergency_code_sos_61_icon_icons_com_57216;
            this.Btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_salir.Location = new System.Drawing.Point(30, 381);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(143, 54);
            this.Btn_salir.TabIndex = 4;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_nuevo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_nuevo.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_nuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_nuevo.Image = global::Capa_Vista_Seguridad.Properties.Resources.asignar;
            this.Btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_nuevo.Location = new System.Drawing.Point(30, 171);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(143, 54);
            this.Btn_nuevo.TabIndex = 1;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_cancelar.Image = global::Capa_Vista_Seguridad.Properties.Resources.cancelar_32px;
            this.Btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_cancelar.Location = new System.Drawing.Point(30, 311);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(143, 54);
            this.Btn_cancelar.TabIndex = 3;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_modificar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_modificar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_modificar.Image = global::Capa_Vista_Seguridad.Properties.Resources.compose_edit_modify_icon_177770;
            this.Btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_modificar.Location = new System.Drawing.Point(30, 26);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(143, 54);
            this.Btn_modificar.TabIndex = 2;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_guardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_guardar.Image = global::Capa_Vista_Seguridad.Properties.Resources.savetheapplication_guardar_2958;
            this.Btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_guardar.Location = new System.Drawing.Point(30, 97);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(143, 54);
            this.Btn_guardar.TabIndex = 0;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(1028, 44);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_Superior_Paint);
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(991, 0);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(37, 44);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_reporte.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_reporte.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_reporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_reporte.Image = global::Capa_Vista_Seguridad.Properties.Resources.exportar;
            this.Btn_reporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_reporte.Location = new System.Drawing.Point(794, 50);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(143, 54);
            this.Btn_reporte.TabIndex = 2;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // Frm_Perfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1028, 761);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.Gbp_opc);
            this.Controls.Add(this.Gpb_datosperfil);
            this.Controls.Add(this.Gpb_buscarperfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "Frm_Perfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfiles";
            this.Gpb_buscarperfiles.ResumeLayout(false);
            this.Gpb_datosperfil.ResumeLayout(false);
            this.Gpb_datosperfil.PerformLayout();
            this.Gbp_estado.ResumeLayout(false);
            this.Gbp_estado.PerformLayout();
            this.Gbp_opc.ResumeLayout(false);
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_buscarperfiles;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.ComboBox Cbo_perfiles;
        private System.Windows.Forms.GroupBox Gpb_datosperfil;
        private System.Windows.Forms.Label Lbl_idpuesto;
        private System.Windows.Forms.TextBox Txt_idperfil;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label Lbl_descripcion;
        private System.Windows.Forms.GroupBox Gbp_estado;
        private System.Windows.Forms.RadioButton Rdb_inhabilitado;
        private System.Windows.Forms.RadioButton Rdb_Habilitado;
        private System.Windows.Forms.Label Lbl_tipoperfil;
        private System.Windows.Forms.TextBox Txt_puesto;
        private System.Windows.Forms.Label Lbl_puesto;
        private System.Windows.Forms.GroupBox Gbp_opc;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.ComboBox Cbo_tipoperfil;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
        private System.Windows.Forms.Button Btn_reporte;
    }
}