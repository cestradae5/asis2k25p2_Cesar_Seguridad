using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;


namespace CapaVista
{
    public partial class frmEmpleados : Form
    {
        private Cls_EmpleadoControlador controlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaEmpleados = new List<Cls_Empleado>();

        public frmEmpleados()
        {
            InitializeComponent();
            CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_ConfiguracionInicial();
        }

        private void func_ConfiguracionInicial()
        {
            Btn_guardar_empleado.Enabled = false;
            Btn_modificar_empleado.Enabled = false;
            Btn_eliminar_empleado.Enabled = false;
            Btn_nuevo_empleado.Enabled = true;
            Btn_cancelar.Enabled = true;
            Txt_id_empleado.Enabled = false;
        }


        private void func_CargarEmpleados()
        {
            listaEmpleados = controlador.ObtenerTodosLosEmpleados();
        }

        private void CargarEmpleados()
        {
            listaEmpleados = controlador.ObtenerTodosLosEmpleados();
        }

        private void func_ConfigurarComboBoxEmpleados()
        {
            // Configurar AutoComplete
            Cbo_mostrar_empleado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_mostrar_empleado.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Crear fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaEmpleados.Select(a => a.PkIdEmpleado.ToString()).ToArray());
            autoComplete.AddRange(listaEmpleados.Select(a => a.NombresEmpleado).ToArray());
            Cbo_mostrar_empleado.AutoCompleteCustomSource = autoComplete;

            // Configurar display y value
            Cbo_mostrar_empleado.DisplayMember = "Display";
            Cbo_mostrar_empleado.ValueMember = "Id";

            // Crear items combinados (ID + Nombre + Apellido)
            foreach (var emp in listaEmpleados)
            {
                Cbo_mostrar_empleado.Items.Add(new
                {
                    Display = $"{emp.PkIdEmpleado} - {emp.NombresEmpleado} {emp.ApellidosEmpleado}",
                    Id = emp.PkIdEmpleado
                });
            }
        }


        private void MostrarEmpleado(Cls_Empleado emp)
        {
            Txt_id_empleado.Text = emp.PkIdEmpleado.ToString();
            Txt_nombre_empleado.Text = emp.NombresEmpleado;
            Txt_apellido_empleado.Text = emp.ApellidosEmpleado;
            Txt_dpi_empleados.Text = emp.DpiEmpleado.ToString();
            Txt_nit_empleados.Text = emp.NitEmpleado.ToString();
            Txt_correo_empleado.Text = emp.CorreoEmpleado;
            Txt_telefono_empleado.Text = emp.TelefonoEmpleado;
            Txt_fechaNac_empleado.Text = emp.FechaNacimientoEmpleado.ToString("yyyy-MM-dd");
            Txt_fechaContra_empleado.Text = emp.FechaContratacionEmpleado.ToString("yyyy-MM-dd");
            Rdb_masculino_empleado.Checked = emp.GeneroEmpleado;
            Rdb_femenino_empleado.Checked = !emp.GeneroEmpleado;
        }

        private void Txt_id_empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_nombre_empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_dpi_empleados_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_fechaNac_empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_apellido_empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_nit_empleados_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_fechaContra_empleado_TextChanged(object sender, EventArgs e)
        {

        }
        private void Txt_correo_empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_masculino_empleado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_femenino_empleado_CheckedChanged(object sender, EventArgs e)
        {

        }

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
                empEncontrado = listaEmpleados.FirstOrDefault(a => a.PkIdEmpleado == id);
            }

            if (empEncontrado == null)
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a =>
                    a.NombresEmpleado.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (empEncontrado != null)
            {
                MostrarEmpleado(empEncontrado);
                Btn_modificar_empleado.Enabled = true;
                Btn_eliminar_empleado.Enabled = true;
                Btn_guardar_empleado.Enabled = false;
            }
            else
            {
                MessageBox.Show("Empleado no encontrado");
                func_LimpiarCampos();
            }
        }



        private void Btn_nuevo_empleado_Click(object sender, EventArgs e)
        {
            func_LimpiarCampos();
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

            bool exito = controlador.ActualizarEmpleado(
                id,
                Txt_nombre_empleado.Text,
                Txt_apellido_empleado.Text,
                long.Parse(Txt_dpi_empleados.Text),
                long.Parse(Txt_nit_empleados.Text),
                Txt_correo_empleado.Text,
                Txt_telefono_empleado.Text,
                Rdb_masculino_empleado.Checked,   // true = Masculino, false = Femenino
                DateTime.Parse(Txt_fechaNac_empleado.Text),
                DateTime.Parse(Txt_fechaContra_empleado.Text)
            );

            MessageBox.Show(exito ? "Empleado modificado correctamente" : "Error al modificar empleado");
            func_CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_LimpiarCampos();
        }

        private void Btn_eliminar_empleado_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_id_empleado.Text, out int id))
            {
                MessageBox.Show("ID no válido");
                return;
            }

            bool exito = controlador.BorrarEmpleado(id);
            MessageBox.Show(exito ? "Empleado eliminado" : "Error al eliminar");
            func_CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        private void Btn_guardar_empleado_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos numéricos y fechas antes de crear el objeto
                if (!int.TryParse(Txt_id_empleado.Text, out int idEmpleado))
                {
                    MessageBox.Show("ID no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(Txt_dpi_empleados.Text, out long dpi))
                {
                    MessageBox.Show("DPI no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(Txt_nit_empleados.Text, out long nit))
                {
                    MessageBox.Show("NIT no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(Txt_fechaNac_empleado.Text, out DateTime fechaNacimiento))
                {
                    MessageBox.Show("Fecha de nacimiento no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(Txt_fechaContra_empleado.Text, out DateTime fechaContratacion))
                {
                    MessageBox.Show("Fecha de contratación no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear objeto empleado con datos del formulario
                var emp = new Cls_Empleado
                {
                    PkIdEmpleado = idEmpleado,
                    NombresEmpleado = Txt_nombre_empleado.Text,
                    ApellidosEmpleado = Txt_apellido_empleado.Text,
                    DpiEmpleado = dpi,
                    NitEmpleado = nit,
                    CorreoEmpleado = Txt_correo_empleado.Text,
                    TelefonoEmpleado = Txt_telefono_empleado.Text,
                    GeneroEmpleado = Rdb_masculino_empleado.Checked, // true = Masculino
                    FechaNacimientoEmpleado = fechaNacimiento,
                    FechaContratacionEmpleado = fechaContratacion
                };

                // Llamar al controlador para insertar el empleado
                controlador.InsertarEmpleado(
                    emp.PkIdEmpleado,
                    emp.NombresEmpleado,
                    emp.ApellidosEmpleado,
                    emp.DpiEmpleado,
                    emp.NitEmpleado,
                    emp.CorreoEmpleado,
                    emp.TelefonoEmpleado,
                    emp.GeneroEmpleado,
                    emp.FechaNacimientoEmpleado,
                    emp.FechaContratacionEmpleado
                );

                // Mensaje de éxito
                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleados();
                func_ConfigurarComboBoxEmpleados();
                func_LimpiarCampos();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            func_ConfiguracionInicial();

        }

        private void func_LimpiarCampos()
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
            frmSalarioEmpleados formSalarioEmpleado = new frmSalarioEmpleados();
            formSalarioEmpleado.Show();
        }

        private void Btn_salir_empleado_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra solo este formulario
        }
    }
}