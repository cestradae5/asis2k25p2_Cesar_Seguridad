//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class FrmAplicacion : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); //Bitacora
        private Cls_AplicacionControlador controlador = new Cls_AplicacionControlador();
        private List<Cls_Aplicacion> listaAplicaciones = new List<Cls_Aplicacion>();

        public FrmAplicacion()
        {
            InitializeComponent();
            CargarAplicaciones();
            ConfigurarComboBox();
            CargarComboModulos();
        }
        private void RecargarTodo()
        {
            LimpiarCampos();
            Cbo_buscar.Items.Clear();
            Cbo_id_modulo.Items.Clear();
            CargarAplicaciones();
            ConfigurarComboBox();
            CargarComboModulos();
        }
        private void CargarAplicaciones()
        {
            listaAplicaciones = controlador.ObtenerTodasLasAplicaciones();
        }

        private void ConfigurarComboBox()
        {
            // Configurar AutoComplete
            Cbo_buscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_buscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Crear fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaAplicaciones.Select(a => a.PkIdAplicacion.ToString()).ToArray());
            autoComplete.AddRange(listaAplicaciones.Select(a => a.NombreAplicacion).ToArray());
            Cbo_buscar.AutoCompleteCustomSource = autoComplete;

            // Configurar display
            Cbo_buscar.DisplayMember = "Display";
            Cbo_buscar.ValueMember = "Id";

            // Crear items combinados id-Nombre
            foreach (var app in listaAplicaciones)
            {
                Cbo_buscar.Items.Add(new
                {
                    Display = $"{app.PkIdAplicacion} - {app.NombreAplicacion}",
                    Id = app.PkIdAplicacion
                });
            }
        }

        private void MostrarAplicacion(Cls_Aplicacion app)
        {
            Txt_id_aplicacion.Text = app.PkIdAplicacion.ToString();
            Txt_Nombre_aplicacion.Text = app.NombreAplicacion;
            Txt_descripcion.Text = app.DescripcionAplicacion;
            Rdb_estado_activo.Checked = app.EstadoAplicacion;
            Rdb_inactivo.Checked = !app.EstadoAplicacion;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            string busqueda = Cbo_buscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }

            Cls_Aplicacion appEncontrada = null;

            // id-nombre
            if (busqueda.Contains("-"))
            {
                string[] partes = busqueda.Split('-');
                if (int.TryParse(partes[0], out int idParte))
                {
                    appEncontrada = controlador.BuscarAplicacionPorId(idParte);
                }
            }

            // solo ID
            if (appEncontrada == null && int.TryParse(busqueda, out int id))
            {
                appEncontrada = controlador.BuscarAplicacionPorId(id);
            }

            // solo Nombre
            if (appEncontrada == null)
            {
                appEncontrada = controlador.BuscarAplicacionPorNombre(busqueda);
            }

            // Mostrar resultado y seleccionar módulo asignado
            if (appEncontrada != null)
            {
                MostrarAplicacion(appEncontrada);

                // Obtener módulo asignado
                Cls_AsignacionModuloAplicacionControlador asignacionCtrl = new Cls_AsignacionModuloAplicacionControlador();
                int? idModulo = asignacionCtrl.ObtenerModuloPorAplicacion(appEncontrada.PkIdAplicacion);

                if (idModulo.HasValue)
                {
                    foreach (var item in Cbo_id_modulo.Items)
                    {
                        if (((dynamic)item).Id == idModulo.Value)
                        {
                            Cbo_id_modulo.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    Cbo_id_modulo.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Aplicación no encontrada");
                LimpiarCampos();
            }
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(Txt_id_aplicacion.Text, out id))
            {
                MessageBox.Show("Ingrese un ID válido para eliminar.");
                return;
            }

            bool exito = controlador.BorrarAplicacion(id);
            MessageBox.Show(exito ? "Aplicación eliminada" : "Error al eliminar");
            LimpiarCampos();

            // Registrar en Bitácora Arón Ricardo Esquit Silva   0901-22-13036
            if (exito)
            {
                //Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Eliminar aplicación", true);

            }
            RecargarTodo();
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_id_aplicacion.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            bool exito = controlador.ActualizarAplicacion(
                id,
                Txt_Nombre_aplicacion.Text,
                Txt_descripcion.Text,
                Rdb_estado_activo.Checked,
                null
            );

            MessageBox.Show(exito ? "Aplicación modificada" : "Error al modificar");

            // Registrar en Bitácora Arón Ricardo Esquit Silva   0901-22-13036
            if (exito)
            {
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Modificar aplicación", true);
            }
            RecargarTodo();
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Txt_id_aplicacion.Clear();
            Txt_Nombre_aplicacion.Clear();
            Txt_descripcion.Clear();
            Rdb_estado_activo.Checked = true;
            Rdb_inactivo.Checked = false;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //Validar ID de aplicación
            if (!int.TryParse(Txt_id_aplicacion.Text, out int idAplicacion))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            string nombre = Txt_Nombre_aplicacion.Text.Trim();
            string descripcion = Txt_descripcion.Text.Trim();
            bool estado = Rdb_estado_activo.Checked;

            if (controlador.BuscarAplicacionPorId(idAplicacion) != null)
            {
                MessageBox.Show("El ID ya existe, por favor ingrese otro.");
                return;
            }


            // Guardar aplicación 
            int resultadoApp = controlador.InsertarAplicacion(idAplicacion, nombre, descripcion, estado, null);

            if (resultadoApp <= 0)
            {
                MessageBox.Show("Error al guardar la aplicación. Verifique que el ID no exista.");
                return;
            }

            // Obtener ID de módulo
            if (Cbo_id_modulo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un módulo para la asignación.");
                return;
            }

            int idModulo = Convert.ToInt32(((dynamic)Cbo_id_modulo.SelectedItem).Id);

            // Guardar asignación 
            Cls_AsignacionModuloAplicacionControlador asignacionCtrl = new Cls_AsignacionModuloAplicacionControlador();
            bool asignacionGuardada = asignacionCtrl.GuardarAsignacion(idModulo, idAplicacion);

            if (!asignacionGuardada)
            {
                MessageBox.Show("La asignación ya existe o hubo un error al guardar.");
                return;
            }

            MessageBox.Show("Aplicación y asignación guardadas correctamente.");
            LimpiarCampos();

            // Registrar en Bitácora Arón Ricardo Esquit Silva   0901-22-13036
            ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Modificar aplicación", true);
            RecargarTodo();
        }

        private void LimpiarCampos()
        {
            Txt_id_aplicacion.Clear();
            Txt_Nombre_aplicacion.Clear();
            Txt_descripcion.Clear();
            Rdb_estado_activo.Checked = true;
            Rdb_inactivo.Checked = false;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Consultar_Asignacion_Click(object sender, EventArgs e)
        {
            Frm_Consultar_Asignacion_Modulo_Aplicacion consulta = new Frm_Consultar_Asignacion_Modulo_Aplicacion();
            consulta.ShowDialog();
        }

        private void CargarComboModulos()
        {
            ControladorModulos controladorModulos = new ControladorModulos();

            DataTable dtModulos = controladorModulos.ObtenerModulos(); // Devuelve pk_id_modulo y nombre_modulo

            Cbo_id_modulo.DisplayMember = "Display";
            Cbo_id_modulo.ValueMember = "Id";

            foreach (DataRow row in dtModulos.Rows)
            {
                Cbo_id_modulo.Items.Add(new
                {
                    Display = $"{row["Pk_id_modulo"]} - {row["Cmp_Nombre_Modulo"]}",
                    Id = row["Pk_Id_Modulo"]
                });
            }
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

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frm_reporte_aplicacion frm = new frm_reporte_aplicacion();
            frm.Show();
        }
    }
}
