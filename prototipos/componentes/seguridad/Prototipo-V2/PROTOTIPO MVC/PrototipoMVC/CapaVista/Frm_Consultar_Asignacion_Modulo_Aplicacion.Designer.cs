
namespace CapaVista
{
    partial class Frm_Consultar_Asignacion_Modulo_Aplicacion
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
            this.Btn_Regresar_Aplicacion = new System.Windows.Forms.Button();
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consulta_Asignacion_Modulo_Aplicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Regresar_Aplicacion
            // 
            this.Btn_Regresar_Aplicacion.Location = new System.Drawing.Point(24, 12);
            this.Btn_Regresar_Aplicacion.Name = "Btn_Regresar_Aplicacion";
            this.Btn_Regresar_Aplicacion.Size = new System.Drawing.Size(101, 36);
            this.Btn_Regresar_Aplicacion.TabIndex = 1;
            this.Btn_Regresar_Aplicacion.Text = "Regresar";
            this.Btn_Regresar_Aplicacion.UseVisualStyleBackColor = true;
            this.Btn_Regresar_Aplicacion.Click += new System.EventHandler(this.Btn_Regresar_Aplicacion_Click);
            // 
            // Dgv_Consulta_Asignacion_Modulo_Aplicacion
            // 
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.Enabled = false;
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.Location = new System.Drawing.Point(24, 68);
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.Name = "Dgv_Consulta_Asignacion_Modulo_Aplicacion";
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.RowHeadersWidth = 62;
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.RowTemplate.Height = 28;
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.Size = new System.Drawing.Size(631, 415);
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.TabIndex = 2;
            this.Dgv_Consulta_Asignacion_Modulo_Aplicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Consulta_Asignacion_Modulo_Aplicacion_CellContentClick);
            // 
            // Frm_Consultar_Asignacion_Modulo_Aplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 495);
            this.Controls.Add(this.Dgv_Consulta_Asignacion_Modulo_Aplicacion);
            this.Controls.Add(this.Btn_Regresar_Aplicacion);
            this.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Consultar_Asignacion_Modulo_Aplicacion";
            this.Text = "Frm_Consultar_Asignacion_Modulo_Aplicacion";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consulta_Asignacion_Modulo_Aplicacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Regresar_Aplicacion;
        private System.Windows.Forms.DataGridView Dgv_Consulta_Asignacion_Modulo_Aplicacion;
    }
}