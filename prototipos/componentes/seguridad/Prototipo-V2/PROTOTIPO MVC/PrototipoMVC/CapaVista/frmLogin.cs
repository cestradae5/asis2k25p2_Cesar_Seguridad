using System; //0901-22-2929 Pablo Jose Quiroa Martinez
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;


namespace Capa_Vista_Seguridad
{
    public partial class frmLogin : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora
        ControladorLogin cn = new ControladorLogin();

        public frmLogin()
        {
            InitializeComponent();
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) { }

        private void txtContrasena_TextChanged(object sender, EventArgs e) { }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContrasena.Checked)
                txtContrasena.UseSystemPasswordChar = false; // Mostrar
            else
                txtContrasena.UseSystemPasswordChar = true;  // Ocultar
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
                // Guardar datos de sesión
                Cls_sesion.iUsuarioId = idUsuario;
                Cls_sesion.sNombreUsuario = usuario;

                // Registrar en bitácora //Aron Ricardo Esquit Silva   0901-22-13036
                ctrlBitacora.RegistrarInicioSesion(idUsuario);


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
