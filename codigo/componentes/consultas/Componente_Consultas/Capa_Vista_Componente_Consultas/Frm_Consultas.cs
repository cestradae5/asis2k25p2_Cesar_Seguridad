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
        }

        private void creaciònToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //En navegador movemos la vista del formulario consultas a creación
            Frm_Creacion creacion = new Frm_Creacion();
            creacion.Show();
            this.Hide();
        }
    }
}
