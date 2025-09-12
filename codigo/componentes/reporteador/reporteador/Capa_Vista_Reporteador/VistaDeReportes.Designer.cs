
namespace Capa_Vista_Reporteador
{
    partial class VistaDeReportes
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
            this.titulo_vista_reportes = new System.Windows.Forms.Label();
            this.panelViewSetting = new System.Windows.Forms.Panel();
            this.pv_reporte = new System.Windows.Forms.Panel();
            this.PicB_vista_reportes = new System.Windows.Forms.PictureBox();
            this.panelViewSetting.SuspendLayout();
            this.pv_reporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicB_vista_reportes)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo_vista_reportes
            // 
            this.titulo_vista_reportes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titulo_vista_reportes.AutoSize = true;
            this.titulo_vista_reportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo_vista_reportes.Location = new System.Drawing.Point(258, 6);
            this.titulo_vista_reportes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titulo_vista_reportes.Name = "titulo_vista_reportes";
            this.titulo_vista_reportes.Size = new System.Drawing.Size(166, 36);
            this.titulo_vista_reportes.TabIndex = 0;
            this.titulo_vista_reportes.Text = "REPORTE";
            // 
            // panelViewSetting
            // 
            this.panelViewSetting.Controls.Add(this.pv_reporte);
            this.panelViewSetting.Location = new System.Drawing.Point(15, 41);
            this.panelViewSetting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelViewSetting.Name = "panelViewSetting";
            this.panelViewSetting.Size = new System.Drawing.Size(575, 301);
            this.panelViewSetting.TabIndex = 1;
            // 
            // pv_reporte
            // 
            this.pv_reporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pv_reporte.AutoScroll = true;
            this.pv_reporte.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pv_reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pv_reporte.Controls.Add(this.PicB_vista_reportes);
            this.pv_reporte.Location = new System.Drawing.Point(0, 0);
            this.pv_reporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pv_reporte.Name = "pv_reporte";
            this.pv_reporte.Size = new System.Drawing.Size(576, 302);
            this.pv_reporte.TabIndex = 0;
            this.pv_reporte.Paint += new System.Windows.Forms.PaintEventHandler(this.pv_reporte_Paint);
            // 
            // PicB_vista_reportes
            // 
            this.PicB_vista_reportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicB_vista_reportes.Location = new System.Drawing.Point(14, 15);
            this.PicB_vista_reportes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PicB_vista_reportes.Name = "PicB_vista_reportes";
            this.PicB_vista_reportes.Size = new System.Drawing.Size(96, 44);
            this.PicB_vista_reportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicB_vista_reportes.TabIndex = 0;
            this.PicB_vista_reportes.TabStop = false;
            this.PicB_vista_reportes.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // VistaDeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panelViewSetting);
            this.Controls.Add(this.titulo_vista_reportes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VistaDeReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaDeReportes";
            this.Load += new System.EventHandler(this.VistaDeReportes_Load);
            this.panelViewSetting.ResumeLayout(false);
            this.pv_reporte.ResumeLayout(false);
            this.pv_reporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicB_vista_reportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo_vista_reportes;
        private System.Windows.Forms.Panel panelViewSetting;
        private System.Windows.Forms.Panel pv_reporte;
        private System.Windows.Forms.PictureBox PicB_vista_reportes;
    }
}