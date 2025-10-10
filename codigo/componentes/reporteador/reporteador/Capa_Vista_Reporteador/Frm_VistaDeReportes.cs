using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using Capa_Controlador_Reporteador;

namespace Capa_Vista_Reporteador
{
    public partial class Frm_VistaDeReportes : Form
    {
        // Instancia del controlador (coordina la lógica con el modelo)
        Cls_Controlador_Reporteador controlador = new Cls_Controlador_Reporteador();

        // Propiedad opcional para manejar el ID del reporte
        public int IdReporte { get; private set; }

        // Constructor que recibe un ID (opcional)
        public Frm_VistaDeReportes(int idReporte) : this()
        {
            IdReporte = idReporte;
        }

        // Constructor base
        public Frm_VistaDeReportes()
        {
            InitializeComponent();
            IdReporte = IdReporte;
            // Ajusta el visor al tamaño del formulario
            crystalReportViewer1.Dock = DockStyle.Fill;
        }

        // ================================================================
        // MostrarReporte: Método para mostrar un reporte en el visor
        // ================================================================
        // Código actualizado para cumplir MVC (ya no maneja conexión directa)
        public void MostrarReporte(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta) || !File.Exists(ruta))
                {
                    MessageBox.Show("El archivo del reporte no existe o la ruta es inválida:\n" + ruta,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // El controlador ahora se encarga de cargar y conectar el reporte
                ReportDocument reporte = controlador.CargarReporte(ruta);

                // Mostrar el reporte en el visor
                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // CargarPrimerReporte: carga el primer reporte disponible en la base de datos
        // ================================================================
        private void CargarPrimerReporte()
        {
            try
            {
                DataTable dt = controlador.ObtenerReportes();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Tomar la ruta del primer reporte de la tabla
                    string ruta = dt.Rows[0]["Cmp_Ruta_Reporte"].ToString();

                    // Mostrarlo usando el método anterior
                    MostrarReporte(ruta);
                }
                else
                {
                    MessageBox.Show("No hay reportes disponibles en la base de datos.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los reportes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // Eventos del formulario
        // ================================================================
        private void Frm_VistaDeReportes_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, muestra el primer reporte automáticamente
            CargarPrimerReporte();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Evento reservado si necesitas inicializar el visor
        }
    }
}
