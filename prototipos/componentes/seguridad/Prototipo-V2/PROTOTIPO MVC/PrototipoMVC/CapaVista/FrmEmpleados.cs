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
    public partial class FrmEmpleados : Form
    {
        private Cls_EmpleadoControlador controlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaAplicaciones = new List<Cls_Empleado>();
        public FrmEmpleados()
        {
            InitializeComponent();
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

        private void Rdb_masculino_empleado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_femenino_empleado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Btn_buscar_empleado_Click(object sender, EventArgs e)
        {

        }

        private void Cbo_mostrar_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_nuevo_empleado_Click(object sender, EventArgs e)
        {

        }

        private void Btn_modificar_empleado_Click(object sender, EventArgs e)
        {

        }

        private void Btn_eliminar_empleado_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_empleado_Click(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_empleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_id_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_nombre_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_apellido_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_dpi_empleados.Text) ||
                    string.IsNullOrWhiteSpace(Txt_nit_empleados.Text) ||
                    string.IsNullOrWhiteSpace(Txt_correo_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_telefono_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_fechaNac_empleado.Text) ||
                    string.IsNullOrWhiteSpace(Txt_fechaContra_empleado.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = int.Parse(Txt_id_empleado.Text.Trim());
                string nombres = Txt_nombre_empleado.Text.Trim();
                string apellidos = Txt_apellido_empleado.Text.Trim();
                long dpi = long.Parse(Txt_dpi_empleados.Text.Trim());
                long nit = long.Parse(Txt_nit_empleados.Text.Trim());
                string correo = Txt_correo_empleado.Text.Trim();
                string telefono = Txt_telefono_empleado.Text.Trim();

                // true = Masculino, false = Femenino
                bool genero = Rdb_masculino_empleado.Checked;

                DateTime fechaNacimiento = DateTime.Parse(Txt_fechaNac_empleado.Text.Trim());
                DateTime fechaContratacion = DateTime.Parse(Txt_fechaContra_empleado.Text.Trim());

                controlador.InsertarEmpleado(idEmpleado, nombres, apellidos, dpi, nit, correo, telefono, genero, fechaNacimiento, fechaContratacion);

                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
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

        private void Txt_correo_empleado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}