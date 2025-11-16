using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Contabilidad;

namespace Capa_Vista_Contabilida
{
    public partial class Frm_depreciacion_activos_fijos : Form
    {
        private Cls_Depreciacion_Controlador controlador = new Cls_Depreciacion_Controlador();

        public Frm_depreciacion_activos_fijos()
        {
            InitializeComponent();
            CargarActivos();
        }

        private void CargarActivos()
        {
            try
            {
                DataTable dt = controlador.CargarActivos();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Cmp_Nombre_Activo";
                comboBox1.ValueMember = "Pk_Activo_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_buscar_activo_fijo_Click(object sender, EventArgs e)
        {
            try
            {
                controlador.ValidarSeleccionActivo(comboBox1.SelectedValue);

                int idActivo = (int)comboBox1.SelectedValue;
                var activo = controlador.ObtenerDatosActivo(idActivo);

                // Usar DTO en lugar de clase del modelo
                Txt_costo_total.Text = activo.dCostoAdquisicion.ToString("F2");
                Txt_valor_residual.Text = activo.dValorResidual.ToString("F2");
                Txt_vida_util.Text = activo.iVidaUtil.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_calcular_Click(object sender, EventArgs e)
        {
            try
            {
                controlador.ValidarSeleccionActivo(comboBox1.SelectedValue);

                int idActivo = (int)comboBox1.SelectedValue;

                // Usar DTO en lugar de clase del modelo
                var (depreciaciones, depreciacionAnual) = controlador.CalcularDepreciacionLineaRecta(idActivo);

                // Mostrar en DataGridView
                Dgv_depreciacion_activo_fijo.DataSource = depreciaciones;

                // Mostrar depreciación anual
                Txt_depreciacion_anual.Text = depreciacionAnual.ToString("F2");

                MessageBox.Show("Cálculo de depreciación completado exitosamente.", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_limpiar_campo_Click(object sender, EventArgs e)
        {
            Txt_costo_total.Clear();
            Txt_valor_residual.Clear();
            Txt_vida_util.Clear();
            Txt_depreciacion_anual.Clear();
            Dgv_depreciacion_activo_fijo.DataSource = null;
            comboBox1.SelectedIndex = -1;
        }
    }
}