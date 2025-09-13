
namespace CapaVista
{
    partial class FrmUsuario
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
            this.lbl_Crear_Usuario = new System.Windows.Forms.Label();
            this.lbl_Id_Empleado = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.lbl_Contraseña = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Txt_Contraseña = new System.Windows.Forms.TextBox();
            this.Cbo_Empleado = new System.Windows.Forms.ComboBox();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Crear_Usuario
            // 
            this.lbl_Crear_Usuario.AutoSize = true;
            this.lbl_Crear_Usuario.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.lbl_Crear_Usuario.Location = new System.Drawing.Point(30, 38);
            this.lbl_Crear_Usuario.Name = "lbl_Crear_Usuario";
            this.lbl_Crear_Usuario.Size = new System.Drawing.Size(125, 20);
            this.lbl_Crear_Usuario.TabIndex = 0;
            this.lbl_Crear_Usuario.Text = "Crear Usuario:";
            // 
            // lbl_Id_Empleado
            // 
            this.lbl_Id_Empleado.AutoSize = true;
            this.lbl_Id_Empleado.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.lbl_Id_Empleado.Location = new System.Drawing.Point(30, 99);
            this.lbl_Id_Empleado.Name = "lbl_Id_Empleado";
            this.lbl_Id_Empleado.Size = new System.Drawing.Size(113, 20);
            this.lbl_Id_Empleado.TabIndex = 1;
            this.lbl_Id_Empleado.Text = "Id Empleado:";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.lbl_Nombre.Location = new System.Drawing.Point(31, 140);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(78, 20);
            this.lbl_Nombre.TabIndex = 2;
            this.lbl_Nombre.Text = "Nombre:";
            // 
            // lbl_Contraseña
            // 
            this.lbl_Contraseña.AutoSize = true;
            this.lbl_Contraseña.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.lbl_Contraseña.Location = new System.Drawing.Point(32, 185);
            this.lbl_Contraseña.Name = "lbl_Contraseña";
            this.lbl_Contraseña.Size = new System.Drawing.Size(105, 20);
            this.lbl_Contraseña.TabIndex = 3;
            this.lbl_Contraseña.Text = "Contraseña:";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Location = new System.Drawing.Point(171, 140);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(248, 22);
            this.Txt_Nombre.TabIndex = 4;
            this.Txt_Nombre.TextChanged += new System.EventHandler(this.Txt_Nombre_TextChanged);
            // 
            // Txt_Contraseña
            // 
            this.Txt_Contraseña.Location = new System.Drawing.Point(171, 185);
            this.Txt_Contraseña.Name = "Txt_Contraseña";
            this.Txt_Contraseña.Size = new System.Drawing.Size(248, 22);
            this.Txt_Contraseña.TabIndex = 5;
            this.Txt_Contraseña.TextChanged += new System.EventHandler(this.Txt_Contraseña_TextChanged);
            // 
            // Cbo_Empleado
            // 
            this.Cbo_Empleado.FormattingEnabled = true;
            this.Cbo_Empleado.Location = new System.Drawing.Point(171, 99);
            this.Cbo_Empleado.Name = "Cbo_Empleado";
            this.Cbo_Empleado.Size = new System.Drawing.Size(248, 24);
            this.Cbo_Empleado.TabIndex = 6;
            this.Cbo_Empleado.SelectedIndexChanged += new System.EventHandler(this.Cbo_Empleado_SelectedIndexChanged);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Nuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Nuevo.Location = new System.Drawing.Point(582, 98);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(114, 30);
            this.Btn_Nuevo.TabIndex = 7;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = false;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Guardar.Location = new System.Drawing.Point(582, 132);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(114, 30);
            this.Btn_Guardar.TabIndex = 8;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Modificar.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Modificar.Location = new System.Drawing.Point(582, 168);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(114, 30);
            this.Btn_Modificar.TabIndex = 9;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Limpiar.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Limpiar.Location = new System.Drawing.Point(582, 204);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(114, 30);
            this.Btn_Limpiar.TabIndex = 10;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = false;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Btn_Salir.Location = new System.Drawing.Point(582, 240);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(114, 30);
            this.Btn_Salir.TabIndex = 11;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Cbo_Empleado);
            this.Controls.Add(this.Txt_Contraseña);
            this.Controls.Add(this.Txt_Nombre);
            this.Controls.Add(this.lbl_Contraseña);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.lbl_Id_Empleado);
            this.Controls.Add(this.lbl_Crear_Usuario);
            this.Name = "FrmUsuario";
            this.Text = "FrmUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Crear_Usuario;
        private System.Windows.Forms.Label lbl_Id_Empleado;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Label lbl_Contraseña;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.TextBox Txt_Contraseña;
        private System.Windows.Forms.ComboBox Cbo_Empleado;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Salir;
    }
}