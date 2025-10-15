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
//Ernesto David Samayoa Jocol - 0901-22-3415 --  Formulario Estandarizado
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Empleados : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitácora Aron Esquit 0901-22-13036
        private Cls_EmpleadoControlador controlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaEmpleados = new List<Cls_Empleado>();

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
            fun_ConfiguracionInicial();


            // --- Eventos de validación ---
            Txt_nombre_empleado.KeyPress += Txt_NombreOApellido_KeyPress;
            Txt_apellido_empleado.KeyPress += Txt_NombreOApellido_KeyPress;
            Txt_dpi_empleados.KeyPress += Txt_Dpi_KeyPress;
            Txt_nit_empleados.KeyPress += Txt_Nit_KeyPress;
            Txt_telefono_empleado.KeyPress += Txt_Telefono_KeyPress;
            Txt_correo_empleado.KeyPress += Txt_Correo_KeyPress;
        }

        // ------------------ VALIDACIONES DE ENTRADA ------------------
        // Ernesto David Samayoa Jocol - 0901-22-3415

        // Solo letras y espacios
        private void Txt_NombreOApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ' '))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        // Solo 13 dígitos para DPI
        private void Txt_Dpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limita a 13 dígitos
            if (char.IsDigit(e.KeyChar) && ((TextBox)sender).Text.Length >= 13)
            {
                e.Handled = true;
            }
        }

        // Solo 9 dígitos para NIT
        private void Txt_Nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limita a 9 dígitos
            if (char.IsDigit(e.KeyChar) && ((TextBox)sender).Text.Length >= 9)
            {
                e.Handled = true;
            }
        }

        // Solo 8 dígitos y guiones para teléfono
        private void Txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }

            // Limita a 8 dígitos (sin contar guiones)
            string textoSinGuiones = ((TextBox)sender).Text.Replace("-", "");
            if (char.IsDigit(e.KeyChar) && textoSinGuiones.Length >= 8)
            {
                e.Handled = true;
            }
        }

        // Solo letras minúsculas, números, @ y . para correo
        private void Txt_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLower(e.KeyChar) || char.IsDigit(e.KeyChar) ||
                  e.KeyChar == '@' || e.KeyChar == '.' || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }



        private void fun_ConfiguracionInicial()
        {
            Btn_guardar_empleado.Enabled = false;
            Btn_modificar_empleado.Enabled = false;
            Btn_eliminar_empleado.Enabled = false;
            Btn_nuevo_empleado.Enabled = true;
            Btn_cancelar.Enabled = true;
            Txt_id_empleado.Enabled = false;
        }

        private void fun_CargarEmpleados()
        {
            listaEmpleados = controlador.fun_ObtenerTodosLosEmpleados();
        }

        private void fun_ConfigurarComboBoxEmpleados()
        {
            Cbo_mostrar_empleado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_mostrar_empleado.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaEmpleados.Select(a => a.iPkIdEmpleado.ToString()).ToArray());
            autoComplete.AddRange(listaEmpleados.Select(a => a.sNombresEmpleado).ToArray());
            Cbo_mostrar_empleado.AutoCompleteCustomSource = autoComplete;

            Cbo_mostrar_empleado.DisplayMember = "Display";
            Cbo_mostrar_empleado.ValueMember = "Id";
            Cbo_mostrar_empleado.Items.Clear();
            foreach (var emp in listaEmpleados)
            {
                Cbo_mostrar_empleado.Items.Add(new
                {
                    Display = $"{emp.iPkIdEmpleado} - {emp.sNombresEmpleado} {emp.sApellidosEmpleado}",
                    Id = emp.iPkIdEmpleado
                });
            }
        }

        private void fun_MostrarEmpleado(Cls_Empleado emp)
        {
            Txt_id_empleado.Text = emp.iPkIdEmpleado.ToString();
            Txt_nombre_empleado.Text = emp.sNombresEmpleado;
            Txt_apellido_empleado.Text = emp.sApellidosEmpleado;
            Txt_dpi_empleados.Text = emp.lDpiEmpleado.ToString();
            Txt_nit_empleados.Text = emp.lNitEmpleado.ToString();
            Txt_correo_empleado.Text = emp.sCorreoEmpleado;
            Txt_telefono_empleado.Text = emp.sTelefonoEmpleado;
            Txt_fechaNac_empleado.Text = emp.dFechaNacimientoEmpleado.ToString("dd/MM/yyyy");
            Txt_fechaContra_empleado.Text = emp.dFechaContratacionEmpleado.ToString("dd/MM/yyyy");
            Rdb_masculino_empleado.Checked = emp.bGeneroEmpleado;
            Rdb_femenino_empleado.Checked = !emp.bGeneroEmpleado;
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
            Cls_Empleado empEncontrado = null;
            if (int.TryParse(sBusqueda.Split('-')[0].Trim(), out int id))
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a => a.iPkIdEmpleado == id);
            }
            if (empEncontrado == null)
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a =>
                    a.sNombresEmpleado.Equals(sBusqueda, StringComparison.OrdinalIgnoreCase));
            }
            if (empEncontrado != null)
            {
                fun_MostrarEmpleado(empEncontrado);
                Btn_modificar_empleado.Enabled = true;
                Btn_eliminar_empleado.Enabled = true;
                Btn_guardar_empleado.Enabled = false;
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
            Btn_guardar_empleado.Enabled = true;
            Btn_modificar_empleado.Enabled = false;
            Btn_eliminar_empleado.Enabled = false;
            Txt_id_empleado.Enabled = true;
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
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Modificó empleado/a: {Txt_nombre_empleado.Text}", true);
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
                        Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario,
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
            //Validación de campos vacíos
            if (!fun_ValidarCampos())
                return;

            try
            {
                // Validaciones de tipo
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
                //Correción de formato de fecha Nacimiento Ernesto David Samayoa Jocol  0901-22-3415
                if (!DateTime.TryParseExact(Txt_fechaNac_empleado.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fechaNac))
                {
                    MessageBox.Show("La fecha de nacimiento debe tener el formato dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Correción de formato de fecha Contratación Ernesto David Samayoa Jocol  0901-22-3415
                if (!DateTime.TryParseExact(Txt_fechaContra_empleado.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime fechaContra))
                {
                    MessageBox.Show("La fecha de contratación debe tener el formato dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Crear empleado
                var vEmp = new Cls_Empleado
                {
                    iPkIdEmpleado = idEmpleado,
                    sNombresEmpleado = Txt_nombre_empleado.Text.Trim(),
                    sApellidosEmpleado = Txt_apellido_empleado.Text.Trim(),
                    lDpiEmpleado = dpi,
                    lNitEmpleado = nit,
                    sCorreoEmpleado = Txt_correo_empleado.Text.Trim(),
                    sTelefonoEmpleado = Txt_telefono_empleado.Text.Trim(),
                    bGeneroEmpleado = Rdb_masculino_empleado.Checked,
                    dFechaNacimientoEmpleado = fechaNac,
                    dFechaContratacionEmpleado = fechaContra
                };

                // Insertar
                controlador.fun_InsertarEmpleado(
                    vEmp.iPkIdEmpleado,
                    vEmp.sNombresEmpleado,
                    vEmp.sApellidosEmpleado,
                    vEmp.lDpiEmpleado,
                    vEmp.lNitEmpleado,
                    vEmp.sCorreoEmpleado,
                    vEmp.sTelefonoEmpleado,
                    vEmp.bGeneroEmpleado,
                    vEmp.dFechaNacimientoEmpleado,
                    vEmp.dFechaContratacionEmpleado
                );

                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Registrar en bitacora   Aron Esquit 0901-22-13036
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Guardó empleado/a: {Txt_nombre_empleado.Text}", true);

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

        /*private bool fun_ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(Txt_id_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_nombre_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_apellido_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_dpi_empleados.Text) ||
                string.IsNullOrWhiteSpace(Txt_nit_empleados.Text) ||
                string.IsNullOrWhiteSpace(Txt_correo_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_telefono_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_fechaNac_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_fechaContra_empleado.Text) ||
                (!Rdb_masculino_empleado.Checked && !Rdb_femenino_empleado.Checked))
            {
                MessageBox.Show("Debe llenar todos los campos antes de guardar.",
                    "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }*/

        private bool fun_ValidarCampos()
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(Txt_id_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_nombre_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_apellido_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_dpi_empleados.Text) ||
                string.IsNullOrWhiteSpace(Txt_nit_empleados.Text) ||
                string.IsNullOrWhiteSpace(Txt_correo_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_telefono_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_fechaNac_empleado.Text) ||
                string.IsNullOrWhiteSpace(Txt_fechaContra_empleado.Text) ||
                (!Rdb_masculino_empleado.Checked && !Rdb_femenino_empleado.Checked))
            {
                MessageBox.Show("Debe llenar todos los campos antes de guardar.",
                    "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validaciones específicas
            if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_nombre_empleado.Text, @"^[a-zA-Z\s]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(Txt_apellido_empleado.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre y apellido solo pueden contener letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_dpi_empleados.Text, @"^\d{13}$"))
            {
                MessageBox.Show("El DPI debe contener exactamente 13 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_nit_empleados.Text, @"^\d{9}$"))
            {
                MessageBox.Show("El NIT debe contener exactamente 9 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_telefono_empleado.Text, @"^[0-9\-]{8,10}$"))
            {
                MessageBox.Show("El teléfono debe contener 8 dígitos y puede incluir guiones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Txt_correo_empleado.Text, @"^[a-z0-9@.]+$"))
            {
                MessageBox.Show("El correo solo puede contener letras minúsculas, números, '@' y '.'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


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
            Frm_Salario_Empleados formSalarioEmpleado = new Frm_Salario_Empleados();
            formSalarioEmpleado.Show();
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