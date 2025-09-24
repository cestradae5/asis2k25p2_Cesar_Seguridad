using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;
using System.Runtime.InteropServices;
//Brandon Alexander Hernandez Salguero - 0901-22-9663

namespace CapaVista
{
    public partial class FrmPermisosPerfiles : Form
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


        public FrmPermisosPerfiles()
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
                dtAplicacion.Rows.Add(app.PkIdAplicacion, app.NombreAplicacion);
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
                    dtAplicacion.Rows.Add(app.PkIdAplicacion, app.NombreAplicacion);
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



        //0901-21-1115 Marcos Andres Velasquez Alcánatara

        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            
            string nombreModulo = "RHM";
            string nombreAplicacion = "Empleados";
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
                Btn_quitar.Enabled = false;
                Btn_insertar.Enabled = false;
                

                return;
            }

            var p = permisosActuales.Value;


            Btn_agregar.Enabled = p.ingresar;
            Btn_quitar.Enabled = p.eliminar;
            Btn_insertar.Enabled = p.ingresar;

        }




    }

}
