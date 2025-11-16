namespace Capa_Vista_Polizas
{
    partial class Frm_PolizasLocales
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
            this.Dgv_EncabezadoPolizas = new System.Windows.Forms.DataGridView();
            this.Lbl_ModoActual = new System.Windows.Forms.Label();
            this.Btn_CambiarModo = new System.Windows.Forms.Button();
            this.Btn_SincronizarModo = new System.Windows.Forms.Button();
            this.Pnl_Botones = new System.Windows.Forms.Panel();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Btn_Borrar = new System.Windows.Forms.Button();
            this.Btn_Filtrar = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_EncabezadoPolizas)).BeginInit();
            this.Pnl_Botones.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_EncabezadoPolizas
            // 
            this.Dgv_EncabezadoPolizas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_EncabezadoPolizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_EncabezadoPolizas.Location = new System.Drawing.Point(0, 175);
            this.Dgv_EncabezadoPolizas.Name = "Dgv_EncabezadoPolizas";
            this.Dgv_EncabezadoPolizas.RowHeadersWidth = 51;
            this.Dgv_EncabezadoPolizas.RowTemplate.Height = 24;
            this.Dgv_EncabezadoPolizas.Size = new System.Drawing.Size(1451, 535);
            this.Dgv_EncabezadoPolizas.TabIndex = 0;
            this.Dgv_EncabezadoPolizas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_EncabezadoPolizas_CellDoubleClick);
            this.Dgv_EncabezadoPolizas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_EncabezadoPolizas_CellFormatting);
            // 
            // Lbl_ModoActual
            // 
            this.Lbl_ModoActual.AutoSize = true;
            this.Lbl_ModoActual.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ModoActual.Location = new System.Drawing.Point(897, 31);
            this.Lbl_ModoActual.Name = "Lbl_ModoActual";
            this.Lbl_ModoActual.Size = new System.Drawing.Size(122, 22);
            this.Lbl_ModoActual.TabIndex = 9;
            this.Lbl_ModoActual.Text = "Modo Actual";
            // 
            // Btn_CambiarModo
            // 
            this.Btn_CambiarModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_CambiarModo.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_CambiarModo.Location = new System.Drawing.Point(901, 56);
            this.Btn_CambiarModo.Name = "Btn_CambiarModo";
            this.Btn_CambiarModo.Size = new System.Drawing.Size(138, 54);
            this.Btn_CambiarModo.TabIndex = 10;
            this.Btn_CambiarModo.Text = "Cambiar Modo";
            this.Btn_CambiarModo.UseVisualStyleBackColor = true;
            this.Btn_CambiarModo.Click += new System.EventHandler(this.Btn_CambiarModo_Click);
            // 
            // Btn_SincronizarModo
            // 
            this.Btn_SincronizarModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SincronizarModo.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SincronizarModo.Location = new System.Drawing.Point(1045, 56);
            this.Btn_SincronizarModo.Name = "Btn_SincronizarModo";
            this.Btn_SincronizarModo.Size = new System.Drawing.Size(134, 54);
            this.Btn_SincronizarModo.TabIndex = 14;
            this.Btn_SincronizarModo.Text = "Sincronizar Modo";
            this.Btn_SincronizarModo.UseVisualStyleBackColor = true;
            this.Btn_SincronizarModo.Click += new System.EventHandler(this.Btn_SincronizarModo_Click);
            // 
            // Pnl_Botones
            // 
            this.Pnl_Botones.Controls.Add(this.Btn_SincronizarModo);
            this.Pnl_Botones.Controls.Add(this.Btn_Ingresar);
            this.Pnl_Botones.Controls.Add(this.Btn_CambiarModo);
            this.Pnl_Botones.Controls.Add(this.Btn_Editar);
            this.Pnl_Botones.Controls.Add(this.Lbl_ModoActual);
            this.Pnl_Botones.Controls.Add(this.Btn_Borrar);
            this.Pnl_Botones.Controls.Add(this.Btn_Filtrar);
            this.Pnl_Botones.Controls.Add(this.Btn_Imprimir);
            this.Pnl_Botones.Controls.Add(this.Btn_Salir);
            this.Pnl_Botones.Controls.Add(this.Btn_Refrescar);
            this.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Botones.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Botones.Name = "Pnl_Botones";
            this.Pnl_Botones.Size = new System.Drawing.Size(1475, 147);
            this.Pnl_Botones.TabIndex = 15;
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingresar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ingresar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_agregar;
            this.Btn_Ingresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Ingresar.Location = new System.Drawing.Point(10, 33);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(116, 77);
            this.Btn_Ingresar.TabIndex = 1;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ingresar.UseVisualStyleBackColor = true;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Editar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Editar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_modificar;
            this.Btn_Editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Editar.Location = new System.Drawing.Point(132, 33);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(109, 77);
            this.Btn_Editar.TabIndex = 2;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Borrar
            // 
            this.Btn_Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Borrar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Borrar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_eliminar;
            this.Btn_Borrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Borrar.Location = new System.Drawing.Point(247, 33);
            this.Btn_Borrar.Name = "Btn_Borrar";
            this.Btn_Borrar.Size = new System.Drawing.Size(106, 77);
            this.Btn_Borrar.TabIndex = 3;
            this.Btn_Borrar.Text = "Borrar";
            this.Btn_Borrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Borrar.UseVisualStyleBackColor = true;
            this.Btn_Borrar.Click += new System.EventHandler(this.Btn_Borrar_Click);
            // 
            // Btn_Filtrar
            // 
            this.Btn_Filtrar.Enabled = false;
            this.Btn_Filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Filtrar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Filtrar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_buscar;
            this.Btn_Filtrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Filtrar.Location = new System.Drawing.Point(607, 33);
            this.Btn_Filtrar.Name = "Btn_Filtrar";
            this.Btn_Filtrar.Size = new System.Drawing.Size(100, 77);
            this.Btn_Filtrar.TabIndex = 7;
            this.Btn_Filtrar.Text = "Filtrar";
            this.Btn_Filtrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Filtrar.UseVisualStyleBackColor = true;
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Imprimir.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Imprimir.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_imprimir;
            this.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Imprimir.Location = new System.Drawing.Point(489, 33);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(112, 77);
            this.Btn_Imprimir.TabIndex = 4;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_salir;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(713, 33);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(100, 77);
            this.Btn_Salir.TabIndex = 6;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Refrescar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Refrescar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_refrescar;
            this.Btn_Refrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Refrescar.Location = new System.Drawing.Point(359, 33);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(124, 77);
            this.Btn_Refrescar.TabIndex = 5;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // Frm_PolizasLocales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 722);
            this.Controls.Add(this.Pnl_Botones);
            this.Controls.Add(this.Dgv_EncabezadoPolizas);
            this.Name = "Frm_PolizasLocales";
            this.Text = "3000 - Polizas Locales";
            this.Load += new System.EventHandler(this.Frm_PolizasLocales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_EncabezadoPolizas)).EndInit();
            this.Pnl_Botones.ResumeLayout(false);
            this.Pnl_Botones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_EncabezadoPolizas;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Borrar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Filtrar;
        private System.Windows.Forms.Label Lbl_ModoActual;
        private System.Windows.Forms.Button Btn_CambiarModo;
        private System.Windows.Forms.Button Btn_SincronizarModo;
        private System.Windows.Forms.Panel Pnl_Botones;
    }
}