using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine; // Gerber Asturias
using CrystalDecisions.Shared;// Gerber Asturias
using CrystalDecisions.Windows.Forms;// Gerber Asturias
using Capa_Controlador_Reporteador;
using System.IO;


namespace Capa_Vista_Reporteador
{
    public partial class VistaDeReportes : Form
    {
        Controlador_Reporteador controlador = new Controlador_Reporteador();
        public VistaDeReportes()
        {
            InitializeComponent();
        }

        //Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
        //Método para motrar report en el CrystalReportViewer
        public void MostrarReporte(string ruta)
        {
            try
            {
                if (!File.Exists(ruta))
                {
                    MessageBox.Show("El archivo del reporte no existe: " + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReportDocument reporte = new ReportDocument();
                reporte.Load(ruta);

                //Configuración de conexión ODBC
                ConnectionInfo connection = new ConnectionInfo
                {
                    ServerName = "db_reportes", //DNS para conexión (modificar según lo indicado)
                    DatabaseName = "db_reportes", //DNS para conexión (modificar según lo indicado)
                    UserID = "root", //Usuario MySql (modificar según lo indicado)
                    Password = "123456" //Constraseña de Mysql (modificar según lo indicado) 
                };

                //Aplicar conexión a cada tabla dentor del reporte
                foreach (Table table in reporte.Database.Tables)
                {
                    TableLogOnInfo logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connection;
                    table.ApplyLogOnInfo(logonInfo);
                }

                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fin de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025

        //Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
        // Método para cargar los reportes en el ComboBox
        private void CargarComboReportes()
        {
            try
            {
                DataTable dt = controlador.ObtenerReportes();

                if (dt != null && dt.Rows.Count > 0)
                {

                    // Cargar automáticamente el primer reporte
                    string primeraRuta = dt.Rows[0]["ruta_reportes"].ToString();
                    MostrarReporte(primeraRuta);
                }
                else
                {
                    MessageBox.Show("No hay reportes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fin de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025

        private void pv_reporte_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void VistaDeReportes_Load(object sender, EventArgs e)
        {
            CargarComboReportes();
        }
        //Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
        private void PicB_vista_reportes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = controlador.ObtenerReportes();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Tomar el PRIMER reporte disponible
                    string ruta = dt.Rows[0]["ruta_reportes"].ToString();
                    MostrarReporte(ruta);
                }
                else
                {
                    MessageBox.Show("No hay reportes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reportes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        //Fin de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
    }
}
