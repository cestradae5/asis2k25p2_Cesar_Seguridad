
namespace Capa_Vista_Seguridad
{
    partial class Frm_Usuario
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
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.lbl_ConfirmarContraseña = new System.Windows.Forms.Label();
            this.Txt_ConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.Chk_ConfirmarContraseña = new System.Windows.Forms.CheckBox();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Crear_Usuario
            // 
            this.lbl_Crear_Usuario.AutoSize = true;
            this.lbl_Crear_Usuario.Font = new System.Drawing.Font("Rockwell", 18F);
            this.lbl_Crear_Usuario.Location = new System.Drawing.Point(38, 79);
            this.lbl_Crear_Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Crear_Usuario.Name = "lbl_Crear_Usuario";
            this.lbl_Crear_Usuario.Size = new System.Drawing.Size(261, 41);
            this.lbl_Crear_Usuario.TabIndex = 0;
            this.lbl_Crear_Usuario.Text = "Crear Usuario:";
            // 
            // lbl_Id_Empleado
            // 
            this.lbl_Id_Empleado.AutoSize = true;
            this.lbl_Id_Empleado.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_Id_Empleado.Location = new System.Drawing.Point(46, 178);
            this.lbl_Id_Empleado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Id_Empleado.Name = "lbl_Id_Empleado";
            this.lbl_Id_Empleado.Size = new System.Drawing.Size(135, 22);
            this.lbl_Id_Empleado.TabIndex = 1;
            this.lbl_Id_Empleado.Text = "iId Empleado:";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_Nombre.Location = new System.Drawing.Point(46, 220);
            this.lbl_Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(90, 22);
            this.lbl_Nombre.TabIndex = 2;
            this.lbl_Nombre.Text = "Nombre:";
            // 
            // lbl_Contraseña
            // 
            this.lbl_Contraseña.AutoSize = true;
            this.lbl_Contraseña.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lbl_Contraseña.Location = new System.Drawing.Point(46, 263);
            this.lbl_Contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Contraseña.Name = "lbl_Contraseña";
            this.lbl_Contraseña.Size = new System.Drawing.Size(120, 22);
            this.lbl_Contraseña.TabIndex = 3;
            this.lbl_Contraseña.Text = "Contraseña:";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_Nombre.Location = new System.Drawing.Point(167, 220);
            this.Txt_Nombre.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(309, 31);
            this.Txt_Nombre.TabIndex = 4;
            this.Txt_Nombre.TextChanged += new System.EventHandler(this.Txt_Nombre_TextChanged);
            // 
            // Txt_Contraseña
            // 
            this.Txt_Contraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Txt_Contraseña.Location = new System.Drawing.Point(167, 263);
            this.Txt_Contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Contraseña.Name = "Txt_Contraseña";
            this.Txt_Contraseña.Size = new System.Drawing.Size(309, 31);
            this.Txt_Contraseña.TabIndex = 5;
            this.Txt_Contraseña.TextChanged += new System.EventHandler(this.Txt_Contraseña_TextChanged);
            // 
            // Cbo_Empleado
            // 
            this.Cbo_Empleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_Empleado.FormattingEnabled = true;
            this.Cbo_Empleado.Location = new System.Drawing.Point(167, 178);
            this.Cbo_Empleado.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Empleado.Name = "Cbo_Empleado";
            this.Cbo_Empleado.Size = new System.Drawing.Size(309, 30);
            this.Cbo_Empleado.TabIndex = 6;
            this.Cbo_Empleado.SelectedIndexChanged += new System.EventHandler(this.Cbo_Empleado_SelectedIndexChanged);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Guardar.Location = new System.Drawing.Point(662, 205);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(142, 50);
            this.Btn_Guardar.TabIndex = 8;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Limpiar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Limpiar.Location = new System.Drawing.Point(662, 263);
            this.Btn_Limpiar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(142, 50);
            this.Btn_Limpiar.TabIndex = 10;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = false;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Salir.Location = new System.Drawing.Point(662, 321);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(142, 50);
            this.Btn_Salir.TabIndex = 11;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(832, 55);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(786, 0);
            this.Pic_Cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(46, 55);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_reporte.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_reporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_reporte.Location = new System.Drawing.Point(662, 147);
            this.Btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(142, 50);
            this.Btn_reporte.TabIndex = 96;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // lbl_ConfirmarContraseña
            // 
            this.lbl_ConfirmarContraseña.AutoSize = true;
            this.lbl_ConfirmarContraseña.Location = new System.Drawing.Point(46, 306);
            this.lbl_ConfirmarContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ConfirmarContraseña.Name = "lbl_ConfirmarContraseña";
            this.lbl_ConfirmarContraseña.Size = new System.Drawing.Size(218, 22);
            this.lbl_ConfirmarContraseña.TabIndex = 97;
            this.lbl_ConfirmarContraseña.Text = "Confirmar Contraseña:";
            // 
            // Txt_ConfirmarContraseña
            // 
            this.Txt_ConfirmarContraseña.Location = new System.Drawing.Point(243, 306);
            this.Txt_ConfirmarContraseña.Name = "Txt_ConfirmarContraseña";
            this.Txt_ConfirmarContraseña.Size = new System.Drawing.Size(285, 31);
            this.Txt_ConfirmarContraseña.TabIndex = 98;
            this.Txt_ConfirmarContraseña.TextChanged += new System.EventHandler(this.Txt_ConfirmarContraseña_TextChanged);
            // 
            // Chk_ConfirmarContraseña
            // 
            this.Chk_ConfirmarContraseña.AutoSize = true;
            this.Chk_ConfirmarContraseña.Location = new System.Drawing.Point(548, 316);
            this.Chk_ConfirmarContraseña.Name = "Chk_ConfirmarContraseña";
            this.Chk_ConfirmarContraseña.Size = new System.Drawing.Size(22, 21);
            this.Chk_ConfirmarContraseña.TabIndex = 99;
            this.Chk_ConfirmarContraseña.UseVisualStyleBackColor = true;
            this.Chk_ConfirmarContraseña.CheckedChanged += new System.EventHandler(this.Chk_ConfirmarContraseña_CheckedChanged);
            // 
            // Frm_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(832, 465);
            this.Controls.Add(this.Chk_ConfirmarContraseña);
            this.Controls.Add(this.Txt_ConfirmarContraseña);
            this.Controls.Add(this.lbl_ConfirmarContraseña);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Cbo_Empleado);
            this.Controls.Add(this.Txt_Contraseña);
            this.Controls.Add(this.Txt_Nombre);
            this.Controls.Add(this.lbl_Contraseña);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.lbl_Id_Empleado);
            this.Controls.Add(this.lbl_Crear_Usuario);
            this.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsuario";
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
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
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Label lbl_ConfirmarContraseña;
        private System.Windows.Forms.TextBox Txt_ConfirmarContraseña;
        private System.Windows.Forms.CheckBox Chk_ConfirmarContraseña;
    }
}