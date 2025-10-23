//Inicio de código de Arón Ricardo Esquit Silva   0901-22-13036   12/10/2025
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Bitacora : Form
    {
        //Controlador
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        // Variables de permisos
        private bool _canConsultar, _canImprimir;

        public Frm_Bitacora()
        {
            InitializeComponent();

            try
            {
                fun_CargarUsuariosEnCombo(); //Carga inicial
                fun_OcultarFiltros();        //Oculta los filtros al inicio
                CargarEnGrid(ctrlBitacora.MostrarBitacora()); //Carga completa de bitácora
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la Bitácora",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            fun_AplicarPermisos(); // APLICAR PERMISOS AL FINAL
        }
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Bitacora");
            if (idAplicacion <= 0) idAplicacion = 309; // Cambia por tu ID real si aplica
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canConsultar = permisos.consultar;
            _canImprimir = permisos.imprimir;

            // Botones principales
            if (Btn_Consultar != null) Btn_Consultar.Enabled = _canConsultar;
            if (Btn_Exportar != null) Btn_Exportar.Enabled = _canImprimir;
            if (Btn_Imprimir != null) Btn_Imprimir.Enabled = _canImprimir;
            if (Btn_BuscarRango != null) Btn_BuscarRango.Enabled = _canConsultar;
            if (Btn_BuscarFecha != null) Btn_BuscarFecha.Enabled = _canConsultar;
            if (Btn_BuscarUsuario != null) Btn_BuscarUsuario.Enabled = _canConsultar;
            if (button1 != null) button1.Enabled = _canImprimir; // Botón de reporte

            // Controles de filtro y DataGrid
            if (Cbo_Usuario != null) Cbo_Usuario.Enabled = _canConsultar;
            if (Dgv_Bitacora != null) Dgv_Bitacora.Enabled = _canConsultar;
        }

        //Mostrar en pantalla
        private void CargarEnGrid(DataTable dt)
        {
            Dgv_Bitacora.DataSource = dt;
            Dgv_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Bitacora.ReadOnly = true;
            Dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Ajustar texto dentro de las celdas 
            Dgv_Bitacora.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //Ajustar automáticamente la altura de las filas
            Dgv_Bitacora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Centrar verticalmente el texto
            Dgv_Bitacora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //Ajustar también encabezados
            Dgv_Bitacora.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        //Carga de usuarios
        private void fun_CargarUsuariosEnCombo()
        {
            var dt = ctrlBitacora.ObtenerUsuarios();
            Cbo_Usuario.DisplayMember = "usuario";
            Cbo_Usuario.ValueMember = "id";
            Cbo_Usuario.DataSource = dt;
            Cbo_Usuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Ocultar filtros
        private void fun_OcultarFiltros()
        {
            Lbl_PrimeraFecha.Visible = false;
            Dtp_PrimeraFecha.Visible = false;
            Lbl_SegundaFecha.Visible = false;
            Dtp_SegundaFecha.Visible = false;
            Lbl_FechaEspecifica.Visible = false;
            Dtp_FechaEspecifica.Visible = false;
            Lbl_Usuario.Visible = false;
            Cbo_Usuario.Visible = false;
            Btn_Imprimir.Visible = true;
        }

        //Botones de barra personalizada
        private void Btn_Cerrar_Click(object sender, EventArgs e) => this.Close();

        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal)
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        //Consulta completa
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            CargarEnGrid(ctrlBitacora.MostrarBitacora());
            fun_AplicarPermisos();
        }

        //Exportar
        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Dgv_Bitacora.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ctrlBitacora.ExportarBitacora(dt, sfd.FileName);
                MessageBox.Show("Bitácora exportada correctamente.",
                                "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Imprimir
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Dgv_Bitacora.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Imprimir",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (s, ev) => DibujarBitacora(ev, dt);
            PrintPreviewDialog preview = new PrintPreviewDialog { Document = doc };
            preview.ShowDialog();
        }

        //Dibujo de impresión
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

        //Filtros por rango
        private void Btn_BuscarRango_Click(object sender, EventArgs e)
        {
            fun_OcultarFiltros();
            Lbl_PrimeraFecha.Visible = true;
            Dtp_PrimeraFecha.Visible = true;
            Lbl_SegundaFecha.Visible = true;
            Dtp_SegundaFecha.Visible = true;
            Btn_Imprimir.Visible = true;
            CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
            fun_AplicarPermisos();
        }

        //Filtros por fecha específica
        private void Btn_BuscarFecha_Click(object sender, EventArgs e)
        {
            fun_OcultarFiltros();
            Lbl_FechaEspecifica.Visible = true;
            Dtp_FechaEspecifica.Visible = true;
            Btn_Imprimir.Visible = true;
            CargarEnGrid(ctrlBitacora.BuscarPorFecha(Dtp_FechaEspecifica.Value));
            fun_AplicarPermisos();
        }

        //Filtros por usuario
        private void Btn_BuscarUsuario_Click(object sender, EventArgs e)
        {
            fun_OcultarFiltros();
            Lbl_Usuario.Visible = true;
            Cbo_Usuario.Visible = true;
            Btn_Imprimir.Visible = true;

            if (Cbo_Usuario.SelectedValue != null &&
                int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
            {
                CargarEnGrid(ctrlBitacora.BuscarPorUsuario(idUsuario));
            }
            fun_AplicarPermisos();
        }

        //Eventos de cambio de fecha
        private void Dtp_FechaEspecifica_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_FechaEspecifica.Visible)
            {
                CargarEnGrid(ctrlBitacora.BuscarPorFecha(Dtp_FechaEspecifica.Value));
                fun_AplicarPermisos();
            }
        }

        private void Dtp_PrimeraFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
            {
                CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
                fun_AplicarPermisos();
            }
        }

        private void Dtp_SegundaFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
            {
                CargarEnGrid(ctrlBitacora.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
                fun_AplicarPermisos();
            }
        }

        private void Cbo_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cbo_Usuario.Visible || Cbo_Usuario.SelectedValue == null) return;
            if (int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
                CargarEnGrid(ctrlBitacora.BuscarPorUsuario(idUsuario));
            fun_AplicarPermisos();
        }

        //Panel superior
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

        //Reporte
        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Bitacoras frm = new Frm_Reporte_Bitacoras();
            frm.Show();
            fun_AplicarPermisos();
        }
    }
}