namespace WindowsFormsApp1
{
    partial class Form1
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
            this.navegador1 = new WindowsFormsApp1.Navegador();
            this.Dgv_prueba = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_prueba)).BeginInit();
            this.SuspendLayout();
            // 
            // navegador1
            // 
            this.navegador1.Location = new System.Drawing.Point(13, 13);
            this.navegador1.Margin = new System.Windows.Forms.Padding(4);
            this.navegador1.Name = "navegador1";
            this.navegador1.Size = new System.Drawing.Size(1516, 390);
            this.navegador1.TabIndex = 0;
            // 
            // Dgv_prueba
            // 
            this.Dgv_prueba.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Dgv_prueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_prueba.Location = new System.Drawing.Point(121, 183);
            this.Dgv_prueba.Name = "Dgv_prueba";
            this.Dgv_prueba.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv_prueba.RowTemplate.Height = 24;
            this.Dgv_prueba.Size = new System.Drawing.Size(1257, 324);
            this.Dgv_prueba.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 549);
            this.Controls.Add(this.Dgv_prueba);
            this.Controls.Add(this.navegador1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_prueba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Navegador navegador1;
        private System.Windows.Forms.DataGridView Dgv_prueba;
    }
}