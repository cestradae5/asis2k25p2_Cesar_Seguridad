using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Modulo : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        Cls_Modulos_Controlador cm = new Cls_Modulos_Controlador();

        bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;

        Frm_Reporte_modulos frmReporte = null;

        public Frm_Modulo()
        {
            InitializeComponent();
            this.Load += frmModulo_Load;
        }

        public Frm_Modulo(int idAplicacion) : this() { }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            fun_AplicarPermisos();
            fun_CargarComboBox();
        }
        //Carlo Sosa 0901-22-1106 15/10/2025
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();

            // Usa la clase correcta para obtener los IDs
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Modulos");
            if (idAplicacion <= 0) idAplicacion = 304;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            if (Btn_guardar != null) Btn_guardar.Enabled = (_canIngresar || _canModificar);
            if (Btn_eliminar != null) Btn_eliminar.Enabled = _canEliminar;
            if (Btn_buscar != null) Btn_buscar.Enabled = _canConsultar;
            if (Btn_reporte != null) Btn_reporte.Enabled = _canImprimir;

            bool puedeEditar = (_canIngresar || _canModificar);
            Txt_id.Enabled = puedeEditar;
            Txt_nombre.Enabled = puedeEditar;
            Txt_descripcion.Enabled = puedeEditar;
            Rdb_habilitado.Enabled = puedeEditar;
            Rdb_inabilitado.Enabled = puedeEditar;
        }
        private void fun_CargarComboBox()
        {
            Cbo_busqueda.Items.Clear();
            string[] items = cm.ItemsModulos();
            foreach (var item in items) Cbo_busqueda.Items.Add(item);
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_id.Text) || string.IsNullOrEmpty(Txt_nombre.Text))
            {
                MessageBox.Show("Debe ingresar Id y Nombre.");
                return;
            }

            if (!int.TryParse(Txt_id.Text, out int Pk_Id_Modulo))
            {
                MessageBox.Show("Id debe ser un número.");
                return;
            }

            string sCmp_Nombre_Modulo = Txt_nombre.Text;
            string sCmp_Descripcion_Modulo = Txt_descripcion.Text;
            byte btCmp_Estado_Modulo = (Rdb_habilitado.Checked) ? (byte)1 : (byte)0;

            DataRow dr = cm.BuscarModulo(Pk_Id_Modulo);
            bool bResultado = false;

            if (dr == null)
            {
                if (!_canIngresar) { MessageBox.Show("No tiene permiso para ingresar."); return; }
                bResultado = cm.InsertarModulo(Pk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            }
            else
            {
                if (!_canModificar) { MessageBox.Show("No tiene permiso para modificar."); return; }
                DialogResult respuesta = MessageBox.Show("El Id ingresado ya existe. ¿Desea actualizar este módulo?", "Módulo existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No) return;
                bResultado = cm.ModificarModulo(Pk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            }

            if (bResultado)
            {
                MessageBox.Show("Guardado correctamente!");
                fun_CargarComboBox();
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Guardó el módulo: {Txt_nombre.Text}", true);
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al guardar el módulo.");
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Txt_id.Enabled = true;
            MessageBox.Show("Campos listos para nuevo registro");
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!_canEliminar) { MessageBox.Show("No tiene permiso para eliminar."); return; }
            if (string.IsNullOrEmpty(Txt_id.Text))
            {
                MessageBox.Show("Ingrese el Id del módulo a eliminar.");
                return;
            }
            if (!int.TryParse(Txt_id.Text, out int Pk_Id_Modulo))
            {
                MessageBox.Show("Id debe ser un número.");
                return;
            }
            if (cm.ModuloEnUso(Pk_Id_Modulo))
            {
                MessageBox.Show("No se puede eliminar el módulo porque está siendo utilizado en una aplicación.");
                return;
            }
            bool bResultado = cm.EliminarModulo(Pk_Id_Modulo);
            if (bResultado)
            {
                MessageBox.Show("Módulo eliminado correctamente.");
                fun_CargarComboBox();
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Eliminó el módulo: {Txt_nombre.Text}", true);
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al eliminar módulo.");
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (!_canConsultar) { MessageBox.Show("No tiene permiso para consultar."); return; }
            if (Cbo_busqueda.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un módulo para buscar.");
                return;
            }
            string sSeleccionado = Cbo_busqueda.SelectedItem.ToString();
            int Pk_Id_Modulo = int.Parse(sSeleccionado.Split('-')[0].Trim());

            DataRow dr = cm.BuscarModulo(Pk_Id_Modulo);
            if (dr != null)
            {
                Txt_id.Text = dr["Pk_Id_Modulo"].ToString();
                Txt_nombre.Text = dr["Cmp_Nombre_Modulo"].ToString();
                Txt_descripcion.Text = dr["Cmp_Descripcion_Modulo"].ToString();

                bool bEstado = Convert.ToBoolean(dr["Cmp_Estado_Modulo"]);
                Rdb_habilitado.Checked = bEstado;
                Rdb_inabilitado.Checked = !bEstado;

                Txt_id.Enabled = false;
                Cbo_busqueda.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Módulo no encontrado.");
            }
        }

        private void fun_LimpiarCampos()
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Cbo_busqueda.SelectedIndex = -1;
        }

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
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            if (!_canImprimir) { MessageBox.Show("No tiene permiso para imprimir/reportar."); return; }
            if (frmReporte == null || frmReporte.IsDisposed)
            {
                frmReporte = new Frm_Reporte_modulos();
                frmReporte.FormClosed += (s, args) => frmReporte = null;
                frmReporte.Show();
            }
            else
            {
                frmReporte.BringToFront();
            }
        }
    }
}