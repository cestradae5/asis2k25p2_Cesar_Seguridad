using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;
using System.Runtime.InteropServices;
//Brandon Alexander Hernandez Salguero - 0901-22-9663

namespace Capa_Vista_Seguridad
{
    public partial class Frm_PermisosPerfiles : Form
    {
        Cls_AplicacionControlador appControlador = new Cls_AplicacionControlador();
        Cls_Asignacion_Permiso_PerfilControador controlador = new Cls_Asignacion_Permiso_PerfilControador();
        private DataTable dtPerfiles;
        private DataTable dtAplicacione;
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora


        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;


        public Frm_PermisosPerfiles()
        {
            InitializeComponent();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
            
        }

        private void InicializarDataGridView()
        {
            Dgv_Permisos.Columns.Clear();
            Dgv_Permisos.Columns.Add("Perfil", "Perfil");
            Dgv_Permisos.Columns.Add("Aplicacion", "Aplicación");
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" });

            // IDs ocultos
            Dgv_Permisos.Columns.Add("IdPerfil", "IdPerfil");
            Dgv_Permisos.Columns["IdPerfil"].Visible = false;
            Dgv_Permisos.Columns.Add("IdModulo", "IdModulo");
            Dgv_Permisos.Columns["IdModulo"].Visible = false;
            Dgv_Permisos.Columns.Add("IdAplicacion", "IdAplicacion");
            Dgv_Permisos.Columns["IdAplicacion"].Visible = false;

            // Obtener lista de aplicaciones
            var lista = appControlador.ObtenerTodasLasAplicaciones();

            DataTable dtAplicacion = new DataTable();
            dtAplicacion.Columns.Add("pk_id_aplicacion", typeof(int));
            dtAplicacion.Columns.Add("nombre_aplicacion", typeof(string));

            foreach (var app in lista)
            {
                dtAplicacion.Rows.Add(app.iPkIdAplicacion, app.sNombreAplicacion);
            }

            Cbo_aplicaciones.DataSource = dtAplicacion;
            Cbo_aplicaciones.DisplayMember = "Cmp_Nombre_Aplicacion";
            Cbo_aplicaciones.ValueMember = "Pk_Id_Aplicacion";
            Cbo_aplicaciones.SelectedIndex = -1;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPermisosPerfiles_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox Modulos
            DataTable dtModulos = controlador.datObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "Cmp_Nombre_Modulo";
            Cbo_Modulos.ValueMember = "Pk_Id_Modulo";
            Cbo_Modulos.SelectedIndex = -1;

            dtPerfiles = controlador.datObtenerPerfiles();
            Cbo_perfiles.DataSource = dtPerfiles.Copy();
            Cbo_perfiles.DisplayMember = "Cmp_Puesto_Perfil";
            Cbo_perfiles.ValueMember = "Pk_Id_Perfil";
            Cbo_perfiles.SelectedIndex = -1;

            dtAplicacione = controlador.datObtenerAplicaciones();
            Cbo_aplicaciones.DataSource = dtAplicacione.Copy();
            Cbo_aplicaciones.DisplayMember = "nombre_aplicacion";
            Cbo_aplicaciones.ValueMember = "pk_id_aplicacion";
            Cbo_aplicaciones.SelectedIndex = -1;

            InicializarDataGridView();
        }

        private void Cbo_Modulos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Cbo_Modulos.SelectedValue != null)
            {
                var lista = appControlador.ObtenerTodasLasAplicaciones();

                DataTable dtAplicacion = new DataTable();
                dtAplicacion.Columns.Add("pk_id_aplicacion", typeof(int));
                dtAplicacion.Columns.Add("nombre_aplicacion", typeof(string));

                foreach (var app in lista)
                {
                    dtAplicacion.Rows.Add(app.iPkIdAplicacion, app.sNombreAplicacion);
                }

                Cbo_aplicaciones.DataSource = dtAplicacion;
                Cbo_aplicaciones.DisplayMember = "nombre_aplicacion";
                Cbo_aplicaciones.ValueMember = "pk_id_aplicacion";
                Cbo_aplicaciones.SelectedIndex = -1;
            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (Cbo_perfiles.SelectedIndex == -1 || Cbo_Modulos.SelectedIndex == -1 || Cbo_aplicaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Perfil, Módulo y Aplicación.");
                return;
            }

            string perfilNombre = Cbo_perfiles.Text;
            string aplicacionNombre = Cbo_aplicaciones.Text;
            int idPerfil = Convert.ToInt32(Cbo_perfiles.SelectedValue);
            int idAplicacion = Convert.ToInt32(Cbo_aplicaciones.SelectedValue);
            int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);

            bool existe = false;
            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;
                int iperfil = Convert.ToInt32(row.Cells["IdPerfil"].Value);
                int imodulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iaplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);
                if (iperfil == idPerfil && imodulo == idModulo && iaplicacion == idAplicacion)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                Dgv_Permisos.Rows.Add(
                    perfilNombre,
                    aplicacionNombre,
                    false, // Ingresar
                    false, // Consultar
                    false, // Modificar
                    false, // Eliminar
                    false, // Imprimir
                    idPerfil,
                    idModulo,
                    idAplicacion
                );

                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Permisos Perfil - Agregar", true);

            }
            else
            {
                MessageBox.Show("Este Perfil ya tiene la aplicación asignada, solo modifique los permisos.");
            }
        }

        private void Btn_insertar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para insertar.");
                return;
            }
            int insertados = 0;
            int actualizados = 0;

            foreach (DataGridViewRow row in Dgv_Permisos.Rows) //FIX: DataGridViewRow, no DataGriedview
            {
                if (row.IsNewRow) continue;
                int iperfil = Convert.ToInt32(row.Cells["IdPerfil"].Value);
                int imodulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iaplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);
                bool ingresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false); // FIX: Cells y Value están con mayúsculas
                bool consultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool modificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool eliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool imprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                // FIX: Llamada del método y parámetros
                if (controlador.bExistePermisoPerfil(iperfil, imodulo, iaplicacion))
                {
                    controlador.iActualizarPermisoPerfilAplicacion(iperfil, imodulo, iaplicacion, ingresar, consultar, modificar, eliminar, imprimir);
                    actualizados++;
                }
                else
                {
                    controlador.iInsertarPermisoPerfilAplicacion(iperfil, imodulo, iaplicacion, ingresar, consultar, modificar, eliminar, imprimir);
                    insertados++;
                }

                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, iaplicacion, "Asignación aplicación a perfil - Insertar", true);


            }
            MessageBox.Show($"Se insertaron {insertados} registros y se actualizaron {actualizados} registros correctamente.");
            Dgv_Permisos.Rows.Clear();
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.CurrentRow != null && !Dgv_Permisos.CurrentRow.IsNewRow) // FIX: Sintaxis
            {
                int idaplicacion = Convert.ToInt32(Dgv_Permisos.CurrentRow.Cells["IdAplicacion"].Value);
                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901 -22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idaplicacion, "Asignación Perfil a Usuario - Quitar", true);

                Dgv_Permisos.Rows.Remove(Dgv_Permisos.CurrentRow);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para quitar.");
            }

        }
        private void Dgv_Permisos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pic_Cerrar_Click(object sender, EventArgs e) => this.Close();

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }




        //Marcos Andres Velásquez Alcántara
        //Carnet: 0901-21-1115

        private Cls_PermisoUsuario gPermisoUsuario = new Cls_PermisoUsuario();

        private List<(int moduloId, int aplicacionId)> gParesModuloAplicacion = new List<(int, int)>();

        private Dictionary<(int moduloId, int aplicacionId), (bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)> gPermisosPorModuloApp
            = new Dictionary<(int, int), (bool, bool, bool, bool, bool)>();


        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            int usuarioId = Cls_sesion.iUsuarioId;

            var sParesNombres = new List<(string sModulo, string sAplicacion)>
    {
        
        ("Seguridad", "Gestion de empleado"),
        ("Seguridad", "Administracion"),
    };

            foreach (var (sNombreModulo, sNombreAplicacion) in sParesNombres)
            {
                int idModulo = gPermisoUsuario.ObtenerIdModuloPorNombre(sNombreModulo);
                int idAplicacion = gPermisoUsuario.ObtenerIdAplicacionPorNombre(sNombreAplicacion);

                if (idModulo != -1 && idAplicacion != -1)
                {
                    gParesModuloAplicacion.Add((idModulo, idAplicacion));
                }
            }

            AplicarPermisosUsuario(usuarioId);
        }

        private void AplicarPermisosUsuario(int usuarioId)
        {
            foreach (var (moduloId, aplicacionId) in gParesModuloAplicacion)
            {
                var bPermisos = gPermisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);

                if (bPermisos != null)
                {
                    gPermisosPorModuloApp[(moduloId, aplicacionId)] = bPermisos.Value;
                }
            }

            CombinarPermisosYActualizarBotones();
        }

        private void CombinarPermisosYActualizarBotones()
        {
            bool bIngresar = false;
            bool bConsultar = false;
            bool bModificar = false;
            bool bEliminar = false;

            foreach (var bPermiso in gPermisosPorModuloApp.Values)
            {
                bIngresar |= bPermiso.bIngresar;
                bConsultar |= bPermiso.bConsultar;
                bModificar |= bPermiso.bModificar;
                bEliminar |= bPermiso.bEliminar;
            }

           


            Btn_agregar.Enabled = bIngresar;
            Btn_quitar.Enabled = bEliminar;
            Btn_insertar.Enabled = bIngresar;

        }








    }

}
