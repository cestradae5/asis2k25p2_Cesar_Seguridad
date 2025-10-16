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
        Cls_Registrar_Permisos_Bitacora registrarBitacora = new Cls_Registrar_Permisos_Bitacora();  //Aron Esquit  0901-22-13036
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitácora Aron Esquit 0901-22-13036
        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;


        public Frm_asignacion_aplicacion_usuario()
        {
            InitializeComponent();
            fun_AplicarPermisos();
            this.Load += frmAsignacion_aplicacion_usuario_Load;
            Cbo_Modulos.SelectedIndexChanged += Cbo_Modulos_SelectedIndexChanged;
            
        }
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            int idUsuario = Capa_Modelo_Seguridad.Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Asig Aplicacion Usuario");
            if (idAplicacion <= 0) idAplicacion = 306; // Usa tu ID real aquí
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            // Habilitar/deshabilitar controles según permisos
            if (Btn_agregar != null) Btn_agregar.Enabled = _canIngresar;
            if (Btn_finalizar != null) Btn_finalizar.Enabled = _canIngresar || _canModificar;
            if (Btn_quitar != null) Btn_quitar.Enabled = _canConsultar;
            if (Btn_Buscar != null) Btn_Buscar.Enabled = _canConsultar;
            if (Btn_salir != null) Btn_salir.Enabled = true;

            // Combos y DataGridView
            Cbo_Usuarios.Enabled = _canConsultar || _canIngresar || _canModificar;
            Cbo_Modulos.Enabled = _canConsultar || _canIngresar || _canModificar;
            Cbo_Aplicaciones.Enabled = _canConsultar || _canIngresar || _canModificar;
            Dgv_Permisos.Enabled = _canConsultar || _canIngresar || _canModificar || _canEliminar;
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

            fun_CargarUsuarios(); 
            fun_CargarModulos();
            

            InicializarDataGridView();

            fun_AplicarPermisos();
            Dgv_Permisos.CellBeginEdit += Dgv_Permisos_CellBeginEdit;
        }

        //Ruben Armando Lopez Luch
        //0901-20-4620
        private void fun_CargarUsuarios()
        {
            DataTable dtUsuarios = controlador.ObtenerUsuarios();
            Cbo_Usuarios.DataSource = dtUsuarios;
            Cbo_Usuarios.DisplayMember = "nombre_usuario";
            Cbo_Usuarios.ValueMember = "pk_id_usuario";
            Cbo_Usuarios.SelectedIndex = -1;
        }

        private void fun_CargarModulos()
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

            string sUsuario = Cbo_Usuarios.Text;
            string sAplicacion = Cbo_Aplicaciones.Text;
            int iIdUsuario = Convert.ToInt32(Cbo_Usuarios.SelectedValue);
            int iIdModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);
            int iIdAplicacion = Convert.ToInt32(Cbo_Aplicaciones.SelectedValue);

            bool bExiste = false;
            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;
                int u = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int m = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int a = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                if (u == iIdUsuario && m == iIdModulo && a == iIdAplicacion)
                {
                    bExiste = true;
                    break;
                }
            }

            if (!bExiste)
            {
                Dgv_Permisos.Rows.Add(sUsuario, sAplicacion, false, false, false, false, false, iIdUsuario, iIdModulo, iIdAplicacion);
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
            // Validacion de sUsuario y plaicacion antes de insertar datos
            if (Dgv_Permisos.Rows.Count == 0)


            {
                MessageBox.Show("Debe seleccionar un usuario y una aplicación antes de insertar.");
                return;
            }

            int iInsertados = 0;
            int iActualizados = 0;

            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;

                int iIdUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int iIdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iIdAplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                bool bIngresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false);
                bool bConsultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool bModificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool bEliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool bImprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                // Clase para bitacora
                // Crear objeto de permisos actuales
                Cls_Permisos gPermisosActuales = new Cls_Permisos
                {
                    bIngresar = bIngresar,
                    bConsultar = bConsultar,
                    bModificar = bModificar,
                    bEliminar = bEliminar,
                    bImprimir = bImprimir
                };

                // Registrar cambios en bitácora comparando con los permisos anteriores
                registrarBitacora.fun_CompararYRegistrar(
                    Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario,
                    iIdUsuario,
                    iIdModulo,
                    iIdAplicacion,
                    row.Cells["Usuario"].Value.ToString(),
                    row.Cells["Aplicacion"].Value.ToString(),
                    gPermisosActuales
                );



                if (modelo.ExistePermiso(iIdUsuario, iIdModulo, iIdAplicacion))
                {
                    modelo.ActualizarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                              bIngresar, bConsultar, bModificar,
                                                              bEliminar, bImprimir);
                    iActualizados++;
                }
                else
                {
                    modelo.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                            bIngresar, bConsultar, bModificar,
                                                            bEliminar, bImprimir);
                    iInsertados++;
                }
            }

            MessageBox.Show($"Se insertaron {iInsertados} registros y se actualizaron {iActualizados} registros correctamente.");
            Dgv_Permisos.Rows.Clear();
        }


        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.CurrentRow != null && !Dgv_Permisos.CurrentRow.IsNewRow)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de quitar el registro seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Capturar datos antes de eliminar la fila
                    int idAplicacion = Convert.ToInt32(Dgv_Permisos.CurrentRow.Cells["IdAplicacion"].Value);
                    int idUsuario = Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario;
                    string sUsuario = Dgv_Permisos.CurrentRow.Cells["Usuario"].Value.ToString();
                    string sAplicacion = Dgv_Permisos.CurrentRow.Cells["Aplicacion"].Value.ToString();

                    // Eliminar la fila
                    Dgv_Permisos.Rows.Remove(Dgv_Permisos.CurrentRow);

                    // Registrar en bitácora
                    ctrlBitacora.RegistrarAccion(idUsuario, idAplicacion,
                        $"Al usuario '{sUsuario}' se le quitarán todos los permisos en la aplicación '{sAplicacion}'", true);

                    MessageBox.Show("Se ha quitado correctamente.",
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
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



        // validacion de sUsuario y sAplicacion antes de poder selecionar los permisos
        private void Dgv_Permisos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Verificar si la celda es un checkbox
            if (Dgv_Permisos.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                var row = Dgv_Permisos.Rows[e.RowIndex];

                // Validar con los IDs ocultos (mejor que con texto)
                var idUsuario = row.Cells["IdUsuario"].Value?.ToString();
                var idAplicacion = row.Cells["IdAplicacion"].Value?.ToString();

                // Si no hay sUsuario o aplicación, cancelar edición
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
                        row["iFk_id_modulo"],
                        row["iFk_id_aplicacion"]
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




      




    }



}

