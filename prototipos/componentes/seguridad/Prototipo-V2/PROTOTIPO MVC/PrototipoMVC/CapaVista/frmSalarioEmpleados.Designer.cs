
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_monto_salario = new System.Windows.Forms.Label();
            this.Txt_id_empl_salario = new System.Windows.Forms.TextBox();
            this.lbl_fk_id_empl_salario = new System.Windows.Forms.Label();
            this.Txt_id_salario = new System.Windows.Forms.TextBox();
            this.lbl_id_salario = new System.Windows.Forms.Label();
            this.Gpb_estado_salario = new System.Windows.Forms.GroupBox();
            this.Rdb_inactivo_salario = new System.Windows.Forms.RadioButton();
            this.Rdb_activo_salario = new System.Windows.Forms.RadioButton();
            this.Gpb_opciones_salario = new System.Windows.Forms.GroupBox();
            this.Btn_eliminar_salario = new System.Windows.Forms.Button();
            this.Btn_modificar_salario = new System.Windows.Forms.Button();
            this.Btn_nuevo_salario = new System.Windows.Forms.Button();
            this.Btn_guardar_salario = new System.Windows.Forms.Button();
            this.Btn_salir_salario = new System.Windows.Forms.Button();
            this.Gpb_datos_salario_empleados.SuspendLayout();
            this.Gpb_estado_salario.SuspendLayout();
            this.Gpb_opciones_salario.SuspendLayout();
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
            this.Gpb_datos_salario_empleados.Controls.Add(this.textBox1);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_monto_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_id_empl_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_fk_id_empl_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.Txt_id_salario);
            this.Gpb_datos_salario_empleados.Controls.Add(this.lbl_id_salario);
            this.Gpb_datos_salario_empleados.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_datos_salario_empleados.Location = new System.Drawing.Point(12, 76);
            this.Gpb_datos_salario_empleados.Name = "Gpb_datos_salario_empleados";
            this.Gpb_datos_salario_empleados.Size = new System.Drawing.Size(789, 167);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(433, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 29);
            this.textBox1.TabIndex = 6;
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
            this.Gpb_estado_salario.Location = new System.Drawing.Point(12, 269);
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
            // 
            // Gpb_opciones_salario
            // 
            this.Gpb_opciones_salario.Controls.Add(this.Btn_guardar_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_eliminar_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_modificar_salario);
            this.Gpb_opciones_salario.Controls.Add(this.Btn_nuevo_salario);
            this.Gpb_opciones_salario.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_opciones_salario.Location = new System.Drawing.Point(415, 249);
            this.Gpb_opciones_salario.Name = "Gpb_opciones_salario";
            this.Gpb_opciones_salario.Size = new System.Drawing.Size(246, 138);
            this.Gpb_opciones_salario.TabIndex = 6;
            this.Gpb_opciones_salario.TabStop = false;
            this.Gpb_opciones_salario.Text = "Opciones";
            // 
            // Btn_eliminar_salario
            // 
            this.Btn_eliminar_salario.Location = new System.Drawing.Point(126, 88);
            this.Btn_eliminar_salario.Name = "Btn_eliminar_salario";
            this.Btn_eliminar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_eliminar_salario.TabIndex = 8;
            this.Btn_eliminar_salario.Text = "Eliminar";
            this.Btn_eliminar_salario.UseVisualStyleBackColor = true;
            // 
            // Btn_modificar_salario
            // 
            this.Btn_modificar_salario.Location = new System.Drawing.Point(6, 88);
            this.Btn_modificar_salario.Name = "Btn_modificar_salario";
            this.Btn_modificar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_modificar_salario.TabIndex = 7;
            this.Btn_modificar_salario.Text = "Modificar";
            this.Btn_modificar_salario.UseVisualStyleBackColor = true;
            // 
            // Btn_nuevo_salario
            // 
            this.Btn_nuevo_salario.Location = new System.Drawing.Point(6, 52);
            this.Btn_nuevo_salario.Name = "Btn_nuevo_salario";
            this.Btn_nuevo_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_nuevo_salario.TabIndex = 6;
            this.Btn_nuevo_salario.Text = "Nuevo";
            this.Btn_nuevo_salario.UseVisualStyleBackColor = true;
            // 
            // Btn_guardar_salario
            // 
            this.Btn_guardar_salario.Location = new System.Drawing.Point(126, 52);
            this.Btn_guardar_salario.Name = "Btn_guardar_salario";
            this.Btn_guardar_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_guardar_salario.TabIndex = 10;
            this.Btn_guardar_salario.Text = "Guardar";
            this.Btn_guardar_salario.UseVisualStyleBackColor = true;
            // 
            // Btn_salir_salario
            // 
            this.Btn_salir_salario.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_salir_salario.Location = new System.Drawing.Point(702, 357);
            this.Btn_salir_salario.Name = "Btn_salir_salario";
            this.Btn_salir_salario.Size = new System.Drawing.Size(114, 30);
            this.Btn_salir_salario.TabIndex = 10;
            this.Btn_salir_salario.Text = "Salir";
            this.Btn_salir_salario.UseVisualStyleBackColor = true;
            // 
            // frmSalarioEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 399);
            this.Controls.Add(this.Btn_salir_salario);
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
        private System.Windows.Forms.TextBox textBox1;
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
    }
}