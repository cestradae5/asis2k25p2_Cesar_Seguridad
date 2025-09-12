using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContrasena.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false; // Mostrar texto
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true; // Ocultar texto
            }

        }

        private void lblkRecuperarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContrasena ventana = new frmRecuperarContrasena();
            ventana.Show();
            this.Hide();

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            frmPrincipal ventana = new frmPrincipal();
            ventana.Show();
            this.Hide();

        }
    }
}
