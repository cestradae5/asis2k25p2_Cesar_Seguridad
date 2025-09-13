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
        Cls_controladorRecuperarContrasena cls_recuperar = new Cls_controladorRecuperarContrasena();
        int iIdUsuario = 1; // Aquí puedes obtener dinámicamente del login o input del usuario
        public frmRecuperarContrasena()
        {
            InitializeComponent();
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sToken = Txt_token.Text.Trim();
            string sNueva = Txt_nueva_contrasena.Text.Trim();
            string sConfirmar = Txt_confirmar_contrasena.Text.Trim();

            if (sNueva != sConfirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (cls_recuperar.funValidarToken(iIdUsuario, sToken, out int idToken))
            {
                bool bExito = cls_recuperar.funCambiarContrasena(iIdUsuario, sNueva, idToken);
                if (bExito)
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
        private void Btn_regresar_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }
    }
}
