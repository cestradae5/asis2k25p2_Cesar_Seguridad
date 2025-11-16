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
    public partial class Frm_CierreAño : Form
    {
        private readonly Cls_PolizaControlador cControlador = new Cls_PolizaControlador();

        public Frm_CierreAño()
        {
            InitializeComponent();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cbo_AñoContable.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un año contable antes de continuar.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int anioSeleccionado = Convert.ToInt32(Cbo_AñoContable.SelectedItem);
                DateTime fechaFin = new DateTime(anioSeleccionado, 12, 31);

                // Confirmación previa
                DialogResult confirmar = MessageBox.Show(
                    $"¿Está seguro de cerrar el año contable {anioSeleccionado}?\n\n" +
                    "Esta acción marcará todas las pólizas activas de ese año como 'Actualizadas (2)' y recalculará los Totales.",
                    "Confirmar Cierre Anual",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.No)
                    return;

                // Ejecutar cierre anual
                var (exito, mensaje) = cControlador.CerrarAnioContable(fechaFin);

                MessageBox.Show(mensaje,
                                exito ? "Cierre Anual" : "Advertencia",
                                MessageBoxButtons.OK,
                                exito ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (exito)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el cierre anual: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_CierreAño_Load(object sender, EventArgs e)
        {
            try
            {
                // Mostrar modo actual
                bool bModoEnLinea = cControlador.GetModoActual() == Cls_PolizaControlador.ModoActualizacion.EnLinea;
                Lbl_Modo.Text = bModoEnLinea ? "Modo: En Línea" : "Modo: Batch";
                Lbl_Modo.ForeColor = bModoEnLinea ? Color.Green : Color.Blue;

                if (bModoEnLinea)
                {
                    MessageBox.Show("El cierre anual solo puede ejecutarse en modo Batch.",
                                    "Modo no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Btn_Aceptar.Enabled = false;
                }

                // Obtener el período activo actual
                DataTable dtPeriodo = cControlador.ObtenerPeriodoActual();
                if (dtPeriodo.Rows.Count > 0)
                {
                    int iAñoActual = Convert.ToInt32(dtPeriodo.Rows[0]["AnioActual"]);

                    // Rellenar el combo
                    Cbo_AñoContable.Items.Clear();
                    Cbo_AñoContable.Items.Add(iAñoActual);
                    Cbo_AñoContable.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se encontró un período contable activo.",
                                    "Cierre Anual", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Btn_Aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del período contable: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
