using System;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using System.Data;
using System.Runtime.InteropServices;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
{
    /* Marcos Andres Velasquez Alcántara 0901-21-1115 */
    public partial class Frm_asignacion_aplicacion_usuario : Form
    {
        Cls_SentenciaAsignacionUsuarioAplicacion modelo = new Cls_SentenciaAsignacionUsuarioAplicacion();
        Cls_AplicacionControlador appControlador = new Cls_AplicacionControlador();
        Cls_ControladorAsignacionUsuarioAplicacion controlador = new Cls_ControladorAsignacionUsuarioAplicacion();
        Cls_SentenciasBitacora bitacora = new Cls_SentenciasBitacora();

        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;

        public Frm_asignacion_aplicacion_usuario()
        {
            InitializeComponent();
            this.Load += frmAsignacion_aplicacion_usuario_Load;
        }

        private void frmAsignacion_aplicacion_usuario_Load(object sender, EventArgs e)
        {
            
            DataTable dtUsuarios = controlador.ObtenerUsuarios();
            Cbo_Usuarios.DataSource = dtUsuarios;
            Cbo_Usuarios.DisplayMember = "nombre_usuario";   // Debe coincidir con el SELECT del modelo
            Cbo_Usuarios.ValueMember = "pk_id_usuario";
            Cbo_Usuarios.SelectedIndex = -1;

            
            DataTable dtModulos = controlador.ObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "nombre_modulo";    
            Cbo_Modulos.ValueMember = "pk_id_modulo";
            Cbo_Modulos.SelectedIndex = -1;

            CargarUsuarios();
            CargarModulos();

            InicializarDataGridView();

            ConfigurarIdsDinamicamenteYAplicarPermisos();
        }

        //Ruben Armando Lopez Luch
        //0901-20-4620
        private void CargarUsuarios()
        {
            DataTable dtUsuarios = controlador.ObtenerUsuarios();
            Cbo_Usuarios.DataSource = dtUsuarios;
            Cbo_Usuarios.DisplayMember = "nombre_usuario";
            Cbo_Usuarios.ValueMember = "pk_id_usuario";
            Cbo_Usuarios.SelectedIndex = -1;
        }

        private void CargarModulos()
        {
            DataTable dtModulos = controlador.ObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "nombre_modulo";
            Cbo_Modulos.ValueMember = "pk_id_modulo";
            Cbo_Modulos.SelectedIndex = -1;
        }
        // fin -> Ruben Armando Lopez Luch
        private void InicializarDataGridView()
        {
            Dgv_Permisos.Columns.Clear();
            Dgv_Permisos.Columns.Add("Usuario", "Usuario");
            Dgv_Permisos.Columns.Add("Aplicacion", "Aplicación");
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" });

            
            Dgv_Permisos.Columns.Add("IdUsuario", "IdUsuario");
            Dgv_Permisos.Columns["IdUsuario"].Visible = false;
            Dgv_Permisos.Columns.Add("IdModulo", "IdModulo");
            Dgv_Permisos.Columns["IdModulo"].Visible = false;
            Dgv_Permisos.Columns.Add("IdAplicacion", "IdAplicacion");
            Dgv_Permisos.Columns["IdAplicacion"].Visible = false;

            // Aplicaciones
            var lista = appControlador.ObtenerTodasLasAplicaciones();
            DataTable dtAplicacion = new DataTable();
            dtAplicacion.Columns.Add("pk_id_aplicacion", typeof(int));
            dtAplicacion.Columns.Add("nombre_aplicacion", typeof(string));
            foreach (var app in lista)
                dtAplicacion.Rows.Add(app.iPkIdAplicacion, app.sNombreAplicacion);

            Cbo_Aplicaciones.DataSource = dtAplicacion;
            Cbo_Aplicaciones.DisplayMember = "nombre_aplicacion";
            Cbo_Aplicaciones.ValueMember = "pk_id_aplicacion";
            Cbo_Aplicaciones.SelectedIndex = -1;
        }

        
        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            // Cambia estos nombres exactamente como están en tu BD
            string nombreModulo = "Seguridad";
            string nombreAplicacion ="Administracion";
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
                Btn_agregar.Enabled = false;        // Botón "Agregar"
                Btn_quitar.Enabled = false;      // Botón "Modificar
                Btn_Buscar.Enabled = false;         // Botón "Buscar"
                Btn_finalizar.Enabled = false;        // Botón "Guardar"
                return;
            }

            var p = permisosActuales.Value;

            Btn_Buscar.Enabled = p.consultar;      
            Btn_agregar.Enabled = p.ingresar;      
            Btn_quitar.Enabled =  p.modificar; 
            Btn_finalizar.Enabled =  p.ingresar || p.modificar;
        }

        // Pablo Quiroa 0901-22-2929
        private void Btn_agregar_Click_1(object sender, EventArgs e)
        {
            if (Cbo_Usuarios.SelectedIndex == -1 || Cbo_Modulos.SelectedIndex == -1 || Cbo_Aplicaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione usuario, módulo y aplicación.");
                return;
            }

            string usuario = Cbo_Usuarios.Text;
            string aplicacion = Cbo_Aplicaciones.Text;
            int idUsuario = Convert.ToInt32(Cbo_Usuarios.SelectedValue);
            int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);
            int idAplicacion = Convert.ToInt32(Cbo_Aplicaciones.SelectedValue);

            bool existe = false;
            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;
                int u = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int m = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int a = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                if (u == idUsuario && m == idModulo && a == idAplicacion)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                Dgv_Permisos.Rows.Add(usuario, aplicacion, false, false, false, false, false, idUsuario, idModulo, idAplicacion);
                bitacora.InsertarBitacora(Cls_sesion.iUsuarioId, idAplicacion, "Asignación Aplicación a Usuario - Agregar", true);
            }
            else
            {
                MessageBox.Show("Este usuario ya tiene esa aplicación asignada. Solo modifique los permisos.");
            }

            Cbo_Usuarios.SelectedIndex = -1;
            Cbo_Modulos.SelectedIndex = -1;
            Cbo_Aplicaciones.SelectedIndex = -1;
        }

     
        private void Btn_finalizar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para insertar.");
                return;
            }

            int insertados = 0;
            int actualizados = 0;

            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;

                int idUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int idModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int idAplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                bool ingresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false);
                bool consultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool modificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool eliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool imprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                if (modelo.ExistePermiso(idUsuario, idModulo, idAplicacion))
                {
                    modelo.ActualizarPermisoUsuarioAplicacion(idUsuario, idModulo, idAplicacion,
                                                              ingresar, consultar, modificar,
                                                              eliminar, imprimir);
                    actualizados++;
                    bitacora.InsertarBitacora(Cls_sesion.iUsuarioId, idAplicacion, "Asignación Aplicación a Usuario - Actualizar", true);
                }
                else
                {
                    modelo.InsertarPermisoUsuarioAplicacion(idUsuario, idModulo, idAplicacion,
                                                            ingresar, consultar, modificar,
                                                            eliminar, imprimir);
                    insertados++;
                    bitacora.InsertarBitacora(Cls_sesion.iUsuarioId, idAplicacion, "Asignación Aplicación a Usuario - Insertar", true);
                }
            }

            MessageBox.Show($"Se insertaron {insertados} registros y se actualizaron {actualizados} registros correctamente.");
            Dgv_Permisos.Rows.Clear();
        }

       
        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.CurrentRow != null && !Dgv_Permisos.CurrentRow.IsNewRow)
            {
                int idAplicacion = Convert.ToInt32(Dgv_Permisos.CurrentRow.Cells["IdAplicacion"].Value);
                bitacora.InsertarBitacora(Cls_sesion.iUsuarioId, idAplicacion, "Asignación Aplicación a Usuario - Quitar", true);
                Dgv_Permisos.Rows.Remove(Dgv_Permisos.CurrentRow);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para quitar.");
            }
        }

        
        private void Btn_salir_Click(object sender, EventArgs e) => this.Close();

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

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_Usuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            int idUsuario = Convert.ToInt32(Cbo_Usuarios.SelectedValue);
            DataTable dtPermisos = controlador.ObtenerPermisosPorUsuario(idUsuario);

            Dgv_Permisos.Rows.Clear();

            if (dtPermisos.Rows.Count > 0)
            {
                foreach (DataRow row in dtPermisos.Rows)
                {
                    Dgv_Permisos.Rows.Add(
                        row["nombre_usuario"].ToString(),
                        row["nombre_aplicacion"].ToString(),
                        Convert.ToBoolean(row["ingresar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["consultar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["modificar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["eliminar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["imprimir_permiso_aplicacion_usuario"]),
                        row["fk_id_usuario"],
                        row["fk_id_modulo"],
                        row["fk_id_aplicacion"]
                    );
                }
                MessageBox.Show("Permisos cargados correctamente.");
            }
            else
            {
                MessageBox.Show("El usuario no tiene permisos asignados.");
            }
        }
    }

        

    }

