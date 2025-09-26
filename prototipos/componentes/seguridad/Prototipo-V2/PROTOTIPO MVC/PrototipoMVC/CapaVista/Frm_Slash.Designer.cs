
namespace Capa_Vista_Seguridad
{
    partial class Frm_Slash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Slash));
            this.Lbl_carga = new System.Windows.Forms.Label();
            this.Tmr_carga = new System.Windows.Forms.Timer(this.components);
            this.Pgb_carga = new System.Windows.Forms.ProgressBar();
            this.Pic_carga = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_carga)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_carga
            // 
            this.Lbl_carga.AutoSize = true;
            this.Lbl_carga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.Lbl_carga.Font = new System.Drawing.Font("Rockwell", 15F, System.Drawing.FontStyle.Bold);
            this.Lbl_carga.Location = new System.Drawing.Point(280, 237);
            this.Lbl_carga.Name = "Lbl_carga";
            this.Lbl_carga.Size = new System.Drawing.Size(40, 24);
            this.Lbl_carga.TabIndex = 0;
            this.Lbl_carga.Text = "0%";
            // 
            // Tmr_carga
            // 
            this.Tmr_carga.Enabled = true;
            this.Tmr_carga.Tick += new System.EventHandler(this.Tmr_carga_Tick);
            // 
            // Pgb_carga
            // 
            this.Pgb_carga.Location = new System.Drawing.Point(71, 199);
            this.Pgb_carga.Maximum = 101;
            this.Pgb_carga.Name = "Pgb_carga";
            this.Pgb_carga.Size = new System.Drawing.Size(450, 35);
            this.Pgb_carga.TabIndex = 1;
            // 
            // Pic_carga
            // 
            this.Pic_carga.BackColor = System.Drawing.Color.Transparent;
            this.Pic_carga.Image = ((System.Drawing.Image)(resources.GetObject("Pic_carga.Image")));
            this.Pic_carga.Location = new System.Drawing.Point(0, -1);
            this.Pic_carga.Name = "Pic_carga";
            this.Pic_carga.Size = new System.Drawing.Size(584, 262);
            this.Pic_carga.TabIndex = 2;
            this.Pic_carga.TabStop = false;
            // 
            // frmSlash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.Pgb_carga);
            this.Controls.Add(this.Lbl_carga);
            this.Controls.Add(this.Pic_carga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSlash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSlash";
            ((System.ComponentModel.ISupportInitialize)(this.Pic_carga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_carga;
        private System.Windows.Forms.Timer Tmr_carga;
        private System.Windows.Forms.ProgressBar Pgb_carga;
        private System.Windows.Forms.PictureBox Pic_carga;
    }
}