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
//Ernesto David Samayoa Jocol - 0901-22-3415 --  Formulario Estandarizado
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Empleados : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitácora Aron Esquit 0901-22-13036
        private Cls_EmpleadoControlador controlador = new Cls_EmpleadoControlador();
        private List<Dictionary<string, object>> listaEmpleados = new List<Dictionary<string, object>>();
        //Brandon Hernandez 0901-22-9663 15/10/2025
        private bool _canIngresar, _canConsultar, _canModificar, _canEliminar, _canImprimir;

        //Nuevo agregado Ernesto David Samayoa Jocol 0901-22-3415
        //Instancia estática única del formulario
        private static Frm_Empleados instancia = null;

        //Método para obtener o crear la instancia
        public static Frm_Empleados fun_ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new Frm_Empleados();
            }
            else
            {
                instancia.BringToFront(); // Si ya está abierta, la trae al frente
            }
            return instancia;
        }

        public Frm_Empleados()
        {
            InitializeComponent();
            fun_CargarEmpleados();
            fun_ConfigurarComboBoxEmpleados();
            fun_AplicarPermisos();
            fun_ConfiguracionInicial();

            // --- Eventos de validación ---
            Txt_nombre_empleado.KeyPress += Txt_NombreOApellido_KeyPress;
            Txt_apellido_empleado.KeyPress += Txt_NombreOApellido_KeyPress;
            Txt_dpi_empleados.KeyPress += Txt_Dpi_KeyPress;
            Txt_nit_empleados.KeyPress += Txt_Nit_KeyPress;
            Txt_telefono_empleado.KeyPress += Txt_Telefono_KeyPress;
            Txt_correo_empleado.KeyPress += Txt_Correo_KeyPress;
        }

        //Brandon Hernandez 0901-22-9663 15/10/2025
        private void fun_AplicarPermisos()
        {
            var permisos = controlador.ObtenerPermisos();

            _canIngresar = permisos.ingresar;
            _canConsultar = permisos.consultar;
            _canModificar = permisos.modificar;
            _canEliminar = permisos.eliminar;
            _canImprimir = permisos.imprimir;

            if (Btn_nuevo_empleado != null) Btn_nuevo_empleado.Enabled = _canIngresar;
            if (Btn_guardar_empleado != null) Btn_guardar_empleado.Enabled = _canIngresar;
            if (Btn_modificar_empleado != null) Btn_modificar_empleado.Enabled = _canModificar;
            if (Btn_eliminar_empleado != null) Btn_eliminar_empleado.Enabled = _canEliminar;
            if (Btn_buscar_empleado != null) Btn_buscar_empleado.Enabled = _canConsultar;
            if (Btn_reporte != null) Btn_reporte.Enabled = _canImprimir;

            bool puedeEditar = _canIngresar || _canModificar;
            Txt_id_empleado.Enabled = puedeEditar;
            Txt_nombre_empleado.Enabled = puedeEditar;
            Txt_apellido_empleado.Enabled = puedeEditar;
            Txt_dpi_empleados.Enabled = puedeEditar;
            Txt_nit_empleados.Enabled = puedeEditar;
            Txt_correo_empleado.Enabled = puedeEditar;
            Txt_telefono_empleado.Enabled = puedeEditar;
            Txt_fechaNac_empleado.Enabled = puedeEditar;
            Txt_fechaContra_empleado.Enabled = puedeEditar;
            Rdb_masculino_empleado.Enabled = puedeEditar;
            Rdb_femenino_empleado.Enabled = puedeEditar;
        }

        // ------------------ VALIDACIONES DE ENTRADA ------------------
        // Ernesto David Samayoa Jocol - 0901-22-3415

        // Solo letras y espacios
        private void Txt_NombreOApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!controlador.ValidarNombreOApellido(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Solo 13 dígitos para DPI
        private void Txt_Dpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!controlador.ValidarDpiKeyPress(e.KeyChar, ((TextBox)sender).Text))
            {
                e.Handled = true;
            }
        }

        // Solo 9 dígitos para NIT
        private void Txt_Nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!controlador.ValidarNitKeyPress(e.KeyChar, ((TextBox)sender).Text))
            {
                e.Handled = true;
            }
        }

        // Solo 8 dígitos y guiones para teléfono
        private void Txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!controlador.ValidarTelefonoKeyPress(e.KeyChar, ((TextBox)sender).Text))
            {
                e.Handled = true;
            }
        }

        // Solo letras minúsculas, números, @ y . para correo
        private void Txt_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!controlador.ValidarCorreoKeyPress(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void fun_ConfiguracionInicial()
        {
            if (Btn_nuevo_empleado != null) Btn_nuevo_empleado.Enabled = _canIngresar;
            if (Btn_guardar_empleado != null) Btn_guardar_empleado.Enabled = false;
            if (Btn_modificar_empleado != null) Btn_modificar_empleado.Enabled = false;
            if (Btn_eliminar_empleado != null) Btn_eliminar_empleado.Enabled = false;
            if (Btn_buscar_empleado != null) Btn_buscar_empleado.Enabled = _canConsultar;
            if (Btn_reporte != null) Btn_reporte.Enabled = _canImprimir;

            Txt_id_empleado.Enabled = false;
            Txt_nombre_empleado.Enabled = false;
            Txt_apellido_empleado.Enabled = false;
            Txt_dpi_empleados.Enabled = false;
            Txt_nit_empleados.Enabled = false;
            Txt_correo_empleado.Enabled = false;
            Txt_telefono_empleado.Enabled = false;
            Txt_fechaNac_empleado.Enabled = false;
            Txt_fechaContra_empleado.Enabled = false;
            Rdb_masculino_empleado.Enabled = false;
            Rdb_femenino_empleado.Enabled = false;
        }

        private void fun_CargarEmpleados()
        {
            listaEmpleados = controlador.fun_ObtenerEmpleadosComoDiccionarios();
        }

        private void fun_ConfigurarComboBoxEmpleados()
        {
            Cbo_mostrar_empleado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_mostrar_empleado.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaEmpleados.Select(a => a["Id"].ToString()).ToArray());
            autoComplete.AddRange(listaEmpleados.Select(a => a["Nombre"].ToString()).ToArray());
            Cbo_mostrar_empleado.AutoCompleteCustomSource = autoComplete;

            Cbo_mostrar_empleado.DisplayMember = "Display";
            Cbo_mostrar_empleado.ValueMember = "Id";
            Cbo_mostrar_empleado.Items.Clear();
            foreach (var emp in listaEmpleados)
            {
                Cbo_mostrar_empleado.Items.Add(new
                {
                    Display = emp["Display"],
                    Id = emp["Id"]
                });
            }
        }

        private void fun_MostrarEmpleado(Dictionary<string, object> emp)
        {
            Txt_id_empleado.Text = emp["Id"].ToString();
            Txt_nombre_empleado.Text = emp["Nombre"].ToString();
            Txt_apellido_empleado.Text = emp["Apellido"].ToString();
            Txt_dpi_empleados.Text = emp["Dpi"].ToString();
            Txt_nit_empleados.Text = emp["Nit"].ToString();
            Txt_correo_empleado.Text = emp["Correo"].ToString();
            Txt_telefono_empleado.Text = emp["Telefono"].ToString();
            Txt_fechaNac_empleado.Text = ((DateTime)emp["FechaNacimiento"]).ToString("dd/MM/yyyy");
            Txt_fechaContra_empleado.Text = ((DateTime)emp["FechaContratacion"]).ToString("dd/MM/yyyy");
            Rdb_masculino_empleado.Checked = (bool)emp["Genero"];
            Rdb_femenino_empleado.Checked = !(bool)emp["Genero"];
        }

        private void Txt_id_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_nombre_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_dpi_empleados_TextChanged(object sender, EventArgs e) { }
        private void Txt_fechaNac_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_apellido_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_nit_empleados_TextChanged(object sender, EventArgs e) { }
        private void Txt_fechaContra_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_correo_empleado_TextChanged(object sender, EventArgs e) { }
        private void Rdb_masculino_empleado_CheckedChanged(object sender, EventArgs e) { }
        private void Rdb_femenino_empleado_CheckedChanged(object sender, EventArgs e) { }

        private void Btn_buscar_empleado_Click(object sender, EventArgs e)
        {
            string sBusqueda = Cbo_mostrar_empleado.Text.Trim();
            if (string.IsNullOrEmpty(sBusqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }

            var empEncontrado = controlador.fun_BuscarEmpleado(sBusqueda);

            if (empEncontrado != null)
            {
                fun_MostrarEmpleado(empEncontrado);

                if (Btn_modificar_empleado != null) Btn_modificar_empleado.Enabled = _canModificar;
                if (Btn_eliminar_empleado != null) Btn_eliminar_empleado.Enabled = _canEliminar;
                if (Btn_guardar_empleado != null) Btn_guardar_empleado.Enabled = false;
                if (Btn_nuevo_empleado != null) Btn_nuevo_empleado.Enabled = _canIngresar;

                // Solo deja campos editables si tienes modificar
                bool puedeEditar = _canModificar;
                Txt_id_empleado.Enabled = false;
                Txt_nombre_empleado.Enabled = puedeEditar;
                Txt_apellido_empleado.Enabled = puedeEditar;
                Txt_dpi_empleados.Enabled = puedeEditar;
                Txt_nit_empleados.Enabled = puedeEditar;
                Txt_correo_empleado.Enabled = puedeEditar;
                Txt_telefono_empleado.Enabled = puedeEditar;
                Txt_fechaNac_empleado.Enabled = puedeEditar;
                Txt_fechaContra_empleado.Enabled = puedeEditar;
                Rdb_masculino_empleado.Enabled = puedeEditar;
                Rdb_femenino_empleado.Enabled = puedeEditar;
            }
            else
            {
                MessageBox.Show("Empleado no encontrado");
                fun_LimpiarCampos();
                fun_ConfiguracionInicial();
            }
        }

        private void Btn_nuevo_empleado_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            if (Btn_guardar_empleado != null) Btn_guardar_empleado.Enabled = _canIngresar;
            if (Btn_modificar_empleado != null) Btn_modificar_empleado.Enabled = false;
            if (Btn_eliminar_empleado != null) Btn_eliminar_empleado.Enabled = false;

            Txt_id_empleado.Enabled = true;
            Txt_nombre_empleado.Enabled = true;
            Txt_apellido_empleado.Enabled = true;
            Txt_dpi_empleados.Enabled = true;
            Txt_nit_empleados.Enabled = true;
            Txt_correo_empleado.Enabled = true;
            Txt_telefono_empleado.Enabled = true;
            Txt_fechaNac_empleado.Enabled = true;
            Txt_fechaContra_empleado.Enabled = true;
            Rdb_masculino_empleado.Enabled = true;
            Rdb_femenino_empleado.Enabled = true;
        }

        private void Btn_modificar_empleado_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(Txt_id_empleado.Text, out id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }
            bool exito = controlador.fun_ActualizarEmpleado(
                id,
                Txt_nombre_empleado.Text,
                Txt_apellido_empleado.Text,
                long.Parse(Txt_dpi_empleados.Text),
                long.Parse(Txt_nit_empleados.Text),
                Txt_correo_empleado.Text,
                Txt_telefono_empleado.Text,
                Rdb_masculino_empleado.Checked,
                DateTime.Parse(Txt_fechaNac_empleado.Text),
                DateTime.Parse(Txt_fechaContra_empleado.Text)
            );
            MessageBox.Show(exito ? "Empleado modificado correctamente" : "Error al modificar empleado");
            //Registrar en bitacora   Aron Esquit 0901-22-13036
            ctrlBitacora.RegistrarAccion(controlador.ObtenerIdUsuarioConectado(), 1, $"Modificó empleado/a: {Txt_nombre_empleado.Text}", true);
            fun_CargarEmpleados();
            fun_ConfigurarComboBoxEmpleados();
            fun_LimpiarCampos();
            fun_ConfiguracionInicial();
        }

        // Ernesto David Samayoa Jocol - 0901-22-3415 - Fecha: 12/10/2025
        private void Btn_eliminar_empleado_Click(object sender, EventArgs e)
        {
            // 1️ Validar que el campo no esté vacío ni sea inválido
            if (string.IsNullOrWhiteSpace(Txt_id_empleado.Text) || !int.TryParse(Txt_id_empleado.Text, out int id))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2️ Verificar si el empleado tiene usuario asociado (ANTES de eliminar)
            if (controlador.fun_EmpleadoTieneUsuario(id))
            {
                MessageBox.Show("No se puede eliminar este empleado porque tiene un usuario asociado. " +
                                "Elimine primero el usuario.",
                                "Restricción de integridad",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️ Confirmar si realmente desea eliminar
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar este empleado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                // 4️ Ejecutar la eliminación
                bool bexito = controlador.fun_BorrarEmpleado(id);

                if (bexito)
                {
                    MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5️⃣ Registrar en bitácora (Aron Esquit 0901-22-13036)
                    ctrlBitacora.RegistrarAccion(
                        controlador.ObtenerIdUsuarioConectado(),
                        1,
                        $"Eliminó empleado/a: {Txt_nombre_empleado.Text}",
                        true
                    );

                    // 6️⃣ Refrescar datos
                    fun_CargarEmpleados();
                    fun_ConfigurarComboBoxEmpleados();
                    fun_LimpiarCampos();
                    fun_ConfiguracionInicial();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Eliminación cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            fun_ConfiguracionInicial();
        }

        private void Btn_guardar_empleado_Click(object sender, EventArgs e)
        {
            // Validación de campos usando el controlador
            string mensajeError;
            if (!controlador.ValidarCampos(
                Txt_id_empleado.Text,
                Txt_nombre_empleado.Text,
                Txt_apellido_empleado.Text,
                Txt_dpi_empleados.Text,
                Txt_nit_empleados.Text,
                Txt_correo_empleado.Text,
                Txt_telefono_empleado.Text,
                Txt_fechaNac_empleado.Text,
                Txt_fechaContra_empleado.Text,
                Rdb_masculino_empleado.Checked,
                Rdb_femenino_empleado.Checked,
                out mensajeError))
            {
                MessageBox.Show(mensajeError, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!int.TryParse(Txt_id_empleado.Text, out int idEmpleado))
                {
                    MessageBox.Show("El ID debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!long.TryParse(Txt_dpi_empleados.Text, out long dpi))
                {
                    MessageBox.Show("El DPI debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!long.TryParse(Txt_nit_empleados.Text, out long nit))
                {
                    MessageBox.Show("El NIT debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParseExact(Txt_fechaNac_empleado.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fechaNac))
                {
                    MessageBox.Show("La fecha de nacimiento debe tener el formato dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParseExact(Txt_fechaContra_empleado.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fechaContra))
                {
                    MessageBox.Show("La fecha de contratación debe tener el formato dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                controlador.fun_InsertarEmpleado(
                    idEmpleado,
                    Txt_nombre_empleado.Text.Trim(),
                    Txt_apellido_empleado.Text.Trim(),
                    dpi,
                    nit,
                    Txt_correo_empleado.Text.Trim(),
                    Txt_telefono_empleado.Text.Trim(),
                    Rdb_masculino_empleado.Checked,
                    fechaNac,
                    fechaContra
                );

                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlBitacora.RegistrarAccion(controlador.ObtenerIdUsuarioConectado(), 1, $"Guardó empleado/a: {Txt_nombre_empleado.Text}", true);
                fun_CargarEmpleados();
                fun_ConfigurarComboBoxEmpleados();
                fun_LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            fun_ConfiguracionInicial();
        }

        // Eliminado: fun_ValidarCampos ahora está en el controlador


        private void fun_LimpiarCampos()
        {
            Txt_id_empleado.Clear();
            Txt_nombre_empleado.Clear();
            Txt_apellido_empleado.Clear();
            Txt_dpi_empleados.Clear();
            Txt_nit_empleados.Clear();
            Txt_correo_empleado.Clear();
            Txt_telefono_empleado.Clear();
            Txt_fechaNac_empleado.Clear();
            Txt_fechaContra_empleado.Clear();
            Rdb_masculino_empleado.Checked = false;
            Rdb_femenino_empleado.Checked = false;
        }

        private void Btn_salario_empleados_Click(object sender, EventArgs e)
        {
            //Frm_Salario_Empleados formSalarioEmpleado = new Frm_Salario_Empleados();
            //formSalarioEmpleado.Show();
        }

        private void Btn_salir_empleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Empleado frm = new Frm_Reporte_Empleado();
            frm.Show();
        }
    }
}