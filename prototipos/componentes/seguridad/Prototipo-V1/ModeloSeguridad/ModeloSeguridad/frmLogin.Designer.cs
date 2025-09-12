
namespace ModeloSeguridad
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblModuloSeguridad = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblkRecuperarContrasena = new System.Windows.Forms.LinkLabel();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pnlPanelSuperior = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.chkMostrarContrasena = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPanelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModuloSeguridad
            // 
            this.lblModuloSeguridad.AutoSize = true;
            this.lblModuloSeguridad.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblModuloSeguridad.Location = new System.Drawing.Point(243, 73);
            this.lblModuloSeguridad.Name = "lblModuloSeguridad";
            this.lblModuloSeguridad.Size = new System.Drawing.Size(239, 37);
            this.lblModuloSeguridad.TabIndex = 20;
            this.lblModuloSeguridad.Text = "Modulo Seguridad";
            this.lblModuloSeguridad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblContrasena.Location = new System.Drawing.Point(27, 235);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(114, 28);
            this.lblContrasena.TabIndex = 19;
            this.lblContrasena.Text = "Contraseña:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(59, 188);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(83, 28);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = "Usuario:";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F);
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.btnIniciarSesion.Location = new System.Drawing.Point(63, 329);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(141, 48);
            this.btnIniciarSesion.TabIndex = 17;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblkRecuperarContrasena
            // 
            this.lblkRecuperarContrasena.AutoSize = true;
            this.lblkRecuperarContrasena.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F);
            this.lblkRecuperarContrasena.Location = new System.Drawing.Point(247, 279);
            this.lblkRecuperarContrasena.Name = "lblkRecuperarContrasena";
            this.lblkRecuperarContrasena.Size = new System.Drawing.Size(144, 19);
            this.lblkRecuperarContrasena.TabIndex = 16;
            this.lblkRecuperarContrasena.TabStop = true;
            this.lblkRecuperarContrasena.Text = "Recuperar contraseña";
            this.lblkRecuperarContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblkRecuperarContrasena_LinkClicked);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtContrasena.Location = new System.Drawing.Point(179, 242);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(213, 22);
            this.txtContrasena.TabIndex = 15;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.txtUsuario.Location = new System.Drawing.Point(179, 194);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(213, 22);
            this.txtUsuario.TabIndex = 14;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // pnlPanelSuperior
            // 
            this.pnlPanelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.pnlPanelSuperior.Controls.Add(this.btnCerrar);
            this.pnlPanelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPanelSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelSuperior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPanelSuperior.Name = "pnlPanelSuperior";
            this.pnlPanelSuperior.Size = new System.Drawing.Size(800, 53);
            this.pnlPanelSuperior.TabIndex = 21;
            this.pnlPanelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPanelSuperior_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(3)))), ((int)(((byte)(1)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(757, 12);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCerrar.Size = new System.Drawing.Size(29, 30);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chkMostrarContrasena
            // 
            this.chkMostrarContrasena.AutoSize = true;
            this.chkMostrarContrasena.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.chkMostrarContrasena.Location = new System.Drawing.Point(397, 235);
            this.chkMostrarContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMostrarContrasena.Name = "chkMostrarContrasena";
            this.chkMostrarContrasena.Size = new System.Drawing.Size(98, 42);
            this.chkMostrarContrasena.TabIndex = 23;
            this.chkMostrarContrasena.Text = "mostrar\r\ncontraseña";
            this.chkMostrarContrasena.UseVisualStyleBackColor = true;
            this.chkMostrarContrasena.CheckedChanged += new System.EventHandler(this.chkMostrarContrasena_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ModeloSeguridad.Properties.Resources.logo_login;
            this.pictureBox1.Location = new System.Drawing.Point(536, 158);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(175)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkMostrarContrasena);
            this.Controls.Add(this.pnlPanelSuperior);
            this.Controls.Add(this.lblModuloSeguridad);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblkRecuperarContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.pnlPanelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModuloSeguridad;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.LinkLabel lblkRecuperarContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel pnlPanelSuperior;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.CheckBox chkMostrarContrasena;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

