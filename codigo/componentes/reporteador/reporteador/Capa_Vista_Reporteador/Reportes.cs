using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Reporteador;

namespace Capa_Vista_Reporteador
{
    public partial class Reportes : Form
    {
        Controlador_Reporteador controlador = new Controlador_Reporteador();
        public Reportes()
        {
            InitializeComponent();
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ver_reporte_Click(object sender, EventArgs e)
        {
            // Instancia para ver reportes //Paula Leonardo 
            VistaDeReportes frm = new VistaDeReportes();

            // Mostrarlo como ventana aparte //Paula Leonardo
            frm.Show();
        }

        private void Dgv_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void Btn_ruta_reporte_Click(object sender, EventArgs e)
        {
            // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025

            // OpenFileDialog ofd = new OpenFileDialog();
            // ofd.Filter = "Crystal Reports (.rpt)|.rpt";  // 

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf"; 
            sfd.Title = "Guardar reporte como PDF";
            sfd.FileName = "Reporte.pdf"; // Nombre sugerido 

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Txt_reportes_ruta.Text = sfd.FileName;
                // Aquí queda la ruta seleccionada, por ejemplo:  C:\Users\Usuario\Desktop\Reporte.pdf

            }
        }
        // fin  de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025


        private void Txt_reportes_ruta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025

            try
            {
                
                string titulo = "Título Prueba";
                string ruta = Txt_reportes_ruta.Text;
                DateTime fecha = DateTime.Now;

                controlador.GuardarReporte(titulo, ruta, fecha);

                MessageBox.Show("Reporte Guardado Correctamente");

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void ActualizarGrid()
        {
            Dgv_reportes.DataSource = controlador.ObtenerReportes();
        }
    }
} // fin  de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025
