
namespace CapaVista
{
    partial class frm_cambiar_contrasena
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
            this.Txt_confirmar_contrasena = new System.Windows.Forms.TextBox();
            this.Txt_nueva_contrasena = new System.Windows.Forms.TextBox();
            this.Txt_contrasena_actual = new System.Windows.Forms.TextBox();
            this.Btn_Cambiar = new System.Windows.Forms.Button();
            this.Lbl_cambiar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_confirmar_contrasena = new System.Windows.Forms.Label();
            this.Lbl_nueva_contrasena = new System.Windows.Forms.Label();
            this.Lbl_contrasena_actual = new System.Windows.Forms.Label();
            this.Chk_Mostrar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Txt_confirmar_contrasena
            // 
            this.Txt_confirmar_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_confirmar_contrasena.Location = new System.Drawing.Point(362, 238);
            this.Txt_confirmar_contrasena.Name = "Txt_confirmar_contrasena";
            this.Txt_confirmar_contrasena.Size = new System.Drawing.Size(211, 27);
            this.Txt_confirmar_contrasena.TabIndex = 102;
            // 
            // Txt_nueva_contrasena
            // 
            this.Txt_nueva_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_nueva_contrasena.Location = new System.Drawing.Point(362, 198);
            this.Txt_nueva_contrasena.Name = "Txt_nueva_contrasena";
            this.Txt_nueva_contrasena.Size = new System.Drawing.Size(211, 27);
            this.Txt_nueva_contrasena.TabIndex = 101;
            // 
            // Txt_contrasena_actual
            // 
            this.Txt_contrasena_actual.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_contrasena_actual.Location = new System.Drawing.Point(362, 123);
            this.Txt_contrasena_actual.Name = "Txt_contrasena_actual";
            this.Txt_contrasena_actual.Size = new System.Drawing.Size(211, 27);
            this.Txt_contrasena_actual.TabIndex = 100;
            // 
            // Btn_Cambiar
            // 
            this.Btn_Cambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Cambiar.FlatAppearance.BorderSize = 0;
            this.Btn_Cambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cambiar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Cambiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Cambiar.Location = new System.Drawing.Point(335, 378);
            this.Btn_Cambiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Cambiar.Name = "Btn_Cambiar";
            this.Btn_Cambiar.Size = new System.Drawing.Size(141, 48);
            this.Btn_Cambiar.TabIndex = 98;
            this.Btn_Cambiar.Text = "Cambiar";
            this.Btn_Cambiar.UseVisualStyleBackColor = false;
            this.Btn_Cambiar.Click += new System.EventHandler(this.Btn_Cambiar_Click);
            // 
            // Lbl_cambiar_contrasena
            // 
            this.Lbl_cambiar_contrasena.AutoSize = true;
            this.Lbl_cambiar_contrasena.Font = new System.Drawing.Font("Rockwell", 18F);
            this.Lbl_cambiar_contrasena.Location = new System.Drawing.Point(284, 33);
            this.Lbl_cambiar_contrasena.Name = "Lbl_cambiar_contrasena";
            this.Lbl_cambiar_contrasena.Size = new System.Drawing.Size(304, 35);
            this.Lbl_cambiar_contrasena.TabIndex = 97;
            this.Lbl_cambiar_contrasena.Text = "Cambiar Contraseña";
            // 
            // Lbl_confirmar_contrasena
            // 
            this.Lbl_confirmar_contrasena.AutoSize = true;
            this.Lbl_confirmar_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_confirmar_contrasena.Location = new System.Drawing.Point(152, 238);
            this.Lbl_confirmar_contrasena.Name = "Lbl_confirmar_contrasena";
            this.Lbl_confirmar_contrasena.Size = new System.Drawing.Size(190, 20);
            this.Lbl_confirmar_contrasena.TabIndex = 96;
            this.Lbl_confirmar_contrasena.Text = "Confirmar Contraseña:";
            // 
            // Lbl_nueva_contrasena
            // 
            this.Lbl_nueva_contrasena.AutoSize = true;
            this.Lbl_nueva_contrasena.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_nueva_contrasena.Location = new System.Drawing.Point(183, 198);
            this.Lbl_nueva_contrasena.Name = "Lbl_nueva_contrasena";
            this.Lbl_nueva_contrasena.Size = new System.Drawing.Size(159, 20);
            this.Lbl_nueva_contrasena.TabIndex = 95;
            this.Lbl_nueva_contrasena.Text = "Nueva Contraseña:";
            // 
            // Lbl_contrasena_actual
            // 
            this.Lbl_contrasena_actual.AutoSize = true;
            this.Lbl_contrasena_actual.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_contrasena_actual.Location = new System.Drawing.Point(190, 123);
            this.Lbl_contrasena_actual.Name = "Lbl_contrasena_actual";
            this.Lbl_contrasena_actual.Size = new System.Drawing.Size(152, 20);
            this.Lbl_contrasena_actual.TabIndex = 94;
            this.Lbl_contrasena_actual.Text = "contraseña actual:";
            // 
            // Chk_Mostrar
            // 
            this.Chk_Mostrar.AutoSize = true;
            this.Chk_Mostrar.Location = new System.Drawing.Point(323, 314);
            this.Chk_Mostrar.Name = "Chk_Mostrar";
            this.Chk_Mostrar.Size = new System.Drawing.Size(153, 21);
            this.Chk_Mostrar.TabIndex = 103;
            this.Chk_Mostrar.Text = "mostrar contraseña";
            this.Chk_Mostrar.UseVisualStyleBackColor = true;
            this.Chk_Mostrar.CheckedChanged += new System.EventHandler(this.Chk_Mostrar_CheckedChanged);
            // 
            // frm_cambiar_contrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Chk_Mostrar);
            this.Controls.Add(this.Txt_confirmar_contrasena);
            this.Controls.Add(this.Txt_nueva_contrasena);
            this.Controls.Add(this.Txt_contrasena_actual);
            this.Controls.Add(this.Btn_Cambiar);
            this.Controls.Add(this.Lbl_cambiar_contrasena);
            this.Controls.Add(this.Lbl_confirmar_contrasena);
            this.Controls.Add(this.Lbl_nueva_contrasena);
            this.Controls.Add(this.Lbl_contrasena_actual);
            this.Name = "frm_cambiar_contrasena";
            this.Text = "frm_cambiar_contrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txt_confirmar_contrasena;
        private System.Windows.Forms.TextBox Txt_nueva_contrasena;
        private System.Windows.Forms.TextBox Txt_contrasena_actual;
        private System.Windows.Forms.Button Btn_Cambiar;
        private System.Windows.Forms.Label Lbl_cambiar_contrasena;
        private System.Windows.Forms.Label Lbl_confirmar_contrasena;
        private System.Windows.Forms.Label Lbl_nueva_contrasena;
        private System.Windows.Forms.Label Lbl_contrasena_actual;
        private System.Windows.Forms.CheckBox Chk_Mostrar;
    }
}