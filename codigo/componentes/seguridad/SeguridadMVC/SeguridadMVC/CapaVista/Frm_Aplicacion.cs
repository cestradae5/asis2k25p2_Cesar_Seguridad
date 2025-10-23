//Cesar Armando Estrada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class FrmAplicacion : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); //Bitacora Aron Esquit  0901-22-13036
        private Cls_AplicacionControlador controlador = new Cls_AplicacionControlador();
        private List<dynamic> listaAplicaciones = new List<dynamic>();
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;

        public FrmAplicacion()
        {
            InitializeComponent();
            fun_AplicarPermisos();
            CargarDatosIniciales();
        }
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario_Controlador();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Aplicacion");
            if (idAplicacion <= 0) idAplicacion = 305;
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

            if (Btn_buscar != null) Btn_buscar.Enabled = _canConsultar;
            if (Cbo_buscar.Enabled != null) Cbo_buscar.Enabled = _canConsultar;
            if (Btn_reporte != null) Btn_reporte.Enabled = _canImprimir;

            bool puedeEditar = (_canIngresar || _canModificar);
            Txt_id_aplicacion.Enabled = puedeEditar;
            Cbo_id_modulo.Enabled = puedeEditar;
            Txt_Nombre_aplicacion.Enabled = puedeEditar;
            Txt_descripcion.Enabled = puedeEditar;


        }

        private void CargarDatosIniciales()
        {
            fun_CargarAplicaciones();
            fun_ConfigurarComboBox();
            fun_CargarComboModulos();
            fun_CargarComboReportes();
        }

        private void RecargarTodo()
        {
            fun_LimpiarCampos();
            Cbo_buscar.Items.Clear();
            Cbo_id_modulo.Items.Clear();
            CargarDatosIniciales();
        }

        private void fun_CargarComboReportes()
        {
            DataTable dtReportes = controlador.ObtenerReportes();

            Cbo_id_reporte.Items.Clear();

            // Agregar opción "Sin reporte" con valor 0
            Cbo_id_reporte.Items.Add(new { Display = "Sin reporte", Id = 0 });

            foreach (DataRow row in dtReportes.Rows)
            {
                int idReporte = Convert.ToInt32(row["Pk_Id_Reporte"]);
                Cbo_id_reporte.Items.Add(new
                {
                    Display = idReporte.ToString(),
                    Id = idReporte
                });
            }

            // Configurar DISPLAY y VALUE members DESPUÉS de agregar items
            Cbo_id_reporte.DisplayMember = "Display";
            Cbo_id_reporte.ValueMember = "Id";

            // Seleccionar "Sin reporte" por defecto
            if (Cbo_id_reporte.Items.Count > 0)
                Cbo_id_reporte.SelectedIndex = 0;
        }

        private void fun_CargarAplicaciones()
        {
            DataTable dtAplicaciones = controlador.ObtenerAplicacionesDataTable();
            listaAplicaciones.Clear();

            foreach (DataRow row in dtAplicaciones.Rows)
            {
                listaAplicaciones.Add(new
                {
                    iPkIdAplicacion = row["iPkIdAplicacion"],
                    sNombreAplicacion = row["sNombreAplicacion"].ToString(),
                    sDescripcionAplicacion = row["sDescripcionAplicacion"].ToString(),
                    bEstadoAplicacion = Convert.ToBoolean(row["bEstadoAplicacion"])
                });
            }
        }

        private void fun_ConfigurarComboBox()
        {
            // Configurar AutoComplete
            Cbo_buscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_buscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Crear fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            // CORRECCIÓN: Convertir explicitamente a array de strings
            foreach (var app in listaAplicaciones)
            {
                autoComplete.Add(app.iPkIdAplicacion.ToString());
                autoComplete.Add(app.sNombreAplicacion);
            }

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

        private void MostrarAplicacion(DataRow app)
        {
            Txt_id_aplicacion.Text = app["iPkIdAplicacion"].ToString();
            Txt_Nombre_aplicacion.Text = app["sNombreAplicacion"].ToString();
            Txt_descripcion.Text = app["sDescripcionAplicacion"].ToString();
            bool estado = Convert.ToBoolean(app["bEstadoAplicacion"]);
            Rdb_estado_activo.Checked = estado;
            Rdb_inactivo.Checked = !estado;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            string sBusqueda = Cbo_buscar.Text.Trim();
            var resultado = controlador.BuscarAplicacion(sBusqueda);

            if (resultado.success)
            {
                MostrarAplicacion(resultado.aplicacion);

                // Obtener módulo asignado
                int idAplicacion = Convert.ToInt32(resultado.aplicacion["iPkIdAplicacion"]);
                Cls_Asignacion_Modulo_Aplicacion_Controlador asignacionCtrl = new Cls_Asignacion_Modulo_Aplicacion_Controlador();
                int? idModulo = asignacionCtrl.ObtenerModuloPorAplicacion(idAplicacion);

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

                // Obtener y mostrar el reporte asignado
                if (!resultado.aplicacion.IsNull("iFkIdReporte"))
                {
                    int idReporte = Convert.ToInt32(resultado.aplicacion["iFkIdReporte"]);
                    foreach (var item in Cbo_id_reporte.Items)
                    {
                        int itemId = (int)item.GetType().GetProperty("Id").GetValue(item);
                        if (itemId == idReporte)
                        {
                            Cbo_id_reporte.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    Cbo_id_reporte.SelectedIndex = 0;
                }

                // NUEVO: Deshabilitar el ComboBox de módulos en modo modificación
                Txt_id_aplicacion.Enabled = false;
                Cbo_id_modulo.Enabled = false; // ← MÓDULO NO EDITABLE EN MODIFICACIÓN
                Btn_guardar.Enabled = false;
                Btn_modificar.Enabled = _canModificar;
            }
            else
            {
                MessageBox.Show(resultado.message);
                fun_LimpiarCampos();
            }
        }


        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            // Validar que el ID sea válido
            if (!int.TryParse(Txt_id_aplicacion.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            string nombre = Txt_Nombre_aplicacion.Text.Trim();
            string descripcion = Txt_descripcion.Text.Trim();
            bool estado = Rdb_estado_activo.Checked;

            // Obtener ID del reporte seleccionado
            int? idReporte = null;
            if (Cbo_id_reporte.SelectedItem != null)
            {
                var selectedReport = Cbo_id_reporte.SelectedItem;
                int reportId = (int)selectedReport.GetType().GetProperty("Id").GetValue(selectedReport);
                if (reportId != 0)
                    idReporte = reportId;
            }

            // Llamar al controlador para modificar (la validación está en el controlador)
            var resultado = controlador.ActualizarAplicacion(id, nombre, descripcion, estado, idReporte);

            if (resultado.success)
            {
                // ELIMINADO: No se permite cambiar el módulo en modificación
                // El módulo permanece igual al original

                MessageBox.Show("Aplicación modificada correctamente.");

                // MENSAJE ACORTADO PARA BITÁCORA
                string mensajeBitacora = $"Modificó aplicación: {Txt_Nombre_aplicacion.Text}";
                if (mensajeBitacora.Length > 80) // Limitar a 80 caracteres
                {
                    mensajeBitacora = mensajeBitacora.Substring(0, 80) + "...";
                }

                ctrlBitacora.RegistrarAccion(
                    Cls_Usuario_Conectado.iIdUsuario,
                    1,
                    mensajeBitacora, // Usar mensaje acortado
                    true
                );
                RecargarTodo();
            }
            else
            {
                MessageBox.Show("Error al modificar la aplicación: " + resultado.message);
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            Btn_modificar.Enabled = false;
            Cbo_id_modulo.Enabled = _canIngresar;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Obtener datos de la vista
            if (!int.TryParse(Txt_id_aplicacion.Text, out int iIdAplicacion))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            string sNombre = Txt_Nombre_aplicacion.Text.Trim();
            string sDescripcion = Txt_descripcion.Text.Trim();
            bool bEstado = Rdb_estado_activo.Checked;

            // Obtener módulo
            int? iIdModulo = null;
            if (Cbo_id_modulo.SelectedItem != null)
            {
                iIdModulo = Convert.ToInt32(((dynamic)Cbo_id_modulo.SelectedItem).Id);
            }

            // Obtener reporte
            int? idReporte = null;
            if (Cbo_id_reporte.SelectedItem != null)
            {
                var selectedReport = Cbo_id_reporte.SelectedItem;
                int reportId = (int)selectedReport.GetType().GetProperty("Id").GetValue(selectedReport);
                if (reportId != 0)
                {
                    idReporte = reportId;
                }
            }

            // Llamar al controlador para guardar (la validación está en el controlador)
            var resultadoApp = controlador.InsertarAplicacion(iIdAplicacion, sNombre, sDescripcion, bEstado, idReporte, iIdModulo);

            if (resultadoApp.resultado <= 0)
            {
                MessageBox.Show("Error al guardar la aplicación: " + resultadoApp.mensaje);
                return;
            }

            // Si el controlador no maneja la asignación, llamar al controlador de asignación
            if (iIdModulo.HasValue)
            {
                Cls_Asignacion_Modulo_Aplicacion_Controlador asignacionCtrl = new Cls_Asignacion_Modulo_Aplicacion_Controlador();
                var resultadoAsignacion = asignacionCtrl.GuardarAsignacion(iIdModulo.Value, iIdAplicacion);

                if (!resultadoAsignacion.success)
                {
                    MessageBox.Show("Aplicación guardada pero error en asignación: " + resultadoAsignacion.message);
                    return;
                }
            }

            MessageBox.Show("Aplicación y asignación guardadas correctamente.");

            // ACORTAR MENSAJE PARA BITÁCORA
            string mensajeBitacora = $"Guardó aplicación: {Txt_Nombre_aplicacion.Text}";
            if (mensajeBitacora.Length > 80) // Limitar a 80 caracteres
            {
                mensajeBitacora = mensajeBitacora.Substring(0, 80) + "...";
            }

            ctrlBitacora.RegistrarAccion(
                Cls_Usuario_Conectado.iIdUsuario,
                1,
                mensajeBitacora, // Usar mensaje acortado
                true
            );
            RecargarTodo();
        }

        private void fun_LimpiarCampos()
        {
            Txt_id_aplicacion.Clear();
            Txt_Nombre_aplicacion.Clear();
            Txt_descripcion.Clear();
            Rdb_estado_activo.Checked = true;
            Rdb_inactivo.Checked = false;
            Cbo_id_modulo.SelectedItem = null;
            Cbo_id_reporte.SelectedIndex = 0;

            //Restaurar estado de controles según permisos
            bool puedeEditar = (_canIngresar || _canModificar);
            Txt_id_aplicacion.Enabled = _canIngresar; // Solo habilitado para nuevos registros
            Cbo_id_modulo.Enabled = _canIngresar; // ← HABILITADO SOLO EN MODO NUEVO
            Btn_guardar.Enabled = _canIngresar;
            Btn_modificar.Enabled = _canModificar;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Consultar_Asignacion_Click(object sender, EventArgs e)
        {
            //Frm_Consultar_Asignacion_Modulo_Aplicacion consulta = new Frm_Consultar_Asignacion_Modulo_Aplicacion();
            //consulta.ShowDialog();
            //this.Close();
        }

        private void fun_CargarComboModulos()
        {
            Cls_Modulos_Controlador controladorModulos = new Cls_Modulos_Controlador();
            DataTable dtModulos = controladorModulos.ObtenerModulos();

            Cbo_id_modulo.DisplayMember = "Display";
            Cbo_id_modulo.ValueMember = "Id";
            Cbo_id_modulo.Items.Clear();

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
            //    ReleaseCapture();
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
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