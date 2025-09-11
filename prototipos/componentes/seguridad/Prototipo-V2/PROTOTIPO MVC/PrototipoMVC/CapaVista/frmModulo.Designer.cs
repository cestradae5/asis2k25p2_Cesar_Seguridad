
namespace CapaVista
{
    partial class frmModulo
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
            this.Lbl_id = new System.Windows.Forms.Label();
            this.Lbl_nombre = new System.Windows.Forms.Label();
            this.Lbl_descripcion = new System.Windows.Forms.Label();
            this.Lbl_modulo = new System.Windows.Forms.Label();
            this.Lbl_estado = new System.Windows.Forms.Label();
            this.Rdb_habilitado = new System.Windows.Forms.RadioButton();
            this.Txt_id = new System.Windows.Forms.TextBox();
            this.Txt_nombre = new System.Windows.Forms.TextBox();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Lbl_busqueda = new System.Windows.Forms.Label();
            this.Cbo_busqueda = new System.Windows.Forms.ComboBox();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Rdb_inabilitado = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Lbl_id
            // 
            this.Lbl_id.AutoSize = true;
            this.Lbl_id.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Lbl_id.Location = new System.Drawing.Point(116, 116);
            this.Lbl_id.Name = "Lbl_id";
            this.Lbl_id.Size = new System.Drawing.Size(21, 17);
            this.Lbl_id.TabIndex = 0;
            this.Lbl_id.Text = "Id";
            // 
            // Lbl_nombre
            // 
            this.Lbl_nombre.AutoSize = true;
            this.Lbl_nombre.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Lbl_nombre.Location = new System.Drawing.Point(320, 116);
            this.Lbl_nombre.Name = "Lbl_nombre";
            this.Lbl_nombre.Size = new System.Drawing.Size(61, 17);
            this.Lbl_nombre.TabIndex = 1;
            this.Lbl_nombre.Text = "Nombre";
            // 
            // Lbl_descripcion
            // 
            this.Lbl_descripcion.AutoSize = true;
            this.Lbl_descripcion.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Lbl_descripcion.Location = new System.Drawing.Point(303, 184);
            this.Lbl_descripcion.Name = "Lbl_descripcion";
            this.Lbl_descripcion.Size = new System.Drawing.Size(85, 17);
            this.Lbl_descripcion.TabIndex = 2;
            this.Lbl_descripcion.Text = "Descripcion";
            // 
            // Lbl_modulo
            // 
            this.Lbl_modulo.AutoSize = true;
            this.Lbl_modulo.Font = new System.Drawing.Font("Rockwell", 18F);
            this.Lbl_modulo.Location = new System.Drawing.Point(328, 43);
            this.Lbl_modulo.Name = "Lbl_modulo";
            this.Lbl_modulo.Size = new System.Drawing.Size(108, 27);
            this.Lbl_modulo.TabIndex = 3;
            this.Lbl_modulo.Text = "Modulos";
            // 
            // Lbl_estado
            // 
            this.Lbl_estado.AutoSize = true;
            this.Lbl_estado.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Lbl_estado.Location = new System.Drawing.Point(116, 184);
            this.Lbl_estado.Name = "Lbl_estado";
            this.Lbl_estado.Size = new System.Drawing.Size(129, 17);
            this.Lbl_estado.TabIndex = 4;
            this.Lbl_estado.Text = "Estado del modulo";
            // 
            // Rdb_habilitado
            // 
            this.Rdb_habilitado.AutoSize = true;
            this.Rdb_habilitado.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Rdb_habilitado.Location = new System.Drawing.Point(119, 215);
            this.Rdb_habilitado.Name = "Rdb_habilitado";
            this.Rdb_habilitado.Size = new System.Drawing.Size(92, 21);
            this.Rdb_habilitado.TabIndex = 5;
            this.Rdb_habilitado.TabStop = true;
            this.Rdb_habilitado.Text = "Habilitado";
            this.Rdb_habilitado.UseVisualStyleBackColor = true;
            // 
            // Txt_id
            // 
            this.Txt_id.Location = new System.Drawing.Point(172, 116);
            this.Txt_id.Name = "Txt_id";
            this.Txt_id.Size = new System.Drawing.Size(100, 20);
            this.Txt_id.TabIndex = 7;
            // 
            // Txt_nombre
            // 
            this.Txt_nombre.Location = new System.Drawing.Point(402, 116);
            this.Txt_nombre.Name = "Txt_nombre";
            this.Txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.Txt_nombre.TabIndex = 8;
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(401, 181);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.Size = new System.Drawing.Size(176, 20);
            this.Txt_descripcion.TabIndex = 10;
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Location = new System.Drawing.Point(469, 259);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_guardar.TabIndex = 11;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = true;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.Location = new System.Drawing.Point(388, 259);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.Btn_nuevo.TabIndex = 12;
            this.Btn_nuevo.Text = "Limpiar";
            this.Btn_nuevo.UseVisualStyleBackColor = true;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Location = new System.Drawing.Point(550, 259);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.Btn_eliminar.TabIndex = 13;
            this.Btn_eliminar.Text = "Elmininar";
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Lbl_busqueda
            // 
            this.Lbl_busqueda.AutoSize = true;
            this.Lbl_busqueda.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Lbl_busqueda.Location = new System.Drawing.Point(585, 95);
            this.Lbl_busqueda.Name = "Lbl_busqueda";
            this.Lbl_busqueda.Size = new System.Drawing.Size(71, 17);
            this.Lbl_busqueda.TabIndex = 14;
            this.Lbl_busqueda.Text = "Busqueda";
            // 
            // Cbo_busqueda
            // 
            this.Cbo_busqueda.FormattingEnabled = true;
            this.Cbo_busqueda.Location = new System.Drawing.Point(588, 115);
            this.Cbo_busqueda.Name = "Cbo_busqueda";
            this.Cbo_busqueda.Size = new System.Drawing.Size(121, 21);
            this.Cbo_busqueda.TabIndex = 15;
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Location = new System.Drawing.Point(715, 113);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.Btn_buscar.TabIndex = 16;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Rdb_inabilitado
            // 
            this.Rdb_inabilitado.AutoSize = true;
            this.Rdb_inabilitado.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Rdb_inabilitado.Location = new System.Drawing.Point(118, 238);
            this.Rdb_inabilitado.Name = "Rdb_inabilitado";
            this.Rdb_inabilitado.Size = new System.Drawing.Size(94, 21);
            this.Rdb_inabilitado.TabIndex = 6;
            this.Rdb_inabilitado.TabStop = true;
            this.Rdb_inabilitado.Text = "Inabilitado";
            this.Rdb_inabilitado.UseVisualStyleBackColor = true;
            // 
            // frmModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 338);
            this.Controls.Add(this.Btn_buscar);
            this.Controls.Add(this.Cbo_busqueda);
            this.Controls.Add(this.Lbl_busqueda);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.Txt_descripcion);
            this.Controls.Add(this.Txt_nombre);
            this.Controls.Add(this.Txt_id);
            this.Controls.Add(this.Rdb_inabilitado);
            this.Controls.Add(this.Rdb_habilitado);
            this.Controls.Add(this.Lbl_estado);
            this.Controls.Add(this.Lbl_modulo);
            this.Controls.Add(this.Lbl_descripcion);
            this.Controls.Add(this.Lbl_nombre);
            this.Controls.Add(this.Lbl_id);
            this.Name = "frmModulo";
            this.Text = "frmModulo";
            this.Load += new System.EventHandler(this.frmModulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_id;
        private System.Windows.Forms.Label Lbl_nombre;
        private System.Windows.Forms.Label Lbl_descripcion;
        private System.Windows.Forms.Label Lbl_modulo;
        private System.Windows.Forms.Label Lbl_estado;
        private System.Windows.Forms.RadioButton Rdb_habilitado;
        private System.Windows.Forms.TextBox Txt_id;
        private System.Windows.Forms.TextBox Txt_nombre;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Label Lbl_busqueda;
        private System.Windows.Forms.ComboBox Cbo_busqueda;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.RadioButton Rdb_inabilitado;
    }
}