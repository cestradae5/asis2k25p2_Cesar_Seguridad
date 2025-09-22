using System;
using System.Windows.Forms;
using CapaControlador;
using System.Data;
using System.Runtime.InteropServices;
using CapaModelo;

namespace CapaVista
{
    /* Marcos Andres Velasquez Alcántara 0901-21-1115 */
    public partial class frmasignacion_aplicacion_usuario : Form
    {
        SentenciaAsignacionUsuarioAplicacion modelo = new SentenciaAsignacionUsuarioAplicacion();
        Cls_AplicacionControlador appControlador = new Cls_AplicacionControlador();
        ControladorAsignacionUsuarioAplicacion controlador = new ControladorAsignacionUsuarioAplicacion();
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacroa

        public frmasignacion_aplicacion_usuario()
        {
            InitializeComponent();
            this.Load += frmAsignacion_aplicacion_usuario_Load;
        }

        private void frmAsignacion_aplicacion_usuario_Load(object sender, EventArgs e)
        {
            DataTable dtUsuarios = controlador.ObtenerUsuarios();
            Cbo_Usuarios.DataSource = dtUsuarios;
            Cbo_Usuarios.DisplayMember = "nombre_usuario";
            Cbo_Usuarios.ValueMember = "pk_id_usuario";
            Cbo_Usuarios.SelectedIndex = -1;

            DataTable dtModulos = controlador.ObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "nombre_modulo";
            Cbo_Modulos.ValueMember = "pk_id_modulo";
            Cbo_Modulos.SelectedIndex = -1;

            InicializarDataGridView();
        }

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

            var lista = appControlador.ObtenerTodasLasAplicaciones();
            DataTable dtAplicacion = new DataTable();
            dtAplicacion.Columns.Add("pk_id_aplicacion", typeof(int));
            dtAplicacion.Columns.Add("nombre_aplicacion", typeof(string));
            foreach (var app in lista)
                dtAplicacion.Rows.Add(app.PkIdAplicacion, app.NombreAplicacion);

            Cbo_Aplicaciones.DataSource = dtAplicacion;
            Cbo_Aplicaciones.DisplayMember = "nombre_aplicacion";
            Cbo_Aplicaciones.ValueMember = "pk_id_aplicacion";
            Cbo_Aplicaciones.SelectedIndex = -1;
        }
        //Pablo Quiroa 0901-22-2929
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

            // Valida si ya existe en el DataGridView
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
                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Agregar", true);
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
                    //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                    ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Actualizar", true);

                }
                else
                {
                    modelo.InsertarPermisoUsuarioAplicacion(idUsuario, idModulo, idAplicacion,
                                                            ingresar, consultar, modificar,
                                                            eliminar, imprimir);
                    insertados++;
                    //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                    ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Insertar", true);

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
                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Aplicación a Usuario - Quitar", true);
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
    }
}
