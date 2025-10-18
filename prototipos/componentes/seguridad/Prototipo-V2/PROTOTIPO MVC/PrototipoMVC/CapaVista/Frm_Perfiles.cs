using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

//Brandon Alexander Hernandez Salguero 0901-22-9663
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Perfiles : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();  //Bitacora  Aron Esquit 0901-22-13036
        private Cls_Perfiles_Controlador controlador = new Cls_Perfiles_Controlador();

        // Permisos (deben ser campos de la clase para que los métodos puedan usarlos)
        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;

        public Frm_Perfiles()
        {
            InitializeComponent();
            fun_AplicarPermisos();
            fun_ConfigurarComboBoxPerfiles();
            fun_ConfigurarComboBoxTipoPerfil();
            fun_Configuracioninicial();
        }

        private void fun_AplicarPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();

            // Usar la clase de permisos para obtener el id de aplicacion y modulo
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();
            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Perfiles");
            if (idAplicacion <= 0) idAplicacion = 303;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;
            if (Btn_nuevo != null) Btn_guardar.Enabled = (_canIngresar);
            if (Btn_guardar != null) Btn_guardar.Enabled = (_canIngresar);
            if (Btn_modificar != null) Btn_modificar.Enabled = (_canModificar);

            if (Btn_Eliminar != null) Btn_Eliminar.Enabled = _canEliminar;
            if (Btn_buscar != null) Btn_buscar.Enabled = _canConsultar;
            if (Cbo_perfiles != null) Cbo_perfiles.Enabled = _canConsultar;
            if (Btn_reporte != null) Btn_reporte.Enabled = _canImprimir;

            bool puedeEditar = (_canIngresar || _canModificar);
            Txt_idperfil.Enabled = puedeEditar;
            Txt_puesto.Enabled = puedeEditar;
            Txt_descripcion.Enabled = puedeEditar;
            Cbo_tipoperfil.Enabled = puedeEditar;
            Rdb_Habilitado.Enabled = puedeEditar;
            Rdb_inhabilitado.Enabled = puedeEditar;
        }

        private void fun_Configuracioninicial()
        {
            Btn_guardar.Enabled = _canIngresar;
            Btn_modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_nuevo.Enabled = _canIngresar;
            Btn_cancelar.Enabled = true;
            Btn_buscar.Enabled = _canConsultar;
            Btn_reporte.Enabled = _canImprimir;
            Txt_idperfil.Enabled = false;
            Txt_puesto.Enabled = false;
            Txt_descripcion.Enabled = false;
            Cbo_tipoperfil.Enabled = false;
            Rdb_Habilitado.Enabled = false;
            Rdb_inhabilitado.Enabled = false;
        }

        // No más listaPerfiles en la vista

        private void fun_ConfigurarComboBoxPerfiles()
        {
            var listaPerfiles = controlador.listObtenerTodosLosPerfiles();
            Cbo_perfiles.Items.Clear();
            Cbo_perfiles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_perfiles.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaPerfiles.Select(p => p.Id.ToString()).ToArray());
            autoComplete.AddRange(listaPerfiles.Select(p => p.Puesto).ToArray());
            Cbo_perfiles.AutoCompleteCustomSource = autoComplete;

            // Display y Value
            Cbo_perfiles.DisplayMember = "Display";
            Cbo_perfiles.ValueMember = "Id";
            foreach (var perfil in listaPerfiles)
            {
                Cbo_perfiles.Items.Add(new
                {
                    Display = $"{perfil.Id} - {perfil.Puesto}",
                    Id = perfil.Id
                });
            }
        }

        private void fun_ConfigurarComboBoxTipoPerfil()
        {
            Cbo_tipoperfil.Items.Clear();
            Cbo_tipoperfil.Items.Add("0 - Cliente");
            Cbo_tipoperfil.Items.Add("1 - Empleado");
            Cbo_tipoperfil.SelectedIndex = -1;
        }

        private void fun_MostrarPerfil(PerfilDTO perfil)
        {
            Txt_idperfil.Text = perfil.Id.ToString();
            Txt_puesto.Text = perfil.Puesto;
            Txt_descripcion.Text = perfil.Descripcion;
            Cbo_tipoperfil.SelectedIndex = perfil.Tipo;
            Rdb_Habilitado.Checked = perfil.Estado;
            Rdb_inhabilitado.Checked = !perfil.Estado;

            // Al mostrar un perfil, activa botones según permisos y contexto
            Btn_guardar.Enabled = false;
            Btn_modificar.Enabled = _canModificar;
            Btn_Eliminar.Enabled = _canEliminar;
            Btn_nuevo.Enabled = _canIngresar;
            Btn_cancelar.Enabled = true;
            Btn_buscar.Enabled = _canConsultar;
            Btn_reporte.Enabled = _canImprimir;

            Txt_idperfil.Enabled = false;
            Txt_puesto.Enabled = _canModificar;
            Txt_descripcion.Enabled = _canModificar;
            Cbo_tipoperfil.Enabled = _canModificar;
            Rdb_Habilitado.Enabled = _canModificar;
            Rdb_inhabilitado.Enabled = _canModificar;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();

            Btn_nuevo.Enabled = false;
            Btn_guardar.Enabled = _canIngresar;
            Btn_modificar.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_cancelar.Enabled = true;

            Txt_idperfil.Enabled = false;
            Txt_puesto.Enabled = true;
            Txt_descripcion.Enabled = true;
            Cbo_tipoperfil.Enabled = true;
            Rdb_Habilitado.Enabled = true;
            Rdb_inhabilitado.Enabled = true;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string mensaje;
            bool bExito = controlador.bInsertarPerfil(
                Txt_puesto.Text,
                Txt_descripcion.Text,
                Rdb_Habilitado.Checked,
                Cbo_tipoperfil.SelectedIndex,
                out mensaje
            );

            if (bExito)
            {
                MessageBox.Show("Perfil guardado correctamente");
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Guardó el perfil: {Txt_puesto.Text}", true);
                fun_ConfigurarComboBoxPerfiles();
                fun_LimpiarCampos();
                fun_Configuracioninicial();
            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_idperfil.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            string mensaje;
            bool bExito = controlador.bActualizarPerfil(
                id,
                Txt_puesto.Text,
                Txt_descripcion.Text,
                Rdb_Habilitado.Checked,
                Cbo_tipoperfil.SelectedIndex,
                out mensaje
            );

            if (bExito)
            {
                MessageBox.Show("Perfil modificado correctamente");
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Modificó el perfil: {Txt_puesto.Text}", true);
                fun_ConfigurarComboBoxPerfiles();
                fun_LimpiarCampos();
                fun_Configuracioninicial();
            }
            else
            {
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            fun_Configuracioninicial();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fun_LimpiarCampos()
        {
            Txt_idperfil.Clear();
            Txt_puesto.Clear();
            Txt_descripcion.Clear();
            Cbo_tipoperfil.SelectedIndex = -1;
            Rdb_Habilitado.Checked = false;
            Rdb_inhabilitado.Checked = false;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            string busqueda = Cbo_perfiles.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre de perfil para buscar");
                return;
            }

            PerfilDTO perfilEncontrado = null;

            // Buscar por ID si es numérico
            if (int.TryParse(busqueda.Split('-')[0].Trim(), out int id))
            {
                perfilEncontrado = controlador.BuscarPerfilPorId(id);
            }
            // Si no encontró por ID, buscar por nombre
            if (perfilEncontrado == null)
            {
                var listaPerfiles = controlador.listObtenerTodosLosPerfiles();
                perfilEncontrado = listaPerfiles.FirstOrDefault(p =>
                                p.Puesto != null && p.Puesto.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

        
            if (perfilEncontrado != null)
            {
                fun_MostrarPerfil(perfilEncontrado);
                Btn_nuevo.Enabled = _canIngresar; // solo si puede crear nuevos
                Btn_guardar.Enabled = false; // guardar solo en modo nuevo
                Btn_modificar.Enabled = _canModificar;
                Btn_Eliminar.Enabled = _canEliminar;
                Btn_cancelar.Enabled = true;
                Btn_reporte.Enabled = _canImprimir;
                Txt_idperfil.Enabled = false;
                Txt_puesto.Enabled = _canModificar;
                Txt_descripcion.Enabled = _canModificar;
                Cbo_tipoperfil.Enabled = _canModificar;
                Rdb_Habilitado.Enabled = _canModificar;
                Rdb_inhabilitado.Enabled = _canModificar;

            }
            else
            {
                MessageBox.Show("Perfil no encontrado");
                fun_LimpiarCampos();
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_idperfil.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para eliminar.");
                return;
            }

            string sMensajeError;
            bool bExito = controlador.bBorrarPerfil(id, out sMensajeError);

            if (bExito)
            {
                MessageBox.Show("Perfil eliminado");
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Eliminó el perfil: {Txt_puesto.Text}", true);
            }
            else
            {
                MessageBox.Show(sMensajeError, "Error al eliminar perfil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            fun_ConfigurarComboBoxPerfiles();
            fun_LimpiarCampos();
            fun_Configuracioninicial();
        }

        //Ruben Lopez 
        // Panel superior
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

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmreporte_perfiles frm = new frmreporte_perfiles();
            frm.Show();
        }

        private void Pnl_Superior_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}