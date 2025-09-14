using System; //0901-22-2929 Pablo Jose Quiroa Martinez
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
    public partial class frmLogin : Form
    {
        ControladorLogin cn = new ControladorLogin();

        public frmLogin()
        {
            InitializeComponent();
            txtContrasena.UseSystemPasswordChar = true;
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

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            string mensaje;
            bool loginExitoso = cn.autenticarUsuario(usuario, contrasena, out mensaje, out int idUsuario);

            MessageBox.Show(mensaje);

            if (loginExitoso)
            {
                Cls_sesion.iUsuarioId = idUsuario;
                Cls_sesion.sNombreUsuario = usuario;

                frmPrincipal menu = new frmPrincipal();
                menu.Show();
                this.Hide();
            }
            else
            {
               
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
    }
}

