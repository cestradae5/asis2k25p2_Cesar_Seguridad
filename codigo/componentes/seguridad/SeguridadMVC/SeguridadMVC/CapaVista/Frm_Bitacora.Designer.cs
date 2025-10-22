
namespace Capa_Vista_Seguridad
{
    partial class Frm_Bitacora
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
            this.Dgv_Bitacora = new System.Windows.Forms.DataGridView();
            this.Lbl_PrimeraFecha = new System.Windows.Forms.Label();
            this.Lbl_SegundaFecha = new System.Windows.Forms.Label();
            this.Dtp_PrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.Dtp_SegundaFecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaEspecifica = new System.Windows.Forms.Label();
            this.Dtp_FechaEspecifica = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Cbo_Usuario = new System.Windows.Forms.ComboBox();
            this.Pnl_Superior = new System.Windows.Forms.Panel();
            this.Pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_BuscarUsuario = new System.Windows.Forms.Button();
            this.Btn_BuscarRango = new System.Windows.Forms.Button();
            this.Btn_BuscarFecha = new System.Windows.Forms.Button();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Gpb_bitacora = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).BeginInit();
            this.Pnl_Superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).BeginInit();
            this.Gpb_bitacora.SuspendLayout();
            this.SuspendLayout();
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
            this.Lbl_PrimeraFecha.Size = new System.Drawing.Size(141, 22);
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
            this.Lbl_SegundaFecha.Size = new System.Drawing.Size(150, 22);
            this.Lbl_SegundaFecha.TabIndex = 11;
            this.Lbl_SegundaFecha.Text = "Segunda Fecha";
            this.Lbl_SegundaFecha.Visible = false;
            // 
            // Dtp_PrimeraFecha
            // 
            this.Dtp_PrimeraFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Dtp_PrimeraFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_PrimeraFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_PrimeraFecha.Location = new System.Drawing.Point(1020, 158);
            this.Dtp_PrimeraFecha.Name = "Dtp_PrimeraFecha";
            this.Dtp_PrimeraFecha.Size = new System.Drawing.Size(180, 31);
            this.Dtp_PrimeraFecha.TabIndex = 10;
            this.Dtp_PrimeraFecha.Visible = false;
            // 
            // Dtp_SegundaFecha
            // 
            this.Dtp_SegundaFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Dtp_SegundaFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_SegundaFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_SegundaFecha.Location = new System.Drawing.Point(1020, 270);
            this.Dtp_SegundaFecha.Name = "Dtp_SegundaFecha";
            this.Dtp_SegundaFecha.Size = new System.Drawing.Size(180, 31);
            this.Dtp_SegundaFecha.TabIndex = 12;
            this.Dtp_SegundaFecha.Visible = false;
            // 
            // Lbl_FechaEspecifica
            // 
            this.Lbl_FechaEspecifica.AutoSize = true;
            this.Lbl_FechaEspecifica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_FechaEspecifica.Location = new System.Drawing.Point(479, 123);
            this.Lbl_FechaEspecifica.Name = "Lbl_FechaEspecifica";
            this.Lbl_FechaEspecifica.Size = new System.Drawing.Size(64, 22);
            this.Lbl_FechaEspecifica.TabIndex = 3;
            this.Lbl_FechaEspecifica.Text = "Fecha";
            this.Lbl_FechaEspecifica.Visible = false;
            // 
            // Dtp_FechaEspecifica
            // 
            this.Dtp_FechaEspecifica.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Dtp_FechaEspecifica.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Dtp_FechaEspecifica.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Dtp_FechaEspecifica.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FechaEspecifica.Location = new System.Drawing.Point(411, 156);
            this.Dtp_FechaEspecifica.Name = "Dtp_FechaEspecifica";
            this.Dtp_FechaEspecifica.Size = new System.Drawing.Size(180, 31);
            this.Dtp_FechaEspecifica.TabIndex = 4;
            this.Dtp_FechaEspecifica.Visible = false;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(737, 123);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(80, 22);
            this.Lbl_Usuario.TabIndex = 6;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Cbo_Usuario
            // 
            this.Cbo_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.Cbo_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Usuario.FormattingEnabled = true;
            this.Cbo_Usuario.Location = new System.Drawing.Point(679, 156);
            this.Cbo_Usuario.Name = "Cbo_Usuario";
            this.Cbo_Usuario.Size = new System.Drawing.Size(200, 28);
            this.Cbo_Usuario.TabIndex = 7;
            this.Cbo_Usuario.SelectedIndexChanged += new System.EventHandler(this.Cbo_Usuario_SelectedIndexChanged);
            // 
            // Pnl_Superior
            // 
            this.Pnl_Superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Pnl_Superior.Controls.Add(this.Pic_Cerrar);
            this.Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Superior.Name = "Pnl_Superior";
            this.Pnl_Superior.Size = new System.Drawing.Size(1330, 44);
            this.Pnl_Superior.TabIndex = 95;
            this.Pnl_Superior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_Superior_MouseDown);
            // 
            // Pic_Cerrar
            // 
            this.Pic_Cerrar.BackColor = System.Drawing.Color.Transparent;
            this.Pic_Cerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pic_Cerrar.Image = global::Capa_Vista_Seguridad.Properties.Resources.Cancel_icon_icons_com_73703;
            this.Pic_Cerrar.Location = new System.Drawing.Point(1293, 0);
            this.Pic_Cerrar.Name = "Pic_Cerrar";
            this.Pic_Cerrar.Size = new System.Drawing.Size(37, 44);
            this.Pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic_Cerrar.TabIndex = 0;
            this.Pic_Cerrar.TabStop = false;
            this.Pic_Cerrar.Click += new System.EventHandler(this.Pic_Cerrar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.button1.Font = new System.Drawing.Font("Rockwell", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.button1.Image = global::Capa_Vista_Seguridad.Properties.Resources.exportar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(1162, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 61);
            this.button1.TabIndex = 96;
            this.button1.Text = "Reporte";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Imprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Imprimir.FlatAppearance.BorderSize = 0;
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Imprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Imprimir.Image = global::Capa_Vista_Seguridad.Properties.Resources.print_black_printer_tool_symbol_icon_icons_com_54467;
            this.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Imprimir.Location = new System.Drawing.Point(18, 26);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(114, 61);
            this.Btn_Imprimir.TabIndex = 13;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Imprimir.UseVisualStyleBackColor = false;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Salir.Image = global::Capa_Vista_Seguridad.Properties.Resources.sign_emergency_code_sos_61_icon_icons_com_57216;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Salir.Location = new System.Drawing.Point(1026, 457);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(115, 61);
            this.Btn_Salir.TabIndex = 14;
            this.Btn_Salir.Text = "   Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_BuscarUsuario
            // 
            this.Btn_BuscarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_BuscarUsuario.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_BuscarUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_BuscarUsuario.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons1;
            this.Btn_BuscarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_BuscarUsuario.Location = new System.Drawing.Point(679, 51);
            this.Btn_BuscarUsuario.Name = "Btn_BuscarUsuario";
            this.Btn_BuscarUsuario.Size = new System.Drawing.Size(241, 63);
            this.Btn_BuscarUsuario.TabIndex = 5;
            this.Btn_BuscarUsuario.Text = "  Buscar por usuario";
            this.Btn_BuscarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_BuscarUsuario.UseVisualStyleBackColor = false;
            this.Btn_BuscarUsuario.Click += new System.EventHandler(this.Btn_BuscarUsuario_Click);
            // 
            // Btn_BuscarRango
            // 
            this.Btn_BuscarRango.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_BuscarRango.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_BuscarRango.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_BuscarRango.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons1;
            this.Btn_BuscarRango.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_BuscarRango.Location = new System.Drawing.Point(996, 51);
            this.Btn_BuscarRango.Name = "Btn_BuscarRango";
            this.Btn_BuscarRango.Size = new System.Drawing.Size(299, 62);
            this.Btn_BuscarRango.TabIndex = 8;
            this.Btn_BuscarRango.Text = " Buscar por rango de fechas";
            this.Btn_BuscarRango.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_BuscarRango.UseVisualStyleBackColor = false;
            this.Btn_BuscarRango.Click += new System.EventHandler(this.Btn_BuscarRango_Click);
            // 
            // Btn_BuscarFecha
            // 
            this.Btn_BuscarFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_BuscarFecha.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_BuscarFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_BuscarFecha.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons1;
            this.Btn_BuscarFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_BuscarFecha.Location = new System.Drawing.Point(407, 50);
            this.Btn_BuscarFecha.Name = "Btn_BuscarFecha";
            this.Btn_BuscarFecha.Size = new System.Drawing.Size(204, 63);
            this.Btn_BuscarFecha.TabIndex = 2;
            this.Btn_BuscarFecha.Text = "  Buscar por fecha";
            this.Btn_BuscarFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_BuscarFecha.UseVisualStyleBackColor = false;
            this.Btn_BuscarFecha.Click += new System.EventHandler(this.Btn_BuscarFecha_Click);
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Exportar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Exportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Exportar.Image = global::Capa_Vista_Seguridad.Properties.Resources.exportar;
            this.Btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Exportar.Location = new System.Drawing.Point(235, 51);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(153, 64);
            this.Btn_Exportar.TabIndex = 1;
            this.Btn_Exportar.Text = "  Exportar";
            this.Btn_Exportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Exportar.UseVisualStyleBackColor = false;
            this.Btn_Exportar.Click += new System.EventHandler(this.Btn_Exportar_Click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(78)))), ((int)(((byte)(88)))));
            this.Btn_Consultar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Consultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(214)))), ((int)(((byte)(221)))));
            this.Btn_Consultar.Image = global::Capa_Vista_Seguridad.Properties.Resources.android_search_icon_icons_com_50501;
            this.Btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Consultar.Location = new System.Drawing.Point(12, 51);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(205, 64);
            this.Btn_Consultar.TabIndex = 0;
            this.Btn_Consultar.Text = "Ver toda la Bitacora";
            this.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Gpb_bitacora
            // 
            this.Gpb_bitacora.Controls.Add(this.Btn_Imprimir);
            this.Gpb_bitacora.Location = new System.Drawing.Point(1009, 336);
            this.Gpb_bitacora.Name = "Gpb_bitacora";
            this.Gpb_bitacora.Size = new System.Drawing.Size(309, 202);
            this.Gpb_bitacora.TabIndex = 97;
            this.Gpb_bitacora.TabStop = false;
            // 
            // Frm_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1330, 568);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Pnl_Superior);
            this.Controls.Add(this.Cbo_Usuario);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Dtp_FechaEspecifica);
            this.Controls.Add(this.Lbl_FechaEspecifica);
            this.Controls.Add(this.Dtp_SegundaFecha);
            this.Controls.Add(this.Dtp_PrimeraFecha);
            this.Controls.Add(this.Lbl_SegundaFecha);
            this.Controls.Add(this.Lbl_PrimeraFecha);
            this.Controls.Add(this.Dgv_Bitacora);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_BuscarUsuario);
            this.Controls.Add(this.Btn_BuscarRango);
            this.Controls.Add(this.Btn_BuscarFecha);
            this.Controls.Add(this.Btn_Exportar);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Gpb_bitacora);
            this.Font = new System.Drawing.Font("Rockwell", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "Frm_Bitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitacora";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).EndInit();
            this.Pnl_Superior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Cerrar)).EndInit();
            this.Gpb_bitacora.ResumeLayout(false);
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
        private System.Windows.Forms.Panel Pnl_Superior;
        private System.Windows.Forms.PictureBox Pic_Cerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox Gpb_bitacora;
    }
}