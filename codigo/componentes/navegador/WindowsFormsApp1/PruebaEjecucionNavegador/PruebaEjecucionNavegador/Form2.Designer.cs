
namespace PruebaEjecucionNavegador
{
    partial class Form2
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
            this.navegador1 = new Capa_Vista_Navegador.Navegador();
            this.Btn_Anterior = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // navegador1
            // 
            this.navegador1.Location = new System.Drawing.Point(13, 13);
            this.navegador1.Name = "navegador1";
            this.navegador1.SAlias = null;
            this.navegador1.Size = new System.Drawing.Size(1180, 488);
            this.navegador1.SNombreTabla = null;
            this.navegador1.TabIndex = 0;
            this.navegador1.Load += new System.EventHandler(this.navegador1_Load);
            // 
            // Btn_Anterior
            // 
            this.Btn_Anterior.Location = new System.Drawing.Point(964, 144);
            this.Btn_Anterior.Name = "Btn_Anterior";
            this.Btn_Anterior.Size = new System.Drawing.Size(147, 49);
            this.Btn_Anterior.TabIndex = 2;
            this.Btn_Anterior.Text = "Anterior";
            this.Btn_Anterior.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 534);
            this.Controls.Add(this.Btn_Anterior);
            this.Controls.Add(this.navegador1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Capa_Vista_Navegador.Navegador navegador1;
        private System.Windows.Forms.Button Btn_Anterior;
    }
}