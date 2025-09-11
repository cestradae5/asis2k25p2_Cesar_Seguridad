
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
            this.txt_Consulta = new System.Windows.Forms.TextBox();
            this.lbl_Cadena_Generada = new System.Windows.Forms.Label();
            this.lbl_Query = new System.Windows.Forms.Label();
            this.btnQuitarCampo = new System.Windows.Forms.Button();
            this.cbo_Query = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Mstp_Consultas = new System.Windows.Forms.MenuStrip();
            this.creaciònToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpb_Listado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Mstp_Consultas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpb_Listado
            // 
            this.gpb_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_Listado.Controls.Add(this.txt_Consulta);
            this.gpb_Listado.Controls.Add(this.lbl_Cadena_Generada);
            this.gpb_Listado.Controls.Add(this.lbl_Query);
            this.gpb_Listado.Controls.Add(this.btnQuitarCampo);
            this.gpb_Listado.Controls.Add(this.cbo_Query);
            this.gpb_Listado.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_Listado.Location = new System.Drawing.Point(0, 26);
            this.gpb_Listado.Name = "gpb_Listado";
            this.gpb_Listado.Size = new System.Drawing.Size(754, 115);
            this.gpb_Listado.TabIndex = 5;
            this.gpb_Listado.TabStop = false;
            this.gpb_Listado.Text = "Listado";
            // 
            // txt_Consulta
            // 
            this.txt_Consulta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_Consulta.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Consulta.Location = new System.Drawing.Point(250, 66);
            this.txt_Consulta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Consulta.Name = "txt_Consulta";
            this.txt_Consulta.ReadOnly = true;
            this.txt_Consulta.Size = new System.Drawing.Size(330, 23);
            this.txt_Consulta.TabIndex = 8;
            // 
            // lbl_Cadena_Generada
            // 
            this.lbl_Cadena_Generada.AutoSize = true;
            this.lbl_Cadena_Generada.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cadena_Generada.Location = new System.Drawing.Point(248, 45);
            this.lbl_Cadena_Generada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Cadena_Generada.Name = "lbl_Cadena_Generada";
            this.lbl_Cadena_Generada.Size = new System.Drawing.Size(136, 17);
            this.lbl_Cadena_Generada.TabIndex = 7;
            this.lbl_Cadena_Generada.Text = "Cadena Generada";
            // 
            // lbl_Query
            // 
            this.lbl_Query.AutoSize = true;
            this.lbl_Query.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Query.Location = new System.Drawing.Point(37, 45);
            this.lbl_Query.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Query.Name = "lbl_Query";
            this.lbl_Query.Size = new System.Drawing.Size(52, 17);
            this.lbl_Query.TabIndex = 6;
            this.lbl_Query.Text = "Query";
            // 
            // btnQuitarCampo
            // 
            this.btnQuitarCampo.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarCampo.Image = global::Capa_Vista_Componente_Consultas.Properties.Resources.android_search_icon_icons_com_50501;
            this.btnQuitarCampo.Location = new System.Drawing.Point(628, 36);
            this.btnQuitarCampo.Name = "btnQuitarCampo";
            this.btnQuitarCampo.Size = new System.Drawing.Size(70, 60);
            this.btnQuitarCampo.TabIndex = 5;
            this.btnQuitarCampo.Text = "Buscar";
            this.btnQuitarCampo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarCampo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnQuitarCampo.UseCompatibleTextRendering = true;
            this.btnQuitarCampo.UseVisualStyleBackColor = true;
            // 
            // cbo_Query
            // 
            this.cbo_Query.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Query.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Query.FormattingEnabled = true;
            this.cbo_Query.Location = new System.Drawing.Point(40, 65);
            this.cbo_Query.Name = "cbo_Query";
            this.cbo_Query.Size = new System.Drawing.Size(158, 25);
            this.cbo_Query.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 147);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(671, 315);
            this.dataGridView1.TabIndex = 6;
            // 
            // Mstp_Consultas
            // 
            this.Mstp_Consultas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Mstp_Consultas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaciònToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.Mstp_Consultas.Location = new System.Drawing.Point(0, 0);
            this.Mstp_Consultas.Name = "Mstp_Consultas";
            this.Mstp_Consultas.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.Mstp_Consultas.Size = new System.Drawing.Size(759, 25);
            this.Mstp_Consultas.TabIndex = 9;
            this.Mstp_Consultas.Text = "menuStrip1";
            // 
            // creaciònToolStripMenuItem
            // 
            this.creaciònToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creaciònToolStripMenuItem.Name = "creaciònToolStripMenuItem";
            this.creaciònToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.creaciònToolStripMenuItem.Text = "Creación";
            this.creaciònToolStripMenuItem.Click += new System.EventHandler(this.creaciònToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // Frm_Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 472);
            this.Controls.Add(this.Mstp_Consultas);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gpb_Listado);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm_Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Consultas";
            this.gpb_Listado.ResumeLayout(false);
            this.gpb_Listado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Mstp_Consultas.ResumeLayout(false);
            this.Mstp_Consultas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpb_Listado;
        private System.Windows.Forms.Button btnQuitarCampo;
        private System.Windows.Forms.ComboBox cbo_Query;
        private System.Windows.Forms.TextBox txt_Consulta;
        private System.Windows.Forms.Label lbl_Cadena_Generada;
        private System.Windows.Forms.Label lbl_Query;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip Mstp_Consultas;
        private System.Windows.Forms.ToolStripMenuItem creaciònToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
    }
}