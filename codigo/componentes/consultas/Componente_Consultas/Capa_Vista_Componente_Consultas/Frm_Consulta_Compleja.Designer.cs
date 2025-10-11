using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Vista_Componente_Consultas
{
    partial class Frm_Consulta_Compleja
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Declaraciones de controles =====
        private Label Lbl_NombreTabla;
        private ComboBox Cbo_Tabla;

        private GroupBox Gpb_Orden;
        private RadioButton Rdb_Asc;
        private RadioButton Rdb_Des;

        private DataGridView Dgv_Preview; // grid superior

        private GroupBox Gbp_Consultas; // listado derecha
        private ListBox Lst_ConsultasGuardadas;
        private Button Btn_AgregarConsulta;
        private Button Btn_EditarConsulta;
        private Button Btn_EliminarConsulta;

        private GroupBox Gpb_Condiciones; // bloque que reemplaza consola SQL
        private CheckBox Chk_AgregarCondiciones;

        private GroupBox Gpb_Logica;
        private Label Lbl_OpLogico;
        private ComboBox Cbo_OperadorLogico;
        private Label Lbl_CampoCond;
        private ComboBox Cbo_CampoCond;
        private Label Lbl_ValorCond;
        private TextBox Txt_ValorCond;
        private Button Btn_AgregarCond;

        private GroupBox Gpb_Comparacion;
        private Label Lbl_TipoComp;
        private ComboBox Cbo_TipoComparador;
        private Label Lbl_CampoComp;
        private ComboBox Cbo_CampoComp;
        private Label Lbl_ValorComp;
        private TextBox Txt_ValorComp;
        private Button Btn_AgregarComp;

        private GroupBox Gpb_Ordenar;
        private Label Lbl_AgruparOrdenar;
        private ComboBox Cbo_AgruparOrdenar;
        private Label Lbl_CampoOrdenar;
        private ComboBox Cbo_CampoOrdenar;
        private Label Lbl_Ordenamiento;
        private ComboBox Cbo_Ordenamiento;
        private Button Btn_AgregarOrden;
        private Button Btn_Ejecutar;
        private System.Windows.Forms.Button Btn_Limpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Lbl_NombreTabla = new System.Windows.Forms.Label();
            this.Cbo_Tabla = new System.Windows.Forms.ComboBox();
            this.Gpb_Orden = new System.Windows.Forms.GroupBox();
            this.Rdb_Asc = new System.Windows.Forms.RadioButton();
            this.Rdb_Des = new System.Windows.Forms.RadioButton();
            this.Dgv_Preview = new System.Windows.Forms.DataGridView();
            this.Gbp_Consultas = new System.Windows.Forms.GroupBox();
            this.Lst_ConsultasGuardadas = new System.Windows.Forms.ListBox();
            this.Btn_AgregarConsulta = new System.Windows.Forms.Button();
            this.Btn_EditarConsulta = new System.Windows.Forms.Button();
            this.Btn_EliminarConsulta = new System.Windows.Forms.Button();
            this.Gpb_Condiciones = new System.Windows.Forms.GroupBox();
            this.Chk_AgregarCondiciones = new System.Windows.Forms.CheckBox();
            this.Gpb_Logica = new System.Windows.Forms.GroupBox();
            this.Lbl_OpLogico = new System.Windows.Forms.Label();
            this.Cbo_OperadorLogico = new System.Windows.Forms.ComboBox();
            this.Lbl_CampoCond = new System.Windows.Forms.Label();
            this.Cbo_CampoCond = new System.Windows.Forms.ComboBox();
            this.Lbl_ValorCond = new System.Windows.Forms.Label();
            this.Txt_ValorCond = new System.Windows.Forms.TextBox();
            this.Btn_AgregarCond = new System.Windows.Forms.Button();
            this.Gpb_Comparacion = new System.Windows.Forms.GroupBox();
            this.Lbl_TipoComp = new System.Windows.Forms.Label();
            this.Cbo_TipoComparador = new System.Windows.Forms.ComboBox();
            this.Lbl_CampoComp = new System.Windows.Forms.Label();
            this.Cbo_CampoComp = new System.Windows.Forms.ComboBox();
            this.Lbl_ValorComp = new System.Windows.Forms.Label();
            this.Txt_ValorComp = new System.Windows.Forms.TextBox();
            this.Btn_AgregarComp = new System.Windows.Forms.Button();
            this.Gpb_Ordenar = new System.Windows.Forms.GroupBox();
            this.Lbl_AgruparOrdenar = new System.Windows.Forms.Label();
            this.Cbo_AgruparOrdenar = new System.Windows.Forms.ComboBox();
            this.Lbl_CampoOrdenar = new System.Windows.Forms.Label();
            this.Cbo_CampoOrdenar = new System.Windows.Forms.ComboBox();
            this.Lbl_Ordenamiento = new System.Windows.Forms.Label();
            this.Cbo_Ordenamiento = new System.Windows.Forms.ComboBox();
            this.Btn_AgregarOrden = new System.Windows.Forms.Button();
            this.Btn_Ejecutar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Txt_CadenaGenerada = new System.Windows.Forms.TextBox();
            this.Btn_Generar = new System.Windows.Forms.Button();
            this.Btn_Regreso = new System.Windows.Forms.Button();
            this.Gpb_Orden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Preview)).BeginInit();
            this.Gbp_Consultas.SuspendLayout();
            this.Gpb_Condiciones.SuspendLayout();
            this.Gpb_Logica.SuspendLayout();
            this.Gpb_Comparacion.SuspendLayout();
            this.Gpb_Ordenar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_NombreTabla
            // 
            this.Lbl_NombreTabla.AutoSize = true;
            this.Lbl_NombreTabla.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NombreTabla.Location = new System.Drawing.Point(53, 44);
            this.Lbl_NombreTabla.Name = "Lbl_NombreTabla";
            this.Lbl_NombreTabla.Size = new System.Drawing.Size(201, 27);
            this.Lbl_NombreTabla.TabIndex = 0;
            this.Lbl_NombreTabla.Text = "Nombre de tabla";
            // 
            // Cbo_Tabla
            // 
            this.Cbo_Tabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Tabla.Location = new System.Drawing.Point(279, 47);
            this.Cbo_Tabla.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_Tabla.Name = "Cbo_Tabla";
            this.Cbo_Tabla.Size = new System.Drawing.Size(396, 24);
            this.Cbo_Tabla.TabIndex = 1;
            // 
            // Gpb_Orden
            // 
            this.Gpb_Orden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Orden.Controls.Add(this.Rdb_Asc);
            this.Gpb_Orden.Controls.Add(this.Rdb_Des);
            this.Gpb_Orden.Location = new System.Drawing.Point(892, 17);
            this.Gpb_Orden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Orden.Name = "Gpb_Orden";
            this.Gpb_Orden.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Orden.Size = new System.Drawing.Size(198, 54);
            this.Gpb_Orden.TabIndex = 3;
            this.Gpb_Orden.TabStop = false;
            this.Gpb_Orden.Text = "Orden";
            // 
            // Rdb_Asc
            // 
            this.Rdb_Asc.AutoSize = true;
            this.Rdb_Asc.Checked = true;
            this.Rdb_Asc.Location = new System.Drawing.Point(14, 22);
            this.Rdb_Asc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rdb_Asc.Name = "Rdb_Asc";
            this.Rdb_Asc.Size = new System.Drawing.Size(52, 20);
            this.Rdb_Asc.TabIndex = 0;
            this.Rdb_Asc.TabStop = true;
            this.Rdb_Asc.Text = "ASC";
            // 
            // Rdb_Des
            // 
            this.Rdb_Des.AutoSize = true;
            this.Rdb_Des.Location = new System.Drawing.Point(93, 22);
            this.Rdb_Des.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rdb_Des.Name = "Rdb_Des";
            this.Rdb_Des.Size = new System.Drawing.Size(50, 20);
            this.Rdb_Des.TabIndex = 1;
            this.Rdb_Des.Text = "DES";
            // 
            // Dgv_Preview
            // 
            this.Dgv_Preview.AllowUserToAddRows = false;
            this.Dgv_Preview.AllowUserToDeleteRows = false;
            this.Dgv_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Preview.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Dgv_Preview.ColumnHeadersHeight = 29;
            this.Dgv_Preview.Location = new System.Drawing.Point(58, 84);
            this.Dgv_Preview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dgv_Preview.Name = "Dgv_Preview";
            this.Dgv_Preview.ReadOnly = true;
            this.Dgv_Preview.RowHeadersWidth = 51;
            this.Dgv_Preview.Size = new System.Drawing.Size(694, 246);
            this.Dgv_Preview.TabIndex = 4;
            // 
            // Gbp_Consultas
            // 
            this.Gbp_Consultas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Gbp_Consultas.Controls.Add(this.Lst_ConsultasGuardadas);
            this.Gbp_Consultas.Controls.Add(this.Btn_AgregarConsulta);
            this.Gbp_Consultas.Controls.Add(this.Btn_EditarConsulta);
            this.Gbp_Consultas.Controls.Add(this.Btn_EliminarConsulta);
            this.Gbp_Consultas.Location = new System.Drawing.Point(822, 75);
            this.Gbp_Consultas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gbp_Consultas.Name = "Gbp_Consultas";
            this.Gbp_Consultas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gbp_Consultas.Size = new System.Drawing.Size(385, 308);
            this.Gbp_Consultas.TabIndex = 5;
            this.Gbp_Consultas.TabStop = false;
            this.Gbp_Consultas.Text = "Consulta";
            // 
            // Lst_ConsultasGuardadas
            // 
            this.Lst_ConsultasGuardadas.ItemHeight = 16;
            this.Lst_ConsultasGuardadas.Location = new System.Drawing.Point(19, 30);
            this.Lst_ConsultasGuardadas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Lst_ConsultasGuardadas.Name = "Lst_ConsultasGuardadas";
            this.Lst_ConsultasGuardadas.Size = new System.Drawing.Size(347, 180);
            this.Lst_ConsultasGuardadas.TabIndex = 0;
            // 
            // Btn_AgregarConsulta
            // 
            this.Btn_AgregarConsulta.Location = new System.Drawing.Point(19, 254);
            this.Btn_AgregarConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_AgregarConsulta.Name = "Btn_AgregarConsulta";
            this.Btn_AgregarConsulta.Size = new System.Drawing.Size(93, 32);
            this.Btn_AgregarConsulta.TabIndex = 1;
            this.Btn_AgregarConsulta.Text = "Agregar";
            // 
            // Btn_EditarConsulta
            // 
            this.Btn_EditarConsulta.Location = new System.Drawing.Point(142, 254);
            this.Btn_EditarConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_EditarConsulta.Name = "Btn_EditarConsulta";
            this.Btn_EditarConsulta.Size = new System.Drawing.Size(93, 32);
            this.Btn_EditarConsulta.TabIndex = 2;
            this.Btn_EditarConsulta.Text = "Editar";
            // 
            // Btn_EliminarConsulta
            // 
            this.Btn_EliminarConsulta.Location = new System.Drawing.Point(254, 254);
            this.Btn_EliminarConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_EliminarConsulta.Name = "Btn_EliminarConsulta";
            this.Btn_EliminarConsulta.Size = new System.Drawing.Size(93, 32);
            this.Btn_EliminarConsulta.TabIndex = 3;
            this.Btn_EliminarConsulta.Text = "Eliminar";
            // 
            // Gpb_Condiciones
            // 
            this.Gpb_Condiciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Gpb_Condiciones.Controls.Add(this.Chk_AgregarCondiciones);
            this.Gpb_Condiciones.Controls.Add(this.Gpb_Logica);
            this.Gpb_Condiciones.Controls.Add(this.Gpb_Comparacion);
            this.Gpb_Condiciones.Controls.Add(this.Gpb_Ordenar);
            this.Gpb_Condiciones.Location = new System.Drawing.Point(58, 391);
            this.Gpb_Condiciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Condiciones.Name = "Gpb_Condiciones";
            this.Gpb_Condiciones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Condiciones.Size = new System.Drawing.Size(994, 271);
            this.Gpb_Condiciones.TabIndex = 6;
            this.Gpb_Condiciones.TabStop = false;
            this.Gpb_Condiciones.Text = "Condiciones - Consulta Compleja";
            // 
            // Chk_AgregarCondiciones
            // 
            this.Chk_AgregarCondiciones.AutoSize = true;
            this.Chk_AgregarCondiciones.Location = new System.Drawing.Point(19, 27);
            this.Chk_AgregarCondiciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chk_AgregarCondiciones.Name = "Chk_AgregarCondiciones";
            this.Chk_AgregarCondiciones.Size = new System.Drawing.Size(151, 20);
            this.Chk_AgregarCondiciones.TabIndex = 0;
            this.Chk_AgregarCondiciones.Text = "Agregar Condiciones";
            // 
            // Gpb_Logica
            // 
            this.Gpb_Logica.Controls.Add(this.Lbl_OpLogico);
            this.Gpb_Logica.Controls.Add(this.Cbo_OperadorLogico);
            this.Gpb_Logica.Controls.Add(this.Lbl_CampoCond);
            this.Gpb_Logica.Controls.Add(this.Cbo_CampoCond);
            this.Gpb_Logica.Controls.Add(this.Lbl_ValorCond);
            this.Gpb_Logica.Controls.Add(this.Txt_ValorCond);
            this.Gpb_Logica.Controls.Add(this.Btn_AgregarCond);
            this.Gpb_Logica.Location = new System.Drawing.Point(19, 59);
            this.Gpb_Logica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Logica.Name = "Gpb_Logica";
            this.Gpb_Logica.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Logica.Size = new System.Drawing.Size(414, 148);
            this.Gpb_Logica.TabIndex = 1;
            this.Gpb_Logica.TabStop = false;
            this.Gpb_Logica.Text = "Lógica";
            // 
            // Lbl_OpLogico
            // 
            this.Lbl_OpLogico.AutoSize = true;
            this.Lbl_OpLogico.Location = new System.Drawing.Point(14, 32);
            this.Lbl_OpLogico.Name = "Lbl_OpLogico";
            this.Lbl_OpLogico.Size = new System.Drawing.Size(107, 16);
            this.Lbl_OpLogico.TabIndex = 0;
            this.Lbl_OpLogico.Text = "Operador Lógico";
            // 
            // Cbo_OperadorLogico
            // 
            this.Cbo_OperadorLogico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_OperadorLogico.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.Cbo_OperadorLogico.Location = new System.Drawing.Point(163, 27);
            this.Cbo_OperadorLogico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_OperadorLogico.Name = "Cbo_OperadorLogico";
            this.Cbo_OperadorLogico.Size = new System.Drawing.Size(221, 24);
            this.Cbo_OperadorLogico.TabIndex = 1;
            // 
            // Lbl_CampoCond
            // 
            this.Lbl_CampoCond.AutoSize = true;
            this.Lbl_CampoCond.Location = new System.Drawing.Point(14, 66);
            this.Lbl_CampoCond.Name = "Lbl_CampoCond";
            this.Lbl_CampoCond.Size = new System.Drawing.Size(51, 16);
            this.Lbl_CampoCond.TabIndex = 2;
            this.Lbl_CampoCond.Text = "Campo";
            // 
            // Cbo_CampoCond
            // 
            this.Cbo_CampoCond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_CampoCond.Location = new System.Drawing.Point(163, 62);
            this.Cbo_CampoCond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_CampoCond.Name = "Cbo_CampoCond";
            this.Cbo_CampoCond.Size = new System.Drawing.Size(221, 24);
            this.Cbo_CampoCond.TabIndex = 3;
            // 
            // Lbl_ValorCond
            // 
            this.Lbl_ValorCond.AutoSize = true;
            this.Lbl_ValorCond.Location = new System.Drawing.Point(14, 101);
            this.Lbl_ValorCond.Name = "Lbl_ValorCond";
            this.Lbl_ValorCond.Size = new System.Drawing.Size(39, 16);
            this.Lbl_ValorCond.TabIndex = 4;
            this.Lbl_ValorCond.Text = "Valor";
            // 
            // Txt_ValorCond
            // 
            this.Txt_ValorCond.Location = new System.Drawing.Point(85, 98);
            this.Txt_ValorCond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_ValorCond.MaxLength = 100;
            this.Txt_ValorCond.Name = "Txt_ValorCond";
            this.Txt_ValorCond.Size = new System.Drawing.Size(174, 23);
            this.Txt_ValorCond.TabIndex = 5;
            // 
            // Btn_AgregarCond
            // 
            this.Btn_AgregarCond.Location = new System.Drawing.Point(265, 95);
            this.Btn_AgregarCond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_AgregarCond.Name = "Btn_AgregarCond";
            this.Btn_AgregarCond.Size = new System.Drawing.Size(143, 32);
            this.Btn_AgregarCond.TabIndex = 6;
            this.Btn_AgregarCond.Text = "Agregar valor";
            // 
            // Gpb_Comparacion
            // 
            this.Gpb_Comparacion.Controls.Add(this.Lbl_TipoComp);
            this.Gpb_Comparacion.Controls.Add(this.Cbo_TipoComparador);
            this.Gpb_Comparacion.Controls.Add(this.Lbl_CampoComp);
            this.Gpb_Comparacion.Controls.Add(this.Cbo_CampoComp);
            this.Gpb_Comparacion.Controls.Add(this.Lbl_ValorComp);
            this.Gpb_Comparacion.Controls.Add(this.Txt_ValorComp);
            this.Gpb_Comparacion.Controls.Add(this.Btn_AgregarComp);
            this.Gpb_Comparacion.Location = new System.Drawing.Point(457, 59);
            this.Gpb_Comparacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Comparacion.Name = "Gpb_Comparacion";
            this.Gpb_Comparacion.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Comparacion.Size = new System.Drawing.Size(411, 148);
            this.Gpb_Comparacion.TabIndex = 2;
            this.Gpb_Comparacion.TabStop = false;
            this.Gpb_Comparacion.Text = "Comparación";
            // 
            // Lbl_TipoComp
            // 
            this.Lbl_TipoComp.AutoSize = true;
            this.Lbl_TipoComp.Location = new System.Drawing.Point(14, 32);
            this.Lbl_TipoComp.Name = "Lbl_TipoComp";
            this.Lbl_TipoComp.Size = new System.Drawing.Size(111, 16);
            this.Lbl_TipoComp.TabIndex = 0;
            this.Lbl_TipoComp.Text = "Tipo Comparador";
            // 
            // Cbo_TipoComparador
            // 
            this.Cbo_TipoComparador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_TipoComparador.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            "<",
            ">=",
            "<=",
            "LIKE",
            "BETWEEN"});
            this.Cbo_TipoComparador.Location = new System.Drawing.Point(163, 27);
            this.Cbo_TipoComparador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_TipoComparador.Name = "Cbo_TipoComparador";
            this.Cbo_TipoComparador.Size = new System.Drawing.Size(221, 24);
            this.Cbo_TipoComparador.TabIndex = 1;
            // 
            // Lbl_CampoComp
            // 
            this.Lbl_CampoComp.AutoSize = true;
            this.Lbl_CampoComp.Location = new System.Drawing.Point(14, 66);
            this.Lbl_CampoComp.Name = "Lbl_CampoComp";
            this.Lbl_CampoComp.Size = new System.Drawing.Size(51, 16);
            this.Lbl_CampoComp.TabIndex = 2;
            this.Lbl_CampoComp.Text = "Campo";
            // 
            // Cbo_CampoComp
            // 
            this.Cbo_CampoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_CampoComp.Location = new System.Drawing.Point(163, 62);
            this.Cbo_CampoComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_CampoComp.Name = "Cbo_CampoComp";
            this.Cbo_CampoComp.Size = new System.Drawing.Size(221, 24);
            this.Cbo_CampoComp.TabIndex = 3;
            // 
            // Lbl_ValorComp
            // 
            this.Lbl_ValorComp.AutoSize = true;
            this.Lbl_ValorComp.Location = new System.Drawing.Point(14, 101);
            this.Lbl_ValorComp.Name = "Lbl_ValorComp";
            this.Lbl_ValorComp.Size = new System.Drawing.Size(39, 16);
            this.Lbl_ValorComp.TabIndex = 4;
            this.Lbl_ValorComp.Text = "Valor";
            // 
            // Txt_ValorComp
            // 
            this.Txt_ValorComp.Location = new System.Drawing.Point(72, 99);
            this.Txt_ValorComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_ValorComp.MaxLength = 100;
            this.Txt_ValorComp.Name = "Txt_ValorComp";
            this.Txt_ValorComp.Size = new System.Drawing.Size(174, 23);
            this.Txt_ValorComp.TabIndex = 5;
            // 
            // Btn_AgregarComp
            // 
            this.Btn_AgregarComp.Location = new System.Drawing.Point(252, 98);
            this.Btn_AgregarComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_AgregarComp.Name = "Btn_AgregarComp";
            this.Btn_AgregarComp.Size = new System.Drawing.Size(145, 32);
            this.Btn_AgregarComp.TabIndex = 6;
            this.Btn_AgregarComp.Text = "Agregar valor";
            // 
            // Gpb_Ordenar
            // 
            this.Gpb_Ordenar.Controls.Add(this.Lbl_AgruparOrdenar);
            this.Gpb_Ordenar.Controls.Add(this.Cbo_AgruparOrdenar);
            this.Gpb_Ordenar.Controls.Add(this.Lbl_CampoOrdenar);
            this.Gpb_Ordenar.Controls.Add(this.Cbo_CampoOrdenar);
            this.Gpb_Ordenar.Controls.Add(this.Lbl_Ordenamiento);
            this.Gpb_Ordenar.Controls.Add(this.Cbo_Ordenamiento);
            this.Gpb_Ordenar.Controls.Add(this.Btn_AgregarOrden);
            this.Gpb_Ordenar.Location = new System.Drawing.Point(19, 209);
            this.Gpb_Ordenar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Ordenar.Name = "Gpb_Ordenar";
            this.Gpb_Ordenar.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Gpb_Ordenar.Size = new System.Drawing.Size(849, 49);
            this.Gpb_Ordenar.TabIndex = 3;
            this.Gpb_Ordenar.TabStop = false;
            this.Gpb_Ordenar.Text = "Agrupar - Ordenar";
            // 
            // Lbl_AgruparOrdenar
            // 
            this.Lbl_AgruparOrdenar.AutoSize = true;
            this.Lbl_AgruparOrdenar.Location = new System.Drawing.Point(14, 20);
            this.Lbl_AgruparOrdenar.Name = "Lbl_AgruparOrdenar";
            this.Lbl_AgruparOrdenar.Size = new System.Drawing.Size(112, 16);
            this.Lbl_AgruparOrdenar.TabIndex = 0;
            this.Lbl_AgruparOrdenar.Text = "Agrupar/Ordenar";
            // 
            // Cbo_AgruparOrdenar
            // 
            this.Cbo_AgruparOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_AgruparOrdenar.Items.AddRange(new object[] {
            "GROUP BY",
            "ORDER BY"});
            this.Cbo_AgruparOrdenar.Location = new System.Drawing.Point(140, 15);
            this.Cbo_AgruparOrdenar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_AgruparOrdenar.Name = "Cbo_AgruparOrdenar";
            this.Cbo_AgruparOrdenar.Size = new System.Drawing.Size(128, 24);
            this.Cbo_AgruparOrdenar.TabIndex = 1;
            // 
            // Lbl_CampoOrdenar
            // 
            this.Lbl_CampoOrdenar.AutoSize = true;
            this.Lbl_CampoOrdenar.Location = new System.Drawing.Point(280, 20);
            this.Lbl_CampoOrdenar.Name = "Lbl_CampoOrdenar";
            this.Lbl_CampoOrdenar.Size = new System.Drawing.Size(51, 16);
            this.Lbl_CampoOrdenar.TabIndex = 2;
            this.Lbl_CampoOrdenar.Text = "Campo";
            // 
            // Cbo_CampoOrdenar
            // 
            this.Cbo_CampoOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_CampoOrdenar.Location = new System.Drawing.Point(338, 15);
            this.Cbo_CampoOrdenar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_CampoOrdenar.Name = "Cbo_CampoOrdenar";
            this.Cbo_CampoOrdenar.Size = new System.Drawing.Size(198, 24);
            this.Cbo_CampoOrdenar.TabIndex = 3;
            // 
            // Lbl_Ordenamiento
            // 
            this.Lbl_Ordenamiento.AutoSize = true;
            this.Lbl_Ordenamiento.Location = new System.Drawing.Point(542, 20);
            this.Lbl_Ordenamiento.Name = "Lbl_Ordenamiento";
            this.Lbl_Ordenamiento.Size = new System.Drawing.Size(91, 16);
            this.Lbl_Ordenamiento.TabIndex = 4;
            this.Lbl_Ordenamiento.Text = "Ordenamiento";
            // 
            // Cbo_Ordenamiento
            // 
            this.Cbo_Ordenamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Ordenamiento.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.Cbo_Ordenamiento.Location = new System.Drawing.Point(653, 15);
            this.Cbo_Ordenamiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbo_Ordenamiento.Name = "Cbo_Ordenamiento";
            this.Cbo_Ordenamiento.Size = new System.Drawing.Size(93, 24);
            this.Cbo_Ordenamiento.TabIndex = 5;
            // 
            // Btn_AgregarOrden
            // 
            this.Btn_AgregarOrden.Location = new System.Drawing.Point(758, 14);
            this.Btn_AgregarOrden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_AgregarOrden.Name = "Btn_AgregarOrden";
            this.Btn_AgregarOrden.Size = new System.Drawing.Size(91, 32);
            this.Btn_AgregarOrden.TabIndex = 6;
            this.Btn_AgregarOrden.Text = "Agregar valor";
            // 
            // Btn_Ejecutar
            // 
            this.Btn_Ejecutar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Ejecutar.Location = new System.Drawing.Point(472, 670);
            this.Btn_Ejecutar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Ejecutar.Name = "Btn_Ejecutar";
            this.Btn_Ejecutar.Size = new System.Drawing.Size(141, 74);
            this.Btn_Ejecutar.TabIndex = 9;
            this.Btn_Ejecutar.Text = "Ejecutar Consulta";
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Limpiar.Location = new System.Drawing.Point(740, 670);
            this.Btn_Limpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(132, 74);
            this.Btn_Limpiar.TabIndex = 10;
            this.Btn_Limpiar.Text = "Limpiar";
            // 
            // Txt_CadenaGenerada
            // 
            this.Txt_CadenaGenerada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_CadenaGenerada.Location = new System.Drawing.Point(257, 752);
            this.Txt_CadenaGenerada.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_CadenaGenerada.Name = "Txt_CadenaGenerada";
            this.Txt_CadenaGenerada.Size = new System.Drawing.Size(587, 23);
            this.Txt_CadenaGenerada.TabIndex = 7;
            // 
            // Btn_Generar
            // 
            this.Btn_Generar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Generar.Location = new System.Drawing.Point(257, 670);
            this.Btn_Generar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Generar.Name = "Btn_Generar";
            this.Btn_Generar.Size = new System.Drawing.Size(128, 74);
            this.Btn_Generar.TabIndex = 8;
            this.Btn_Generar.Text = "Generar";
            // 
            // Btn_Regreso
            // 
            this.Btn_Regreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regreso.Location = new System.Drawing.Point(1186, 1);
            this.Btn_Regreso.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Regreso.Name = "Btn_Regreso";
            this.Btn_Regreso.Size = new System.Drawing.Size(95, 28);
            this.Btn_Regreso.TabIndex = 16;
            this.Btn_Regreso.Text = "Regresar";
            this.Btn_Regreso.UseVisualStyleBackColor = true;
            this.Btn_Regreso.Click += new System.EventHandler(this.Btn_Regreso_Click);
            // 
            // Frm_Consulta_Compleja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1276, 788);
            this.Controls.Add(this.Btn_Regreso);
            this.Controls.Add(this.Lbl_NombreTabla);
            this.Controls.Add(this.Cbo_Tabla);
            this.Controls.Add(this.Gpb_Orden);
            this.Controls.Add(this.Dgv_Preview);
            this.Controls.Add(this.Gbp_Consultas);
            this.Controls.Add(this.Gpb_Condiciones);
            this.Controls.Add(this.Txt_CadenaGenerada);
            this.Controls.Add(this.Btn_Generar);
            this.Controls.Add(this.Btn_Ejecutar);
            this.Controls.Add(this.Btn_Limpiar);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Consulta_Compleja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Compleja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Gpb_Orden.ResumeLayout(false);
            this.Gpb_Orden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Preview)).EndInit();
            this.Gbp_Consultas.ResumeLayout(false);
            this.Gpb_Condiciones.ResumeLayout(false);
            this.Gpb_Condiciones.PerformLayout();
            this.Gpb_Logica.ResumeLayout(false);
            this.Gpb_Logica.PerformLayout();
            this.Gpb_Comparacion.ResumeLayout(false);
            this.Gpb_Comparacion.PerformLayout();
            this.Gpb_Ordenar.ResumeLayout(false);
            this.Gpb_Ordenar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox Txt_CadenaGenerada;
        private Button Btn_Generar;
        private Button Btn_Regreso;
    }
}
