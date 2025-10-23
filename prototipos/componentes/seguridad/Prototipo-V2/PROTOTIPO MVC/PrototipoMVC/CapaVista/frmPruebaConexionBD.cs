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

namespace CapaVista
{
    public partial class frmPruebaConexionBD : Form
    {

        string emp = "tbl_EMPLEADO";
        ControladorPruebaBD cn = new ControladorPruebaBD();

        public frmPruebaConexionBD()
        {
            InitializeComponent();
        }

        //Mostrar los datos CAPA VISTA
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl(emp);
            dgvRegistros.DataSource = dt;

        }


        private void btnConsulta_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }
    }
}
