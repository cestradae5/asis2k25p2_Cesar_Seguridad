using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class Frm_Consultar_Asignacion_Modulo_Aplicacion : Form
    {
        private Cls_AsignacionModuloAplicacionControlador controlador = new Cls_AsignacionModuloAplicacionControlador();

        public Frm_Consultar_Asignacion_Modulo_Aplicacion()
        {
            InitializeComponent();
            CargarAsignaciones();
        }
        private void CargarAsignaciones()
        {
            DataTable dt = controlador.ObtenerAsignaciones();
            Dgv_Consulta_Asignacion_Modulo_Aplicacion.DataSource = dt;

            // Cambiar los títulos de las columnas
            if (Dgv_Consulta_Asignacion_Modulo_Aplicacion.Columns.Count > 0)
            {
                Dgv_Consulta_Asignacion_Modulo_Aplicacion.Columns["fk_id_aplicacion"].HeaderText = "ID Aplicación";
                Dgv_Consulta_Asignacion_Modulo_Aplicacion.Columns["nombre_aplicacion"].HeaderText = "Nombre Aplicación";
                Dgv_Consulta_Asignacion_Modulo_Aplicacion.Columns["fk_id_modulo"].HeaderText = "ID Módulo";
                Dgv_Consulta_Asignacion_Modulo_Aplicacion.Columns["nombre_modulo"].HeaderText = "Nombre Módulo";
            }

            // Ajustar el ancho de las columnas
            Dgv_Consulta_Asignacion_Modulo_Aplicacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Btn_Regresar_Aplicacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_Consulta_Asignacion_Modulo_Aplicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
