
namespace Capa_Vista_Seguridad
{
    partial class FrmAplicacion
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
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Cbo_buscar = new System.Windows.Forms.ComboBox();
            this.Txt_id_aplicacion = new System.Windows.Forms.TextBox();
            this.Gpb_buscar_aplicacion = new System.Windows.Forms.GroupBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Lbl_id_aplicacion = new System.Windows.Forms.Label();
            this.Lbl_id_modulo = new System.Windows.Forms.Label();
            this.Lbl_nombre_aplicacion = new System.Windows.Forms.Label();
            this.Lbl_descripcion = new System.Windows.Forms.Label();
            this.Txt_Nombre_aplicacion = new System.Windows.Forms.TextBox();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Gbp_datos_aplicacion = new System.Windows.Forms.GroupBox();
            this.Cbo_id_reporte = new System.Windows.Forms.ComboBox();
            this.lbl_id_reporte = new System.Windows.Forms.Label();
            this.Cbo_id_modulo = new System.Windows.Forms.ComboBox();
            this.Gbp_estado_aplicacion = new System.Windows.Forms.GroupBox();
            this.Rdb_inactivo = new System.Windows.Forms.RadioButton();
            this.Rdb_estado_activo = new System.Windows.Forms.RadioButton();
            this.Lbl_mantenimiento_aplicacion = new System.Windows.Forms.Label();
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Gpb_buscar_aplicacion.SuspendLayout();
            this.Gbp_datos_aplicacion.SuspendLayout();
            this.Gbp_estado_aplicacion.SuspendLayout();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_salir.Image = global::Capa_Vista_Seguridad.Properties.Resources.sign_emergency_code_sos_61_icon_icons_com_57216;
            this.Btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_salir.Location = new System.Drawing.Point(963, 504);
            this.Btn_salir.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(119, 47);
            this.Btn_salir.TabIndex = 4;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Cbo_buscar
            // 
            this.Cbo_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_buscar.FormattingEnabled = true;
            this.Cbo_buscar.Location = new System.Drawing.Point(193, 32);
            this.Cbo_buscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Cbo_buscar.Name = "Cbo_buscar";
            this.Cbo_buscar.Size = new System.Drawing.Size(407, 33);
            this.Cbo_buscar.TabIndex = 6;
            // 
            // Txt_id_aplicacion
            // 
            this.Txt_id_aplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_id_aplicacion.Location = new System.Drawing.Point(299, 39);
            this.Txt_id_aplicacion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Txt_id_aplicacion.Name = "Txt_id_aplicacion";
            this.Txt_id_aplicacion.Size = new System.Drawing.Size(535, 33);
            this.Txt_id_aplicacion.TabIndex = 7;
            // 
            // Gpb_buscar_aplicacion
            // 
            this.Gpb_buscar_aplicacion.Controls.Add(this.Cbo_buscar);
            this.Gpb_buscar_aplicacion.Controls.Add(this.Btn_buscar);
            this.Gpb_buscar_aplicacion.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_buscar_aplicacion.Location = new System.Drawing.Point(13, 86);
            this.Gpb_buscar_aplicacion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gpb_buscar_aplicacion.Name = "Gpb_buscar_aplicacion";
            this.Gpb_buscar_aplicacion.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gpb_buscar_aplicacion.Size = new System.Drawing.Size(667, 97);
            this.Gpb_buscar_aplicacion.TabIndex = 8;
            this.Gpb_buscar_aplicacion.TabStop = false;
            this.Gpb_buscar_aplicacion.Text = "Modificar";
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_buscar.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_buscar.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons1;
            this.Btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_buscar.Location = new System.Drawing.Point(20, 26);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(119, 47);
            this.Btn_buscar.TabIndex = 5;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_buscar.UseVisualStyleBackColor = false;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Lbl_id_aplicacion
            // 
            this.Lbl_id_aplicacion.AutoSize = true;
            this.Lbl_id_aplicacion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_id_aplicacion.Location = new System.Drawing.Point(49, 42);
            this.Lbl_id_aplicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_id_aplicacion.Name = "Lbl_id_aplicacion";
            this.Lbl_id_aplicacion.Size = new System.Drawing.Size(134, 22);
            this.Lbl_id_aplicacion.TabIndex = 9;
            this.Lbl_id_aplicacion.Text = "ID Aplicacion";
            // 
            // Lbl_id_modulo
            // 
            this.Lbl_id_modulo.AutoSize = true;
            this.Lbl_id_modulo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_id_modulo.Location = new System.Drawing.Point(49, 150);
            this.Lbl_id_modulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_id_modulo.Name = "Lbl_id_modulo";
            this.Lbl_id_modulo.Size = new System.Drawing.Size(106, 22);
            this.Lbl_id_modulo.TabIndex = 10;
            this.Lbl_id_modulo.Text = "ID Modulo";
            // 
            // Lbl_nombre_aplicacion
            // 
            this.Lbl_nombre_aplicacion.AutoSize = true;
            this.Lbl_nombre_aplicacion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_nombre_aplicacion.Location = new System.Drawing.Point(48, 214);
            this.Lbl_nombre_aplicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_nombre_aplicacion.Name = "Lbl_nombre_aplicacion";
            this.Lbl_nombre_aplicacion.Size = new System.Drawing.Size(187, 22);
            this.Lbl_nombre_aplicacion.TabIndex = 11;
            this.Lbl_nombre_aplicacion.Text = "Nombre Aplicacion";
            // 
            // Lbl_descripcion
            // 
            this.Lbl_descripcion.AutoSize = true;
            this.Lbl_descripcion.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_descripcion.Location = new System.Drawing.Point(48, 267);
            this.Lbl_descripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_descripcion.Name = "Lbl_descripcion";
            this.Lbl_descripcion.Size = new System.Drawing.Size(120, 22);
            this.Lbl_descripcion.TabIndex = 12;
            this.Lbl_descripcion.Text = "Descripcion";
            // 
            // Txt_Nombre_aplicacion
            // 
            this.Txt_Nombre_aplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_Nombre_aplicacion.Location = new System.Drawing.Point(299, 212);
            this.Txt_Nombre_aplicacion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Txt_Nombre_aplicacion.Name = "Txt_Nombre_aplicacion";
            this.Txt_Nombre_aplicacion.Size = new System.Drawing.Size(535, 33);
            this.Txt_Nombre_aplicacion.TabIndex = 14;
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_descripcion.Location = new System.Drawing.Point(299, 262);
            this.Txt_descripcion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(535, 33);
            this.Txt_descripcion.TabIndex = 15;
            // 
            // Gbp_datos_aplicacion
            // 
            this.Gbp_datos_aplicacion.Controls.Add(this.Cbo_id_reporte);
            this.Gbp_datos_aplicacion.Controls.Add(this.lbl_id_reporte);
            this.Gbp_datos_aplicacion.Controls.Add(this.Cbo_id_modulo);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_descripcion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_Nombre_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_descripcion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_nombre_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_id_modulo);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_id_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_id_aplicacion);
            this.Gbp_datos_aplicacion.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbp_datos_aplicacion.Location = new System.Drawing.Point(13, 216);
            this.Gbp_datos_aplicacion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gbp_datos_aplicacion.Name = "Gbp_datos_aplicacion";
            this.Gbp_datos_aplicacion.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gbp_datos_aplicacion.Size = new System.Drawing.Size(912, 319);
            this.Gbp_datos_aplicacion.TabIndex = 16;
            this.Gbp_datos_aplicacion.TabStop = false;
            this.Gbp_datos_aplicacion.Text = "Datos de aplicacion";
            // 
            // Cbo_id_reporte
            // 
            this.Cbo_id_reporte.FormattingEnabled = true;
            this.Cbo_id_reporte.Location = new System.Drawing.Point(299, 91);
            this.Cbo_id_reporte.Name = "Cbo_id_reporte";
            this.Cbo_id_reporte.Size = new System.Drawing.Size(534, 33);
            this.Cbo_id_reporte.TabIndex = 18;
            // 
            // lbl_id_reporte
            // 
            this.lbl_id_reporte.AutoSize = true;
            this.lbl_id_reporte.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_reporte.Location = new System.Drawing.Point(48, 101);
            this.lbl_id_reporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_id_reporte.Name = "lbl_id_reporte";
            this.lbl_id_reporte.Size = new System.Drawing.Size(108, 22);
            this.lbl_id_reporte.TabIndex = 17;
            this.lbl_id_reporte.Text = "ID Reporte";
            // 
            // Cbo_id_modulo
            // 
            this.Cbo_id_modulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_id_modulo.FormattingEnabled = true;
            this.Cbo_id_modulo.Location = new System.Drawing.Point(299, 149);
            this.Cbo_id_modulo.Name = "Cbo_id_modulo";
            this.Cbo_id_modulo.Size = new System.Drawing.Size(534, 33);
            this.Cbo_id_modulo.TabIndex = 16;
            // 
            // Gbp_estado_aplicacion
            // 
            this.Gbp_estado_aplicacion.Controls.Add(this.Rdb_inactivo);
            this.Gbp_estado_aplicacion.Controls.Add(this.Rdb_estado_activo);
            this.Gbp_estado_aplicacion.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Gbp_estado_aplicacion.Location = new System.Drawing.Point(265, 539);
            this.Gbp_estado_aplicacion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gbp_estado_aplicacion.Name = "Gbp_estado_aplicacion";
            this.Gbp_estado_aplicacion.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Gbp_estado_aplicacion.Size = new System.Drawing.Size(543, 77);
            this.Gbp_estado_aplicacion.TabIndex = 17;
            this.Gbp_estado_aplicacion.TabStop = false;
            this.Gbp_estado_aplicacion.Text = "Estado";
            // 
            // Rdb_inactivo
            // 
            this.Rdb_inactivo.AutoSize = true;
            this.Rdb_inactivo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_inactivo.Location = new System.Drawing.Point(361, 28);
            this.Rdb_inactivo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Rdb_inactivo.Name = "Rdb_inactivo";
            this.Rdb_inactivo.Size = new System.Drawing.Size(107, 26);
            this.Rdb_inactivo.TabIndex = 1;
            this.Rdb_inactivo.TabStop = true;
            this.Rdb_inactivo.Text = "Inactivo";
            this.Rdb_inactivo.UseVisualStyleBackColor = true;
            // 
            // Rdb_estado_activo
            // 
            this.Rdb_estado_activo.AutoSize = true;
            this.Rdb_estado_activo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_estado_activo.Location = new System.Drawing.Point(87, 28);
            this.Rdb_estado_activo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Rdb_estado_activo.Name = "Rdb_estado_activo";
            this.Rdb_estado_activo.Size = new System.Drawing.Size(93, 26);
            this.Rdb_estado_activo.TabIndex = 0;
            this.Rdb_estado_activo.TabStop = true;
            this.Rdb_estado_activo.Text = "Activo";
            this.Rdb_estado_activo.UseVisualStyleBackColor = true;
            // 
            // Lbl_mantenimiento_aplicacion
            // 
            this.Lbl_mantenimiento_aplicacion.AutoSize = true;
            this.Lbl_mantenimiento_aplicacion.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_mantenimiento_aplicacion.Location = new System.Drawing.Point(742, 118);
            this.Lbl_mantenimiento_aplicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_mantenimiento_aplicacion.Name = "Lbl_mantenimiento_aplicacion";
            this.Lbl_mantenimiento_aplicacion.Size = new System.Drawing.Size(512, 41);
            this.Lbl_mantenimiento_aplicacion.TabIndex = 18;
            this.Lbl_mantenimiento_aplicacion.Text = "Mantenimiento de Aplicación";
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(1277, 44);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(1240, 0);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(37, 44);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_guardar.Image = global::Capa_Vista_Seguridad.Properties.Resources.savetheapplication_guardar_2958;
            this.Btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_guardar.Location = new System.Drawing.Point(963, 292);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(119, 47);
            this.Btn_guardar.TabIndex = 0;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_modificar.Image = global::Capa_Vista_Seguridad.Properties.Resources.compose_edit_modify_icon_177770;
            this.Btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_modificar.Location = new System.Drawing.Point(963, 365);
            this.Btn_modificar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(119, 47);
            this.Btn_modificar.TabIndex = 2;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_nuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_nuevo.Image = global::Capa_Vista_Seguridad.Properties.Resources.add_insert_new_plus_button_icon_142943;
            this.Btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_nuevo.Location = new System.Drawing.Point(963, 233);
            this.Btn_nuevo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(119, 47);
            this.Btn_nuevo.TabIndex = 1;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_reporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_reporte.Image = global::Capa_Vista_Seguridad.Properties.Resources.exportar;
            this.Btn_reporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_reporte.Location = new System.Drawing.Point(963, 434);
            this.Btn_reporte.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(119, 47);
            this.Btn_reporte.TabIndex = 96;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // FrmAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1277, 617);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Lbl_mantenimiento_aplicacion);
            this.Controls.Add(this.Gbp_estado_aplicacion);
            this.Controls.Add(this.Gbp_datos_aplicacion);
            this.Controls.Add(this.Gpb_buscar_aplicacion);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_nuevo);
            this.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAplicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Aplicacion";
            this.Gpb_buscar_aplicacion.ResumeLayout(false);
            this.Gbp_datos_aplicacion.ResumeLayout(false);
            this.Gbp_datos_aplicacion.PerformLayout();
            this.Gbp_estado_aplicacion.ResumeLayout(false);
            this.Gbp_estado_aplicacion.PerformLayout();
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.ComboBox Cbo_buscar;
        private System.Windows.Forms.TextBox Txt_id_aplicacion;
        private System.Windows.Forms.GroupBox Gpb_buscar_aplicacion;
        private System.Windows.Forms.Label Lbl_id_aplicacion;
        private System.Windows.Forms.Label Lbl_id_modulo;
        private System.Windows.Forms.Label Lbl_nombre_aplicacion;
        private System.Windows.Forms.Label Lbl_descripcion;
        private System.Windows.Forms.TextBox Txt_Nombre_aplicacion;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.GroupBox Gbp_datos_aplicacion;
        private System.Windows.Forms.GroupBox Gbp_estado_aplicacion;
        private System.Windows.Forms.RadioButton Rdb_inactivo;
        private System.Windows.Forms.RadioButton Rdb_estado_activo;
        private System.Windows.Forms.Label Lbl_mantenimiento_aplicacion;
        private System.Windows.Forms.ComboBox Cbo_id_modulo;
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Label lbl_id_reporte;
        private System.Windows.Forms.ComboBox Cbo_id_reporte;
    }
}