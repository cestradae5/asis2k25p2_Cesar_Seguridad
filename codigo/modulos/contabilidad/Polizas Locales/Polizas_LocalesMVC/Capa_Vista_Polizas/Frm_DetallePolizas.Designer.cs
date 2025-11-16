namespace Capa_Vista_Polizas
{
    partial class Frm_DetallePolizas
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
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Lbl_TotalCargo = new System.Windows.Forms.Label();
            this.Dgv_DetallePoliza = new System.Windows.Forms.DataGridView();
            this.Lbl_TotalAbono = new System.Windows.Forms.Label();
            this.Lbl_Diferencial = new System.Windows.Forms.Label();
            this.Btn_Quitar = new System.Windows.Forms.Button();
            this.Lbl_DetalleMovimientos = new System.Windows.Forms.Label();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Lbl_CodigoCta = new System.Windows.Forms.Label();
            this.Cmb_CodigoCuenta = new System.Windows.Forms.ComboBox();
            this.Lbl_Valor = new System.Windows.Forms.Label();
            this.Txt_Valor = new System.Windows.Forms.TextBox();
            this.Lbl_DctoPoliza = new System.Windows.Forms.Label();
            this.Txt_IdPoliza = new System.Windows.Forms.TextBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Lbl_Concepto = new System.Windows.Forms.Label();
            this.Txt_Concepto = new System.Windows.Forms.TextBox();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_CargoTtl = new System.Windows.Forms.Label();
            this.Lbl_AbonoTtl = new System.Windows.Forms.Label();
            this.Lbl_DiferencialTtl = new System.Windows.Forms.Label();
            this.Gpo_Encabezado = new System.Windows.Forms.GroupBox();
            this.Gpo_Detalle = new System.Windows.Forms.GroupBox();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetallePoliza)).BeginInit();
            this.Gpo_Encabezado.SuspendLayout();
            this.Gpo_Detalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Editar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Editar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_modificar;
            this.Btn_Editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Editar.Location = new System.Drawing.Point(155, 12);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(132, 80);
            this.Btn_Editar.TabIndex = 8;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Lbl_TotalCargo
            // 
            this.Lbl_TotalCargo.AutoSize = true;
            this.Lbl_TotalCargo.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_TotalCargo.Location = new System.Drawing.Point(132, 739);
            this.Lbl_TotalCargo.Name = "Lbl_TotalCargo";
            this.Lbl_TotalCargo.Size = new System.Drawing.Size(101, 20);
            this.Lbl_TotalCargo.TabIndex = 13;
            this.Lbl_TotalCargo.Text = "Total Cargo";
            // 
            // Dgv_DetallePoliza
            // 
            this.Dgv_DetallePoliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_DetallePoliza.Location = new System.Drawing.Point(23, 425);
            this.Dgv_DetallePoliza.Name = "Dgv_DetallePoliza";
            this.Dgv_DetallePoliza.RowHeadersWidth = 51;
            this.Dgv_DetallePoliza.RowTemplate.Height = 24;
            this.Dgv_DetallePoliza.Size = new System.Drawing.Size(898, 285);
            this.Dgv_DetallePoliza.TabIndex = 14;
            this.Dgv_DetallePoliza.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_DetallePoliza_CellClick);
            // 
            // Lbl_TotalAbono
            // 
            this.Lbl_TotalAbono.AutoSize = true;
            this.Lbl_TotalAbono.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_TotalAbono.Location = new System.Drawing.Point(537, 739);
            this.Lbl_TotalAbono.Name = "Lbl_TotalAbono";
            this.Lbl_TotalAbono.Size = new System.Drawing.Size(104, 20);
            this.Lbl_TotalAbono.TabIndex = 15;
            this.Lbl_TotalAbono.Text = "Total Abono";
            // 
            // Lbl_Diferencial
            // 
            this.Lbl_Diferencial.AutoSize = true;
            this.Lbl_Diferencial.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Diferencial.Location = new System.Drawing.Point(945, 739);
            this.Lbl_Diferencial.Name = "Lbl_Diferencial";
            this.Lbl_Diferencial.Size = new System.Drawing.Size(96, 20);
            this.Lbl_Diferencial.TabIndex = 16;
            this.Lbl_Diferencial.Text = "Diferencial";
            // 
            // Btn_Quitar
            // 
            this.Btn_Quitar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Quitar.Location = new System.Drawing.Point(941, 425);
            this.Btn_Quitar.Name = "Btn_Quitar";
            this.Btn_Quitar.Size = new System.Drawing.Size(100, 71);
            this.Btn_Quitar.TabIndex = 17;
            this.Btn_Quitar.Text = "Quitar";
            this.Btn_Quitar.UseVisualStyleBackColor = true;
            this.Btn_Quitar.Click += new System.EventHandler(this.Btn_Quitar_Click_1);
            // 
            // Lbl_DetalleMovimientos
            // 
            this.Lbl_DetalleMovimientos.AutoSize = true;
            this.Lbl_DetalleMovimientos.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DetalleMovimientos.Location = new System.Drawing.Point(18, 402);
            this.Lbl_DetalleMovimientos.Name = "Lbl_DetalleMovimientos";
            this.Lbl_DetalleMovimientos.Size = new System.Drawing.Size(203, 20);
            this.Lbl_DetalleMovimientos.TabIndex = 18;
            this.Lbl_DetalleMovimientos.Text = "Detalle de Movimientos";
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Location = new System.Drawing.Point(570, 66);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(152, 28);
            this.Cmb_Tipo.TabIndex = 20;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Tipo.Location = new System.Drawing.Point(586, 31);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(117, 20);
            this.Lbl_Tipo.TabIndex = 21;
            this.Lbl_Tipo.Text = "Cargo/Abono";
            // 
            // Lbl_CodigoCta
            // 
            this.Lbl_CodigoCta.AutoSize = true;
            this.Lbl_CodigoCta.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CodigoCta.Location = new System.Drawing.Point(240, 31);
            this.Lbl_CodigoCta.Name = "Lbl_CodigoCta";
            this.Lbl_CodigoCta.Size = new System.Drawing.Size(128, 20);
            this.Lbl_CodigoCta.TabIndex = 22;
            this.Lbl_CodigoCta.Text = "Codigo Cuenta";
            // 
            // Cmb_CodigoCuenta
            // 
            this.Cmb_CodigoCuenta.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_CodigoCuenta.FormattingEnabled = true;
            this.Cmb_CodigoCuenta.Location = new System.Drawing.Point(10, 66);
            this.Cmb_CodigoCuenta.Name = "Cmb_CodigoCuenta";
            this.Cmb_CodigoCuenta.Size = new System.Drawing.Size(554, 28);
            this.Cmb_CodigoCuenta.TabIndex = 23;
            // 
            // Lbl_Valor
            // 
            this.Lbl_Valor.AutoSize = true;
            this.Lbl_Valor.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Valor.Location = new System.Drawing.Point(792, 31);
            this.Lbl_Valor.Name = "Lbl_Valor";
            this.Lbl_Valor.Size = new System.Drawing.Size(52, 20);
            this.Lbl_Valor.TabIndex = 24;
            this.Lbl_Valor.Text = "Valor";
            // 
            // Txt_Valor
            // 
            this.Txt_Valor.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Valor.Location = new System.Drawing.Point(728, 66);
            this.Txt_Valor.Name = "Txt_Valor";
            this.Txt_Valor.Size = new System.Drawing.Size(171, 27);
            this.Txt_Valor.TabIndex = 25;
            // 
            // Lbl_DctoPoliza
            // 
            this.Lbl_DctoPoliza.AutoSize = true;
            this.Lbl_DctoPoliza.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DctoPoliza.Location = new System.Drawing.Point(-1, 45);
            this.Lbl_DctoPoliza.Name = "Lbl_DctoPoliza";
            this.Lbl_DctoPoliza.Size = new System.Drawing.Size(111, 20);
            this.Lbl_DctoPoliza.TabIndex = 26;
            this.Lbl_DctoPoliza.Text = "Docto. Poliza";
            // 
            // Txt_IdPoliza
            // 
            this.Txt_IdPoliza.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_IdPoliza.Location = new System.Drawing.Point(115, 42);
            this.Txt_IdPoliza.Name = "Txt_IdPoliza";
            this.Txt_IdPoliza.Size = new System.Drawing.Size(148, 27);
            this.Txt_IdPoliza.TabIndex = 27;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Fecha.Location = new System.Drawing.Point(307, 45);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(132, 20);
            this.Lbl_Fecha.TabIndex = 28;
            this.Lbl_Fecha.Text = "Emision (fecha)";
            // 
            // Lbl_Concepto
            // 
            this.Lbl_Concepto.AutoSize = true;
            this.Lbl_Concepto.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Concepto.Location = new System.Drawing.Point(3, 93);
            this.Lbl_Concepto.Name = "Lbl_Concepto";
            this.Lbl_Concepto.Size = new System.Drawing.Size(86, 20);
            this.Lbl_Concepto.TabIndex = 30;
            this.Lbl_Concepto.Text = "Concepto";
            // 
            // Txt_Concepto
            // 
            this.Txt_Concepto.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Concepto.Location = new System.Drawing.Point(109, 93);
            this.Txt_Concepto.Name = "Txt_Concepto";
            this.Txt_Concepto.Size = new System.Drawing.Size(788, 27);
            this.Txt_Concepto.TabIndex = 31;
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Aceptar.Location = new System.Drawing.Point(919, 31);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(100, 62);
            this.Btn_Aceptar.TabIndex = 32;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha.Location = new System.Drawing.Point(454, 40);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(366, 27);
            this.Dtp_Fecha.TabIndex = 33;
            // 
            // Lbl_CargoTtl
            // 
            this.Lbl_CargoTtl.AutoSize = true;
            this.Lbl_CargoTtl.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CargoTtl.Location = new System.Drawing.Point(20, 739);
            this.Lbl_CargoTtl.Name = "Lbl_CargoTtl";
            this.Lbl_CargoTtl.Size = new System.Drawing.Size(106, 20);
            this.Lbl_CargoTtl.TabIndex = 34;
            this.Lbl_CargoTtl.Text = "Total Cargo:";
            // 
            // Lbl_AbonoTtl
            // 
            this.Lbl_AbonoTtl.AutoSize = true;
            this.Lbl_AbonoTtl.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_AbonoTtl.Location = new System.Drawing.Point(422, 739);
            this.Lbl_AbonoTtl.Name = "Lbl_AbonoTtl";
            this.Lbl_AbonoTtl.Size = new System.Drawing.Size(109, 20);
            this.Lbl_AbonoTtl.TabIndex = 35;
            this.Lbl_AbonoTtl.Text = "Total Abono:";
            // 
            // Lbl_DiferencialTtl
            // 
            this.Lbl_DiferencialTtl.AutoSize = true;
            this.Lbl_DiferencialTtl.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DiferencialTtl.Location = new System.Drawing.Point(830, 739);
            this.Lbl_DiferencialTtl.Name = "Lbl_DiferencialTtl";
            this.Lbl_DiferencialTtl.Size = new System.Drawing.Size(101, 20);
            this.Lbl_DiferencialTtl.TabIndex = 36;
            this.Lbl_DiferencialTtl.Text = "Diferencial:";
            // 
            // Gpo_Encabezado
            // 
            this.Gpo_Encabezado.Controls.Add(this.Txt_Concepto);
            this.Gpo_Encabezado.Controls.Add(this.Lbl_DctoPoliza);
            this.Gpo_Encabezado.Controls.Add(this.Txt_IdPoliza);
            this.Gpo_Encabezado.Controls.Add(this.Lbl_Fecha);
            this.Gpo_Encabezado.Controls.Add(this.Dtp_Fecha);
            this.Gpo_Encabezado.Controls.Add(this.Lbl_Concepto);
            this.Gpo_Encabezado.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_Encabezado.Location = new System.Drawing.Point(24, 124);
            this.Gpo_Encabezado.Name = "Gpo_Encabezado";
            this.Gpo_Encabezado.Size = new System.Drawing.Size(907, 134);
            this.Gpo_Encabezado.TabIndex = 38;
            this.Gpo_Encabezado.TabStop = false;
            this.Gpo_Encabezado.Text = "Encabezado Poliza";
            // 
            // Gpo_Detalle
            // 
            this.Gpo_Detalle.Controls.Add(this.Btn_Aceptar);
            this.Gpo_Detalle.Controls.Add(this.Cmb_Tipo);
            this.Gpo_Detalle.Controls.Add(this.Lbl_Tipo);
            this.Gpo_Detalle.Controls.Add(this.Lbl_CodigoCta);
            this.Gpo_Detalle.Controls.Add(this.Cmb_CodigoCuenta);
            this.Gpo_Detalle.Controls.Add(this.Lbl_Valor);
            this.Gpo_Detalle.Controls.Add(this.Txt_Valor);
            this.Gpo_Detalle.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpo_Detalle.Location = new System.Drawing.Point(22, 275);
            this.Gpo_Detalle.Name = "Gpo_Detalle";
            this.Gpo_Detalle.Size = new System.Drawing.Size(1031, 115);
            this.Gpo_Detalle.TabIndex = 39;
            this.Gpo_Detalle.TabStop = false;
            this.Gpo_Detalle.Text = "Detalle de las Polizas";
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingresar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ingresar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_agregar;
            this.Btn_Ingresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Ingresar.Location = new System.Drawing.Point(22, 12);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(127, 80);
            this.Btn_Ingresar.TabIndex = 7;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Ingresar.UseVisualStyleBackColor = true;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_salir;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(718, 12);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(114, 80);
            this.Btn_Salir.TabIndex = 12;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click_1);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Refrescar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Refrescar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_refrescar;
            this.Btn_Refrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Refrescar.Location = new System.Drawing.Point(584, 12);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(128, 80);
            this.Btn_Refrescar.TabIndex = 11;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancelar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_cancelar;
            this.Btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Cancelar.Location = new System.Drawing.Point(453, 12);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(125, 80);
            this.Btn_Cancelar.TabIndex = 10;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Grabar.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Grabar.Image = global::Capa_Vista_Polizas.Properties.Resources.icono_guardar;
            this.Btn_Grabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Grabar.Location = new System.Drawing.Point(293, 12);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(156, 80);
            this.Btn_Grabar.TabIndex = 9;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Frm_DetallePolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 784);
            this.Controls.Add(this.Gpo_Detalle);
            this.Controls.Add(this.Gpo_Encabezado);
            this.Controls.Add(this.Lbl_DiferencialTtl);
            this.Controls.Add(this.Lbl_AbonoTtl);
            this.Controls.Add(this.Lbl_CargoTtl);
            this.Controls.Add(this.Lbl_DetalleMovimientos);
            this.Controls.Add(this.Btn_Quitar);
            this.Controls.Add(this.Lbl_Diferencial);
            this.Controls.Add(this.Lbl_TotalAbono);
            this.Controls.Add(this.Dgv_DetallePoliza);
            this.Controls.Add(this.Lbl_TotalCargo);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Refrescar);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.Btn_Editar);
            this.Controls.Add(this.Btn_Ingresar);
            this.Name = "Frm_DetallePolizas";
            this.Text = "3010 - Detalle Polizas";
            this.Load += new System.EventHandler(this.Frm_DetallePolizas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetallePoliza)).EndInit();
            this.Gpo_Encabezado.ResumeLayout(false);
            this.Gpo_Encabezado.PerformLayout();
            this.Gpo_Detalle.ResumeLayout(false);
            this.Gpo_Detalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Refrescar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Label Lbl_TotalCargo;
        private System.Windows.Forms.DataGridView Dgv_DetallePoliza;
        private System.Windows.Forms.Label Lbl_TotalAbono;
        private System.Windows.Forms.Label Lbl_Diferencial;
        private System.Windows.Forms.Button Btn_Quitar;
        private System.Windows.Forms.Label Lbl_DetalleMovimientos;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.Label Lbl_CodigoCta;
        private System.Windows.Forms.ComboBox Cmb_CodigoCuenta;
        private System.Windows.Forms.Label Lbl_Valor;
        private System.Windows.Forms.TextBox Txt_Valor;
        private System.Windows.Forms.Label Lbl_DctoPoliza;
        private System.Windows.Forms.TextBox Txt_IdPoliza;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.Label Lbl_Concepto;
        private System.Windows.Forms.TextBox Txt_Concepto;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Label Lbl_CargoTtl;
        private System.Windows.Forms.Label Lbl_AbonoTtl;
        private System.Windows.Forms.Label Lbl_DiferencialTtl;
        private System.Windows.Forms.GroupBox Gpo_Encabezado;
        private System.Windows.Forms.GroupBox Gpo_Detalle;
        private System.Windows.Forms.Button Btn_Ingresar;
    }
}