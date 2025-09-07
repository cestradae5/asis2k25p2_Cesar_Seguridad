
namespace Bitacora_Menu
{
    partial class Frm_Menu
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Mnu_Principal = new System.Windows.Forms.MenuStrip();
            this.Mni_Bitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.Mni_ExportarCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.Mni_Imprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.Mni_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.Mni_Bitacora_Consultar = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu_Principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mnu_Principal
            // 
            this.Mnu_Principal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Mnu_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mni_Bitacora});
            this.Mnu_Principal.Location = new System.Drawing.Point(0, 0);
            this.Mnu_Principal.Name = "Mnu_Principal";
            this.Mnu_Principal.Size = new System.Drawing.Size(800, 28);
            this.Mnu_Principal.TabIndex = 1;
            this.Mnu_Principal.Text = "menuStrip1";
            this.Mnu_Principal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Mnu_Principal_ItemClicked);
            // 
            // Mni_Bitacora
            // 
            this.Mni_Bitacora.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mni_ExportarCSV,
            this.Mni_Imprimir,
            this.Mni_Salir,
            this.Mni_Bitacora_Consultar});
            this.Mni_Bitacora.Name = "Mni_Bitacora";
            this.Mni_Bitacora.Size = new System.Drawing.Size(78, 24);
            this.Mni_Bitacora.Text = "Bitacora";
            this.Mni_Bitacora.Click += new System.EventHandler(this.Mni_Bitacora_Click);
            // 
            // Mni_ExportarCSV
            // 
            this.Mni_ExportarCSV.Name = "Mni_ExportarCSV";
            this.Mni_ExportarCSV.Size = new System.Drawing.Size(224, 26);
            this.Mni_ExportarCSV.Text = "Exportar CSV";
            // 
            // Mni_Imprimir
            // 
            this.Mni_Imprimir.Name = "Mni_Imprimir";
            this.Mni_Imprimir.Size = new System.Drawing.Size(224, 26);
            this.Mni_Imprimir.Text = "Imprimir";
            // 
            // Mni_Salir
            // 
            this.Mni_Salir.Name = "Mni_Salir";
            this.Mni_Salir.Size = new System.Drawing.Size(224, 26);
            this.Mni_Salir.Text = "Salir";
            // 
            // Mni_Bitacora_Consultar
            // 
            this.Mni_Bitacora_Consultar.Name = "Mni_Bitacora_Consultar";
            this.Mni_Bitacora_Consultar.Size = new System.Drawing.Size(224, 26);
            this.Mni_Bitacora_Consultar.Text = "Consultar";
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Mnu_Principal);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.Mnu_Principal;
            this.Name = "Frm_Menu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.Frm_Menu_Load);
            this.Mnu_Principal.ResumeLayout(false);
            this.Mnu_Principal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Mnu_Principal;
        private System.Windows.Forms.ToolStripMenuItem Mni_Bitacora;
        private System.Windows.Forms.ToolStripMenuItem Mni_ExportarCSV;
        private System.Windows.Forms.ToolStripMenuItem Mni_Imprimir;
        private System.Windows.Forms.ToolStripMenuItem Mni_Salir;
        private System.Windows.Forms.ToolStripMenuItem Mni_Bitacora_Consultar;
    }
}

