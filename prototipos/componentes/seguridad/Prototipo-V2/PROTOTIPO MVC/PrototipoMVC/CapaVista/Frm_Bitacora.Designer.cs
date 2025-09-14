// Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025

namespace CapaVista
{
    partial class Frm_Bitacora
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Btn_BuscarFecha = new System.Windows.Forms.Button();
            this.Btn_BuscarRango = new System.Windows.Forms.Button();
            this.Btn_BuscarUsuario = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Cerrar = new System.Windows.Forms.Button();
            this.Btn_Maximizar = new System.Windows.Forms.Button();
            this.Btn_Minimizar = new System.Windows.Forms.Button();
            this.Dgv_Bitacora = new System.Windows.Forms.DataGridView();
            this.Lbl_PrimeraFecha = new System.Windows.Forms.Label();
            this.Lbl_SegundaFecha = new System.Windows.Forms.Label();
            this.Dtp_PrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.Dtp_SegundaFecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaEspecifica = new System.Windows.Forms.Label();
            this.Dtp_FechaEspecifica = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Cbo_Usuario = new System.Windows.Forms.ComboBox();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Consultar.Location = new System.Drawing.Point(44, 49);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(122, 64);
            this.Btn_Consultar.TabIndex = 0;
            this.Btn_Consultar.Text = "Consultar";
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Exportar.Location = new System.Drawing.Point(223, 49);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(132, 64);
            this.Btn_Exportar.TabIndex = 1;
            this.Btn_Exportar.Text = "Exportar";
            this.Btn_Exportar.UseVisualStyleBackColor = true;
            this.Btn_Exportar.Click += new System.EventHandler(this.Btn_Exportar_Click);
            // 
            // Btn_BuscarFecha
            // 
            this.Btn_BuscarFecha.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_BuscarFecha.Location = new System.Drawing.Point(407, 50);
            this.Btn_BuscarFecha.Name = "Btn_BuscarFecha";
            this.Btn_BuscarFecha.Size = new System.Drawing.Size(204, 63);
            this.Btn_BuscarFecha.TabIndex = 2;
            this.Btn_BuscarFecha.Text = "Buscar por fecha";
            this.Btn_BuscarFecha.UseVisualStyleBackColor = true;
            this.Btn_BuscarFecha.Click += new System.EventHandler(this.Btn_BuscarFecha_Click);
            // 
            // Btn_BuscarRango
            // 
            this.Btn_BuscarRango.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_BuscarRango.Location = new System.Drawing.Point(996, 51);
            this.Btn_BuscarRango.Name = "Btn_BuscarRango";
            this.Btn_BuscarRango.Size = new System.Drawing.Size(273, 62);
            this.Btn_BuscarRango.TabIndex = 8;
            this.Btn_BuscarRango.Text = "Buscar por rango de fechas";
            this.Btn_BuscarRango.UseVisualStyleBackColor = true;
            this.Btn_BuscarRango.Click += new System.EventHandler(this.Btn_BuscarRango_Click);
            // 
            // Btn_BuscarUsuario
            // 
            this.Btn_BuscarUsuario.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_BuscarUsuario.Location = new System.Drawing.Point(660, 50);
            this.Btn_BuscarUsuario.Name = "Btn_BuscarUsuario";
            this.Btn_BuscarUsuario.Size = new System.Drawing.Size(246, 63);
            this.Btn_BuscarUsuario.TabIndex = 5;
            this.Btn_BuscarUsuario.Text = "Buscar por usuario";
            this.Btn_BuscarUsuario.UseVisualStyleBackColor = true;
            this.Btn_BuscarUsuario.Click += new System.EventHandler(this.Btn_BuscarUsuario_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Salir.Location = new System.Drawing.Point(1020, 478);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(115, 61);
            this.Btn_Salir.TabIndex = 14;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.Btn_Cerrar);
            this.panel1.Controls.Add(this.Btn_Maximizar);
            this.panel1.Controls.Add(this.Btn_Minimizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Rockwell", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 44);
            this.panel1.TabIndex = 6;
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Btn_Cerrar.FlatAppearance.BorderSize = 0;
            this.Btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cerrar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Cerrar.Location = new System.Drawing.Point(1242, 0);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(27, 44);
            this.Btn_Cerrar.TabIndex = 2;
            this.Btn_Cerrar.Text = "X";
            this.Btn_Cerrar.UseVisualStyleBackColor = true;
            this.Btn_Cerrar.Click += new System.EventHandler(this.Btn_Cerrar_Click);
            // 
            // Btn_Maximizar
            // 
            this.Btn_Maximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Maximizar.FlatAppearance.BorderSize = 0;
            this.Btn_Maximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Maximizar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Maximizar.Location = new System.Drawing.Point(1269, 0);
            this.Btn_Maximizar.Name = "Btn_Maximizar";
            this.Btn_Maximizar.Size = new System.Drawing.Size(31, 44);
            this.Btn_Maximizar.TabIndex = 1;
            this.Btn_Maximizar.Text = "□";
            this.Btn_Maximizar.UseVisualStyleBackColor = true;
            this.Btn_Maximizar.Click += new System.EventHandler(this.Btn_Maximizar_Click);
            // 
            // Btn_Minimizar
            // 
            this.Btn_Minimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Minimizar.FlatAppearance.BorderSize = 0;
            this.Btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Minimizar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Minimizar.Location = new System.Drawing.Point(1300, 0);
            this.Btn_Minimizar.Name = "Btn_Minimizar";
            this.Btn_Minimizar.Size = new System.Drawing.Size(30, 44);
            this.Btn_Minimizar.TabIndex = 0;
            this.Btn_Minimizar.Text = "-";
            this.Btn_Minimizar.UseVisualStyleBackColor = true;
            this.Btn_Minimizar.Click += new System.EventHandler(this.Btn_Minimizar_Click);
            // 
            // Dgv_Bitacora
            // 
            this.Dgv_Bitacora.AllowUserToAddRows = false;
            this.Dgv_Bitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Bitacora.Location = new System.Drawing.Point(12, 197);
            this.Dgv_Bitacora.Name = "Dgv_Bitacora";
            this.Dgv_Bitacora.ReadOnly = true;
            this.Dgv_Bitacora.RowHeadersWidth = 51;
            this.Dgv_Bitacora.RowTemplate.Height = 24;
            this.Dgv_Bitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Bitacora.Size = new System.Drawing.Size(986, 361);
            this.Dgv_Bitacora.TabIndex = 7;
            // 
            // Lbl_PrimeraFecha
            // 
            this.Lbl_PrimeraFecha.AutoSize = true;
            this.Lbl_PrimeraFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_PrimeraFecha.Location = new System.Drawing.Point(1017, 126);
            this.Lbl_PrimeraFecha.Name = "Lbl_PrimeraFecha";
            this.Lbl_PrimeraFecha.Size = new System.Drawing.Size(123, 20);
            this.Lbl_PrimeraFecha.TabIndex = 9;
            this.Lbl_PrimeraFecha.Text = "Primera Fecha";
            this.Lbl_PrimeraFecha.Visible = false;
            // 
            // Lbl_SegundaFecha
            // 
            this.Lbl_SegundaFecha.AutoSize = true;
            this.Lbl_SegundaFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_SegundaFecha.Location = new System.Drawing.Point(1017, 238);
            this.Lbl_SegundaFecha.Name = "Lbl_SegundaFecha";
            this.Lbl_SegundaFecha.Size = new System.Drawing.Size(128, 20);
            this.Lbl_SegundaFecha.TabIndex = 11;
            this.Lbl_SegundaFecha.Text = "Segunda Fecha";
            this.Lbl_SegundaFecha.Visible = false;
            // 
            // Dtp_PrimeraFecha
            // 
            this.Dtp_PrimeraFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_PrimeraFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_PrimeraFecha.Location = new System.Drawing.Point(1020, 158);
            this.Dtp_PrimeraFecha.Name = "Dtp_PrimeraFecha";
            this.Dtp_PrimeraFecha.Size = new System.Drawing.Size(180, 27);
            this.Dtp_PrimeraFecha.TabIndex = 10;
            this.Dtp_PrimeraFecha.Visible = false;
            // 
            // Dtp_SegundaFecha
            // 
            this.Dtp_SegundaFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_SegundaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_SegundaFecha.Location = new System.Drawing.Point(1020, 270);
            this.Dtp_SegundaFecha.Name = "Dtp_SegundaFecha";
            this.Dtp_SegundaFecha.Size = new System.Drawing.Size(180, 27);
            this.Dtp_SegundaFecha.TabIndex = 12;
            this.Dtp_SegundaFecha.Visible = false;
            // 
            // Lbl_FechaEspecifica
            // 
            this.Lbl_FechaEspecifica.AutoSize = true;
            this.Lbl_FechaEspecifica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_FechaEspecifica.Location = new System.Drawing.Point(479, 123);
            this.Lbl_FechaEspecifica.Name = "Lbl_FechaEspecifica";
            this.Lbl_FechaEspecifica.Size = new System.Drawing.Size(56, 20);
            this.Lbl_FechaEspecifica.TabIndex = 3;
            this.Lbl_FechaEspecifica.Text = "Fecha";
            this.Lbl_FechaEspecifica.Visible = false;
            // 
            // Dtp_FechaEspecifica
            // 
            this.Dtp_FechaEspecifica.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Dtp_FechaEspecifica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_FechaEspecifica.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FechaEspecifica.Location = new System.Drawing.Point(411, 156);
            this.Dtp_FechaEspecifica.Name = "Dtp_FechaEspecifica";
            this.Dtp_FechaEspecifica.Size = new System.Drawing.Size(180, 27);
            this.Dtp_FechaEspecifica.TabIndex = 4;
            this.Dtp_FechaEspecifica.Visible = false;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(737, 123);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(70, 20);
            this.Lbl_Usuario.TabIndex = 6;
            this.Lbl_Usuario.Text = "Usuario";
            this.Lbl_Usuario.Visible = false; // CORREGIDO
            // 
            // Cbo_Usuario
            // 
            this.Cbo_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Usuario.FormattingEnabled = true;
            this.Cbo_Usuario.Location = new System.Drawing.Point(679, 156);
            this.Cbo_Usuario.Name = "Cbo_Usuario";
            this.Cbo_Usuario.Size = new System.Drawing.Size(200, 25);
            this.Cbo_Usuario.TabIndex = 7;
            this.Cbo_Usuario.Visible = false; // CORREGIDO
            this.Cbo_Usuario.SelectedIndexChanged += new System.EventHandler(this.Cbo_Usuario_SelectedIndexChanged);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Imprimir.FlatAppearance.BorderSize = 0;
            this.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_Imprimir.Location = new System.Drawing.Point(1013, 357);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(127, 35);
            this.Btn_Imprimir.TabIndex = 13;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Frm_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 568);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Cbo_Usuario);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Dtp_FechaEspecifica);
            this.Controls.Add(this.Lbl_FechaEspecifica);
            this.Controls.Add(this.Dtp_SegundaFecha);
            this.Controls.Add(this.Dtp_PrimeraFecha);
            this.Controls.Add(this.Lbl_SegundaFecha);
            this.Controls.Add(this.Lbl_PrimeraFecha);
            this.Controls.Add(this.Dgv_Bitacora);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_BuscarUsuario);
            this.Controls.Add(this.Btn_BuscarRango);
            this.Controls.Add(this.Btn_BuscarFecha);
            this.Controls.Add(this.Btn_Exportar);
            this.Controls.Add(this.Btn_Consultar);
            this.Font = new System.Drawing.Font("Rockwell", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Bitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.Frm_Bitacora_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Exportar;
        private System.Windows.Forms.Button Btn_BuscarFecha;
        private System.Windows.Forms.Button Btn_BuscarRango;
        private System.Windows.Forms.Button Btn_BuscarUsuario;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Cerrar;
        private System.Windows.Forms.Button Btn_Maximizar;
        private System.Windows.Forms.Button Btn_Minimizar;
        private System.Windows.Forms.DataGridView Dgv_Bitacora;
        private System.Windows.Forms.Label Lbl_PrimeraFecha;
        private System.Windows.Forms.Label Lbl_SegundaFecha;
        private System.Windows.Forms.DateTimePicker Dtp_PrimeraFecha;
        private System.Windows.Forms.DateTimePicker Dtp_SegundaFecha;
        private System.Windows.Forms.Label Lbl_FechaEspecifica;
        private System.Windows.Forms.DateTimePicker Dtp_FechaEspecifica;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.ComboBox Cbo_Usuario;
        private System.Windows.Forms.Button Btn_Imprimir;
    }
}
