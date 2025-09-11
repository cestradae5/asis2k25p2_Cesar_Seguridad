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
    public partial class Frm_Editar : Form
    {
        public Frm_Editar()
        {
            InitializeComponent();
        }

        // Cuando el usuario haga clic en "Consultas"
        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consultas frm = new Frm_Consultas();
            frm.Show();
            this.Close(); // Cerramos este formulario para liberar memoria
        }

        // Cuando el usuario haga clic en "Creación"
        private void creaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Creacion frm = new Frm_Creacion();
            frm.Show();
            this.Close(); // Cerramos este formulario para liberar memoria
        }

        // Cuando el usuario haga clic en "Editar/Eliminar"
        private void editarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ya estamos en Frm_Editar, no abrimos otra vez
            MessageBox.Show("Ya te encuentras en la ventana de Editar/Eliminar.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
