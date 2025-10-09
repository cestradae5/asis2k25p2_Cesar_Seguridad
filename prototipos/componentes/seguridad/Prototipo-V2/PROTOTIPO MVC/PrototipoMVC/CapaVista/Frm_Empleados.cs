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
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitácora
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
            Txt_fechaNac_empleado.Text = emp.dFechaNacimientoEmpleado.ToString("yyyy-MM-dd");
            Txt_fechaContra_empleado.Text = emp.dFechaContratacionEmpleado.ToString("yyyy-MM-dd");
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
            string busqueda = Cbo_mostrar_empleado.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }
            Cls_Empleado empEncontrado = null;
            if (int.TryParse(busqueda.Split('-')[0].Trim(), out int id))
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a => a.iPkIdEmpleado == id);
            }
            if (empEncontrado == null)
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a =>
                    a.sNombresEmpleado.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
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
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 0, "Modificar empleado", true);
            fun_CargarEmpleados();
            fun_ConfigurarComboBoxEmpleados();
            fun_LimpiarCampos();
            fun_ConfiguracionInicial();
        }

        private void Btn_eliminar_empleado_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_id_empleado.Text, out int id))
            {
                MessageBox.Show("ID no válido");
                return;
            }
            bool exito = controlador.fun_BorrarEmpleado(id);
            MessageBox.Show(exito ? "Empleado eliminado" : "Error al eliminar");
            ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 0, "Eliminar empleado", true);
            fun_CargarEmpleados();
            fun_ConfigurarComboBoxEmpleados();
            fun_LimpiarCampos();
            fun_ConfiguracionInicial();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            fun_ConfiguracionInicial();
        }

        private void Btn_guardar_empleado_Click(object sender, EventArgs e)
        {
            //Validación de campos vacíos
            if (!ValidarCampos())
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

                if (!DateTime.TryParse(Txt_fechaNac_empleado.Text, out DateTime fechaNac))
                {
                    MessageBox.Show("La fecha de nacimiento no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(Txt_fechaContra_empleado.Text, out DateTime fechaContra))
                {
                    MessageBox.Show("La fecha de contratación no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear empleado
                var emp = new Cls_Empleado
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
                    emp.iPkIdEmpleado,
                    emp.sNombresEmpleado,
                    emp.sApellidosEmpleado,
                    emp.lDpiEmpleado,
                    emp.lNitEmpleado,
                    emp.sCorreoEmpleado,
                    emp.sTelefonoEmpleado,
                    emp.bGeneroEmpleado,
                    emp.dFechaNacimientoEmpleado,
                    emp.dFechaContratacionEmpleado
                );

                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 0, "Guardar empleado", true);

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

        private bool ValidarCampos()
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