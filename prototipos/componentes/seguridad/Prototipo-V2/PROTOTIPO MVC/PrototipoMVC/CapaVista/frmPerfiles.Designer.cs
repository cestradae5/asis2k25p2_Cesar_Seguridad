
namespace CapaVista
{
    partial class frmPerfiles
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
            this.Gpb_buscarperfiles = new System.Windows.Forms.GroupBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Cbo_perfiles = new System.Windows.Forms.ComboBox();
            this.Gpb_datosperfil = new System.Windows.Forms.GroupBox();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_descripcion = new System.Windows.Forms.Label();
            this.Gbp_estado = new System.Windows.Forms.GroupBox();
            this.Rdb_inhabilitado = new System.Windows.Forms.RadioButton();
            this.Rdb_Habilitado = new System.Windows.Forms.RadioButton();
            this.Lbl_tipoperfil = new System.Windows.Forms.Label();
            this.Txt_puesto = new System.Windows.Forms.TextBox();
            this.Lbl_puesto = new System.Windows.Forms.Label();
            this.Txt_idperfil = new System.Windows.Forms.TextBox();
            this.Lbl_idpuesto = new System.Windows.Forms.Label();
            this.Gbp_opc = new System.Windows.Forms.GroupBox();
            this.Btn_salir = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Cbo_tipoperfil = new System.Windows.Forms.ComboBox();
            this.Gpb_buscarperfiles.SuspendLayout();
            this.Gpb_datosperfil.SuspendLayout();
            this.Gbp_estado.SuspendLayout();
            this.Gbp_opc.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gpb_buscarperfiles
            // 
            this.Gpb_buscarperfiles.Controls.Add(this.Btn_buscar);
            this.Gpb_buscarperfiles.Controls.Add(this.Cbo_perfiles);
            this.Gpb_buscarperfiles.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_buscarperfiles.Location = new System.Drawing.Point(12, 21);
            this.Gpb_buscarperfiles.Name = "Gpb_buscarperfiles";
            this.Gpb_buscarperfiles.Size = new System.Drawing.Size(919, 125);
            this.Gpb_buscarperfiles.TabIndex = 0;
            this.Gpb_buscarperfiles.TabStop = false;
            this.Gpb_buscarperfiles.Text = "Buscar Perfiles ";
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_buscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.Location = new System.Drawing.Point(544, 35);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(152, 66);
            this.Btn_buscar.TabIndex = 1;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = false;
            // 
            // Cbo_perfiles
            // 
            this.Cbo_perfiles.FormattingEnabled = true;
            this.Cbo_perfiles.Location = new System.Drawing.Point(32, 55);
            this.Cbo_perfiles.Name = "Cbo_perfiles";
            this.Cbo_perfiles.Size = new System.Drawing.Size(474, 28);
            this.Cbo_perfiles.TabIndex = 0;
            // 
            // Gpb_datosperfil
            // 
            this.Gpb_datosperfil.Controls.Add(this.Cbo_tipoperfil);
            this.Gpb_datosperfil.Controls.Add(this.Txt_descripcion);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_descripcion);
            this.Gpb_datosperfil.Controls.Add(this.Gbp_estado);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_tipoperfil);
            this.Gpb_datosperfil.Controls.Add(this.Txt_puesto);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_puesto);
            this.Gpb_datosperfil.Controls.Add(this.Txt_idperfil);
            this.Gpb_datosperfil.Controls.Add(this.Lbl_idpuesto);
            this.Gpb_datosperfil.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_datosperfil.Location = new System.Drawing.Point(12, 165);
            this.Gpb_datosperfil.Name = "Gpb_datosperfil";
            this.Gpb_datosperfil.Size = new System.Drawing.Size(733, 417);
            this.Gpb_datosperfil.TabIndex = 2;
            this.Gpb_datosperfil.TabStop = false;
            this.Gpb_datosperfil.Text = "Datos";
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(125, 142);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(525, 27);
            this.Txt_descripcion.TabIndex = 8;
            // 
            // Lbl_descripcion
            // 
            this.Lbl_descripcion.AutoSize = true;
            this.Lbl_descripcion.Location = new System.Drawing.Point(6, 148);
            this.Lbl_descripcion.Name = "Lbl_descripcion";
            this.Lbl_descripcion.Size = new System.Drawing.Size(104, 20);
            this.Lbl_descripcion.TabIndex = 7;
            this.Lbl_descripcion.Text = "Descripcion";
            // 
            // Gbp_estado
            // 
            this.Gbp_estado.Controls.Add(this.Rdb_inhabilitado);
            this.Gbp_estado.Controls.Add(this.Rdb_Habilitado);
            this.Gbp_estado.Location = new System.Drawing.Point(10, 249);
            this.Gbp_estado.Name = "Gbp_estado";
            this.Gbp_estado.Size = new System.Drawing.Size(595, 120);
            this.Gbp_estado.TabIndex = 6;
            this.Gbp_estado.TabStop = false;
            this.Gbp_estado.Text = "Estado";
            // 
            // Rdb_inhabilitado
            // 
            this.Rdb_inhabilitado.AutoSize = true;
            this.Rdb_inhabilitado.Location = new System.Drawing.Point(363, 54);
            this.Rdb_inhabilitado.Name = "Rdb_inhabilitado";
            this.Rdb_inhabilitado.Size = new System.Drawing.Size(123, 24);
            this.Rdb_inhabilitado.TabIndex = 2;
            this.Rdb_inhabilitado.TabStop = true;
            this.Rdb_inhabilitado.Text = "Inhabilitado";
            this.Rdb_inhabilitado.UseVisualStyleBackColor = true;
            // 
            // Rdb_Habilitado
            // 
            this.Rdb_Habilitado.AutoSize = true;
            this.Rdb_Habilitado.Location = new System.Drawing.Point(115, 54);
            this.Rdb_Habilitado.Name = "Rdb_Habilitado";
            this.Rdb_Habilitado.Size = new System.Drawing.Size(110, 24);
            this.Rdb_Habilitado.TabIndex = 1;
            this.Rdb_Habilitado.TabStop = true;
            this.Rdb_Habilitado.Text = "Habilitado";
            this.Rdb_Habilitado.UseVisualStyleBackColor = true;
            // 
            // Lbl_tipoperfil
            // 
            this.Lbl_tipoperfil.AutoSize = true;
            this.Lbl_tipoperfil.Location = new System.Drawing.Point(28, 195);
            this.Lbl_tipoperfil.Name = "Lbl_tipoperfil";
            this.Lbl_tipoperfil.Size = new System.Drawing.Size(44, 20);
            this.Lbl_tipoperfil.TabIndex = 5;
            this.Lbl_tipoperfil.Text = "Tipo";
            // 
            // Txt_puesto
            // 
            this.Txt_puesto.Location = new System.Drawing.Point(125, 91);
            this.Txt_puesto.Name = "Txt_puesto";
            this.Txt_puesto.Size = new System.Drawing.Size(525, 27);
            this.Txt_puesto.TabIndex = 3;
            // 
            // Lbl_puesto
            // 
            this.Lbl_puesto.AutoSize = true;
            this.Lbl_puesto.Location = new System.Drawing.Point(22, 94);
            this.Lbl_puesto.Name = "Lbl_puesto";
            this.Lbl_puesto.Size = new System.Drawing.Size(62, 20);
            this.Lbl_puesto.TabIndex = 2;
            this.Lbl_puesto.Text = "Puesto";
            // 
            // Txt_idperfil
            // 
            this.Txt_idperfil.Location = new System.Drawing.Point(125, 49);
            this.Txt_idperfil.Name = "Txt_idperfil";
            this.Txt_idperfil.Size = new System.Drawing.Size(525, 27);
            this.Txt_idperfil.TabIndex = 1;
            // 
            // Lbl_idpuesto
            // 
            this.Lbl_idpuesto.AutoSize = true;
            this.Lbl_idpuesto.Location = new System.Drawing.Point(6, 52);
            this.Lbl_idpuesto.Name = "Lbl_idpuesto";
            this.Lbl_idpuesto.Size = new System.Drawing.Size(113, 20);
            this.Lbl_idpuesto.TabIndex = 0;
            this.Lbl_idpuesto.Text = "Codigo Perfil";
            // 
            // Gbp_opc
            // 
            this.Gbp_opc.Controls.Add(this.Btn_salir);
            this.Gbp_opc.Controls.Add(this.Btn_cancelar);
            this.Gbp_opc.Controls.Add(this.Btn_modificar);
            this.Gbp_opc.Controls.Add(this.Btn_nuevo);
            this.Gbp_opc.Controls.Add(this.Btn_guardar);
            this.Gbp_opc.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbp_opc.Location = new System.Drawing.Point(751, 181);
            this.Gbp_opc.Name = "Gbp_opc";
            this.Gbp_opc.Size = new System.Drawing.Size(225, 401);
            this.Gbp_opc.TabIndex = 3;
            this.Gbp_opc.TabStop = false;
            this.Gbp_opc.Text = "Opciones";
            // 
            // Btn_salir
            // 
            this.Btn_salir.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir.Location = new System.Drawing.Point(54, 317);
            this.Btn_salir.Name = "Btn_salir";
            this.Btn_salir.Size = new System.Drawing.Size(138, 54);
            this.Btn_salir.TabIndex = 4;
            this.Btn_salir.Text = "Salir";
            this.Btn_salir.UseVisualStyleBackColor = false;
            this.Btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.Location = new System.Drawing.Point(54, 244);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(138, 54);
            this.Btn_cancelar.TabIndex = 3;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_modificar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_modificar.Location = new System.Drawing.Point(54, 171);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(138, 54);
            this.Btn_modificar.TabIndex = 2;
            this.Btn_modificar.Text = "Modificar";
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_nuevo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_nuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_nuevo.Location = new System.Drawing.Point(54, 30);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(138, 54);
            this.Btn_nuevo.TabIndex = 1;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_guardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.Location = new System.Drawing.Point(54, 98);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(138, 54);
            this.Btn_guardar.TabIndex = 0;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Cbo_tipoperfil
            // 
            this.Cbo_tipoperfil.FormattingEnabled = true;
            this.Cbo_tipoperfil.Location = new System.Drawing.Point(125, 195);
            this.Cbo_tipoperfil.Name = "Cbo_tipoperfil";
            this.Cbo_tipoperfil.Size = new System.Drawing.Size(525, 28);
            this.Cbo_tipoperfil.TabIndex = 2;
            // 
            // frmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(990, 609);
            this.Controls.Add(this.Gbp_opc);
            this.Controls.Add(this.Gpb_datosperfil);
            this.Controls.Add(this.Gpb_buscarperfiles);
            this.Name = "frmPerfiles";
            this.Text = "Perfiles";
            this.Gpb_buscarperfiles.ResumeLayout(false);
            this.Gpb_datosperfil.ResumeLayout(false);
            this.Gpb_datosperfil.PerformLayout();
            this.Gbp_estado.ResumeLayout(false);
            this.Gbp_estado.PerformLayout();
            this.Gbp_opc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_buscarperfiles;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.ComboBox Cbo_perfiles;
        private System.Windows.Forms.GroupBox Gpb_datosperfil;
        private System.Windows.Forms.Label Lbl_idpuesto;
        private System.Windows.Forms.TextBox Txt_idperfil;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label Lbl_descripcion;
        private System.Windows.Forms.GroupBox Gbp_estado;
        private System.Windows.Forms.RadioButton Rdb_inhabilitado;
        private System.Windows.Forms.RadioButton Rdb_Habilitado;
        private System.Windows.Forms.Label Lbl_tipoperfil;
        private System.Windows.Forms.TextBox Txt_puesto;
        private System.Windows.Forms.Label Lbl_puesto;
        private System.Windows.Forms.GroupBox Gbp_opc;
        private System.Windows.Forms.Button Btn_salir;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.ComboBox Cbo_tipoperfil;
    }
}