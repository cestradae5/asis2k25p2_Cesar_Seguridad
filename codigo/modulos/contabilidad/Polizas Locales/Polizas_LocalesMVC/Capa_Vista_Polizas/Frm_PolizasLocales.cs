using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Polizas;

namespace Capa_Vista_Polizas
{
    public partial class Frm_PolizasLocales : Form
    {

        private Cls_PolizaControlador cControlador = new Cls_PolizaControlador();

        public Frm_PolizasLocales()
        {
            InitializeComponent();
            ConfigurarBotonesInicio();

            // Maximiza el formulario al abrir
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frm_PolizasLocales_Load(object sender, EventArgs e)
        {
            cControlador.AsegurarPeriodoActivo();
            SincronizarModoUI();
            CargarEncabezados();
        }

        private void SincronizarModoUI()
        {
            var modo = cControlador.SincronizarModoConBD();

            if (modo == Cls_PolizaControlador.ModoActualizacion.EnLinea)
            {
                Lbl_ModoActual.Text = "Modo actual: En línea (automático)";
                Lbl_ModoActual.ForeColor = Color.DarkGreen;
            }
            else
            {
                Lbl_ModoActual.Text = "Modo actual: Batch (manual)";
                Lbl_ModoActual.ForeColor = Color.DarkOrange;
            }
        }




        // configuracion botones
        private void ConfigurarBotonesInicio()
        {
            Btn_Ingresar.Enabled = true;
            Btn_Editar.Enabled = true;
            Btn_Borrar.Enabled = true;
            Btn_Imprimir.Enabled = true;
            Btn_Refrescar.Enabled = true;
            Btn_Salir.Enabled = true;
        }

        //cargar encabezados en el dgv
        private void CargarEncabezados()
        {
            try
            {
                // Cargar los encabezados desde el controlador
                Dgv_EncabezadoPolizas.DataSource = cControlador.ObtenerEncabezados();

                // Ocultar columna de código numérico de estado
                if (Dgv_EncabezadoPolizas.Columns.Contains("EstadoCodigo"))
                {
                    Dgv_EncabezadoPolizas.Columns["EstadoCodigo"].Visible = false;
                }

                // Ajustar formato general
                Dgv_EncabezadoPolizas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Dgv_EncabezadoPolizas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Dgv_EncabezadoPolizas.MultiSelect = false;
                Dgv_EncabezadoPolizas.ReadOnly = true;
                Dgv_EncabezadoPolizas.ClearSelection();

                // Formato visual de encabezados
                Dgv_EncabezadoPolizas.EnableHeadersVisualStyles = false;
                Dgv_EncabezadoPolizas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 140);
                Dgv_EncabezadoPolizas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Dgv_EncabezadoPolizas.ColumnHeadersDefaultCellStyle.Font = new Font("Rockwell", 10F, FontStyle.Bold);
                Dgv_EncabezadoPolizas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Alinear columnas por tipo
                if (Dgv_EncabezadoPolizas.Columns.Contains("Valor"))
                {
                    Dgv_EncabezadoPolizas.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Dgv_EncabezadoPolizas.Columns["Valor"].DefaultCellStyle.Format = "N2";
                }

                if (Dgv_EncabezadoPolizas.Columns.Contains("Fecha"))
                {
                    Dgv_EncabezadoPolizas.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Dgv_EncabezadoPolizas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                // Suscribir evento para colorear filas
                Dgv_EncabezadoPolizas.CellFormatting -= Dgv_EncabezadoPolizas_CellFormatting;
                Dgv_EncabezadoPolizas.CellFormatting += Dgv_EncabezadoPolizas_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar encabezados: " + ex.Message);
            }
        }

        private void Dgv_EncabezadoPolizas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Dgv_EncabezadoPolizas.Columns[e.ColumnIndex].HeaderText == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                switch (estado)
                {
                    case "Inactivo":
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font("Rockwell", 10F, FontStyle.Italic);
                        break;

                    case "Activo":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font("Rockwell", 10F, FontStyle.Bold);
                        break;

                    case "Actualizado":
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.Font = new Font("Rockwell", 10F, FontStyle.Bold);
                        break;
                }
            }
        }


        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Frm_Reporte frm_Reporte = new Frm_Reporte();
            frm_Reporte.ShowDialog();
        }

        //doble click para ver detalle de poliza
        private void Dgv_EncabezadoPolizas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv_EncabezadoPolizas.Rows.Count == 0 || e.RowIndex < 0)
                    return;

                if (e.RowIndex >= 0)
                {
                    int iIdPoliza = Convert.ToInt32(Dgv_EncabezadoPolizas.Rows[e.RowIndex].Cells["Codigo"].Value);
                    Frm_DetallePolizas frmDetalle = new Frm_DetallePolizas(iIdPoliza, "lectura");
                    frmDetalle.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir detalle: " + ex.Message);
            }
        }

        private void Dgv_EncabezadoPolizas_SelectionChanged(object sender, EventArgs e)
        {
            Btn_Editar.Enabled = Dgv_EncabezadoPolizas.SelectedRows.Count > 0;
            Btn_Borrar.Enabled = Dgv_EncabezadoPolizas.SelectedRows.Count > 0;
        }

        //ingresar nueva poliza

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                int iNuevoId = cControlador.ObtenerSiguienteIdEncabezado(DateTime.Now);
                Frm_DetallePolizas frmDetalle = new Frm_DetallePolizas(iNuevoId, "insertar");
                frmDetalle.ShowDialog();
                CargarEncabezados();
                SincronizarModoUI(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar póliza: " + ex.Message);
            }
        }

        //editar poliza existente
        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_EncabezadoPolizas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una póliza para editar.");
                    return;
                }

                int iIdPoliza = Convert.ToInt32(Dgv_EncabezadoPolizas.CurrentRow.Cells["Codigo"].Value);

                Frm_DetallePolizas frmDetalle = new Frm_DetallePolizas(iIdPoliza, "editar");
                frmDetalle.ShowDialog();
                CargarEncabezados();
                SincronizarModoUI(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar póliza: " + ex.Message);
            }
        }

        //eliminar poliza existente
        private void Btn_Borrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_EncabezadoPolizas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una póliza para eliminar.");
                    return;
                }

                int iIdPoliza = Convert.ToInt32(Dgv_EncabezadoPolizas.CurrentRow.Cells["Codigo"].Value);
                DateTime dFecha = Convert.ToDateTime(Dgv_EncabezadoPolizas.CurrentRow.Cells["Fecha"].Value);

                DialogResult r = MessageBox.Show("¿Desea eliminar esta póliza y todos sus detalles?",
                                                 "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    bool eliminado = cControlador.EliminarPoliza(iIdPoliza, dFecha);
                    if (eliminado)
                        MessageBox.Show("Póliza eliminada correctamente.");
                    else
                        MessageBox.Show("No se pudo eliminar la póliza.");
                }

                CargarEncabezados();
                SincronizarModoUI(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar póliza: " + ex.Message);
            }
        }

        //refrescar dgv
        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CargarEncabezados();
        }

        //salir del formulario
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_CambiarModo_Click(object sender, EventArgs e)
        {
            try
            {
                cControlador.CambiarModoContable();
                SincronizarModoUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar modo contable: " + ex.Message);
            }
        }

        private void Btn_SincronizarModo_Click(object sender, EventArgs e)
        {
            try
            {
                SincronizarModoUI(); 
                MessageBox.Show("Modo contable sincronizado correctamente con la base de datos.",
                                "Sincronización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincronizar modo contable: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
