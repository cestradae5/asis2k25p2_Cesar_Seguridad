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
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
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
            autoComplete.AddRange(listaAplicaciones.Select(a => a.iPkIdAplicacion.ToString()).ToArray());
            autoComplete.AddRange(listaAplicaciones.Select(a => a.sNombreAplicacion).ToArray());
            Cbo_buscar.AutoCompleteCustomSource = autoComplete;

            // Configurar display
            Cbo_buscar.DisplayMember = "Display";
            Cbo_buscar.ValueMember = "Id";

            // Crear items combinados id-Nombre
            foreach (var app in listaAplicaciones)
            {
                Cbo_buscar.Items.Add(new
                {
                    Display = $"{app.iPkIdAplicacion} - {app.sNombreAplicacion}",
                    Id = app.iPkIdAplicacion
                });
            }
        }

        //0901-21-1115 Marcos Andres Velasquez Alcánatara -- permisos script
        //0901-22-9663 Brandon Alexander Hernandez Salguero --  asignacion Modulos y aplicaciones




       







        private void MostrarAplicacion(Cls_Aplicacion app)
        {
            Txt_id_aplicacion.Text = app.iPkIdAplicacion.ToString();
            Txt_Nombre_aplicacion.Text = app.sNombreAplicacion;
            Txt_descripcion.Text = app.sDescripcionAplicacion;
            Rdb_estado_activo.Checked = app.bEstadoAplicacion;
            Rdb_inactivo.Checked = !app.bEstadoAplicacion;
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
                int? idModulo = asignacionCtrl.ObtenerModuloPorAplicacion(appEncontrada.iPkIdAplicacion);

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

            // 1. Verificar si la aplicación tiene relaciones (llaves foráneas)
            if (controlador.TieneRelaciones(id))
            {
                // 1.1 Mostrar el mensaje de error solicitado
                MessageBox.Show(
                    "**Imposible Eliminar.** Esta aplicación se encuentra relacionada con uno o más módulos o permisos, lo que afectaría la integridad referencial del sistema. Por favor, inspeccione primero las relaciones (asignaciones) de la aplicación.",
                    "Error de Integridad de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                // Registrar el intento fallido en Bitácora
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 1, "Fallido Eliminacion: App con relaciones", false);

                return; // Detiene la eliminación
            }

            // 2. Preguntar confirmación antes de eliminar (Buena práctica)
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la aplicación con ID: {id}? Esta acción es permanente.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                // 3. Proceder a eliminar
                bool exito = controlador.BorrarAplicacion(id);

                if (exito)
                {
                    MessageBox.Show(" Aplicación eliminada exitosamente.");
                    // Registrar en Bitácora
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 1, "Eliminar aplicación", true);
                }
                else
                {
                    MessageBox.Show("❌ Error al eliminar la aplicación. Puede que no exista o haya un problema de base de datos.");
                    // Registrar en Bitácora de error
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 1, "Error en el intento de eliminar aplicación", false);
                }

                LimpiarCampos();
                RecargarTodo();
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            //  Validar que el ID sea válido
            if (!int.TryParse(Txt_id_aplicacion.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            string nombre = Txt_Nombre_aplicacion.Text.Trim();
            string descripcion = Txt_descripcion.Text.Trim();
            bool estado = Rdb_estado_activo.Checked;

            //  Validar campos vacíos
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar el nombre de la aplicación.");
                Txt_Nombre_aplicacion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe ingresar la descripción de la aplicación.");
                Txt_descripcion.Focus();
                return;
            }

            //  Validar longitud máxima de texto (ajusta si tu BD usa otros límites)
            if (nombre.Length > 50)
            {
                MessageBox.Show("Cadena muy larga o se pasó del número de caracteres permitidos en el campo 'Nombre de aplicación' (máx. 50).");
                Txt_Nombre_aplicacion.Focus();
                return;
            }

            if (descripcion.Length > 255)
            {
                MessageBox.Show("Cadena muy larga o se pasó del número de caracteres permitidos en el campo 'Descripción' (máx. 255).");
                Txt_descripcion.Focus();
                return;
            }

            //  Validar que se haya seleccionado un módulo (opcional, según tu lógica)
            if (Cbo_id_modulo.SelectedItem == null || string.IsNullOrWhiteSpace(Cbo_id_modulo.Text))
            {
                MessageBox.Show("Debe seleccionar un módulo en el ComboBox de módulos.");
                return;
            }

            //  Confirmar que el ID exista antes de modificar
            var appExistente = controlador.BuscarAplicacionPorId(id);
            if (appExistente == null)
            {
                MessageBox.Show("No existe una aplicación con ese ID para modificar.");
                return;
            }

            //  Ejecutar la modificación
            bool exito = controlador.ActualizarAplicacion(id, nombre, descripcion, estado, null);

            if (exito)
            {
                MessageBox.Show("Aplicación modificada correctamente.");

                // Registrar en bitácora
                ctrlBitacora.RegistrarAccion(
                    Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario,
                    1,
                    "Modificar aplicación",
                    true
                );

                RecargarTodo();
            }
            else
            {
                MessageBox.Show("Error al modificar la aplicación. Verifique los datos ingresados.");
            }
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
            // Validar que el ID sea numérico
            if (!int.TryParse(Txt_id_aplicacion.Text, out int idAplicacion))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            string nombre = Txt_Nombre_aplicacion.Text.Trim();
            string descripcion = Txt_descripcion.Text.Trim();
            bool estado = Rdb_estado_activo.Checked;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar el nombre de la aplicación.");
                Txt_Nombre_aplicacion.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Debe ingresar la descripción de la aplicación.");
                Txt_descripcion.Focus();
                return;
            }

            //  Validar longitud máxima de los textos
            // Puedes ajustar los valores según tu base de datos
            if (nombre.Length > 50)
            {
                MessageBox.Show("Cadena muy larga o se pasó del número de caracteres permitidos en el campo 'Nombre de aplicación' (máx. 50).");
                Txt_Nombre_aplicacion.Focus();
                return;
            }

            if (descripcion.Length > 255)
            {
                MessageBox.Show("Cadena muy larga o se pasó del número de caracteres permitidos en el campo 'Descripción' (máx. 255).");
                Txt_descripcion.Focus();
                return;
            }

            //  Validar que se haya seleccionado un módulo
            if (Cbo_id_modulo.SelectedItem == null || string.IsNullOrWhiteSpace(Cbo_id_modulo.Text))
            {
                MessageBox.Show("Debe seleccionar un módulo en el ComboBox de módulos.");
                return;
            }

            // Validar si el ID ya existe
            if (controlador.BuscarAplicacionPorId(idAplicacion) != null)
            {
                MessageBox.Show("El ID ya existe, por favor ingrese otro.");
                return;
            }

            //  Guardar aplicación
            int resultadoApp = controlador.InsertarAplicacion(idAplicacion, nombre, descripcion, estado, null);

            if (resultadoApp <= 0)
            {
                MessageBox.Show("Error al guardar la aplicación. Verifique que el ID no exista.");
                return;
            }

            //  Obtener ID del módulo seleccionado
            int idModulo = Convert.ToInt32(((dynamic)Cbo_id_modulo.SelectedItem).Id);

            //  Guardar asignación
            Cls_AsignacionModuloAplicacionControlador asignacionCtrl = new Cls_AsignacionModuloAplicacionControlador();
            bool asignacionGuardada = asignacionCtrl.GuardarAsignacion(idModulo, idAplicacion);

            if (!asignacionGuardada)
            {
                MessageBox.Show("La asignación ya existe o hubo un error al guardar.");
                return;
            }

            MessageBox.Show("Aplicación y asignación guardadas correctamente.");
            LimpiarCampos();

            //  Registrar en bitácora
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 1, "Guardar aplicación", true);
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
            this.Close();
        }

        private void CargarComboModulos()
        {
            Cls_ModulosControlador controladorModulos = new Cls_ModulosControlador();

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
            //if (e.Button == MouseButtons.Left)
            //{
            //    ReleaseCapture(); // Libera el mouse
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Simula arrastre
            //}
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmreporte_aplicacion frm = new frmreporte_aplicacion();
            frm.Show();
            this.Close();
        }


       


    }
}
