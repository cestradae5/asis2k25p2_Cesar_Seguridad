// Autor: Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaControlador;

namespace CapaVista
{
    public partial class Frm_Bitacora : Form
    {
        // Controlador (puente con la capa modelo)
        private readonly Cls_BitacoraControlador _ctrl = new Cls_BitacoraControlador();

        public Frm_Bitacora()
        {
            InitializeComponent();
            CargarUsuariosEnCombo(); // carga usuarios al abrir
            OcultarFiltros();        // opcional
        }



        private void CargarEnGrid(DataTable dt)
        {
            Dgv_Bitacora.DataSource = dt; // ajusta el nombre si tu grid se llama distinto
            Dgv_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Bitacora.ReadOnly = true;
            Dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarUsuariosEnCombo()
        {
            try
            {
                var dt = _ctrl.ObtenerUsuarios(); // id, usuario
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

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        // Comandos de la vista

        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            CargarEnGrid(_ctrl.MostrarBitacora());
        }

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
                    _ctrl.ExportarCsv(sfd.FileName);
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

        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument doc = _ctrl.CrearDocumentoImpresion();

                // Vista previa 
                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = doc
                };
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

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Filtros (mostrar/ocultar)


        private void Btn_BuscarRango_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_PrimeraFecha.Visible = true;
            Dtp_PrimeraFecha.Visible = true;
            Lbl_SegundaFecha.Visible = true;
            Dtp_SegundaFecha.Visible = true;

            Btn_Imprimir.Visible = true;

            // Hace una primera carga con el rango actual
            CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Btn_BuscarFecha_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_FechaEspecifica.Visible = true;
            Dtp_FechaEspecifica.Visible = true;

            Btn_Imprimir.Visible = true;

            // Hace una primera carga con la fecha actual
            CargarEnGrid(_ctrl.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        private void Btn_BuscarUsuario_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_Usuario.Visible = true;
            Cbo_Usuario.Visible = true;

            Btn_Imprimir.Visible = true;

            // Si ya hay usuario seleccionado, filtra
            if (Cbo_Usuario.SelectedValue != null &&
                int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
            {
                CargarEnGrid(_ctrl.BuscarPorUsuario(idUsuario));
            }
        }

        private void Dtp_FechaEspecifica_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_FechaEspecifica.Visible)
                CargarEnGrid(_ctrl.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        private void Dtp_PrimeraFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Dtp_SegundaFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        private void Cbo_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cbo_Usuario.Visible) return;
            if (Cbo_Usuario.SelectedValue == null) return;

            if (int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
                CargarEnGrid(_ctrl.BuscarPorUsuario(idUsuario));
        }

        // Panel superior
        //0901-20-4620 Ruben Armando Lopez Luch

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Libera el mouse
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Simula arrastre
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReporte_Bitacora frm = new frmReporte_Bitacora();
            frm.Show();
        }
    }
}
