using System; //0901-22-2929 Pablo Jose Quiroa Martinez
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;


namespace Capa_Vista_Seguridad
{
    public partial class Frm_Login : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora
        Cls_ControladorLogin cn = new Cls_ControladorLogin();

        public Frm_Login()
        {
            InitializeComponent();
            txtContrasena.UseSystemPasswordChar = true;
            this.FormClosing += Frm_Login_FormClosing;
        }
        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si el cierre fue con el botón "X" o cualquier otra forma
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }


        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContrasena.Checked)
                txtContrasena.UseSystemPasswordChar = false; // Mostrar
            else
                txtContrasena.UseSystemPasswordChar = true;  // Ocultar
        }

        private void lblkRecuperarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_RecuperarContrasena ventana = new Frm_RecuperarContrasena();
            ventana.Show();
            this.Hide();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string nombreUsuarioReal = "";

            string mensaje;
            bool loginExitoso = cn.autenticarUsuario(usuario, contrasena, out mensaje, out int idUsuario, out nombreUsuarioReal);

            MessageBox.Show(mensaje);

            if (loginExitoso)
            {
                // Guardar sesión del usuario conectado (nombre real + ID)
                Cls_UsuarioConectado.iIdUsuario = idUsuario;
                Cls_UsuarioConectado.sNombreUsuario = nombreUsuarioReal;

                // Registrar inicio en bitácora
                ctrlBitacora.RegistrarInicioSesion(idUsuario);

                // Abrir Frm_Principal sin pasar parámetros
                Frm_Principal menu = new Frm_Principal();
                menu.Show();
                this.Hide();
            }
            else
            {
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e) { }


        // panel superior
        //0901-20-4620 Rubén Armando López Luch

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
                ReleaseCapture(); 
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); 
            }

        }
    }
}
