
namespace CapaVista
{
    partial class frmRecuperarContrasena
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
            this.Btn_regresar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Lbl_recuperar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_confirmar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_nueva_contrasena = new System.Windows.Forms.Label();
            this.Lbl_apellido = new System.Windows.Forms.Label();
            this.Lbl_usuario = new System.Windows.Forms.Label();
            this.Txt_usuario = new System.Windows.Forms.TextBox();
            this.Txt_token = new System.Windows.Forms.TextBox();
            this.Txt_nueva_contrasena = new System.Windows.Forms.TextBox();
            this.Txt_confirmar_contrasena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_regresar
            // 
            this.Btn_regresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_regresar.FlatAppearance.BorderSize = 0;
            this.Btn_regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_regresar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_regresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_regresar.Location = new System.Drawing.Point(463, 357);
            this.Btn_regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_regresar.Name = "Btn_regresar";
            this.Btn_regresar.Size = new System.Drawing.Size(141, 48);
            this.Btn_regresar.TabIndex = 46;
            this.Btn_regresar.Text = "Regresar";
            this.Btn_regresar.UseVisualStyleBackColor = false;
            this.Btn_regresar.Click += new System.EventHandler(this.Btn_regresar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_guardar.FlatAppearance.BorderSize = 0;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_guardar.Location = new System.Drawing.Point(192, 357);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(141, 48);
            this.Btn_guardar.TabIndex = 45;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Lbl_recuperar_contrasena
            // 
            this.Lbl_recuperar_contrasena.AutoSize = true;
            this.Lbl_recuperar_contrasena.Font = new System.Drawing.Font("Rockwell", 18F);
            this.Lbl_recuperar_contrasena.Location = new System.Drawing.Point(243, 54);
            this.Lbl_recuperar_contrasena.Name = "Lbl_recuperar_contrasena";
            this.Lbl_recuperar_contrasena.Size = new System.Drawing.Size(328, 35);
            this.Lbl_recuperar_contrasena.TabIndex = 44;
            this.Lbl_recuperar_contrasena.Text = "Recuperar Contraseña";
            // 
            // Lbl_confirmar_contrasena
            // 
            this.Lbl_confirmar_contrasena.AutoSize = true;
            this.Lbl_confirmar_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_confirmar_contrasena.Location = new System.Drawing.Point(132, 279);
            this.Lbl_confirmar_contrasena.Name = "Lbl_confirmar_contrasena";
            this.Lbl_confirmar_contrasena.Size = new System.Drawing.Size(190, 20);
            this.Lbl_confirmar_contrasena.TabIndex = 43;
            this.Lbl_confirmar_contrasena.Text = "Confirmar Contraseña:";
            // 
            // Lbl_nueva_contrasena
            // 
            this.Lbl_nueva_contrasena.AutoSize = true;
            this.Lbl_nueva_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_nueva_contrasena.Location = new System.Drawing.Point(163, 239);
            this.Lbl_nueva_contrasena.Name = "Lbl_nueva_contrasena";
            this.Lbl_nueva_contrasena.Size = new System.Drawing.Size(159, 20);
            this.Lbl_nueva_contrasena.TabIndex = 42;
            this.Lbl_nueva_contrasena.Text = "Nueva Contraseña:";
            // 
            // Lbl_apellido
            // 
            this.Lbl_apellido.AutoSize = true;
            this.Lbl_apellido.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_apellido.Location = new System.Drawing.Point(258, 197);
            this.Lbl_apellido.Name = "Lbl_apellido";
            this.Lbl_apellido.Size = new System.Drawing.Size(64, 20);
            this.Lbl_apellido.TabIndex = 41;
            this.Lbl_apellido.Text = "Token:";
            // 
            // Lbl_usuario
            // 
            this.Lbl_usuario.AutoSize = true;
            this.Lbl_usuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_usuario.Location = new System.Drawing.Point(249, 156);
            this.Lbl_usuario.Name = "Lbl_usuario";
            this.Lbl_usuario.Size = new System.Drawing.Size(73, 20);
            this.Lbl_usuario.TabIndex = 40;
            this.Lbl_usuario.Text = "usuario:";
            // 
            // Txt_usuario
            // 
            this.Txt_usuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_usuario.Location = new System.Drawing.Point(366, 156);
            this.Txt_usuario.Name = "Txt_usuario";
            this.Txt_usuario.Size = new System.Drawing.Size(211, 27);
            this.Txt_usuario.TabIndex = 47;
            // 
            // Txt_token
            // 
            this.Txt_token.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_token.Location = new System.Drawing.Point(366, 197);
            this.Txt_token.Name = "Txt_token";
            this.Txt_token.Size = new System.Drawing.Size(211, 27);
            this.Txt_token.TabIndex = 48;
            // 
            // Txt_nueva_contrasena
            // 
            this.Txt_nueva_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_nueva_contrasena.Location = new System.Drawing.Point(366, 239);
            this.Txt_nueva_contrasena.Name = "Txt_nueva_contrasena";
            this.Txt_nueva_contrasena.Size = new System.Drawing.Size(211, 27);
            this.Txt_nueva_contrasena.TabIndex = 49;
            // 
            // Txt_confirmar_contrasena
            // 
            this.Txt_confirmar_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_confirmar_contrasena.Location = new System.Drawing.Point(366, 279);
            this.Txt_confirmar_contrasena.Name = "Txt_confirmar_contrasena";
            this.Txt_confirmar_contrasena.Size = new System.Drawing.Size(211, 27);
            this.Txt_confirmar_contrasena.TabIndex = 50;
            // 
            // frmRecuperarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 459);
            this.Controls.Add(this.Txt_confirmar_contrasena);
            this.Controls.Add(this.Txt_nueva_contrasena);
            this.Controls.Add(this.Txt_token);
            this.Controls.Add(this.Txt_usuario);
            this.Controls.Add(this.Btn_regresar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Lbl_recuperar_contrasena);
            this.Controls.Add(this.Lbl_confirmar_contrasena);
            this.Controls.Add(this.Lbl_nueva_contrasena);
            this.Controls.Add(this.Lbl_apellido);
            this.Controls.Add(this.Lbl_usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecuperarContrasena";
            this.Text = "frmRecuperarContrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_regresar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Label Lbl_recuperar_contrasena;
        private System.Windows.Forms.Label Lbl_confirmar_contrasena;
        private System.Windows.Forms.Label Lbl_nueva_contrasena;
        private System.Windows.Forms.Label Lbl_apellido;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.TextBox Txt_usuario;
        private System.Windows.Forms.TextBox Txt_token;
        private System.Windows.Forms.TextBox Txt_nueva_contrasena;
        private System.Windows.Forms.TextBox Txt_confirmar_contrasena;
    }
}