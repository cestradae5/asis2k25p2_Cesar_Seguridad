﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        // ==========================
        // Variables globales
        // ==========================
        Controlador_Reporteador controlador = new Controlador_Reporteador();
        private int iCodigoRuta = -1;
        private int iCodigoFilaSeleccionada = 0;

        // ==========================
        // Constructor
        // ==========================
        public Reportes()
        {
            InitializeComponent();
        }

        // ==========================
        // Métodos privados de lógica
        // ==========================

        private void modificarRuta(string sNuevaRuta)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            controlador.ModificarRuta(iCodigoFilaSeleccionada, sNuevaRuta);
            ActualizarGrid();
            iCodigoRuta = -1;
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void modificarTitulo(string sTituloNuevo)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            controlador.ModificarTitulo(iCodigoFilaSeleccionada, sTituloNuevo);
            ActualizarGrid();
            iCodigoRuta = -1;
            iCodigoFilaSeleccionada = 0;
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void eliminarRegistro()
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            controlador.EliminarReporte(iCodigoRuta);
            ActualizarGrid();
            Txt_reportes_ruta.Clear();
            Txt_Titulo.Clear();
            iCodigoRuta = -1;
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025     
        }

        //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 16/09/2025
        private int verificarRegistroExistente(string titulo)
        {
            int iResultadoConsulta = controlador.verificartitulo(titulo);
            return iResultadoConsulta;
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 16/09/2025

        private void ActualizarGrid()
        {
            //inicio del codigo Kevin Santos 0901-17-2994
            DataTable datos = controlador.ObtenerReportes();
            Dgv_reportes.DataSource = controlador.ObtenerReportes();
            // Opcional: cambiar los encabezados de las columnas
            if (Dgv_reportes.Columns.Count > 0)
            {
                Dgv_reportes.Columns["Pk_Id_Reporte"].HeaderText = "ID";
                Dgv_reportes.Columns["Cmp_Titulo_Reporte"].HeaderText = "Título";
                Dgv_reportes.Columns["Cmp_Ruta_Reporte"].HeaderText = "Ruta";
                Dgv_reportes.Columns["Cmp_Fecha_Reporte"].HeaderText = "Fecha";
            }   //fin codigo Kevin Santos 0901-17-2994

            // Inicio código Paula Leonardo  0901-22-9580
            Dgv_reportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_reportes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Dgv_reportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_reportes.AllowUserToAddRows = false;

            // Fin código Paula Leonardo  0901-22-9580
        }

        // ==========================
        // Eventos del formulario
        // ==========================

        private void Reportes_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025
            try
            {
                string titulo = Txt_Titulo.Text.Trim();
                string ruta = Txt_reportes_ruta.Text.Trim();
                DateTime fecha = DateTime.Now;

                // Validar que el título no esté vacío
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    MessageBox.Show("No se pudo guardar el reporte porque falta ingresar el título.",
                                    "Error al Guardar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return; // sale sin guardar
                }

                int iExistencia = verificarRegistroExistente(titulo);
                if (iExistencia == 1)
                {
                    MessageBox.Show("Ya existe un registro con el mismo título.",
                                    "Duplicado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else if (iExistencia == 0)
                {
                    controlador.GuardarReporte(titulo, ruta, fecha);
                    MessageBox.Show("Reporte Guardado Correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    ActualizarGrid();

                    // Limpieza de campos
                    Txt_reportes_ruta.Clear(); // Inicio de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 24/09/2025
                    Txt_Titulo.Clear();        // Fin de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 24/09/2025
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            // Fin de código de: Cesar Santizo con carné: 0901-22-5215 en la fecha de: 12/09/2025
        }


        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (string.IsNullOrEmpty(Txt_reportes_ruta.Text) && iCodigoRuta < 0)
            {
                MessageBox.Show("Seleccione primero la ruta que desea modificar de la tabla.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(Txt_reportes_ruta.Text))
            {
                string sRutaModificada = Txt_reportes_ruta.Text;
                modificarRuta(sRutaModificada);
            }
            if (!string.IsNullOrWhiteSpace(Txt_Titulo.Text))
            {
                string sTituloNuevo = Txt_Titulo.Text;
                modificarTitulo(sTituloNuevo);
            }
            Txt_reportes_ruta.Clear();
            Txt_Titulo.Clear();
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025

        }



        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (string.IsNullOrEmpty(Txt_reportes_ruta.Text) && iCodigoRuta < 0)
            {
                MessageBox.Show("Seleccione primero el reporte que desea eliminar de la tabla.");
                return;
            }
            else
            {
                // Inicio de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 23/09/2025
                DialogResult resultado = MessageBox.Show(
                    "¿Seguro que desea eliminar este registro?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    eliminarRegistro();
                }
                // Fin de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 23/09/2025
            }
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void Btn_ver_reporte_Click(object sender, EventArgs e)
        {
            // Instancia para ver reportes //Paula Leonardo 
            //Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha 13/09/2025
            if (Dgv_reportes.CurrentRow != null)
            {
                string ruta = Dgv_reportes.CurrentRow.Cells["Cmp_Ruta_Reporte"].Value?.ToString();

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

        private void Dgv_reportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = Dgv_reportes.Rows[e.RowIndex];
                string sRuta = filaSeleccionada.Cells["Cmp_Ruta_Reporte"].Value?.ToString();
                string sTitulo = filaSeleccionada.Cells["Cmp_Titulo_Reporte"].Value?.ToString();
                iCodigoRuta = Convert.ToInt32(filaSeleccionada.Cells["Pk_Id_Reporte"].Value);
                iCodigoFilaSeleccionada = iCodigoRuta;
                Txt_reportes_ruta.Text = sRuta;
                Txt_Titulo.Text = sTitulo;

            }
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 12/09/2025
        }

        private void Dgv_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Método que debe llamar navegador//
        private void reporteAplicacion(int idAplicacion)
        {
            //Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 25/09/2025
            string sRuta = controlador.ConsultarReporteAplicacion(idAplicacion);
            VistaDeReportes frm = new VistaDeReportes();
            frm.MostrarReporte(sRuta);
            // Mostrarlo como ventana aparte //Paula Leonardo
            frm.Show();
            // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha 25/09/2025
        }

        private void Btn_Navegador_Click(object sender, EventArgs e)
        {
            reporteAplicacion(100);
        }
    }
}
