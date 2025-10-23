using System;
using System.Data;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    public partial class Consulta : Form
    {
        private readonly Controlador cn = new Controlador();

        public Consulta()
        {
            InitializeComponent();

            // Configuración del DataGridView
            Dgv_registros.AutoGenerateColumns = true;
            Dgv_registros.ReadOnly = true;
            Dgv_registros.AllowUserToAddRows = false;
            Dgv_registros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_registros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Dgv_registros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Dgv_registros.CellFormatting += Dgv_registros_CellFormatting;
        }

        // Cargar datos de bitácora
        public void actualizardatagriew()
        {
            try
            {
                DataTable dt = cn.ObtenerBitacora();
                Dgv_registros.DataSource = dt;

                // Encabezados si existen esas columnas
                if (Dgv_registros.Columns.Contains("id")) Dgv_registros.Columns["id"].HeaderText = "ID";
                if (Dgv_registros.Columns.Contains("usuario")) Dgv_registros.Columns["usuario"].HeaderText = "Usuario";
                if (Dgv_registros.Columns.Contains("aplicacion")) Dgv_registros.Columns["aplicacion"].HeaderText = "Aplicación";
                if (Dgv_registros.Columns.Contains("fecha")) Dgv_registros.Columns["fecha"].HeaderText = "Fecha";
                if (Dgv_registros.Columns.Contains("accion")) Dgv_registros.Columns["accion"].HeaderText = "Acción";
                if (Dgv_registros.Columns.Contains("ip")) Dgv_registros.Columns["ip"].HeaderText = "IP";
                if (Dgv_registros.Columns.Contains("equipo")) Dgv_registros.Columns["equipo"].HeaderText = "Equipo";
                if (Dgv_registros.Columns.Contains("login")) Dgv_registros.Columns["login"].HeaderText = "Login";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar bitácora:\n" + ex.Message,
                                "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Consulta_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void Dgv_registros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = Dgv_registros.Columns[e.ColumnIndex].Name;

            if (col == "fecha" && e.Value != null && e.Value != DBNull.Value
                && DateTime.TryParse(e.Value.ToString(), out var dt))
            {
                e.Value = dt.ToString("yyyy-MM-dd HH:mm");
                e.FormattingApplied = true;
            }

            if (col == "login" && e.Value != null && e.Value != DBNull.Value
                && int.TryParse(e.Value.ToString(), out var val))
            {
                e.Value = (val != 0) ? "Sí" : "No";
                e.FormattingApplied = true;
            }
        }
    }
}
