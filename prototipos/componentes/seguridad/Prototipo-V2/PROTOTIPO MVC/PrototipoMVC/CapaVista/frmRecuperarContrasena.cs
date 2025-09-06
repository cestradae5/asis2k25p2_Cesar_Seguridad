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

// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaVista
{
    public partial class frmRecuperarContrasena : Form
    {
        ControladorRecuperarContrasena controlador = new ControladorRecuperarContrasena();
        int idUsuario = 1; // Aquí puedes obtener dinámicamente del login o input del usuario
        public frmRecuperarContrasena()
        {
            InitializeComponent();
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text.Trim();
            string nueva = txtNuevaContrasena.Text.Trim();
            string confirmar = txtConfirmarContrasena.Text.Trim();

            if (nueva != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (controlador.ValidarToken(idUsuario, token, out int idToken))
            {
                bool exito = controlador.CambiarContrasena(idUsuario, nueva, idToken);
                if (exito)
                    MessageBox.Show("Contraseña actualizada correctamente.");
                else
                    MessageBox.Show("Error al actualizar la contraseña.");
            }
            else
            {
                MessageBox.Show("Token inválido o expirado.");
            }

        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }
    }
}
