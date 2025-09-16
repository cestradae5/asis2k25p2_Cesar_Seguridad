
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
            this.chkMostrarContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.chkMostrarContrasena.Location = new System.Drawing.Point(480, 216);
            this.chkMostrarContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMostrarContrasena.Name = "chkMostrarContrasena";
            this.chkMostrarContrasena.Size = new System.Drawing.Size(118, 44);
            this.chkMostrarContrasena.TabIndex = 31;
            this.chkMostrarContrasena.Text = "mostrar\r\ncontraseña";
            this.chkMostrarContrasena.UseVisualStyleBackColor = true;
            this.chkMostrarContrasena.CheckedChanged += new System.EventHandler(this.chkMostrarContrasena_CheckedChanged);
            // 
            // lblModuloSeguridad
            // 
            this.lblModuloSeguridad.AutoSize = true;
            this.lblModuloSeguridad.Font = new System.Drawing.Font("Rockwell", 18F);
            this.lblModuloSeguridad.Location = new System.Drawing.Point(219, 59);
            this.lblModuloSeguridad.Name = "lblModuloSeguridad";
            this.lblModuloSeguridad.Size = new System.Drawing.Size(273, 35);
            this.lblModuloSeguridad.TabIndex = 30;
            this.lblModuloSeguridad.Text = "Modulo Seguridad";
            this.lblModuloSeguridad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblContrasena.Location = new System.Drawing.Point(109, 224);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(105, 20);
            this.lblContrasena.TabIndex = 29;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblUsuario.Location = new System.Drawing.Point(141, 177);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(75, 20);
            this.lblUsuario.TabIndex = 28;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Rockwell", 10F);
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.btnIniciarSesion.Location = new System.Drawing.Point(113, 376);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(141, 48);
            this.btnIniciarSesion.TabIndex = 27;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblkRecuperarContrasena
            // 
            this.lblkRecuperarContrasena.AutoSize = true;
            this.lblkRecuperarContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.lblkRecuperarContrasena.Location = new System.Drawing.Point(292, 267);
            this.lblkRecuperarContrasena.Name = "lblkRecuperarContrasena";
            this.lblkRecuperarContrasena.Size = new System.Drawing.Size(182, 20);
            this.lblkRecuperarContrasena.TabIndex = 26;
            this.lblkRecuperarContrasena.TabStop = true;
            this.lblkRecuperarContrasena.Text = "Recuperar contraseña";
            this.lblkRecuperarContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblkRecuperarContrasena_LinkClicked);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtContrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.txtContrasena.Location = new System.Drawing.Point(261, 224);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(213, 27);
            this.txtContrasena.TabIndex = 25;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtUsuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(261, 177);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(213, 27);
            this.txtUsuario.TabIndex = 24;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 483);
            this.Controls.Add(this.chkMostrarContrasena);
            this.Controls.Add(this.lblModuloSeguridad);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblkRecuperarContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
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