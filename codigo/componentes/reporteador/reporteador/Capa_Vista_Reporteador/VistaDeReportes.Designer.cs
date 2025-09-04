
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
            this.titulo = new System.Windows.Forms.Label();
            this.panelViewSetting = new System.Windows.Forms.Panel();
            this.panelView = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelViewSetting.SuspendLayout();
            this.panelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Rockwell Nova Cond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(344, 7);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(135, 41);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "REPORTE";
            // 
            // panelViewSetting
            // 
            this.panelViewSetting.Controls.Add(this.panelView);
            this.panelViewSetting.Location = new System.Drawing.Point(20, 51);
            this.panelViewSetting.Name = "panelViewSetting";
            this.panelViewSetting.Size = new System.Drawing.Size(767, 371);
            this.panelViewSetting.TabIndex = 1;
            // 
            // panelView
            // 
            this.panelView.AutoScroll = true;
            this.panelView.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelView.Controls.Add(this.pictureBox1);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(767, 371);
            this.panelView.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // VistaDeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelViewSetting);
            this.Controls.Add(this.titulo);
            this.Name = "VistaDeReportes";
            this.Text = "VistaDeReportes";
            this.panelViewSetting.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel panelViewSetting;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}