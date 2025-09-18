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
        private int iCodigoRuta = -1;

        public Reportes()
        {
            InitializeComponent();
        }

        private void modificarRuta(string sNuevaRuta)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            controlador.ModificarRuta(iCodigoRuta, sNuevaRuta);
            ActualizarGrid();
            Txt_reportes_ruta.Clear();
            iCodigoRuta = -1;
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }


        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (string.IsNullOrEmpty(Txt_reportes_ruta.Text) && iCodigoRuta < 0)
            {
                MessageBox.Show("Seleccione primero la ruta que desea modificar de la tabla.");
                return;
            }
            else
            {
                string sRutaModificada = Txt_reportes_ruta.Text;
                modificarRuta(sRutaModificada);
            }

            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025

        }

        private void Btn_ver_reporte_Click(object sender, EventArgs e)
        {
            // Instancia para ver reportes //Paula Leonardo 
            //Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
            if (Dgv_reportes.CurrentRow !=null)
            {
                string ruta = Dgv_reportes.CurrentRow.Cells["ruta_reportes"].Value?.ToString();

                VistaDeReportes frm = new VistaDeReportes();
                frm.MostrarReporte(ruta);
                // Mostrarlo como ventana aparte //Paula Leonardo
                frm.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un reporte de la tabla primero");
            }
        }
        //Fin de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025

        private void Dgv_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = Dgv_reportes.Rows[e.RowIndex];
                string sRuta = filaSeleccionada.Cells["ruta_reportes"].Value?.ToString();
                iCodigoRuta = Convert.ToInt32(filaSeleccionada.Cells["pk_id_reportes"].Value);
                Txt_reportes_ruta.Text = sRuta;
            }
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void eliminarRegistro()
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            controlador.EliminarReporte(iCodigoRuta);
            ActualizarGrid();
            Txt_reportes_ruta.Clear();
            iCodigoRuta = -1;
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025     
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 16/09/2025
        private int verificarRegistroExistente(string titulo)
        {
            int iResultadoConsulta = controlador.verificartitulo(titulo);
            return iResultadoConsulta;
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 16/09/2025

        private void Btn_ruta_reporte_Click(object sender, EventArgs e)
        {
            // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Crystal Reports (*.rpt)|*.rpt|Todos los archivos (*.*)|*.*";
            ofd.Title = "Seleccionar reporte RPT";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Txt_reportes_ruta.Text = ofd.FileName;
                // Aquí queda la ruta seleccionada, por ejemplo: C:\Users\Usuario\Desktop\Reporte1.rpt
            }

                

            // fin de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025
        }


        private void Txt_reportes_ruta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025

            try
            {
                string titulo = Txt_Titulo.Text;
                string ruta = Txt_reportes_ruta.Text;
                DateTime fecha = DateTime.Now;

                int iExistencia = verificarRegistroExistente(titulo);
                if (iExistencia == 1)
                {
                    MessageBox.Show("Ya existe un registro con el mismo titulo.");
                }
                else if (iExistencia == 0)
                {
                    controlador.GuardarReporte(titulo, ruta, fecha);
                    MessageBox.Show("Reporte Guardado Correctamente");
                    ActualizarGrid();
                }
      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            // fin  de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025
        }

        private void ActualizarGrid()
        {
            //inicio del codigo Kevin Santos 0901-17-2994
            DataTable datos = controlador.ObtenerReportes();
            Dgv_reportes.DataSource = controlador.ObtenerReportes();
            // Opcional: cambiar los encabezados de las columnas
            if (Dgv_reportes.Columns.Count > 0)
            {
                Dgv_reportes.Columns["pk_id_reportes"].HeaderText = "ID";
                Dgv_reportes.Columns["titulo_reportes"].HeaderText = "Título";
                Dgv_reportes.Columns["ruta_reportes"].HeaderText = "Ruta";
                Dgv_reportes.Columns["fecha_reportes"].HeaderText = "Fecha";
            }   //fin codigo Kevin Santos 0901-17-2994
                // Inicio código Paula Leonardo  0901-22-9580
            Dgv_reportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_reportes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv_reportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_reportes.AllowUserToAddRows = false;
            // Fin código Paula Leonardo  0901-22-9580
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (string.IsNullOrEmpty(Txt_reportes_ruta.Text) && iCodigoRuta < 0)
            {
                MessageBox.Show("Seleccione primero la ruta que desea eliminar de la tabla.");
                return;
            }
            else
            {
                eliminarRegistro();
            }
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }



    }
} 
