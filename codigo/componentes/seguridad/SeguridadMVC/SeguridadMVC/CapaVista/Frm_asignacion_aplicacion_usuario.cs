using System;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_asignacion_aplicacion_usuario : Form
    {
   
        Cls_AplicacionControlador appControlador = new Cls_AplicacionControlador();
        Cls_ControladorAsignacionUsuarioAplicacion controlador = new Cls_ControladorAsignacionUsuarioAplicacion();
        Cls_Registrar_Permisos_Bitacora registrarBitacora = new Cls_Registrar_Permisos_Bitacora();
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
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
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Asig Aplicacion Usuario");
            if (idAplicacion <= 0) idAplicacion = 306;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            // SOLO validaciones visuales - habilitar/deshabilitar controles
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
            fun_CargarUsuarios();
            fun_CargarModulos();
            InicializarDataGridView();
            fun_AplicarPermisos();
            Dgv_Permisos.CellBeginEdit += Dgv_Permisos_CellBeginEdit;
        }

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

        private void Cbo_Modulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SOLO validación visual - combo vacío
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
            Dgv_Permisos.EditMode = DataGridViewEditMode.EditOnEnter;

            // Columnas visibles
            var colUsuario = new DataGridViewTextBoxColumn() { Name = "Usuario", HeaderText = "Usuario", ReadOnly = true };
            var colAplicacion = new DataGridViewTextBoxColumn() { Name = "Aplicacion", HeaderText = "Aplicación", ReadOnly = true };
            var colIngresar = new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" };
            var colConsultar = new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" };
            var colModificar = new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" };
            var colEliminar = new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" };
            var colImprimir = new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" };

            // Columnas ocultas
            var colIdUsuario = new DataGridViewTextBoxColumn() { Name = "IdUsuario", Visible = false };
            var colIdModulo = new DataGridViewTextBoxColumn() { Name = "IdModulo", Visible = false };
            var colIdAplicacion = new DataGridViewTextBoxColumn() { Name = "IdAplicacion", Visible = false };

            Dgv_Permisos.Columns.AddRange(new DataGridViewColumn[]
            {
                colUsuario, colAplicacion, colIngresar, colConsultar,
                colModificar, colEliminar, colImprimir,
                colIdUsuario, colIdModulo, colIdAplicacion
            });

            // SOLO validaciones visuales - bloquear edición de columnas específicas
            Dgv_Permisos.KeyPress += (s, e) =>
            {
                if (Dgv_Permisos.CurrentCell != null)
                {
                    string colName = Dgv_Permisos.Columns[Dgv_Permisos.CurrentCell.ColumnIndex].Name;
                    if (colName == "Usuario" || colName == "Aplicacion")
                        e.Handled = true;
                }
            };

            Dgv_Permisos.CellBeginEdit += (s, e) =>
            {
                string colName = Dgv_Permisos.Columns[e.ColumnIndex].Name;
                if (colName == "Usuario" || colName == "Aplicacion")
                    e.Cancel = true;
            };
        }

        private void Btn_agregar_Click_1(object sender, EventArgs e)
        {
            // SOLO validaciones visuales básicas
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

            // Delegar la lógica de negocio al Controlador
            bool puedeAgregar = controlador.ValidarYAgregarPermiso(Dgv_Permisos, iIdUsuario, iIdModulo, iIdAplicacion, sUsuario, sAplicacion);

            if (puedeAgregar)
            {
                Cbo_Usuarios.SelectedIndex = -1;
                Cbo_Modulos.SelectedIndex = -1;
                Cbo_Aplicaciones.SelectedIndex = -1;
            }
        }

        private void Btn_finalizar_Click(object sender, EventArgs e)
        {
            // SOLO validación visual básica
            if (Dgv_Permisos.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario y una aplicación antes de insertar.");
                return;
            }

            // Delegar toda la lógica al Controlador
            var resultado = controlador.ProcesarPermisos(Dgv_Permisos, registrarBitacora);

            MessageBox.Show($"Se insertaron {resultado.Insertados} registros y se actualizaron {resultado.Actualizados} registros correctamente.");
            Dgv_Permisos.Rows.Clear();
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            // SOLO validación visual básica
            if (Dgv_Permisos.CurrentRow == null || Dgv_Permisos.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione una fila para quitar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de quitar el registro seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                // Delegar lógica al Controlador
                controlador.QuitarPermiso(Dgv_Permisos, ctrlBitacora);
                MessageBox.Show("Se ha quitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Dgv_Permisos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // SOLO validación visual
            if (Dgv_Permisos.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                var row = Dgv_Permisos.Rows[e.RowIndex];
                var idUsuario = row.Cells["IdUsuario"].Value?.ToString();
                var idAplicacion = row.Cells["IdAplicacion"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(idUsuario) || string.IsNullOrWhiteSpace(idAplicacion))
                {
                    e.Cancel = true;
                    MessageBox.Show("Debe seleccionar un usuario y una aplicación antes de marcar permisos.");
                }
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // SOLO validación visual
            if (Cbo_Usuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            int idUsuario = Convert.ToInt32(Cbo_Usuarios.SelectedValue);

            // Delegar al Controlador
            bool permisosCargados = controlador.CargarPermisosUsuario(Dgv_Permisos, idUsuario);

            if (permisosCargados)
            {
                MessageBox.Show("Permisos cargados correctamente.");
            }
            else
            {
                MessageBox.Show("El usuario no tiene permisos asignados.");
            }
        }

        // Resto de métodos de UI (sin cambios)
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

        private void Cbo_Aplicaciones_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}