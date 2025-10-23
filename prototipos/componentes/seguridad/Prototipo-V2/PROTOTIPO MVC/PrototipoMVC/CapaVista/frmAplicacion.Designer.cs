
namespace CapaVista
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
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Cbo_buscar = new System.Windows.Forms.ComboBox();
            this.Txt_id_aplicacion = new System.Windows.Forms.TextBox();
            this.Gpb_buscar_aplicacion = new System.Windows.Forms.GroupBox();
            this.Lbl_id_aplicacion = new System.Windows.Forms.Label();
            this.Lbl_id_modulo = new System.Windows.Forms.Label();
            this.Lbl_nombre_aplicacion = new System.Windows.Forms.Label();
            this.Lbl_descripcion = new System.Windows.Forms.Label();
            this.Txt_Nombre_aplicacion = new System.Windows.Forms.TextBox();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Gbp_datos_aplicacion = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Gbp_estado_aplicacion = new System.Windows.Forms.GroupBox();
            this.Rdb_inactivo = new System.Windows.Forms.RadioButton();
            this.Rdb_estado_activo = new System.Windows.Forms.RadioButton();
            this.Lbl_mantenimiento_aplicacion = new System.Windows.Forms.Label();
            this.Gpb_buscar_aplicacion.SuspendLayout();
            this.Gbp_datos_aplicacion.SuspendLayout();
            this.Gbp_estado_aplicacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Location = new System.Drawing.Point(657, 117);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(67, 25);
            this.Btn_guardar.TabIndex = 0;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = true;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.Location = new System.Drawing.Point(657, 163);
            this.Btn_nuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(67, 25);
            this.Btn_nuevo.TabIndex = 1;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.UseVisualStyleBackColor = true;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Location = new System.Drawing.Point(657, 209);
            this.Btn_modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(67, 25);
            this.Btn_modificar.TabIndex = 2;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.UseVisualStyleBackColor = true;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Location = new System.Drawing.Point(657, 255);
            this.Btn_eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(67, 25);
            this.Btn_eliminar.TabIndex = 3;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_salir
            // 
            this.Btn_salir.Location = new System.Drawing.Point(772, 367);
            this.Btn_salir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(67, 25);
            this.Btn_salir.TabIndex = 4;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.UseVisualStyleBackColor = true;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Location = new System.Drawing.Point(20, 22);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(67, 24);
            this.Btn_buscar.TabIndex = 5;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Cbo_buscar
            // 
            this.Cbo_buscar.FormattingEnabled = true;
            this.Cbo_buscar.Location = new System.Drawing.Point(129, 23);
            this.Cbo_buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbo_buscar.Name = "Cbo_buscar";
            this.Cbo_buscar.Size = new System.Drawing.Size(272, 24);
            this.Cbo_buscar.TabIndex = 6;
            this.Cbo_buscar.SelectedIndexChanged += new System.EventHandler(this.Cbo_buscar_SelectedIndexChanged);
            // 
            // Txt_id_aplicacion
            // 
            this.Txt_id_aplicacion.Location = new System.Drawing.Point(199, 28);
            this.Txt_id_aplicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_id_aplicacion.Name = "Txt_id_aplicacion";
            this.Txt_id_aplicacion.Size = new System.Drawing.Size(358, 22);
            this.Txt_id_aplicacion.TabIndex = 7;
            this.Txt_id_aplicacion.TextChanged += new System.EventHandler(this.Txt_id_aplicacion_TextChanged);
            // 
            // Gpb_buscar_aplicacion
            // 
            this.Gpb_buscar_aplicacion.Controls.Add(this.Cbo_buscar);
            this.Gpb_buscar_aplicacion.Controls.Add(this.Btn_buscar);
            this.Gpb_buscar_aplicacion.Location = new System.Drawing.Point(11, 22);
            this.Gpb_buscar_aplicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gpb_buscar_aplicacion.Name = "Gpb_buscar_aplicacion";
            this.Gpb_buscar_aplicacion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gpb_buscar_aplicacion.Size = new System.Drawing.Size(444, 70);
            this.Gpb_buscar_aplicacion.TabIndex = 8;
            this.Gpb_buscar_aplicacion.TabStop = false;
            this.Gpb_buscar_aplicacion.Text = "Modificar";
            // 
            // Lbl_id_aplicacion
            // 
            this.Lbl_id_aplicacion.AutoSize = true;
            this.Lbl_id_aplicacion.Location = new System.Drawing.Point(33, 30);
            this.Lbl_id_aplicacion.Name = "Lbl_id_aplicacion";
            this.Lbl_id_aplicacion.Size = new System.Drawing.Size(89, 17);
            this.Lbl_id_aplicacion.TabIndex = 9;
            this.Lbl_id_aplicacion.Text = "ID Aplicacion";
            // 
            // Lbl_id_modulo
            // 
            this.Lbl_id_modulo.AutoSize = true;
            this.Lbl_id_modulo.Location = new System.Drawing.Point(33, 74);
            this.Lbl_id_modulo.Name = "Lbl_id_modulo";
            this.Lbl_id_modulo.Size = new System.Drawing.Size(71, 17);
            this.Lbl_id_modulo.TabIndex = 10;
            this.Lbl_id_modulo.Text = "ID Modulo";
            // 
            // Lbl_nombre_aplicacion
            // 
            this.Lbl_nombre_aplicacion.AutoSize = true;
            this.Lbl_nombre_aplicacion.Location = new System.Drawing.Point(32, 120);
            this.Lbl_nombre_aplicacion.Name = "Lbl_nombre_aplicacion";
            this.Lbl_nombre_aplicacion.Size = new System.Drawing.Size(126, 17);
            this.Lbl_nombre_aplicacion.TabIndex = 11;
            this.Lbl_nombre_aplicacion.Text = "Nombre Aplicacion";
            // 
            // Lbl_descripcion
            // 
            this.Lbl_descripcion.AutoSize = true;
            this.Lbl_descripcion.Location = new System.Drawing.Point(32, 158);
            this.Lbl_descripcion.Name = "Lbl_descripcion";
            this.Lbl_descripcion.Size = new System.Drawing.Size(82, 17);
            this.Lbl_descripcion.TabIndex = 12;
            this.Lbl_descripcion.Text = "Descripcion";
            // 
            // Txt_Nombre_aplicacion
            // 
            this.Txt_Nombre_aplicacion.Location = new System.Drawing.Point(199, 118);
            this.Txt_Nombre_aplicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Nombre_aplicacion.Name = "Txt_Nombre_aplicacion";
            this.Txt_Nombre_aplicacion.Size = new System.Drawing.Size(358, 22);
            this.Txt_Nombre_aplicacion.TabIndex = 14;
            this.Txt_Nombre_aplicacion.TextChanged += new System.EventHandler(this.Txt_Nombre_aplicacion_TextChanged);
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(199, 155);
            this.Txt_descripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(358, 22);
            this.Txt_descripcion.TabIndex = 15;
            this.Txt_descripcion.TextChanged += new System.EventHandler(this.Txt_descripcion_TextChanged);
            // 
            // Gbp_datos_aplicacion
            // 
            this.Gbp_datos_aplicacion.Controls.Add(this.comboBox1);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_descripcion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_Nombre_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_descripcion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_nombre_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_id_modulo);
            this.Gbp_datos_aplicacion.Controls.Add(this.Lbl_id_aplicacion);
            this.Gbp_datos_aplicacion.Controls.Add(this.Txt_id_aplicacion);
            this.Gbp_datos_aplicacion.Location = new System.Drawing.Point(11, 117);
            this.Gbp_datos_aplicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gbp_datos_aplicacion.Name = "Gbp_datos_aplicacion";
            this.Gbp_datos_aplicacion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gbp_datos_aplicacion.Size = new System.Drawing.Size(608, 189);
            this.Gbp_datos_aplicacion.TabIndex = 16;
            this.Gbp_datos_aplicacion.TabStop = false;
            this.Gbp_datos_aplicacion.Text = "Datos de aplicacion";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(199, 72);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(359, 24);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Gbp_estado_aplicacion
            // 
            this.Gbp_estado_aplicacion.Controls.Add(this.Rdb_inactivo);
            this.Gbp_estado_aplicacion.Controls.Add(this.Rdb_estado_activo);
            this.Gbp_estado_aplicacion.Location = new System.Drawing.Point(182, 323);
            this.Gbp_estado_aplicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gbp_estado_aplicacion.Name = "Gbp_estado_aplicacion";
            this.Gbp_estado_aplicacion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gbp_estado_aplicacion.Size = new System.Drawing.Size(362, 56);
            this.Gbp_estado_aplicacion.TabIndex = 17;
            this.Gbp_estado_aplicacion.TabStop = false;
            this.Gbp_estado_aplicacion.Text = "Estado";
            // 
            // Rdb_inactivo
            // 
            this.Rdb_inactivo.AutoSize = true;
            this.Rdb_inactivo.Location = new System.Drawing.Point(241, 20);
            this.Rdb_inactivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rdb_inactivo.Name = "Rdb_inactivo";
            this.Rdb_inactivo.Size = new System.Drawing.Size(77, 21);
            this.Rdb_inactivo.TabIndex = 1;
            this.Rdb_inactivo.TabStop = true;
            this.Rdb_inactivo.Text = "Inactivo";
            this.Rdb_inactivo.UseVisualStyleBackColor = true;
            this.Rdb_inactivo.CheckedChanged += new System.EventHandler(this.Rdb_inactivo_CheckedChanged);
            // 
            // Rdb_estado_activo
            // 
            this.Rdb_estado_activo.AutoSize = true;
            this.Rdb_estado_activo.Location = new System.Drawing.Point(58, 20);
            this.Rdb_estado_activo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rdb_estado_activo.Name = "Rdb_estado_activo";
            this.Rdb_estado_activo.Size = new System.Drawing.Size(67, 21);
            this.Rdb_estado_activo.TabIndex = 0;
            this.Rdb_estado_activo.TabStop = true;
            this.Rdb_estado_activo.Text = "Activo";
            this.Rdb_estado_activo.UseVisualStyleBackColor = true;
            this.Rdb_estado_activo.CheckedChanged += new System.EventHandler(this.Rdb_estado_activo_CheckedChanged);
            // 
            // Lbl_mantenimiento_aplicacion
            // 
            this.Lbl_mantenimiento_aplicacion.AutoSize = true;
            this.Lbl_mantenimiento_aplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_mantenimiento_aplicacion.Location = new System.Drawing.Point(463, 46);
            this.Lbl_mantenimiento_aplicacion.Name = "Lbl_mantenimiento_aplicacion";
            this.Lbl_mantenimiento_aplicacion.Size = new System.Drawing.Size(359, 31);
            this.Lbl_mantenimiento_aplicacion.TabIndex = 18;
            this.Lbl_mantenimiento_aplicacion.Text = "Mantenimiento de Aplicación";
            // 
            // FrmAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 402);
            this.Controls.Add(this.Lbl_mantenimiento_aplicacion);
            this.Controls.Add(this.Gbp_estado_aplicacion);
            this.Controls.Add(this.Gbp_datos_aplicacion);
            this.Controls.Add(this.Gpb_buscar_aplicacion);
            this.Controls.Add(this.Btn_salir);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Btn_guardar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAplicacion";
            this.Text = "Mantenimiento de Aplicacion";
            
            this.Gpb_buscar_aplicacion.ResumeLayout(false);
            this.Gbp_datos_aplicacion.ResumeLayout(false);
            this.Gbp_datos_aplicacion.PerformLayout();
            this.Gbp_estado_aplicacion.ResumeLayout(false);
            this.Gbp_estado_aplicacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_eliminar;
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}