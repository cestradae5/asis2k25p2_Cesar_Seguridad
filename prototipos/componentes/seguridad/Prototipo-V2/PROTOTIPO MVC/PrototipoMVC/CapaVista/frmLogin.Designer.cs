
namespace CapaVista
{
    partial class frmLogin
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
            this.chkMostrarContrasena = new System.Windows.Forms.CheckBox();
            this.lblModuloSeguridad = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblkRecuperarContrasena = new System.Windows.Forms.LinkLabel();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkMostrarContrasena
            // 
            this.chkMostrarContrasena.AutoSize = true;
            this.chkMostrarContrasena.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.chkMostrarContrasena.Location = new System.Drawing.Point(357, 199);
            this.chkMostrarContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.chkMostrarContrasena.Name = "chkMostrarContrasena";
            this.chkMostrarContrasena.Size = new System.Drawing.Size(83, 30);
            this.chkMostrarContrasena.TabIndex = 31;
            this.chkMostrarContrasena.Text = "mostrar\r\ncontraseña";
            this.chkMostrarContrasena.UseVisualStyleBackColor = true;
            this.chkMostrarContrasena.CheckedChanged += new System.EventHandler(this.chkMostrarContrasena_CheckedChanged);
            // 
            // lblModuloSeguridad
            // 
            this.lblModuloSeguridad.AutoSize = true;
            this.lblModuloSeguridad.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblModuloSeguridad.Location = new System.Drawing.Point(241, 67);
            this.lblModuloSeguridad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModuloSeguridad.Name = "lblModuloSeguridad";
            this.lblModuloSeguridad.Size = new System.Drawing.Size(194, 30);
            this.lblModuloSeguridad.TabIndex = 30;
            this.lblModuloSeguridad.Text = "Modulo Seguridad";
            this.lblModuloSeguridad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblContrasena.Location = new System.Drawing.Point(79, 199);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(92, 21);
            this.lblContrasena.TabIndex = 29;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(103, 161);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 28;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F);
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.btnIniciarSesion.Location = new System.Drawing.Point(106, 275);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(106, 39);
            this.btnIniciarSesion.TabIndex = 27;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblkRecuperarContrasena
            // 
            this.lblkRecuperarContrasena.AutoSize = true;
            this.lblkRecuperarContrasena.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F);
            this.lblkRecuperarContrasena.Location = new System.Drawing.Point(244, 235);
            this.lblkRecuperarContrasena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblkRecuperarContrasena.Name = "lblkRecuperarContrasena";
            this.lblkRecuperarContrasena.Size = new System.Drawing.Size(116, 13);
            this.lblkRecuperarContrasena.TabIndex = 26;
            this.lblkRecuperarContrasena.TabStop = true;
            this.lblkRecuperarContrasena.Text = "Recuperar contraseña";
            this.lblkRecuperarContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblkRecuperarContrasena_LinkClicked);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtContrasena.Location = new System.Drawing.Point(193, 205);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(161, 20);
            this.txtContrasena.TabIndex = 25;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtUsuario.Location = new System.Drawing.Point(193, 166);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(161, 20);
            this.txtUsuario.TabIndex = 24;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 343);
            this.Controls.Add(this.chkMostrarContrasena);
            this.Controls.Add(this.lblModuloSeguridad);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblkRecuperarContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMostrarContrasena;
        private System.Windows.Forms.Label lblModuloSeguridad;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.LinkLabel lblkRecuperarContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}