using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
{
    /* Brandon Alexander Hernandez Salguero
     * 0901-22-9663
     */
    public partial class frmasignacion_perfil_usuario : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora
        Cls_asignacion_perfil_usuarioControlador controlador = new Cls_asignacion_perfil_usuarioControlador();
        Cls_asignacion_perfil_usuarioDAO modelo = new Cls_asignacion_perfil_usuarioDAO();
        private List<Cls_asignacion_perfil_usuario> asignacionesPendientes = new List<Cls_asignacion_perfil_usuario>();

        // DataTables para lookup de nombres
        private DataTable dtUsuarios;
        private DataTable dtPerfiles;


        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;

        public frmasignacion_perfil_usuario()
        {
            InitializeComponent();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
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
            Cbo_perfil.ValueMember = "Pk_id_Perfil";
            Cbo_perfil.SelectedIndex = -1;
        }

        private void Cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_usuario.SelectedIndex != -1 && Cbo_usuario.SelectedValue != null)
            {
                int idUsuario;

                if (Cbo_usuario.SelectedValue is DataRowView drv)
                {
                    idUsuario = Convert.ToInt32(drv["Pk_Id_Usuario"]);
                }
                else
                {
                    idUsuario = Convert.ToInt32(Cbo_usuario.SelectedValue);
                }

                DataTable dt = modelo.datObtenerPerfilesPorUsuario(idUsuario);
                Dgv_consulta.DataSource = dt;
            }
            else
            {
                Dgv_consulta.DataSource = null;
            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (Cbo_usuarios2.SelectedIndex == -1 || Cbo_perfil.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un usuario y un perfil.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(Cbo_usuarios2.SelectedValue);
            int idPerfil = Convert.ToInt32(Cbo_perfil.SelectedValue);


            if (asignacionesPendientes.Any(x => x.Fk_Id_Usuario == idUsuario && x.Fk_Id_Perfil == idPerfil))
            {
                MessageBox.Show("Esta asignación ya está en la lista.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            asignacionesPendientes.Add(new Cls_asignacion_perfil_usuario(idUsuario, idPerfil));
            fun_RefrescarAsignacionesPendientes();

            // Registrar en Bitácora -Arón Ricardo Esquit Silva  0901 - 22 - 13036
            ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Agregar", true);
        }

        private void fun_RefrescarAsignacionesPendientes()
        {
            Dgv_asignaciones.DataSource = null;
            var lista = asignacionesPendientes
                .Select(x => new
                {
                    Usuario = dtUsuarios.Select($"Pk_Id_Usuario = {x.Fk_Id_Usuario}").FirstOrDefault()?["Cmp_Nombre_Usuario"]?.ToString() ?? x.Fk_Id_Usuario.ToString(),
                    Perfil = dtPerfiles.Select($"Pk_Id_Perfil = {x.Fk_Id_Perfil}").FirstOrDefault()?["Cmp_Puesto_Perfil"]?.ToString() ?? x.Fk_Id_Perfil.ToString()
                }).ToList();

            Dgv_asignaciones.DataSource = lista;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            int guardados = 0;
            foreach (var asignacion in asignacionesPendientes)
            {
                if (controlador.bInsertar(asignacion.Fk_Id_Usuario, asignacion.Fk_Id_Perfil))
                    guardados++;
            }
            MessageBox.Show($"Se guardaron {guardados} asignaciones correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            asignacionesPendientes.Clear();
            fun_RefrescarAsignacionesPendientes();

            // Registrar en Bitácora - Arón Ricardo Esquit Silva  0901-22-13036
            ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Guardar", true);
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
                    int idUsuario = usuarioRow.Field<int>("Pk_Id_Usuario");
                    int idPerfil = perfilRow.Field<int>("Pk_Id_Perfil");


                    asignacionesPendientes.RemoveAll(x => x.Fk_Id_Usuario == idUsuario && x.Fk_Id_Perfil == idPerfil);


                    fun_RefrescarAsignacionesPendientes();

                    // Registrar en Bitácora - Arón Ricardo Esquit Silva  0901-22-13036
                    ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Eliminar", true);
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

        //0901-21-1115 Marcos Andres Velasquez Alcánatara -- permisos script
        //0901-22-9663 Brandon Alexander Hernandez Salguero --  asignacion Modulos y aplicaciones



        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            
            string nombreModulo = "Seguridad";
            string nombreAplicacion = "Administracion";
            aplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(nombreAplicacion);
            moduloId = permisoUsuario.ObtenerIdModuloPorNombre(nombreModulo);
            AplicarPermisosUsuario();
        }

        private void AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado
            if (aplicacionId == -1 || moduloId == -1)
            {
                permisosActuales = null;
                ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);
            permisosActuales = permisos;
            ActualizarEstadoBotonesSegunPermisos();
        }

        // Centraliza el habilitado/deshabilitado de botones según permisos y estado de navegación
        private void ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
        {
            if (!permisosActuales.HasValue)
            {
                Btn_agregar.Enabled = false;
                Btn_eliminar_asignacion.Enabled = false;
                Btn_eliminar_consulta.Enabled = false;
                btn_finalizar.Enabled = false;
                 
                return;
            }

            var p = permisosActuales.Value;

            
            Btn_agregar.Enabled = p.ingresar;
            Btn_eliminar_asignacion.Enabled = p.eliminar;
            Btn_eliminar_consulta.Enabled = p.eliminar;
            btn_finalizar.Enabled = p.ingresar;
            
        }




    }
}