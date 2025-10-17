
namespace Capa_Vista_Componente_Consultas_simples
{
    partial class Consulta_simple
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Filtrar = new System.Windows.Forms.Button();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Gpb_Listado = new System.Windows.Forms.GroupBox();
            this.Lbl_Valor = new System.Windows.Forms.Label();
            this.Lbl_Operador = new System.Windows.Forms.Label();
            this.Lbl_Campos = new System.Windows.Forms.Label();
            this.Cbo_Operador = new System.Windows.Forms.ComboBox();
            this.Cbo_Campos = new System.Windows.Forms.ComboBox();
            this.Txt_Filtro = new System.Windows.Forms.TextBox();
            this.Gpb_Ordenamiento = new System.Windows.Forms.GroupBox();
            this.Rdb_asc = new System.Windows.Forms.RadioButton();
            this.Rdb_desc = new System.Windows.Forms.RadioButton();
            this.Dgv_consultas_simples = new System.Windows.Forms.DataGridView();
            this.Gpb_Listado.SuspendLayout();
            this.Gpb_Ordenamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_consultas_simples)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Filtrar
            // 
            this.Btn_Filtrar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_Filtrar.Image = global::Capa_Vista_Componente_Consultas_simples.Properties.Resources.android_search_icon_icons1;
            this.Btn_Filtrar.Location = new System.Drawing.Point(720, 32);
            this.Btn_Filtrar.Name = "Btn_Filtrar";
            this.Btn_Filtrar.Size = new System.Drawing.Size(67, 61);
            this.Btn_Filtrar.TabIndex = 28;
            this.Btn_Filtrar.Text = "Filtrar";
            this.Btn_Filtrar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Filtrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Btn_Filtrar.UseCompatibleTextRendering = true;
            this.Btn_Filtrar.UseVisualStyleBackColor = true;
            this.Btn_Filtrar.Click += new System.EventHandler(this.Btn_filtrar_Click);
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Btn_buscar.Image = global::Capa_Vista_Componente_Consultas_simples.Properties.Resources.android_search_icon_icons1;
            this.Btn_buscar.Location = new System.Drawing.Point(25, 36);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(67, 61);
            this.Btn_buscar.TabIndex = 29;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Btn_buscar.UseCompatibleTextRendering = true;
            this.Btn_buscar.UseVisualStyleBackColor = true;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Gpb_Listado
            // 
            this.Gpb_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Listado.Controls.Add(this.Lbl_Valor);
            this.Gpb_Listado.Controls.Add(this.Lbl_Operador);
            this.Gpb_Listado.Controls.Add(this.Lbl_Campos);
            this.Gpb_Listado.Controls.Add(this.Btn_buscar);
            this.Gpb_Listado.Controls.Add(this.Cbo_Operador);
            this.Gpb_Listado.Controls.Add(this.Btn_Filtrar);
            this.Gpb_Listado.Controls.Add(this.Cbo_Campos);
            this.Gpb_Listado.Controls.Add(this.Txt_Filtro);
            this.Gpb_Listado.Controls.Add(this.Gpb_Ordenamiento);
            this.Gpb_Listado.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Listado.Location = new System.Drawing.Point(2, 33);
            this.Gpb_Listado.Name = "Gpb_Listado";
            this.Gpb_Listado.Size = new System.Drawing.Size(803, 115);
            this.Gpb_Listado.TabIndex = 30;
            this.Gpb_Listado.TabStop = false;
            this.Gpb_Listado.Text = "Consultas Simples";
            // 
            // Lbl_Valor
            // 
            this.Lbl_Valor.AutoSize = true;
            this.Lbl_Valor.Location = new System.Drawing.Point(578, 32);
            this.Lbl_Valor.Name = "Lbl_Valor";
            this.Lbl_Valor.Size = new System.Drawing.Size(73, 27);
            this.Lbl_Valor.TabIndex = 33;
            this.Lbl_Valor.Text = "Valor";
            // 
            // Lbl_Operador
            // 
            this.Lbl_Operador.AutoSize = true;
            this.Lbl_Operador.Location = new System.Drawing.Point(385, 32);
            this.Lbl_Operador.Name = "Lbl_Operador";
            this.Lbl_Operador.Size = new System.Drawing.Size(122, 27);
            this.Lbl_Operador.TabIndex = 32;
            this.Lbl_Operador.Text = "Operador";
            // 
            // Lbl_Campos
            // 
            this.Lbl_Campos.AutoSize = true;
            this.Lbl_Campos.Location = new System.Drawing.Point(251, 31);
            this.Lbl_Campos.Name = "Lbl_Campos";
            this.Lbl_Campos.Size = new System.Drawing.Size(104, 27);
            this.Lbl_Campos.TabIndex = 31;
            this.Lbl_Campos.Text = "Campos";
            // 
            // Cbo_Operador
            // 
            this.Cbo_Operador.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_Operador.FormattingEnabled = true;
            this.Cbo_Operador.Location = new System.Drawing.Point(390, 65);
            this.Cbo_Operador.Name = "Cbo_Operador";
            this.Cbo_Operador.Size = new System.Drawing.Size(132, 27);
            this.Cbo_Operador.TabIndex = 30;
            // 
            // Cbo_Campos
            // 
            this.Cbo_Campos.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_Campos.FormattingEnabled = true;
            this.Cbo_Campos.Location = new System.Drawing.Point(252, 65);
            this.Cbo_Campos.Name = "Cbo_Campos";
            this.Cbo_Campos.Size = new System.Drawing.Size(132, 27);
            this.Cbo_Campos.TabIndex = 29;
            // 
            // Txt_Filtro
            // 
            this.Txt_Filtro.Font = new System.Drawing.Font("Rockwell", 10F);
            this.Txt_Filtro.Location = new System.Drawing.Point(528, 69);
            this.Txt_Filtro.Name = "Txt_Filtro";
            this.Txt_Filtro.Size = new System.Drawing.Size(186, 23);
            this.Txt_Filtro.TabIndex = 27;
            // 
            // Gpb_Ordenamiento
            // 
            this.Gpb_Ordenamiento.Controls.Add(this.Rdb_asc);
            this.Gpb_Ordenamiento.Controls.Add(this.Rdb_desc);
            this.Gpb_Ordenamiento.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Gpb_Ordenamiento.Location = new System.Drawing.Point(107, 50);
            this.Gpb_Ordenamiento.Name = "Gpb_Ordenamiento";
            this.Gpb_Ordenamiento.Size = new System.Drawing.Size(138, 47);
            this.Gpb_Ordenamiento.TabIndex = 26;
            this.Gpb_Ordenamiento.TabStop = false;
            this.Gpb_Ordenamiento.Text = "Ordenamiento";
            // 
            // Rdb_asc
            // 
            this.Rdb_asc.AutoSize = true;
            this.Rdb_asc.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Rdb_asc.Location = new System.Drawing.Point(6, 21);
            this.Rdb_asc.Name = "Rdb_asc";
            this.Rdb_asc.Size = new System.Drawing.Size(55, 21);
            this.Rdb_asc.TabIndex = 10;
            this.Rdb_asc.TabStop = true;
            this.Rdb_asc.Text = "ASC";
            this.Rdb_asc.UseVisualStyleBackColor = true;
            // 
            // Rdb_desc
            // 
            this.Rdb_desc.AutoSize = true;
            this.Rdb_desc.Font = new System.Drawing.Font("Rockwell", 11F);
            this.Rdb_desc.Location = new System.Drawing.Point(67, 21);
            this.Rdb_desc.Name = "Rdb_desc";
            this.Rdb_desc.Size = new System.Drawing.Size(65, 21);
            this.Rdb_desc.TabIndex = 26;
            this.Rdb_desc.TabStop = true;
            this.Rdb_desc.Text = "DESC";
            this.Rdb_desc.UseVisualStyleBackColor = true;
            // 
            // Dgv_consultas_simples
            // 
            this.Dgv_consultas_simples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_consultas_simples.Location = new System.Drawing.Point(16, 154);
            this.Dgv_consultas_simples.Margin = new System.Windows.Forms.Padding(2);
            this.Dgv_consultas_simples.Name = "Dgv_consultas_simples";
            this.Dgv_consultas_simples.RowHeadersWidth = 51;
            this.Dgv_consultas_simples.RowTemplate.Height = 24;
            this.Dgv_consultas_simples.Size = new System.Drawing.Size(782, 314);
            this.Dgv_consultas_simples.TabIndex = 31;
            // 
            // Consulta_simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Gpb_Listado);
            this.Controls.Add(this.Dgv_consultas_simples);
            this.Name = "Consulta_simple";
            this.Size = new System.Drawing.Size(825, 511);
            this.Gpb_Listado.ResumeLayout(false);
            this.Gpb_Listado.PerformLayout();
            this.Gpb_Ordenamiento.ResumeLayout(false);
            this.Gpb_Ordenamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_consultas_simples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Filtrar;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.GroupBox Gpb_Listado;
        private System.Windows.Forms.Label Lbl_Operador;
        private System.Windows.Forms.Label Lbl_Campos;
        private System.Windows.Forms.ComboBox Cbo_Operador;
        private System.Windows.Forms.ComboBox Cbo_Campos;
        private System.Windows.Forms.TextBox Txt_Filtro;
        private System.Windows.Forms.GroupBox Gpb_Ordenamiento;
        private System.Windows.Forms.RadioButton Rdb_asc;
        private System.Windows.Forms.RadioButton Rdb_desc;
        private System.Windows.Forms.DataGridView Dgv_consultas_simples;
        private System.Windows.Forms.Label Lbl_Valor;
    }
}
