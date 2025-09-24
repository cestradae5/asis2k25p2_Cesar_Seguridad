
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.titulo_vista_reportes.Location = new System.Drawing.Point(344, 7);
            this.titulo_vista_reportes.Name = "titulo_vista_reportes";
            this.titulo_vista_reportes.Size = new System.Drawing.Size(166, 36);
            this.titulo_vista_reportes.TabIndex = 0;
            this.titulo_vista_reportes.Text = "REPORTE";
            // 
            // panelViewSetting
            // 
            this.panelViewSetting.Controls.Add(this.pv_reporte);
            this.panelViewSetting.Location = new System.Drawing.Point(20, 50);
            this.panelViewSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelViewSetting.Name = "panelViewSetting";
            this.panelViewSetting.Size = new System.Drawing.Size(767, 370);
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
            this.pv_reporte.Controls.Add(this.crystalReportViewer1);
            this.pv_reporte.Controls.Add(this.PicB_vista_reportes);
            this.pv_reporte.Location = new System.Drawing.Point(0, 0);
            this.pv_reporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pv_reporte.Name = "pv_reporte";
            this.pv_reporte.Size = new System.Drawing.Size(767, 371);
            this.pv_reporte.TabIndex = 0;
            this.pv_reporte.Paint += new System.Windows.Forms.PaintEventHandler(this.pv_reporte_Paint);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.AutoSize = true;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(765, 369);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // PicB_vista_reportes
            // 
            this.PicB_vista_reportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicB_vista_reportes.Location = new System.Drawing.Point(19, 18);
            this.PicB_vista_reportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PicB_vista_reportes.Name = "PicB_vista_reportes";
            this.PicB_vista_reportes.Size = new System.Drawing.Size(96, 44);
            this.PicB_vista_reportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicB_vista_reportes.TabIndex = 0;
            this.PicB_vista_reportes.TabStop = false;
            this.PicB_vista_reportes.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // VistaDeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelViewSetting);
            this.Controls.Add(this.titulo_vista_reportes);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}