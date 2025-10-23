using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Recuperar_Contrasena : Form
    {
        private ClsControladorRecuperarContrasena cls_recuperar = new ClsControladorRecuperarContrasena();

        public Frm_Recuperar_Contrasena()
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

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(sNueva) || string.IsNullOrEmpty(sConfirmar))
            {
                MessageBox.Show("Debe ingresar la nueva contraseña y confirmarla.");
                return;
            }

            // Validación de coincidencia
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
                string sHashNueva = Cls_Seguridad_Hash_Controlador.HashearSHA256(sNueva);
                if (cls_recuperar.fun_cambiar_contrasena(iIdUsuario, sHashNueva, idToken))
                {
                    MessageBox.Show("Contraseña actualizada correctamente.");

                    // Registrar en Bitácora
                    Cls_BitacoraControlador bit = new Cls_BitacoraControlador();
                    bit.RegistrarAccion(iIdUsuario, 0, "Recuperar contraseña", true);


                    // limpia campos despues de guardar
                    Txt_usuario.Clear();
                    Txt_Mostrar_Token.Clear();
                    Txt_Verificar_Token.Clear();
                    Txt_nueva_contrasena.Clear();
                    Txt_confirmar_contrasena.Clear();

                    // Desabilita los botones despues de guardar cambios
                    Txt_nueva_contrasena.Enabled = false;
                    Txt_confirmar_contrasena.Enabled = false;
                    Btn_Guardar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.");
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
            Frm_Login login = new Frm_Login();
            login.Show();
            this.Hide();
        }

        // Panel superior
        //0901-20-4620 Ruben Armando Lopez Luch

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Libera el mouse
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Simula arrastre
            }
        }
    }
}
