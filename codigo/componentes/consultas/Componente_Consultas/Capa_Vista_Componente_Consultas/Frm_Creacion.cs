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
    public partial class Frm_Creacion : Form
    {
        public Frm_Creacion()
        {
            InitializeComponent();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //esto es para moverse al formulario editar y eliminar
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Esto es para movernos entre formularios consultas
            Frm_Consultas consultas = new Frm_Consultas();
            consultas.Show();
            this.Hide();
        }
    }
}
