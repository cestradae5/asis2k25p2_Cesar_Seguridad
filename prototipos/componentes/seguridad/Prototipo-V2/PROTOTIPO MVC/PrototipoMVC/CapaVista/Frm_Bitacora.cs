//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Bitacora : Form
    {
        // Controlador (puente con la capa modelo)
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();

        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario(); //Esto llama a modelo, no va aquí

        private int iModuloId = -1;
        private int iAplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)? permisosActuales = null;

        public Frm_Bitacora()
        {
            InitializeComponent();
            CargarUsuariosEnCombo(); // carga usuarios al abrir
            OcultarFiltros();        // opcional
            fun_ConfigurarIdsDinamicamenteYAplicarPermisos();
            CargarEnGrid(ctrlBitacora.MostrarBitacora()); //Mostrar toda la bitácora al inicio
        }

        //Mostrar en pantalla
        private void CargarEnGrid(DataTable dt)
        {
            Dgv_Bitacora.DataSource = dt;
            Dgv_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Bitacora.ReadOnly = true;
            Dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Desplegar usuarios
        private void CargarUsuariosEnCombo()
        {
            try
            {
                var dt = ctrlBitacora.ObtenerUsuarios(); // id, usuario
                Cbo_Usuario.DisplayMember = "usuario";
                Cbo_Usuario.ValueMember = "id";
                Cbo_Usuario.DataSource = dt;
                Cbo_Usuario.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los usuarios: " + ex.Message);
            }
        }

        //No mostrar las barras hasta presionar los botones
        private void OcultarFiltros()
        {
            Lbl_PrimeraFecha.Visible = false;
            Dtp_PrimeraFecha.Visible = false;
            Lbl_SegundaFecha.Visible = false;
            Dtp_SegundaFecha.Visible = false;

            Lbl_FechaEspecifica.Visible = false;
            Dtp_FechaEspecifica.Visible = false;

            Lbl_Usuario.Visible = false;
            Cbo_Usuario.Visible = false;

            Btn_Imprimir.Visible = false;
        }

        // Botones de barra personalizada
        private void Btn_Cerrar_Click(object sender, EventArgs e) => this.Close();

        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal)
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        // Consultar toda la bitácora
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            CargarEnGrid(ctrlBitacora.MostrarBitacora());
        }

        //Exportar
        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Dgv_Bitacora.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = "Guardar Bitácora como CSV",
                    FileName = "Bitacora.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarCsv(dt, sfd.FileName);
                    MessageBox.Show("Bitácora exportada correctamente.",
                                    "Exportar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ExportarCsv(DataTable dt, string ruta)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(dt.Columns[i].ColumnName);
            }
            sb.AppendLine();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(row[i]?.ToString().Replace(",", " "));
                }
                sb.AppendLine();
            }

            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }

        //Imprimir
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Dgv_Bitacora.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PrintDocument doc = new PrintDocument();
                doc.PrintPage += (s, ev) => DibujarBitacora(ev, dt);
                PrintPreviewDialog preview = new PrintPreviewDialog { Document = doc };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void DibujarBitacora(PrintPageEventArgs e, DataTable dt)
        {
            Graphics g = e.Graphics;
            Font fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontCell = new Font("Segoe UI", 9);
            int x = 50;
            int y = 100;
            int rowH = 25;

            g.DrawString("Bitácora", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, x, y - 50);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), fontCell, Brushes.Black, x + 600, y - 40);

            foreach (DataColumn col in dt.Columns)
            {
                g.DrawString(col.ColumnName.ToUpper(), fontHeader, Brushes.Black, x, y);
                x += 120;
            }

            y += rowH;
            x = 50;

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    string texto = item?.ToString() ?? "";
                    g.DrawString(texto, fontCell, Brushes.Black, x, y);
                    x += 120;
                }

                x = 50;
                y += rowH;

                if (y > e.MarginBounds.Bottom - rowH)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        //Salir
        private void Btn_Salir_Click(object sender, EventArgs e) => this.Close();

        // Filtros
        private void Btn_BuscarRango_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_PrimeraFecha.Visible = true;
            Dtp_PrimeraFecha.Visible = true;
            Lbl_SegundaFecha.Visible = true;
            Dtp_SegundaFecha.Visible = true;
            Btn_Imprimir.Visible = true;

            CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Btn_BuscarFecha_Click(object sender, EventArgs e)
        {
            OcultarFiltros();
            Lbl_FechaEspecifica.Visible = true;
            Dtp_FechaEspecifica.Visible = true;
            Btn_Imprimir.Visible = true;
            CargarEnGrid(ctrlBitacora.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        private void Btn_BuscarUsuario_Click(object sender, EventArgs e)
        {
            OcultarFiltros();
            Lbl_Usuario.Visible = true;
            Cbo_Usuario.Visible = true;
            Btn_Imprimir.Visible = true;

            if (Cbo_Usuario.SelectedValue != null &&
                int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
            {
                CargarEnGrid(ctrlBitacora.BuscarPorUsuario(idUsuario));
            }
        }

        // Eventos de cambio de fecha
        private void Dtp_FechaEspecifica_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_FechaEspecifica.Visible)
                CargarEnGrid(ctrlBitacora.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        private void Dtp_PrimeraFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Dtp_SegundaFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Cbo_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cbo_Usuario.Visible || Cbo_Usuario.SelectedValue == null) return;
            if (int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
                CargarEnGrid(ctrlBitacora.BuscarPorUsuario(idUsuario));
        }

        // Panel superior
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Pic_Cerrar_Click(object sender, EventArgs e) => this.Close();

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Bitacoras frm = new Frm_Reporte_Bitacoras();
            frm.Show();
        }

        //Permisos de compañeros
        private void fun_ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            string sNombreModulo = "Seguridad";
            string sNombreAplicacion = "Administracion";
            iAplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(sNombreAplicacion);
            iModuloId = permisoUsuario.ObtenerIdModuloPorNombre(sNombreModulo);
            fun_AplicarPermisosUsuario();
        }

        private void fun_AplicarPermisosUsuario()
        {
            int usuarioId = Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario; // Usuario logueado
            if (iAplicacionId == -1 || iModuloId == -1)
            {
                permisosActuales = null;
                fun_ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, iAplicacionId, iModuloId);
            permisosActuales = permisos;
            fun_ActualizarEstadoBotonesSegunPermisos();
        }

        private void fun_ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
        {
            if (!permisosActuales.HasValue)
            {
                Btn_Consultar.Enabled = false;
                Btn_Exportar.Enabled = false;
                Btn_BuscarFecha.Enabled = false;
                Btn_BuscarUsuario.Enabled = false;
                Btn_BuscarRango.Enabled = false;
                Btn_Imprimir.Enabled = false;
                button1.Enabled = false;
                return;
            }

            var p = permisosActuales.Value;
            Btn_Consultar.Enabled = p.bConsultar;
            Btn_Exportar.Enabled = p.bImprimir;
            Btn_BuscarFecha.Enabled = p.bConsultar;
            Btn_BuscarUsuario.Enabled = p.bConsultar;
            Btn_BuscarRango.Enabled = p.bConsultar;
            Btn_Imprimir.Enabled = p.bConsultar;
            button1.Enabled = p.bConsultar;
        }
    }
}
