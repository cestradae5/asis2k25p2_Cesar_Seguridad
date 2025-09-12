using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;




namespace ModeloSeguridad
{
    public partial class frmLogin : Form
    {

        // Importar funciones de la API de Windows
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Constantes para mover la ventana
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void pnlPanelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }





        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

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
