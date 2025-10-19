using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    /* Brandon Alexander Hernandez Salguero
     * 0901-22-9663
     */
    public partial class Frm_asignacion_perfil_usuario : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora
        Cls_asignacion_perfil_usuarioControlador controlador = new Cls_asignacion_perfil_usuarioControlador();
        private List<AsignacionPerfilUsuarioDTO> asignacionesPendientes = new List<AsignacionPerfilUsuarioDTO>();

       
        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;
        private DataTable dtUsuarios;
        private DataTable dtPerfiles;

        public Frm_asignacion_perfil_usuario()
        {
            InitializeComponent();
            fun_AplicarPermisos();
        }

        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            int idUsuario = Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Asig Perfiles");
            if (idAplicacion <= 0) idAplicacion = 308;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            // Habilitar/deshabilitar controles según permisos
            Btn_agregar.Enabled = _canIngresar;
            btn_finalizar.Enabled = _canIngresar || _canModificar;
            Btn_eliminar_asignacion.Enabled = true;
            Btn_eliminar_consulta.Enabled = true;

            // Combos y DataGridViews
            Cbo_usuario.Enabled = _canConsultar || _canIngresar || _canModificar;
            Cbo_usuarios2.Enabled = _canIngresar || _canModificar;
            Cbo_perfil.Enabled = _canIngresar || _canModificar;
            Dgv_asignaciones.Enabled = _canIngresar || _canModificar || _canEliminar;
            Dgv_consulta.Enabled = _canConsultar;
        }

        private void frmasignacion_perfil_usuario_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox Usuarios y guardar DataTable
            dtUsuarios = controlador.datObtenerUsuarios();
            Cbo_usuario.DataSource = dtUsuarios.Copy();
            Cbo_usuario.DisplayMember = "Cmp_Nombre_Usuario";
            Cbo_usuario.ValueMember = "Pk_Id_Usuario";
            Cbo_usuario.SelectedIndex = -1;

            Cbo_usuarios2.DataSource = dtUsuarios.Copy();
            Cbo_usuarios2.DisplayMember = "Cmp_Nombre_Usuario";
            Cbo_usuarios2.ValueMember = "Pk_Id_Usuario";
            Cbo_usuarios2.SelectedIndex = -1;

            dtPerfiles = controlador.datObtenerPerfiles();
            Cbo_perfil.DataSource = dtPerfiles.Copy();
            Cbo_perfil.DisplayMember = "Cmp_Puesto_Perfil";
            Cbo_perfil.ValueMember = "Pk_Id_Perfil";
            Cbo_perfil.SelectedIndex = -1;
        }

        private void Cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_usuario.SelectedIndex != -1 && Cbo_usuario.SelectedValue != null)
            {
                int iIdUsuario;

                if (Cbo_usuario.SelectedValue is DataRowView drv)
                {
                    iIdUsuario = Convert.ToInt32(drv["Pk_Id_Usuario"]);
                }
                else
                {
                    iIdUsuario = Convert.ToInt32(Cbo_usuario.SelectedValue);
                }

                DataTable dt = controlador.datObtenerPerfilesPorUsuario(iIdUsuario);
                Dgv_consulta.DataSource = dt;
            }
            else
            {
                Dgv_consulta.DataSource = null;
            }
        }

        //0901-22-9663 Brandon Hernandez 12/10/2025
        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            int usuarioId = (Cbo_usuarios2.SelectedIndex != -1 && Cbo_usuarios2.SelectedValue != null)
                ? Convert.ToInt32(Cbo_usuarios2.SelectedValue)
                : 0;
            int perfilId = (Cbo_perfil.SelectedIndex != -1 && Cbo_perfil.SelectedValue != null)
                ? Convert.ToInt32(Cbo_perfil.SelectedValue)
                : 0;

            string mensaje;
            bool ok = controlador.AgregarAsignacionPendiente(usuarioId, perfilId, asignacionesPendientes, out mensaje);
            if (!ok)
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fun_RefrescarAsignacionesPendientes();
        }

        private void fun_RefrescarAsignacionesPendientes()
        {
            Dgv_asignaciones.DataSource = null;
            var lista = asignacionesPendientes
                .Select(x => new
                {
                    Usuario = dtUsuarios.Select($"Pk_Id_Usuario = {x.UsuarioId}").FirstOrDefault()?["Cmp_Nombre_Usuario"]?.ToString() ?? x.UsuarioId.ToString(),
                    Perfil = dtPerfiles.Select($"Pk_Id_Perfil = {x.PerfilId}").FirstOrDefault()?["Cmp_Puesto_Perfil"]?.ToString() ?? x.PerfilId.ToString()
                }).ToList();

            Dgv_asignaciones.DataSource = lista;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            int iGuardados = 0;
            foreach (var asignacion in asignacionesPendientes)
            {
                string mensajeError;
                bool ok = controlador.GuardarAsignacion(asignacion.UsuarioId, asignacion.PerfilId, out mensajeError);

                if (ok)
                {
                    iGuardados++;
                    string nombreUsuario = dtUsuarios.Select($"Pk_Id_Usuario = {asignacion.UsuarioId}")
                        .FirstOrDefault()?["Cmp_Nombre_Usuario"]?.ToString() ?? asignacion.UsuarioId.ToString();

                    string nombrePerfil = dtPerfiles.Select($"Pk_Id_Perfil = {asignacion.PerfilId}")
                        .FirstOrDefault()?["Cmp_Puesto_Perfil"]?.ToString() ?? asignacion.PerfilId.ToString();

                    ctrlBitacora.RegistrarAccion(
                        Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario,
                        1,
                        $"Se asignó el perfil '{nombrePerfil}' al usuario '{nombreUsuario}'",
                        true
                    );
                }
                else
                {
                    MessageBox.Show(mensajeError, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show($"Se guardaron {iGuardados} asignaciones correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            asignacionesPendientes.Clear();
            fun_RefrescarAsignacionesPendientes();
        }

        private void Btn_eliminar_asignacion_Click_1(object sender, EventArgs e)
        {
            if (Dgv_asignaciones.CurrentRow != null)
            {
                string snombreUsuario = Dgv_asignaciones.CurrentRow.Cells["Usuario"].Value.ToString();
                string snombrePerfil = Dgv_asignaciones.CurrentRow.Cells["Perfil"].Value.ToString();

                var usuarioRow = dtUsuarios.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("Cmp_Nombre_Usuario") == snombreUsuario);
                var perfilRow = dtPerfiles.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("Cmp_Puesto_Perfil") == snombrePerfil);

                if (usuarioRow != null && perfilRow != null)
                {
                    int iIdUsuario = usuarioRow.Field<int>("Pk_Id_Usuario");
                    int iIdPerfil = perfilRow.Field<int>("Pk_Id_Perfil");

                    asignacionesPendientes.RemoveAll(x => x.UsuarioId == iIdUsuario && x.PerfilId == iIdPerfil);

                    fun_RefrescarAsignacionesPendientes();

                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Se eliminó la asignación del perfil '{snombrePerfil}' para el usuario '{snombreUsuario}'", true);
                }
            }
        }

        private void Btn_eliminar_consulta_Click(object sender, EventArgs e)
        {
            Dgv_consulta.DataSource = null;
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