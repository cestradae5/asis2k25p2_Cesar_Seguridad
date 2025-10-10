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

       

        public Frm_asignacion_aplicacion_usuario()
        {
            InitializeComponent();
            this.Load += frmAsignacion_aplicacion_usuario_Load;
            Cbo_Modulos.SelectedIndexChanged += Cbo_Modulos_SelectedIndexChanged;
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

            fun_AplicarPermisos();
            Dgv_Permisos.CellBeginEdit += Dgv_Permisos_CellBeginEdit;
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


        private void Cbo_Modulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evita ejecutar mientras el combo está vacío o cargándose
            if (Cbo_Modulos.SelectedValue == null || Cbo_Modulos.SelectedValue is DataRowView)
            {
                Cbo_Aplicaciones.DataSource = null;
                return;
            }

            try
            {
                int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);

                DataTable dtApps = controlador.ObtenerAplicacionesPorModulo(idModulo);

                if (dtApps != null && dtApps.Rows.Count > 0)
                {
                    Cbo_Aplicaciones.DataSource = dtApps;
                    Cbo_Aplicaciones.DisplayMember = "nombre_aplicacion";
                    Cbo_Aplicaciones.ValueMember = "Pk_Id_Aplicacion";
                    Cbo_Aplicaciones.SelectedIndex = -1;
                }
                else
                {
                    Cbo_Aplicaciones.DataSource = null;
                    MessageBox.Show("Este módulo no tiene aplicaciones activas.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar aplicaciones del módulo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InicializarDataGridView()
        {
            Dgv_Permisos.Columns.Clear();
            Dgv_Permisos.AllowUserToAddRows = false;
            Dgv_Permisos.AllowUserToDeleteRows = true;
            Dgv_Permisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Permisos.EditMode = DataGridViewEditMode.EditOnEnter; // Solo se puede editar celdas editables (como checkboxes)

            // Columnas visibles
            var colUsuario = new DataGridViewTextBoxColumn()
            {
                Name = "Usuario",
                HeaderText = "Usuario",
                ReadOnly = true // Bloquea edición
            };
            var colAplicacion = new DataGridViewTextBoxColumn()
            {
                Name = "Aplicacion",
                HeaderText = "Aplicación",
                ReadOnly = true // Bloquea edición
            };
            var colIngresar = new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" };
            var colConsultar = new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" };
            var colModificar = new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" };
            var colEliminar = new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" };
            var colImprimir = new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" };

            // Columnas ocultas
            var colIdUsuario = new DataGridViewTextBoxColumn() { Name = "IdUsuario", Visible = false };
            var colIdModulo = new DataGridViewTextBoxColumn() { Name = "IdModulo", Visible = false };
            var colIdAplicacion = new DataGridViewTextBoxColumn() { Name = "IdAplicacion", Visible = false };

            // Agregar columnas
            Dgv_Permisos.Columns.AddRange(new DataGridViewColumn[]
            {
        colUsuario, colAplicacion, colIngresar, colConsultar,
        colModificar, colEliminar, colImprimir,
        colIdUsuario, colIdModulo, colIdAplicacion
            });

            // Impedir edición por teclado en columnas bloqueadas
            Dgv_Permisos.KeyPress += (s, e) =>
            {
                if (Dgv_Permisos.CurrentCell != null)
                {
                    string colName = Dgv_Permisos.Columns[Dgv_Permisos.CurrentCell.ColumnIndex].Name;
                    if (colName == "Usuario" || colName == "Aplicacion")
                        e.Handled = true; // Bloquea teclas
                }
            };

            // Impedir edición con doble clic
            Dgv_Permisos.CellBeginEdit += (s, e) =>
            {
                string colName = Dgv_Permisos.Columns[e.ColumnIndex].Name;
                if (colName == "Usuario" || colName == "Aplicacion")
                    e.Cancel = true;
            };

            // Cargar aplicaciones en el combo
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
                //Bitacora Aron Ricardo Esquit Silva 0901-22-13036
                bitacora.InsertarBitacora(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Agregar", true);
            }
            else
            {
                MessageBox.Show("Este usuario ya tiene esa aplicación asignada. Solo modifique los permisos.");
            }

            Cbo_Usuarios.SelectedIndex = -1;
            Cbo_Modulos.SelectedIndex = -1;
            Cbo_Aplicaciones.SelectedIndex = -1;
        }

        //0901-21-1115 Marcos Andres Velásquez Alcántara
        private void Btn_finalizar_Click(object sender, EventArgs e)

        {
            // Validacion de usuario y plaicacion antes de insertar datos
            if (Dgv_Permisos.Rows.Count == 0)


            {
                MessageBox.Show("Debe seleccionar un usuario y una aplicación antes de insertar.");
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
                    bitacora.InsertarBitacora(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Actualizar", true);
                }
                else
                {
                    modelo.InsertarPermisoUsuarioAplicacion(idUsuario, idModulo, idAplicacion,
                                                            ingresar, consultar, modificar,
                                                            eliminar, imprimir);
                    insertados++;
                    bitacora.InsertarBitacora(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Insertar", true);
                }
            }

            MessageBox.Show($"Se insertaron {insertados} registros y se actualizaron {actualizados} registros correctamente.");
            Dgv_Permisos.Rows.Clear();
        }


        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.CurrentRow != null && !Dgv_Permisos.CurrentRow.IsNewRow)
            {
                // Mostrar mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de quitar el registro seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Si el usuario confirma, eliminar el registro
                if (resultado == DialogResult.Yes)
                {
                    int idAplicacion = Convert.ToInt32(Dgv_Permisos.CurrentRow.Cells["IdAplicacion"].Value);

                    // Registrar en bitácora
                    bitacora.InsertarBitacora(
                        Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario,
                        idAplicacion,
                        "Asignación Aplicación a Usuario - Quitar",
                        true
                    );

                    // Eliminar la fila del DataGridView
                    Dgv_Permisos.Rows.Remove(Dgv_Permisos.CurrentRow);

                    MessageBox.Show("Se ha quitadocorrectamente.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    // Si el usuario presiona "No"
                    MessageBox.Show("Operación cancelada.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para quitar.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }



        // validacion de usuario y aplicacion antes de poder selecionar los permisos
        private void Dgv_Permisos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Verificar si la celda es un checkbox
            if (Dgv_Permisos.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                var row = Dgv_Permisos.Rows[e.RowIndex];

                // Validar con los IDs ocultos (mejor que con texto)
                var idUsuario = row.Cells["IdUsuario"].Value?.ToString();
                var idAplicacion = row.Cells["IdAplicacion"].Value?.ToString();

                // Si no hay usuario o aplicación, cancelar edición
                if (string.IsNullOrWhiteSpace(idUsuario) || string.IsNullOrWhiteSpace(idAplicacion))
                {
                    e.Cancel = true;
                    MessageBox.Show("Debe seleccionar un usuario y una aplicación antes de marcar permisos.");
                }
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

        private void Cbo_Aplicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /* 0901-21-1115 
    Marcos Velásquez Alcántara
        
         Filtros de Permisos 
         */


        private void fun_AplicarPermisos()
        {
            try
            {
                int idUsuario = Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario;

                Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();
                Cls_Asignacion_Permiso_PerfilesDAO perfilDAO = new Cls_Asignacion_Permiso_PerfilesDAO();

                int IidAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Asig Aplicacion Usuario");
                int IidModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");

                bool bIngresar = false, bConsultar = false, bModificar = false, bEliminar = false, bImprimir = false;

                //  Revisar permisos or usuario + aplicación + módulo
                var permisosUsuario = permisoUsuario.ConsultarPermisos(idUsuario, IidAplicacion, IidModulo);

                if (permisosUsuario.HasValue)
                {
                    bIngresar = permisosUsuario.Value.ingresar;
                    bConsultar = permisosUsuario.Value.consultar;
                    bModificar = permisosUsuario.Value.modificar;
                    bEliminar = permisosUsuario.Value.eliminar;
                    bImprimir = permisosUsuario.Value.imprimir;
                }

                //  revisar ese permiso por perfil + aplicación
                if (!bIngresar || !bConsultar || !bModificar || !bEliminar || !bImprimir)
                {
                    DataTable dtPerfiles = perfilDAO.datObtenerPerfiles();

                    foreach (DataRow perfilRow in dtPerfiles.Rows)
                    {
                        int IidPerfil = Convert.ToInt32(perfilRow["Pk_Id_Perfil"]);
                        DataTable permisosPerfil = perfilDAO.ObtenerPermisosPerfilAplicacion(IidPerfil, IidAplicacion);

                        if (permisosPerfil.Rows.Count > 0)
                        {
                            DataRow row = permisosPerfil.Rows[0];

                            // Revisar permisos por separado
                            if (!bIngresar && Convert.ToBoolean(row["ingresar"]))
                                bIngresar = true;

                            if (!bConsultar && Convert.ToBoolean(row["consultar"]))
                                bConsultar = true;

                            if (!bModificar && Convert.ToBoolean(row["modificar"]))
                                bModificar = true;

                            if (!bEliminar && Convert.ToBoolean(row["eliminar"]))
                                bEliminar = true;

                            if (!bImprimir && Convert.ToBoolean(row["imprimir"]))
                                bImprimir = true;
                        }
                    }
                }

                //   Aplicar permisos a botones
                Btn_agregar.Enabled = bIngresar || bModificar;
                Btn_Buscar.Enabled = bConsultar;
                Btn_finalizar.Enabled = bModificar;
                Btn_quitar.Enabled = bEliminar || bModificar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar permisos: " + ex.Message);
            }
        }





    }



}

