
namespace Capa_Vista_Contabilida
{
    partial class Frm_depreciacion_activos_fijos
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
            this.Lbl_Activo_fijo = new System.Windows.Forms.Label();
            this.Lbl_costo_total = new System.Windows.Forms.Label();
            this.Lbl_valor_residual = new System.Windows.Forms.Label();
            this.Lbl_vida_util = new System.Windows.Forms.Label();
            this.Lbl_depreciacion_anual = new System.Windows.Forms.Label();
            this.Gbp_caracteristicas_activo_fijo = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Btn_calcular = new System.Windows.Forms.Button();
            this.Txt_depreciacion_anual = new System.Windows.Forms.TextBox();
            this.Btn_buscar_activo_fijo = new System.Windows.Forms.Button();
            this.Txt_vida_util = new System.Windows.Forms.TextBox();
            this.Txt_valor_residual = new System.Windows.Forms.TextBox();
            this.Txt_costo_total = new System.Windows.Forms.TextBox();
            this.Dgv_depreciacion_activo_fijo = new System.Windows.Forms.DataGridView();
            this.Btn_limpiar_campo = new System.Windows.Forms.Button();
            this.Gbp_caracteristicas_activo_fijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_depreciacion_activo_fijo)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Activo_fijo
            // 
            this.Lbl_Activo_fijo.AutoSize = true;
            this.Lbl_Activo_fijo.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Activo_fijo.Location = new System.Drawing.Point(334, 22);
            this.Lbl_Activo_fijo.Name = "Lbl_Activo_fijo";
            this.Lbl_Activo_fijo.Size = new System.Drawing.Size(589, 41);
            this.Lbl_Activo_fijo.TabIndex = 0;
            this.Lbl_Activo_fijo.Text = "Calculo Linea Recta - Activos Fijos";
            // 
            // Lbl_costo_total
            // 
            this.Lbl_costo_total.AutoSize = true;
            this.Lbl_costo_total.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_costo_total.Location = new System.Drawing.Point(374, 59);
            this.Lbl_costo_total.Name = "Lbl_costo_total";
            this.Lbl_costo_total.Size = new System.Drawing.Size(123, 22);
            this.Lbl_costo_total.TabIndex = 2;
            this.Lbl_costo_total.Text = "Costo Total: ";
            // 
            // Lbl_valor_residual
            // 
            this.Lbl_valor_residual.AutoSize = true;
            this.Lbl_valor_residual.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_valor_residual.Location = new System.Drawing.Point(342, 101);
            this.Lbl_valor_residual.Name = "Lbl_valor_residual";
            this.Lbl_valor_residual.Size = new System.Drawing.Size(155, 22);
            this.Lbl_valor_residual.TabIndex = 3;
            this.Lbl_valor_residual.Text = "Valor Residual: ";
            // 
            // Lbl_vida_util
            // 
            this.Lbl_vida_util.AutoSize = true;
            this.Lbl_vida_util.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_vida_util.Location = new System.Drawing.Point(337, 146);
            this.Lbl_vida_util.Name = "Lbl_vida_util";
            this.Lbl_vida_util.Size = new System.Drawing.Size(160, 22);
            this.Lbl_vida_util.TabIndex = 4;
            this.Lbl_vida_util.Text = "Vida Util (años):";
            // 
            // Lbl_depreciacion_anual
            // 
            this.Lbl_depreciacion_anual.AutoSize = true;
            this.Lbl_depreciacion_anual.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_depreciacion_anual.Location = new System.Drawing.Point(300, 187);
            this.Lbl_depreciacion_anual.Name = "Lbl_depreciacion_anual";
            this.Lbl_depreciacion_anual.Size = new System.Drawing.Size(197, 22);
            this.Lbl_depreciacion_anual.TabIndex = 5;
            this.Lbl_depreciacion_anual.Text = "Depreciacion Anual:";
            // 
            // Gbp_caracteristicas_activo_fijo
            // 
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.comboBox1);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Btn_calcular);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Txt_depreciacion_anual);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Btn_buscar_activo_fijo);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Txt_vida_util);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Txt_valor_residual);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Txt_costo_total);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Lbl_depreciacion_anual);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Lbl_vida_util);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Lbl_valor_residual);
            this.Gbp_caracteristicas_activo_fijo.Controls.Add(this.Lbl_costo_total);
            this.Gbp_caracteristicas_activo_fijo.Font = new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbp_caracteristicas_activo_fijo.Location = new System.Drawing.Point(24, 89);
            this.Gbp_caracteristicas_activo_fijo.Name = "Gbp_caracteristicas_activo_fijo";
            this.Gbp_caracteristicas_activo_fijo.Size = new System.Drawing.Size(729, 273);
            this.Gbp_caracteristicas_activo_fijo.TabIndex = 6;
            this.Gbp_caracteristicas_activo_fijo.TabStop = false;
            this.Gbp_caracteristicas_activo_fijo.Text = "Caracteristicas Activo Fijo";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(35, 153);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 33);
            this.comboBox1.TabIndex = 12;
            // 
            // Btn_calcular
            // 
            this.Btn_calcular.Location = new System.Drawing.Point(551, 226);
            this.Btn_calcular.Name = "Btn_calcular";
            this.Btn_calcular.Size = new System.Drawing.Size(165, 41);
            this.Btn_calcular.TabIndex = 10;
            this.Btn_calcular.Text = "Calcular";
            this.Btn_calcular.UseVisualStyleBackColor = true;
            this.Btn_calcular.Click += new System.EventHandler(this.Btn_calcular_Click);
            // 
            // Txt_depreciacion_anual
            // 
            this.Txt_depreciacion_anual.Location = new System.Drawing.Point(503, 182);
            this.Txt_depreciacion_anual.Name = "Txt_depreciacion_anual";
            this.Txt_depreciacion_anual.Size = new System.Drawing.Size(213, 33);
            this.Txt_depreciacion_anual.TabIndex = 9;
            // 
            // Btn_buscar_activo_fijo
            // 
            this.Btn_buscar_activo_fijo.Location = new System.Drawing.Point(35, 81);
            this.Btn_buscar_activo_fijo.Name = "Btn_buscar_activo_fijo";
            this.Btn_buscar_activo_fijo.Size = new System.Drawing.Size(219, 60);
            this.Btn_buscar_activo_fijo.TabIndex = 11;
            this.Btn_buscar_activo_fijo.Text = "Buscar Activo Fijo";
            this.Btn_buscar_activo_fijo.UseVisualStyleBackColor = true;
            this.Btn_buscar_activo_fijo.Click += new System.EventHandler(this.Btn_buscar_activo_fijo_Click);
            // 
            // Txt_vida_util
            // 
            this.Txt_vida_util.Location = new System.Drawing.Point(503, 141);
            this.Txt_vida_util.Name = "Txt_vida_util";
            this.Txt_vida_util.Size = new System.Drawing.Size(213, 33);
            this.Txt_vida_util.TabIndex = 8;
            // 
            // Txt_valor_residual
            // 
            this.Txt_valor_residual.Location = new System.Drawing.Point(503, 96);
            this.Txt_valor_residual.Name = "Txt_valor_residual";
            this.Txt_valor_residual.Size = new System.Drawing.Size(213, 33);
            this.Txt_valor_residual.TabIndex = 7;
            // 
            // Txt_costo_total
            // 
            this.Txt_costo_total.Location = new System.Drawing.Point(503, 54);
            this.Txt_costo_total.Name = "Txt_costo_total";
            this.Txt_costo_total.Size = new System.Drawing.Size(213, 33);
            this.Txt_costo_total.TabIndex = 6;
            // 
            // Dgv_depreciacion_activo_fijo
            // 
            this.Dgv_depreciacion_activo_fijo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_depreciacion_activo_fijo.Location = new System.Drawing.Point(29, 385);
            this.Dgv_depreciacion_activo_fijo.Name = "Dgv_depreciacion_activo_fijo";
            this.Dgv_depreciacion_activo_fijo.RowHeadersWidth = 62;
            this.Dgv_depreciacion_activo_fijo.RowTemplate.Height = 28;
            this.Dgv_depreciacion_activo_fijo.Size = new System.Drawing.Size(1184, 235);
            this.Dgv_depreciacion_activo_fijo.TabIndex = 7;
            // 
            // Btn_limpiar_campo
            // 
            this.Btn_limpiar_campo.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_limpiar_campo.Location = new System.Drawing.Point(986, 325);
            this.Btn_limpiar_campo.Name = "Btn_limpiar_campo";
            this.Btn_limpiar_campo.Size = new System.Drawing.Size(203, 37);
            this.Btn_limpiar_campo.TabIndex = 9;
            this.Btn_limpiar_campo.Text = "Limpiar Campos";
            this.Btn_limpiar_campo.UseVisualStyleBackColor = true;
            this.Btn_limpiar_campo.Click += new System.EventHandler(this.Btn_limpiar_campo_Click);
            // 
            // Frm_depreciacion_activos_fijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1241, 635);
            this.Controls.Add(this.Btn_limpiar_campo);
            this.Controls.Add(this.Dgv_depreciacion_activo_fijo);
            this.Controls.Add(this.Gbp_caracteristicas_activo_fijo);
            this.Controls.Add(this.Lbl_Activo_fijo);
            this.Name = "Frm_depreciacion_activos_fijos";
            this.Text = "Frm_depreciacion_activos_fijos";
            this.Gbp_caracteristicas_activo_fijo.ResumeLayout(false);
            this.Gbp_caracteristicas_activo_fijo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_depreciacion_activo_fijo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Activo_fijo;
        private System.Windows.Forms.Label Lbl_costo_total;
        private System.Windows.Forms.Label Lbl_valor_residual;
        private System.Windows.Forms.Label Lbl_vida_util;
        private System.Windows.Forms.Label Lbl_depreciacion_anual;
        private System.Windows.Forms.GroupBox Gbp_caracteristicas_activo_fijo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Btn_calcular;
        private System.Windows.Forms.TextBox Txt_depreciacion_anual;
        private System.Windows.Forms.Button Btn_buscar_activo_fijo;
        private System.Windows.Forms.TextBox Txt_vida_util;
        private System.Windows.Forms.TextBox Txt_valor_residual;
        private System.Windows.Forms.TextBox Txt_costo_total;
        private System.Windows.Forms.DataGridView Dgv_depreciacion_activo_fijo;
        private System.Windows.Forms.Button Btn_limpiar_campo;
    }
}