using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

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


        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int iModuloId = -1;
        private int iAplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)? permisosActuales = null;

     


        private void fun_ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            // Nombres existentes en la base de datos
            string sNombreModulo = "Seguridad";
            string sNombreAplicacion = "Administracion";
            iAplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(sNombreAplicacion);
            iModuloId = permisoUsuario.ObtenerIdModuloPorNombre(sNombreModulo);
            fun_AplicarPermisosUsuario();
        }

        private void fun_AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado
            if (iAplicacionId == -1 || iModuloId == -1)
            {
                permisosActuales = null;
                fun_ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, iAplicacionId, iModuloId);
            permisosActuales = permisos;
            fun_ActualizarEstadoBotonesSegunPermisos();
        }

        // Centraliza el habilitado/deshabilitado de botones según permisos y estado de navegación
        private void fun_ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
        {
            if (!permisosActuales.HasValue)
            {
                Btn_Cambiar.Enabled = false;
                


                return;
            }

            var p = permisosActuales.Value;

            Btn_Cambiar.Enabled = p.bModificar;

        }





    }
}
