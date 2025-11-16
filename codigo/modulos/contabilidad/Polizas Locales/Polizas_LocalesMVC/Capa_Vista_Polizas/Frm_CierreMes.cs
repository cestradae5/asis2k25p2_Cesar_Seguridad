using Capa_Controlador_Polizas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Polizas
{
    public partial class Frm_CierreMes : Form
    {
        private readonly Cls_PolizaControlador cControlador = new Cls_PolizaControlador();

        public Frm_CierreMes()
        {
            InitializeComponent();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cbo_MesContable.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el mes contable activo antes de continuar.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mesSeleccionado = Cbo_MesContable.SelectedItem.ToString();

                // confirmación 
                DialogResult dr = MessageBox.Show(
                    $"¿Está seguro de cerrar el mes contable de {mesSeleccionado}?\n\n" +
                    "Esta acción marcará todas las pólizas activas de ese mes como 'Actualizadas (estado = 2)' " +
                    "y recalculará los saldos contables.",
                    "Confirmar Cierre de Mes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                    return;

                // cierre de mes
                var (exito, mensaje) = cControlador.CerrarMesContable(DateTime.Now);

                MessageBox.Show(mensaje,
                                exito ? "Cierre Contable" : "Advertencia",
                                MessageBoxButtons.OK,
                                exito ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (exito)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar mes contable: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        private void Frm_CierreMes_Load(object sender, EventArgs e)
        {
            try
            {
                bool modoEnLinea = cControlador.GetModoActual() == Cls_PolizaControlador.ModoActualizacion.EnLinea;
                Lbl_Modo.Text = modoEnLinea ? "Modo: En Línea" : "Modo: Batch";
                Lbl_Modo.ForeColor = modoEnLinea ? Color.Green : Color.Blue;

                DataTable dtPeriodo = cControlador.ObtenerPeriodoActual();

                if (dtPeriodo.Rows.Count > 0)
                {
                    int iMes = Convert.ToInt32(dtPeriodo.Rows[0]["MesActual"]);
                    string sNombreMes = ObtenerNombreMes(iMes);
                    Cbo_MesContable.Items.Clear();
                    Cbo_MesContable.Items.Add(sNombreMes);
                    Cbo_MesContable.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se encontró un período contable activo.",
                                    "Cierre Mensual", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Btn_Aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar período contable activo: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private string ObtenerNombreMes(int iMes)
        {
            string[] sMeses = { "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                                  "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            return sMeses[iMes];
        }
    }
    
}
