
namespace CapaVista
{
    partial class frmSalarioEmpleados
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
            this.lbl_salario_empleados = new System.Windows.Forms.Label();
            this.Gpb_datos_salario_empleados = new System.Windows.Forms.GroupBox();
            this.Txt_fechafin_salario = new System.Windows.Forms.TextBox();
            this.lbl_fechafin_salario = new System.Windows.Forms.Label();
            this.Txt_fechainicio_salario = new System.Windows.Forms.TextBox();
            this.lbl_fechainicios_salario = new System.Windows.Forms.Label();
            this.Txt_monto = new System.Windows.Forms.TextBox();
            this.lbl_monto_salario = new System.Windows.Forms.Label();
            this.Txt_id_empl_salario = new System.Windows.Forms.TextBox();
            this.lbl_fk_id_empl_salario = new System.Windows.Forms.Label();
            this.Txt_id_salario = new System.Windows.Forms.TextBox();
            this.lbl_id_salario = new System.Windows.Forms.Label();
            this.Gpb_estado_salario = new System.Windows.Forms.GroupBox();
            this.Rdb_inactivo_salario = new System.Windows.Forms.RadioButton();
            this.Rdb_activo_salario = new System.Windows.Forms.RadioButton();
            this.Gpb_opciones_salario = new System.Windows.Forms.GroupBox();
            this.Btn_guardar_salario = new System.Windows.Forms.Button();
            this.Btn_eliminar_salario = new System.Windows.Forms.Button();
            this.Btn_modificar_salario = new System.Windows.Forms.Button();
            this.Btn_nuevo_salario = new System.Windows.Forms.Button();
            this.Btn_salir_salario = new System.Windows.Forms.Button();
            this.Gpb_mostrar_datos = new System.Windows.Forms.GroupBox();
            this.Btn_buscar_salario = new System.Windows.Forms.Button();
            this.Cbo_mostrar_datos = new System.Windows.Forms.ComboBox();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Gpb_datos_salario_empleados.SuspendLayout();
            this.Gpb_estado_salario.SuspendLayout();
            this.Gpb_opciones_salario.SuspendLayout();
            this.Gpb_mostrar_datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_salario_empleados
            // 
            this.lbl_salario_empleados.AutoSize = true;
            this.lbl_salario_empleados.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_salario_empleados.Location = new System.Drawing.Point(31, 25);
            this.lbl_salario_empleados.Name = "lbl_salario_empleados";
            this.lbl_salario_empleados.Size = new System.Drawing.Size(326, 35);
            this.lbl_salario_empleados.TabIndex = 1;
            this.lbl_salario_empleados.Text = "Salario de empleados.";
            // 
            // Gpb_datos_salario_empleados
            // 
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_fechafin_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_fechafin_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_fechainicio_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_fechainicios_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_monto);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_monto_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_id_empl_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_fk_id_empl_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_id_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_id_salario);
            this.Gpb_datos_salario_empleados.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_datos_salario_empleados.Location = new System.Drawing.Point(12, 104);
            this.Gpb_datos_salario_empleados.Name = "Gpb_datos_salario_empleados";
            this.Gpb_datos_salario_empleados.Size = new System.Drawing.Size(789, 164);
            this.Gpb_datos_salario_empleados.TabIndex = 4;
            this.Gpb_datos_salario_empleados.TabStop = false;
            this.Gpb_datos_salario_empleados.Text = "Datos";
            // 
            // Txt_fechafin_salario
            // 
            this.Txt_fechafin_salario.Location = new System.Drawing.Point(520, 127);
            this.Txt_fechafin_salario.Name = "Txt_fechafin_salario";
            this.Txt_fechafin_salario.Size = new System.Drawing.Size(205, 29);
            this.Txt_fechafin_salario.TabIndex = 14;
            this.Txt_fechafin_salario.TextChanged += new System.EventHandler(this.Txt_fechafin_salario_TextChanged);
            // 
            // lbl_fechafin_salario
            // 
            this.lbl_fechafin_salario.AutoSize = true;
            this.lbl_fechafin_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fechafin_salario.Location = new System.Drawing.Point(346, 130);
            this.lbl_fechafin_salario.Name = "lbl_fechafin_salario";
            this.lbl_fechafin_salario.Size = new System.Drawing.Size(159, 20);
            this.lbl_fechafin_salario.TabIndex = 13;
            this.lbl_fechafin_salario.Text = "Fecha Finalización:";
            // 
            // Txt_fechainicio_salario
            // 
            this.Txt_fechainicio_salario.Location = new System.Drawing.Point(127, 127);
            this.Txt_fechainicio_salario.Name = "Txt_fechainicio_salario";
            this.Txt_fechainicio_salario.Size = new System.Drawing.Size(165, 29);
            this.Txt_fechainicio_salario.TabIndex = 12;
            this.Txt_fechainicio_salario.TextChanged += new System.EventHandler(this.Txt_fechainicio_salario_TextChanged);
            // 
            // lbl_fechainicios_salario
            // 
            this.lbl_fechainicios_salario.AutoSize = true;
            this.lbl_fechainicios_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fechainicios_salario.Location = new System.Drawing.Point(6, 130);
            this.lbl_fechainicios_salario.Name = "lbl_fechainicios_salario";
            this.lbl_fechainicios_salario.Size = new System.Drawing.Size(109, 20);
            this.lbl_fechainicios_salario.TabIndex = 11;
            this.lbl_fechainicios_salario.Text = "Fecha Inicio:";
            // 
            // Txt_monto
            // 
            this.Txt_monto.Location = new System.Drawing.Point(433, 73);
            this.Txt_monto.Name = "Txt_monto";
            this.Txt_monto.Size = new System.Drawing.Size(205, 29);
            this.Txt_monto.TabIndex = 6;
            this.Txt_monto.TextChanged += new System.EventHandler(this.Txt_monto_TextChanged);
            // 
            // lbl_monto_salario
            // 
            this.lbl_monto_salario.AutoSize = true;
            this.lbl_monto_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_monto_salario.Location = new System.Drawing.Point(346, 76);
            this.lbl_monto_salario.Name = "lbl_monto_salario";
            this.lbl_monto_salario.Size = new System.Drawing.Size(64, 20);
            this.lbl_monto_salario.TabIndex = 5;
            this.lbl_monto_salario.Text = "Monto:";
            // 
            // Txt_id_empl_salario
            // 
            this.Txt_id_empl_salario.Location = new System.Drawing.Point(127, 73);
            this.Txt_id_empl_salario.Name = "Txt_id_empl_salario";
            this.Txt_id_empl_salario.Size = new System.Drawing.Size(205, 29);
            this.Txt_id_empl_salario.TabIndex = 4;
            this.Txt_id_empl_salario.TextChanged += new System.EventHandler(this.Txt_id_empl_salario_TextChanged);
            // 
            // lbl_fk_id_empl_salario
            // 
            this.lbl_fk_id_empl_salario.AutoSize = true;
            this.lbl_fk_id_empl_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fk_id_empl_salario.Location = new System.Drawing.Point(6, 76);
            this.lbl_fk_id_empl_salario.Name = "lbl_fk_id_empl_salario";
            this.lbl_fk_id_empl_salario.Size = new System.Drawing.Size(119, 20);
            this.lbl_fk_id_empl_salario.TabIndex = 3;
            this.lbl_fk_id_empl_salario.Text = "ID Empleado :";
            // 
            // Txt_id_salario
            // 
            this.Txt_id_salario.Location = new System.Drawing.Point(127, 28);
            this.Txt_id_salario.Name = "Txt_id_salario";
            this.Txt_id_salario.Size = new System.Drawing.Size(205, 29);
            this.Txt_id_salario.TabIndex = 2;
            this.Txt_id_salario.TextChanged += new System.EventHandler(this.Txt_id_salario_TextChanged);
            // 
            // lbl_id_salario
            // 
            this.lbl_id_salario.AutoSize = true;
            this.lbl_id_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id_salario.Location = new System.Drawing.Point(6, 37);
            this.lbl_id_salario.Name = "lbl_id_salario";
            this.lbl_id_salario.Size = new System.Drawing.Size(89, 20);
            this.lbl_id_salario.TabIndex = 1;
            this.lbl_id_salario.Text = "ID Salario:";
            // 
            // Gpb_estado_salario
            // 
            this.Gpb_estado_salario.Controls.Add(this.Rdb_inactivo_salario);
            this.Gpb_estado_salario.Controls.Add(this.Rdb_activo_salario);
            this.Gpb_estado_salario.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_estado_salario.Location = new System.Drawing.Point(212, 314);
            this.Gpb_estado_salario.Name = "Gpb_estado_salario";
            this.Gpb_estado_salario.Size = new System.Drawing.Size(387, 82);
            this.Gpb_estado_salario.TabIndex = 5;
            this.Gpb_estado_salario.TabStop = false;
            this.Gpb_estado_salario.Text = "Estado:";
            // 
            // Rdb_inactivo_salario
            // 
            this.Rdb_inactivo_salario.AutoSize = true;
            this.Rdb_inactivo_salario.Location = new System.Drawing.Point(183, 39);
            this.Rdb_inactivo_salario.Name = "Rdb_inactivo_salario";
            this.Rdb_inactivo_salario.Size = new System.Drawing.Size(101, 25);
            this.Rdb_inactivo_salario.TabIndex = 5;
            this.Rdb_inactivo_salario.TabStop = true;
            this.Rdb_inactivo_salario.Text = "Inactivo";
            this.Rdb_inactivo_salario.UseVisualStyleBackColor = true;
            this.Rdb_inactivo_salario.CheckedChanged += new System.EventHandler(this.Rdb_inactivo_salario_CheckedChanged);
            // 
            // Rdb_activo_salario
            // 
            this.Rdb_activo_salario.AutoSize = true;
            this.Rdb_activo_salario.Location = new System.Drawing.Point(10, 39);
            this.Rdb_activo_salario.Name = "Rdb_activo_salario";
            this.Rdb_activo_salario.Size = new System.Drawing.Size(87, 25);
            this.Rdb_activo_salario.TabIndex = 0;
            this.Rdb_activo_salario.TabStop = true;
            this.Rdb_activo_salario.Text = "Activo";
            this.Rdb_activo_salario.UseVisualStyleBackColor = true;
            this.Rdb_activo_salario.CheckedChanged += new System.EventHandler(this.Rdb_activo_salario_CheckedChanged);
            // 
            // Gpb_opciones_salario
            // 
            this.Gpb_opciones_salario.Controls.Add(this.Btn_cancelar);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_nuevo_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_salir_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_eliminar_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_modificar_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_guardar_salario);
            this.Gpb_opciones_salario.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_opciones_salario.Location = new System.Drawing.Point(807, 116);
            this.Gpb_opciones_salario.Name = "Gpb_opciones_salario";
            this.Gpb_opciones_salario.Size = new System.Drawing.Size(137, 313);
            this.Gpb_opciones_salario.TabIndex = 6;
            this.Gpb_opciones_salario.TabStop = false;
            this.Gpb_opciones_salario.Text = "Opciones";
            // 
            // Btn_guardar_salario
            // 
            this.Btn_guardar_salario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_guardar_salario.Location = new System.Drawing.Point(6, 86);
            this.Btn_guardar_salario.Name = "Btn_guardar_salario";
            this.Btn_guardar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_guardar_salario.TabIndex = 10;
            this.Btn_guardar_salario.Text = "Guardar";
            this.Btn_guardar_salario.UseVisualStyleBackColor = false;
            this.Btn_guardar_salario.Click += new System.EventHandler(this.Btn_guardar_salario_Click);
            // 
            // Btn_eliminar_salario
            // 
            this.Btn_eliminar_salario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_eliminar_salario.Location = new System.Drawing.Point(6, 182);
            this.Btn_eliminar_salario.Name = "Btn_eliminar_salario";
            this.Btn_eliminar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_eliminar_salario.TabIndex = 8;
            this.Btn_eliminar_salario.Text = "Eliminar";
            this.Btn_eliminar_salario.UseVisualStyleBackColor = false;
            this.Btn_eliminar_salario.Click += new System.EventHandler(this.Btn_eliminar_salario_Click);
            // 
            // Btn_modificar_salario
            // 
            this.Btn_modificar_salario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_modificar_salario.Location = new System.Drawing.Point(6, 135);
            this.Btn_modificar_salario.Name = "Btn_modificar_salario";
            this.Btn_modificar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_modificar_salario.TabIndex = 7;
            this.Btn_modificar_salario.Text = "Modificar";
            this.Btn_modificar_salario.UseVisualStyleBackColor = false;
            this.Btn_modificar_salario.Click += new System.EventHandler(this.Btn_modificar_salario_Click);
            // 
            // Btn_nuevo_salario
            // 
            this.Btn_nuevo_salario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_nuevo_salario.Location = new System.Drawing.Point(6, 38);
            this.Btn_nuevo_salario.Name = "Btn_nuevo_salario";
            this.Btn_nuevo_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_nuevo_salario.TabIndex = 6;
            this.Btn_nuevo_salario.Text = "Nuevo";
            this.Btn_nuevo_salario.UseVisualStyleBackColor = false;
            this.Btn_nuevo_salario.Click += new System.EventHandler(this.Btn_nuevo_salario_Click);
            // 
            // Btn_salir_salario
            // 
            this.Btn_salir_salario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_salir_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_salir_salario.Location = new System.Drawing.Point(6, 266);
            this.Btn_salir_salario.Name = "Btn_salir_salario";
            this.Btn_salir_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_salir_salario.TabIndex = 10;
            this.Btn_salir_salario.Text = "Salir";
            this.Btn_salir_salario.UseVisualStyleBackColor = false;
            this.Btn_salir_salario.Click += new System.EventHandler(this.Btn_salir_salario_Click);
            // 
            // Gpb_mostrar_datos
            // 
            this.Gpb_mostrar_datos.Controls.Add(this.Btn_buscar_salario);
            this.Gpb_mostrar_datos.Controls.Add(this.Cbo_mostrar_datos);
            this.Gpb_mostrar_datos.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_mostrar_datos.Location = new System.Drawing.Point(445, 12);
            this.Gpb_mostrar_datos.Name = "Gpb_mostrar_datos";
            this.Gpb_mostrar_datos.Size = new System.Drawing.Size(543, 76);
            this.Gpb_mostrar_datos.TabIndex = 12;
            this.Gpb_mostrar_datos.TabStop = false;
            this.Gpb_mostrar_datos.Text = "Mostrar";
            // 
            // Btn_buscar_salario
            // 
            this.Btn_buscar_salario.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_buscar_salario.Location = new System.Drawing.Point(28, 28);
            this.Btn_buscar_salario.Name = "Btn_buscar_salario";
            this.Btn_buscar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_buscar_salario.TabIndex = 16;
            this.Btn_buscar_salario.Text = "Buscar";
            this.Btn_buscar_salario.UseVisualStyleBackColor = false;
            this.Btn_buscar_salario.Click += new System.EventHandler(this.Btn_buscar_salario_Click);
            // 
            // Cbo_mostrar_datos
            // 
            this.Cbo_mostrar_datos.FormattingEnabled = true;
            this.Cbo_mostrar_datos.Location = new System.Drawing.Point(188, 28);
            this.Cbo_mostrar_datos.Name = "Cbo_mostrar_datos";
            this.Cbo_mostrar_datos.Size = new System.Drawing.Size(349, 28);
            this.Cbo_mostrar_datos.TabIndex = 15;
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar.Location = new System.Drawing.Point(6, 218);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(114, 30);
            this.Btn_cancelar.TabIndex = 14;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // frmSalarioEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 460);
            this.Controls.Add(this.Gpb_mostrar_datos);
            this.Controls.Add(this.Gpb_opciones_salario);
            this.Controls.Add(this.Gpb_estado_salario);
            this.Controls.Add(this.Gpb_datos_salario_empleados);
            this.Controls.Add(this.lbl_salario_empleados);
            this.Name = "frmSalarioEmpleados";
            this.Text = "frmSalarioEmpleados";
            this.Gpb_datos_salario_empleados.ResumeLayout(false);
            this.Gpb_datos_salario_empleados.PerformLayout();
            this.Gpb_estado_salario.ResumeLayout(false);
            this.Gpb_estado_salario.PerformLayout();
            this.Gpb_opciones_salario.ResumeLayout(false);
            this.Gpb_mostrar_datos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_salario_empleados;
        private System.Windows.Forms.GroupBox Gpb_datos_salario_empleados;
        private System.Windows.Forms.TextBox Txt_fechafin_salario;
        private System.Windows.Forms.Label lbl_fechafin_salario;
        private System.Windows.Forms.TextBox Txt_fechainicio_salario;
        private System.Windows.Forms.Label lbl_fechainicios_salario;
        private System.Windows.Forms.TextBox Txt_monto;
        private System.Windows.Forms.Label lbl_monto_salario;
        private System.Windows.Forms.TextBox Txt_id_empl_salario;
        private System.Windows.Forms.Label lbl_fk_id_empl_salario;
        private System.Windows.Forms.TextBox Txt_id_salario;
        private System.Windows.Forms.Label lbl_id_salario;
        private System.Windows.Forms.GroupBox Gpb_estado_salario;
        private System.Windows.Forms.RadioButton Rdb_inactivo_salario;
        private System.Windows.Forms.RadioButton Rdb_activo_salario;
        private System.Windows.Forms.GroupBox Gpb_opciones_salario;
        private System.Windows.Forms.Button Btn_eliminar_salario;
        private System.Windows.Forms.Button Btn_modificar_salario;
        private System.Windows.Forms.Button Btn_nuevo_salario;
        private System.Windows.Forms.Button Btn_guardar_salario;
        private System.Windows.Forms.Button Btn_salir_salario;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.GroupBox Gpb_mostrar_datos;
        private System.Windows.Forms.Button Btn_buscar_salario;
        private System.Windows.Forms.ComboBox Cbo_mostrar_datos;
    }
}