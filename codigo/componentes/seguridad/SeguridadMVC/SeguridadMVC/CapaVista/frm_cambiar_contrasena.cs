using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Vista_Seguridad
{
    public partial class Frm_cambiar_contrasena : Form
    {
        Cls_BitacoraControlador bit = new Cls_BitacoraControlador(); //Bitacora
        private Cls_controlador_cambio_contrasena controlador = new Cls_controlador_cambio_contrasena();
        private int iIdUsuario;

        // 0901-20-4620 Ruben Armando Lopez Luch
        public Frm_cambiar_contrasena(int iIdUsuarioActual)
        {
            InitializeComponent();
            iIdUsuario = iIdUsuarioActual;

            Txt_contrasena_actual.UseSystemPasswordChar = true;
            Txt_nueva_contrasena.UseSystemPasswordChar = true;
            Txt_confirmar_contrasena.UseSystemPasswordChar = true;
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Btn_Cambiar_Click(object sender, EventArgs e)
        {
            string sActual = Txt_contrasena_actual.Text.Trim();
            string sNueva = Txt_nueva_contrasena.Text.Trim();
            string sConfirmar = Txt_confirmar_contrasena.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(sActual))
            {
                MessageBox.Show("Debe ingresar la contraseña actual.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(sNueva) || string.IsNullOrEmpty(sConfirmar))
            {
                MessageBox.Show("Debe ingresar y confirmar la nueva contraseña.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar coincidencia de nuevas contraseñas
            if (sNueva != sConfirmar)
            {
                MessageBox.Show("La nueva contraseña y su confirmación no coinciden.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar contraseña actual
            if (!controlador.fun_validar_contrasena(iIdUsuario, sActual))
            {
                MessageBox.Show("La contraseña actual es incorrecta.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intentar actualizar
            bool bExito = controlador.fun_actualizar_Contrasena(iIdUsuario, sNueva);
            if (bExito)
            {
                MessageBox.Show("Contraseña cambiada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Registrar en Bitácora
                bit.RegistrarAccion(iIdUsuario, 0, "Cambio de contraseña", true);

                // Limpiar campos
                Txt_contrasena_actual.Clear();
                Txt_nueva_contrasena.Clear();
                Txt_confirmar_contrasena.Clear();

                
            }
            else
            {
                MessageBox.Show("Ocurrió un error al cambiar la contraseña.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        private void Chk_Mostrar_CheckedChanged(object sender, EventArgs e)
        {
            bool bMostrar = Chk_Mostrar.Checked;
            Txt_contrasena_actual.UseSystemPasswordChar = !bMostrar;
            Txt_nueva_contrasena.UseSystemPasswordChar = !bMostrar;
            Txt_confirmar_contrasena.UseSystemPasswordChar = !bMostrar;
        }

        // Panel superior
        //0901-20-4620 Ruben Armando Lopez Luch

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
