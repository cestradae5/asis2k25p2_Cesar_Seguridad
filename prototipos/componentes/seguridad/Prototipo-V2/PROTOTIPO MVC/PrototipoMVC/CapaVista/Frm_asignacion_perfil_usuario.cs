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
    public partial class Frm_asignacion_perfil_usuario : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora
        Cls_asignacion_perfil_usuarioControlador controlador = new Cls_asignacion_perfil_usuarioControlador();
       
        Cls_Usuario_Controlador controladorUsuario = new Cls_Usuario_Controlador();
        private List<Cls_asignacion_perfil_usuario> asignacionesPendientes = new List<Cls_asignacion_perfil_usuario>();

        // DataTables para lookup de nombres
        private DataTable dtUsuarios;
        private DataTable dtPerfiles;


       

        public Frm_asignacion_perfil_usuario()
        {
            InitializeComponent();
            fun_AplicarPermisos();
            
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
                int iIdUsuario;

                if (Cbo_usuario.SelectedValue is DataRowView drv)
                {
                    iIdUsuario = Convert.ToInt32(drv["Pk_Id_Usuario"]);
                }
                else
                {
                    iIdUsuario = Convert.ToInt32(Cbo_usuario.SelectedValue);
                }

                DataTable dt =controlador.datObtenerPerfilesPorUsuario(iIdUsuario);
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
            if (Cbo_usuarios2.SelectedIndex == -1 || Cbo_perfil.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un usuario y un perfil.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int iIdUsuario = Convert.ToInt32(Cbo_usuarios2.SelectedValue);
            int iIdPerfil = Convert.ToInt32(Cbo_perfil.SelectedValue);

            // --- NUEVO: Verifica si el usuario ya tiene un perfil ---

            int perfilAsignado = controladorUsuario.ObtenerIdPerfilDeUsuario(iIdUsuario); // Debe retornar 0 si no tiene perfil

            if (perfilAsignado != 0)
            {
                MessageBox.Show($"Este usuario ya está asignado a un perfil {perfilAsignado}.", "Asignación existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (asignacionesPendientes.Any(x => x.Fk_Id_Usuario == iIdUsuario && x.Fk_Id_Perfil == iIdPerfil))
            {
                MessageBox.Show("Esta asignación ya está en la lista.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            asignacionesPendientes.Add(new Cls_asignacion_perfil_usuario(iIdUsuario, iIdPerfil));
            fun_RefrescarAsignacionesPendientes();

            // Registrar en Bitácora -Arón Ricardo Esquit Silva  0901-22-13036
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Agregar", true);
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
            int iGuardados = 0;
            foreach (var asignacion in asignacionesPendientes)
            {
                string mensajeError; // Variable para el mensaje de error personalizado
                                     // Llama al controlador, que retorna true si se guardó, false si hubo error (duplicado, etc)
                bool ok = controlador.bInsertar(asignacion.Fk_Id_Usuario, asignacion.Fk_Id_Perfil, out mensajeError);

                if (ok)
                {
                    iGuardados++;
                }
                else
                {
                    // Muestra el mensaje personalizado si hubo error (por ejemplo, relación duplicada)
                    MessageBox.Show(mensajeError, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show($"Se guardaron {iGuardados} asignaciones correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            asignacionesPendientes.Clear();
            fun_RefrescarAsignacionesPendientes();

            // Registrar en Bitácora (si lo usas)
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Guardar", true);
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


                    asignacionesPendientes.RemoveAll(x => x.Fk_Id_Usuario == iIdUsuario && x.Fk_Id_Perfil == iIdPerfil);


                    fun_RefrescarAsignacionesPendientes();

                    // Registrar en Bitácora - Arón Ricardo Esquit Silva  0901-22-13036
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, "Asignación Perfil a Usuario - Eliminar", true);
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


        /* 0901-21-1115 
    Marcos Velásquez Alcántara
        
         Filtros de Permisos 
         */


        private void fun_AplicarPermisos()
        {
            try
            {
                // Obtener ID del usuario conectado
                int iIdUsuario = Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario;

                // Instancias de clases del modelo
                Cls_Permiso_Usuario clsPermisoUsuario = new Cls_Permiso_Usuario();
                Cls_Asignacion_Permiso_PerfilesDAO clsAsignacionPermisoPerfilDAO = new Cls_Asignacion_Permiso_PerfilesDAO();

                // Obtener IDs según nombres
                int iIdAplicacion = clsPermisoUsuario.ObtenerIdAplicacionPorNombre("Asig Perfiles");
                int iIdModulo = clsPermisoUsuario.ObtenerIdModuloPorNombre("Seguridad");

                // Inicializar permisos en false
                bool bIngresar = false, bConsultar = false, bModificar = false, bEliminar = false, bImprimir = false;

                //  Consultar permisos específicos del usuario
                var vPermisosUsuario = clsPermisoUsuario.ConsultarPermisos(iIdUsuario, iIdAplicacion, iIdModulo);

                if (vPermisosUsuario.HasValue)
                {
                    bIngresar = vPermisosUsuario.Value.ingresar;
                    bConsultar = vPermisosUsuario.Value.consultar;
                    bModificar = vPermisosUsuario.Value.modificar;
                    bEliminar = vPermisosUsuario.Value.eliminar;
                    bImprimir = vPermisosUsuario.Value.imprimir;
                }

                //  Si algún permiso no está activo, verificar permisos por perfil
                if (!bIngresar || !bConsultar || !bModificar || !bEliminar || !bImprimir)
                {
                    DataTable dtPerfiles = clsAsignacionPermisoPerfilDAO.datObtenerPerfiles();

                    foreach (DataRow rowPerfil in dtPerfiles.Rows)
                    {
                        int iIdPerfil = Convert.ToInt32(rowPerfil["Pk_Id_Perfil"]);
                        DataTable dtPermisosPerfil = clsAsignacionPermisoPerfilDAO.ObtenerPermisosPerfilAplicacion(iIdPerfil, iIdAplicacion);

                        if (dtPermisosPerfil.Rows.Count > 0)
                        {
                            DataRow rowPermiso = dtPermisosPerfil.Rows[0];

                            // Actualizar solo los permisos que estén en false
                            if (!bIngresar && Convert.ToBoolean(rowPermiso["bIngresar"]))
                                bIngresar = true;

                            if (!bConsultar && Convert.ToBoolean(rowPermiso["bConsultar"]))
                                bConsultar = true;

                            if (!bModificar && Convert.ToBoolean(rowPermiso["bModificar"]))
                                bModificar = true;

                            if (!bEliminar && Convert.ToBoolean(rowPermiso["bEliminar"]))
                                bEliminar = true;

                            if (!bImprimir && Convert.ToBoolean(rowPermiso["bImprimir"]))
                                bImprimir = true;
                        }
                    }
                }

                //  Aplicar permisos a botones del formulario
                Btn_agregar.Enabled = bIngresar || bConsultar;
                btn_finalizar.Enabled =  bIngresar || bModificar;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar permisos: " + ex.Message);
            }
        }







    }
}