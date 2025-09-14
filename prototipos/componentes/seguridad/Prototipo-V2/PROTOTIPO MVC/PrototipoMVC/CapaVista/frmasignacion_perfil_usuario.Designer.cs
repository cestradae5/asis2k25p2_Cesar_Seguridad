
namespace CapaVista
{
    partial class frmasignacion_perfil_usuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.Gbp_consulta = new System.Windows.Forms.GroupBox();
            this.Lbl_usuario = new System.Windows.Forms.Label();
            this.Cbo_usuario = new System.Windows.Forms.ComboBox();
            this.Dgv_perfil = new System.Windows.Forms.DataGridView();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Cbo_usuarios2 = new System.Windows.Forms.ComboBox();
            this.Lbl_usuario2 = new System.Windows.Forms.Label();
            this.Lbl_perfiles = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Dgv_usuario = new System.Windows.Forms.DataGridView();
            this.Btn_cancelar2 = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.Gbp_consulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_perfil)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_usuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignacion de Perfiles ";
            // 
            // Gbp_consulta
            // 
            this.Gbp_consulta.Controls.Add(this.Cbo_usuario);
            this.Gbp_consulta.Controls.Add(this.Lbl_usuario);
            this.Gbp_consulta.Controls.Add(this.Dgv_perfil);
            this.Gbp_consulta.Location = new System.Drawing.Point(15, 106);
            this.Gbp_consulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gbp_consulta.Name = "Gbp_consulta";
            this.Gbp_consulta.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gbp_consulta.Size = new System.Drawing.Size(507, 443);
            this.Gbp_consulta.TabIndex = 1;
            this.Gbp_consulta.TabStop = false;
            this.Gbp_consulta.Text = "Consulta de Pefiles a Usuarios";
            // 
            // Lbl_usuario
            // 
            this.Lbl_usuario.AutoSize = true;
            this.Lbl_usuario.Location = new System.Drawing.Point(8, 52);
            this.Lbl_usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_usuario.Name = "Lbl_usuario";
            this.Lbl_usuario.Size = new System.Drawing.Size(78, 20);
            this.Lbl_usuario.TabIndex = 2;
            this.Lbl_usuario.Text = "Usuarios";
            // 
            // Cbo_usuario
            // 
            this.Cbo_usuario.FormattingEnabled = true;
            this.Cbo_usuario.Location = new System.Drawing.Point(110, 44);
            this.Cbo_usuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cbo_usuario.Name = "Cbo_usuario";
            this.Cbo_usuario.Size = new System.Drawing.Size(334, 28);
            this.Cbo_usuario.TabIndex = 3;
            // 
            // Dgv_perfil
            // 
            this.Dgv_perfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_perfil.Location = new System.Drawing.Point(0, 133);
            this.Dgv_perfil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgv_perfil.Name = "Dgv_perfil";
            this.Dgv_perfil.RowHeadersWidth = 51;
            this.Dgv_perfil.RowTemplate.Height = 24;
            this.Dgv_perfil.Size = new System.Drawing.Size(418, 276);
            this.Dgv_perfil.TabIndex = 2;
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.Location = new System.Drawing.Point(448, 286);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(64, 58);
            this.Btn_cancelar.TabIndex = 3;
            this.Btn_cancelar.Text = "X";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_finalizar);
            this.groupBox1.Controls.Add(this.Btn_cancelar2);
            this.groupBox1.Controls.Add(this.Dgv_usuario);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.Lbl_perfiles);
            this.groupBox1.Controls.Add(this.Lbl_usuario2);
            this.groupBox1.Controls.Add(this.Cbo_usuarios2);
            this.groupBox1.Location = new System.Drawing.Point(539, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 426);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asingacion de Perfiles a Usuarios";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 5;
            // 
            // Cbo_usuarios2
            // 
            this.Cbo_usuarios2.FormattingEnabled = true;
            this.Cbo_usuarios2.Location = new System.Drawing.Point(6, 65);
            this.Cbo_usuarios2.Name = "Cbo_usuarios2";
            this.Cbo_usuarios2.Size = new System.Drawing.Size(196, 28);
            this.Cbo_usuarios2.TabIndex = 0;
            // 
            // Lbl_usuario2
            // 
            this.Lbl_usuario2.AutoSize = true;
            this.Lbl_usuario2.Location = new System.Drawing.Point(30, 42);
            this.Lbl_usuario2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_usuario2.Name = "Lbl_usuario2";
            this.Lbl_usuario2.Size = new System.Drawing.Size(78, 20);
            this.Lbl_usuario2.TabIndex = 4;
            this.Lbl_usuario2.Text = "Usuarios";
            // 
            // Lbl_perfiles
            // 
            this.Lbl_perfiles.AutoSize = true;
            this.Lbl_perfiles.Location = new System.Drawing.Point(279, 42);
            this.Lbl_perfiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_perfiles.Name = "Lbl_perfiles";
            this.Lbl_perfiles.Size = new System.Drawing.Size(69, 20);
            this.Lbl_perfiles.TabIndex = 5;
            this.Lbl_perfiles.Text = "Perfiles";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(216, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(196, 28);
            this.comboBox2.TabIndex = 6;
            // 
            // Dgv_usuario
            // 
            this.Dgv_usuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_usuario.Location = new System.Drawing.Point(6, 133);
            this.Dgv_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_usuario.Name = "Dgv_usuario";
            this.Dgv_usuario.RowHeadersWidth = 51;
            this.Dgv_usuario.RowTemplate.Height = 24;
            this.Dgv_usuario.Size = new System.Drawing.Size(291, 238);
            this.Dgv_usuario.TabIndex = 4;
            // 
            // Btn_cancelar2
            // 
            this.Btn_cancelar2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar2.Location = new System.Drawing.Point(318, 201);
            this.Btn_cancelar2.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar2.Name = "Btn_cancelar2";
            this.Btn_cancelar2.Size = new System.Drawing.Size(64, 58);
            this.Btn_cancelar2.TabIndex = 6;
            this.Btn_cancelar2.Text = "X";
            this.Btn_cancelar2.UseVisualStyleBackColor = false;
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_finalizar.Location = new System.Drawing.Point(274, 386);
            this.btn_finalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(118, 33);
            this.btn_finalizar.TabIndex = 7;
            this.btn_finalizar.Text = "Finalizar";
            this.btn_finalizar.UseVisualStyleBackColor = false;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // frmasignacion_perfil_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 565);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_cancelar);
            this.Controls.Add(this.Gbp_consulta);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmasignacion_perfil_usuario";
            this.Text = "Asignaciones Perfil a Usuario";
            this.Gbp_consulta.ResumeLayout(false);
            this.Gbp_consulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_perfil)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_usuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Gbp_consulta;
        private System.Windows.Forms.ComboBox Cbo_usuario;
        private System.Windows.Forms.Label Lbl_usuario;
        private System.Windows.Forms.DataGridView Dgv_perfil;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.Button Btn_cancelar2;
        private System.Windows.Forms.DataGridView Dgv_usuario;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Lbl_perfiles;
        private System.Windows.Forms.Label Lbl_usuario2;
        private System.Windows.Forms.ComboBox Cbo_usuarios2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}