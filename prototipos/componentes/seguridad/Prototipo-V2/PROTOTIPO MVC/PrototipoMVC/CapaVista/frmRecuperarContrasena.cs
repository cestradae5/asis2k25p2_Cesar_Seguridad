using System;
using System.Windows.Forms;
using CapaControlador;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaVista
{
    public partial class frmRecuperarContrasena : Form
    {
        private ClsControladorRecuperarContrasena cls_recuperar = new ClsControladorRecuperarContrasena();

        public frmRecuperarContrasena()
        {
            InitializeComponent();

            // Configuración inicial
            Txt_Mostrar_Token.ReadOnly = true;
            Txt_nueva_contrasena.Enabled = false;
            Txt_confirmar_contrasena.Enabled = false;
            Btn_Guardar.Enabled = false;
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_Generar_Token_Click(object sender, EventArgs e)
        {
            string sUsuario = Txt_usuario.Text.Trim();
            if (string.IsNullOrEmpty(sUsuario))
            {
                MessageBox.Show("Ingrese un nombre de usuario.");
                return;
            }

            int iIdUsuario = cls_recuperar.fun_obtener_IdUsuario(sUsuario);
            if (iIdUsuario == 0)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            string sToken = cls_recuperar.fun_generar_token(iIdUsuario);
            Txt_Mostrar_Token.Text = sToken;
            MessageBox.Show("Token generado correctamente. Vigente por 5 minutos.");
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_Verificar_Token_Click(object sender, EventArgs e)
        {
            string sToken = Txt_Verificar_Token.Text.Trim().ToUpper();
            string sUsuario = Txt_usuario.Text.Trim();

            if (string.IsNullOrEmpty(sUsuario))
            {
                MessageBox.Show("Ingrese un nombre de usuario.");
                return;
            }

            int idUsuario = cls_recuperar.fun_obtener_IdUsuario(sUsuario);
            if (idUsuario == 0)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if (cls_recuperar.fun_validar_token(idUsuario, sToken, out int iIdToken))
            {
                MessageBox.Show("Token válido. Ahora puede cambiar su contraseña.");
                Txt_nueva_contrasena.Enabled = true;
                Txt_confirmar_contrasena.Enabled = true;
                Btn_Guardar.Enabled = true;
                Txt_Mostrar_Token.Text = sToken;
            }
            else
            {
                MessageBox.Show("Token inválido o expirado.");
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            string sToken = Txt_Mostrar_Token.Text.Trim().ToUpper();
            string sNueva = Txt_nueva_contrasena.Text.Trim();
            string sConfirmar = Txt_confirmar_contrasena.Text.Trim();

            if (sNueva != sConfirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            int iIdUsuario = cls_recuperar.fun_obtener_IdUsuario(Txt_usuario.Text.Trim());
            if (iIdUsuario == 0)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            if (cls_recuperar.fun_validar_token(iIdUsuario, sToken, out int idToken))
            {
                string sHashNueva = SeguridadHash.HashearSHA256(sNueva);
                if (cls_recuperar.fun_cambiar_contrasena(iIdUsuario, sHashNueva, idToken))
                {
                    MessageBox.Show("Contraseña actualizada correctamente.");

                    // Registrar en Bitácora Arón Ricardo Esquit Silva   0901-22-13036
                    Cls_BitacoraControlador bit = new Cls_BitacoraControlador();
                    bit.RegistrarAccion(iIdUsuario, "Recuperar contraseña", true);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña. Revisa la consola para detalles.");
                }
            }
            else
            {
                MessageBox.Show("Token inválido o expirado.");
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }
    }
}
