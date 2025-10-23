
namespace Capa_Vista_Componente_Consultas
{
    partial class Frm_Consultas
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
            this.gpb_Listado = new System.Windows.Forms.GroupBox();
            this.Gpb_Ordenamiento = new System.Windows.Forms.GroupBox();
            this.ASC = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txt_Consulta = new System.Windows.Forms.TextBox();
            this.lbl_Cadena_Generada = new System.Windows.Forms.Label();
            this.lbl_Query = new System.Windows.Forms.Label();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.cbo_Query = new System.Windows.Forms.ComboBox();
            this.dgv_consultas_simples = new System.Windows.Forms.DataGridView();
            this.Mstp_Consultas = new System.Windows.Forms.MenuStrip();
            this.btn_min = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_max = new System.Windows.Forms.Button();
            this.gpb_Listado.SuspendLayout();
            this.Gpb_Ordenamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultas_simples)).BeginInit();
            this.SuspendLayout();
            // 
            // gpb_Listado
            // 
            this.gpb_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_Listado.Controls.Add(this.Gpb_Ordenamiento);
            this.gpb_Listado.Controls.Add(this.txt_Consulta);
            this.gpb_Listado.Controls.Add(this.lbl_Cadena_Generada);
            this.gpb_Listado.Controls.Add(this.lbl_Query);
            this.gpb_Listado.Controls.Add(this.Btn_buscar);
            this.gpb_Listado.Controls.Add(this.cbo_Query);
            this.gpb_Listado.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_Listado.Location = new System.Drawing.Point(0, 32);
            this.gpb_Listado.Margin = new System.Windows.Forms.Padding(4);
            this.gpb_Listado.Name = "gpb_Listado";
            this.gpb_Listado.Padding = new System.Windows.Forms.Padding(4);
            this.gpb_Listado.Size = new System.Drawing.Size(1071, 142);
            this.gpb_Listado.TabIndex = 5;
            this.gpb_Listado.TabStop = false;
            this.gpb_Listado.Text = "Consultas Simples";
            // 
            // Gpb_Ordenamiento
            // 
            this.Gpb_Ordenamiento.Controls.Add(this.ASC);
            this.Gpb_Ordenamiento.Controls.Add(this.radioButton1);
            this.Gpb_Ordenamiento.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Gpb_Ordenamiento.Location = new System.Drawing.Point(603, 43);
            this.Gpb_Ordenamiento.Margin = new System.Windows.Forms.Padding(4);
            this.Gpb_Ordenamiento.Name = "Gpb_Ordenamiento";
            this.Gpb_Ordenamiento.Padding = new System.Windows.Forms.Padding(4);
            this.Gpb_Ordenamiento.Size = new System.Drawing.Size(232, 91);
            this.Gpb_Ordenamiento.TabIndex = 26;
            this.Gpb_Ordenamiento.TabStop = false;
            this.Gpb_Ordenamiento.Text = "Ordenamiento";
            // 
            // ASC
            // 
            this.ASC.AutoSize = true;
            this.ASC.Font = new System.Drawing.Font("Rockwell", 11F);
            this.ASC.Location = new System.Drawing.Point(27, 48);
            this.ASC.Margin = new System.Windows.Forms.Padding(4);
            this.ASC.Name = "ASC";
            this.ASC.Size = new System.Drawing.Size(68, 25);
            this.ASC.TabIndex = 10;
            this.ASC.TabStop = true;
            this.ASC.Text = "ASC";
            this.ASC.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Rockwell", 11F);
            this.radioButton1.Location = new System.Drawing.Point(125, 48);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 25);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DESC";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txt_Consulta
            // 
            this.txt_Consulta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Consulta.Font = new System.Drawing.Font("Rockwell", 10F);
            this.txt_Consulta.Location = new System.Drawing.Point(224, 90);
            this.txt_Consulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Consulta.Name = "txt_Consulta";
            this.txt_Consulta.ReadOnly = true;
            this.txt_Consulta.Size = new System.Drawing.Size(371, 27);
            this.txt_Consulta.TabIndex = 8;
            // 
            // lbl_Cadena_Generada
            // 
            this.lbl_Cadena_Generada.AutoSize = true;
            this.lbl_Cadena_Generada.Font = new System.Drawing.Font("Rockwell", 11F);
            this.lbl_Cadena_Generada.Location = new System.Drawing.Point(220, 49);
            this.lbl_Cadena_Generada.Name = "lbl_Cadena_Generada";
            this.lbl_Cadena_Generada.Size = new System.Drawing.Size(171, 21);
            this.lbl_Cadena_Generada.TabIndex = 7;
            this.lbl_Cadena_Generada.Text = "Cadena Generada";
            // 
            // lbl_Query
            // 
            this.lbl_Query.AutoSize = true;
            this.lbl_Query.Font = new System.Drawing.Font("Rockwell", 11F);
            this.lbl_Query.Location = new System.Drawing.Point(15, 49);
            this.lbl_Query.Name = "lbl_Query";
            this.lbl_Query.Size = new System.Drawing.Size(185, 21);
            this.lbl_Query.TabIndex = 6;
            this.lbl_Query.Text = "Nombre de la tabla ";
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Btn_buscar.Image = global::Capa_Vista_Componente_Consultas.Properties.Resources.android_search_icon_icons_com_50501;
            this.Btn_buscar.Location = new System.Drawing.Point(843, 43);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(95, 75);
            this.Btn_buscar.TabIndex = 5;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Btn_buscar.UseCompatibleTextRendering = true;
            this.Btn_buscar.UseVisualStyleBackColor = true;
            // 
            // cbo_Query
            // 
            this.cbo_Query.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Query.Font = new System.Drawing.Font("Rockwell", 10F);
            this.cbo_Query.FormattingEnabled = true;
            this.cbo_Query.Location = new System.Drawing.Point(16, 87);
            this.cbo_Query.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_Query.Name = "cbo_Query";
            this.cbo_Query.Size = new System.Drawing.Size(188, 28);
            this.cbo_Query.TabIndex = 0;
            // 
            // dgv_consultas_simples
            // 
            this.dgv_consultas_simples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consultas_simples.Location = new System.Drawing.Point(16, 182);
            this.dgv_consultas_simples.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_consultas_simples.Name = "dgv_consultas_simples";
            this.dgv_consultas_simples.RowHeadersWidth = 51;
            this.dgv_consultas_simples.RowTemplate.Height = 24;
            this.dgv_consultas_simples.Size = new System.Drawing.Size(1008, 388);
            this.dgv_consultas_simples.TabIndex = 6;
            // 
            // Mstp_Consultas
            // 
            this.Mstp_Consultas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Mstp_Consultas.Location = new System.Drawing.Point(0, 0);
            this.Mstp_Consultas.Name = "Mstp_Consultas";
            this.Mstp_Consultas.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.Mstp_Consultas.Size = new System.Drawing.Size(1077, 24);
            this.Mstp_Consultas.TabIndex = 9;
            this.Mstp_Consultas.Text = "menuStrip1";
            // 
            // btn_min
            // 
            this.btn_min.Location = new System.Drawing.Point(976, 1);
            this.btn_min.Margin = new System.Windows.Forms.Padding(4);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(85, 28);
            this.btn_min.TabIndex = 14;
            this.btn_min.Text = "Minimizar";
            this.btn_min.UseVisualStyleBackColor = true;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(781, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 28);
            this.button1.TabIndex = 15;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 30);
            this.button2.TabIndex = 16;
            this.button2.Text = "Consulta Compleja";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_max
            // 
            this.btn_max.Location = new System.Drawing.Point(884, 2);
            this.btn_max.Margin = new System.Windows.Forms.Padding(4);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(84, 28);
            this.btn_max.TabIndex = 25;
            this.btn_max.Text = "Maximizar";
            this.btn_max.UseVisualStyleBackColor = true;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // Frm_Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 581);
            this.ControlBox = false;
            this.Controls.Add(this.gpb_Listado);
            this.Controls.Add(this.btn_max);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_min);
            this.Controls.Add(this.Mstp_Consultas);
            this.Controls.Add(this.dgv_consultas_simples);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Consultas";
            this.gpb_Listado.ResumeLayout(false);
            this.gpb_Listado.PerformLayout();
            this.Gpb_Ordenamiento.ResumeLayout(false);
            this.Gpb_Ordenamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultas_simples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_Listado;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.ComboBox cbo_Query;
        private System.Windows.Forms.TextBox txt_Consulta;
        private System.Windows.Forms.Label lbl_Cadena_Generada;
        private System.Windows.Forms.Label lbl_Query;
        private System.Windows.Forms.DataGridView dgv_consultas_simples;
        private System.Windows.Forms.MenuStrip Mstp_Consultas;
        private System.Windows.Forms.Button btn_min;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_max;
        private System.Windows.Forms.RadioButton ASC;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox Gpb_Ordenamiento;
    }
}