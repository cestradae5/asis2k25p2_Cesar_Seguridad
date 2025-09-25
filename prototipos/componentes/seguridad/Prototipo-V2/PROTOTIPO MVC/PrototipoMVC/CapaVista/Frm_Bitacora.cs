//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class Frm_Bitacora : Form
    {
        // Controlador (puente con la capa modelo)
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();

        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;

        public Frm_Bitacora()
        {
            InitializeComponent();
            CargarUsuariosEnCombo(); // carga usuarios al abrir
            OcultarFiltros();        // opcional
            ConfigurarIdsDinamicamenteYAplicarPermisos();
            CargarEnGrid(ctrlBitacora.MostrarBitacora()); //Mostrar toda la bitacora al inicio
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

        //No mostrar las barras hasta precionar los botones
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
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        // Comandos de la vista
        private void Btn_Consultar_Click(object sender, EventArgs e) =>
            CargarEnGrid(ctrlBitacora.MostrarBitacora());

        //Exportar
        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = "Guardar Bitácora como CSV",
                    FileName = "Bitacora.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ctrlBitacora.ExportarCsv(sfd.FileName);
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

        //Imprimir
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument doc = ctrlBitacora.CrearDocumentoImpresion();
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

        //Muestra la barra de fecha
        private void Btn_BuscarFecha_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_FechaEspecifica.Visible = true;
            Dtp_FechaEspecifica.Visible = true;
            Btn_Imprimir.Visible = true;

            CargarEnGrid(ctrlBitacora.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        //Botos para buscar usuari0
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

        //Buscar por fecha especifica
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

        //Filtrar por usuario seleccionado
        private void Cbo_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cbo_Usuario.Visible || Cbo_Usuario.SelectedValue == null) return;

            if (int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
                CargarEnGrid(ctrlBitacora.BuscarPorUsuario(idUsuario));
        }

        // Panel superior
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

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
            frmReporte_Bitacoras frm = new frmReporte_Bitacoras();
            frm.Show();
        }



        //0901-21-1115 Marcos Andres Velasquez Alcánatara -- permisos script
        //0901-22-9663 Brandon Alexander Hernandez Salguero --  asignacion Modulos y aplicaciones


        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            // Cambia estos nombres exactamente como están en tu BD
            string nombreModulo = "Seguridad";
            string nombreAplicacion = "Administracion";
            aplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(nombreAplicacion);
            moduloId = permisoUsuario.ObtenerIdModuloPorNombre(nombreModulo);
            AplicarPermisosUsuario();
        }

        private void AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado
            if (aplicacionId == -1 || moduloId == -1)
            {
                permisosActuales = null;
                ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);
            permisosActuales = permisos;
            ActualizarEstadoBotonesSegunPermisos();
        }

        // Centraliza el habilitado/deshabilitado de botones según permisos y estado de navegación
        private void ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
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

            Btn_Consultar.Enabled = p.consultar;
            Btn_Exportar.Enabled = p.imprimir;
            Btn_BuscarFecha.Enabled = p.consultar;
            Btn_BuscarUsuario.Enabled = p.consultar;
            Btn_BuscarRango.Enabled = p.consultar;
            Btn_Imprimir.Enabled = p.consultar;
            button1.Enabled = p.consultar;


        }


    }
}