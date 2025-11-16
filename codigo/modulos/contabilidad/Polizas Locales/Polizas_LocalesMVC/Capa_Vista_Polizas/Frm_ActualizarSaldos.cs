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
    public partial class Frm_ActualizarSaldos : Form
    {
        private Cls_PolizaControlador cControlador = new Cls_PolizaControlador();
        public Frm_ActualizarSaldos()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            DateTime desde = Dtp_FechaDesde.Value.Date;
            DateTime hasta = Dtp_FechaHasta.Value.Date;

            //confirmación previa
            DialogResult dr = MessageBox.Show(
                $"¿Desea actualizar los saldos contables entre el {desde:dd/MM/yyyy} y el {hasta:dd/MM/yyyy}?\n\n" +
                "Esta acción recalculará los cargos, abonos y saldos de todas las cuentas afectadas " +
                "en el rango de fechas seleccionado.",
                "Confirmar Actualización de Saldos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            // ejecutar actualización
            bool exito = cControlador.ActualizarSaldosPorRango(desde, hasta);

            if (exito)
            {
                MessageBox.Show($"Saldos actualizados correctamente del {desde:dd/MM/yyyy} al {hasta:dd/MM/yyyy}.",
                                "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudieron actualizar los saldos contables en el rango indicado.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
