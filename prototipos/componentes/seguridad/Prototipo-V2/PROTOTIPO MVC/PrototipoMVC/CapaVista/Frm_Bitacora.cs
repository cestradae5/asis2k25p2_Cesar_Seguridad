// Arón Ricardo Esquit Silva
// Carnet: 0901-22-13036
// Fecha: 12/09/2025

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
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
        }

        private void Frm_Bitacora_Load(object sender, EventArgs e)
        {
            // Orden de botones en la barra personalizada
            panel1.Controls.SetChildIndex(Btn_Minimizar, 2);
            panel1.Controls.SetChildIndex(Btn_Maximizar, 1);
            panel1.Controls.SetChildIndex(Btn_Cerrar, 0);

            // Botón minimizar deshabilitado
            Btn_Minimizar.Enabled = false;

            // Estilo plano
            Btn_Minimizar.FlatAppearance.BorderSize = 0;
            Btn_Maximizar.FlatAppearance.BorderSize = 0;
            Btn_Cerrar.FlatAppearance.BorderSize = 0;

            // Colores al pasar el mouse
            Btn_Minimizar.FlatAppearance.MouseOverBackColor = Color.LightGray;
            Btn_Maximizar.FlatAppearance.MouseOverBackColor = Color.LightGray;
            Btn_Cerrar.FlatAppearance.MouseOverBackColor = Color.Red;

            // Colores al hacer clic
            Btn_Minimizar.FlatAppearance.MouseDownBackColor = Color.Gray;
            Btn_Maximizar.FlatAppearance.MouseDownBackColor = Color.Gray;
            Btn_Cerrar.FlatAppearance.MouseDownBackColor = Color.DarkRed;

            // Ocultar filtros al inicio
            OcultarFiltros();

            // Consultar toda la bitácora al cargar
            CargarEnGrid(_ctrl.MostrarBitacora());

            // Cargar usuarios en el combo
            CargarUsuariosEnCombo();
        }

        // Cargar datos en el DataGridView
        private void CargarEnGrid(DataTable dt)
        {
            Dgv_Bitacora.DataSource = dt;
            Dgv_Bitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Bitacora.ReadOnly = true;
            Dgv_Bitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Cargar usuarios en el ComboBox
        private void CargarUsuariosEnCombo()
        {
            try
            {
                var dt = _ctrl.ObtenerUsuarios();
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

        // Ocultar filtros
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

        // Botón cerrar
        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón maximizar/restaurar
        private void Btn_Maximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        // Botón minimizar
        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Consultar
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            CargarEnGrid(_ctrl.MostrarBitacora());
        }

        // Exportar
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

        // Imprimir
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument doc = _ctrl.CrearDocumentoImpresion();

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

        // Salir
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Buscar por rango
        private void Btn_BuscarRango_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_PrimeraFecha.Visible = true;
            Dtp_PrimeraFecha.Visible = true;
            Lbl_SegundaFecha.Visible = true;
            Dtp_SegundaFecha.Visible = true;
            Btn_Imprimir.Visible = true;

            CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        // Buscar por fecha
        private void Btn_BuscarFecha_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_FechaEspecifica.Visible = true;
            Dtp_FechaEspecifica.Visible = true;
            Btn_Imprimir.Visible = true;

            CargarEnGrid(_ctrl.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        // Buscar por usuario
        private void Btn_BuscarUsuario_Click(object sender, EventArgs e)
        {
            OcultarFiltros();

            Lbl_Usuario.Visible = true;
            Cbo_Usuario.Visible = true;
            Btn_Imprimir.Visible = true;

            if (Cbo_Usuario.SelectedValue != null &&
                int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
            {
                CargarEnGrid(_ctrl.BuscarPorUsuario(idUsuario));
            }
        }

        // Cambiar fecha específica
        private void Dtp_FechaEspecifica_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_FechaEspecifica.Visible)
                CargarEnGrid(_ctrl.BuscarPorFecha(Dtp_FechaEspecifica.Value));
        }

        // Cambiar primera fecha
        private void Dtp_PrimeraFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        // Cambiar segunda fecha
        private void Dtp_SegundaFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Dtp_PrimeraFecha.Visible && Dtp_SegundaFecha.Visible)
                CargarEnGrid(_ctrl.BuscarPorRango(Dtp_PrimeraFecha.Value, Dtp_SegundaFecha.Value));
        }

        // Cambiar usuario
        private void Cbo_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Cbo_Usuario.Visible) return;
            if (Cbo_Usuario.SelectedValue == null) return;

            if (int.TryParse(Cbo_Usuario.SelectedValue.ToString(), out int idUsuario))
                CargarEnGrid(_ctrl.BuscarPorUsuario(idUsuario));
        }
    }
}
