using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Componente_Consultas
{
    public partial class Frm_Consultas : Form
    {
        public Frm_Consultas()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
        }

        private void creaciònToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En navegador movemos la vista del formulario consultas a creación
            Frm_Creacion creacion = new Frm_Creacion();
            creacion.Show();
            this.Hide();
        }

        private void Frm_Consultas_Load(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
    }
}
