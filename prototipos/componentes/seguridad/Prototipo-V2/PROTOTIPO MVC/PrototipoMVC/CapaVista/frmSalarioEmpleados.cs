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
    public partial class frmSalarioEmpleados : Form
    {
        private Cls_SalarioEmpleadosControlador controlador = new Cls_SalarioEmpleadosControlador();
        private List<Cls_SalarioEmpleados> listaSalarioEmpleados = new List<Cls_SalarioEmpleados>();

        public frmSalarioEmpleados()
        {
            InitializeComponent();
            CargarSalarioEmpleados();
            func_ConfigurarComboBoxSalarios();
            func_ConfiguracionInicial();
        }

        private void func_ConfiguracionInicial()
        {
            Btn_guardar_salario.Enabled = false;
            Btn_modificar_salario.Enabled = false;
            Btn_eliminar_salario.Enabled = false;
            Btn_nuevo_salario.Enabled = true;
            Btn_cancelar.Enabled = true;
            Txt_id_salario.Enabled = false;
        }

        private void CargarSalarioEmpleados()
        {
            listaSalarioEmpleados = controlador.ObtenerTodosLosSalarios();
        }

        public class SalarioDisplay
        {
            public int Id { get; set; }
            public string Display { get; set; }

            public override string ToString()
            {
                return Display;
            }
        }

        private void func_ConfigurarComboBoxSalarios()
        {
            Cbo_mostrar_datos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_mostrar_datos.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaSalarioEmpleados
                .Select(s => $"{s.PkIdSalario} {s.NombresEmpleado} {s.ApellidosEmpleado}")
                .ToArray());
            Cbo_mostrar_datos.AutoCompleteCustomSource = autoComplete;

            Cbo_mostrar_datos.Items.Clear();

            foreach (var s in listaSalarioEmpleados)
            {
                Cbo_mostrar_datos.Items.Add(new SalarioDisplay
                {
                    Id = s.PkIdSalario,
                    Display = $"{s.PkIdSalario} {s.NombresEmpleado} {s.ApellidosEmpleado} - {s.MontoSalario:C}"
                });
            }

            //
            Cbo_mostrar_datos.DisplayMember = "Display";
            Cbo_mostrar_datos.ValueMember = "Id";
        }


        private void MostrarSalario(Cls_SalarioEmpleados s)
        {
            Txt_id_salario.Text = s.PkIdSalario.ToString();
            Txt_id_empl_salario.Text = s.FkIdEmpleado.ToString();
            Txt_monto.Text = s.MontoSalario.ToString("F2");
            Txt_fechainicio_salario.Text = s.FechaInicioSalario.ToString("yyyy-MM-dd");
            Txt_fechafin_salario.Text = s.FechaInicioSalario.ToString("yyyy-MM-dd");

            Rdb_activo_salario.Checked = s.EstadoSalario;
            Rdb_inactivo_salario.Checked = !s.EstadoSalario;
        }


        private void Txt_id_salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_id_empl_salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_fechainicio_salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_activo_salario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_inactivo_salario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Txt_monto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_fechafin_salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_buscar_salario_Click(object sender, EventArgs e)
        {
            if (Cbo_mostrar_datos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado primero.");
                return;
            }

            // Obtener el ID del salario seleccionado
            int idSalario = (int)Cbo_mostrar_datos.SelectedValue;

            // Buscar el objeto en tu lista original
            var salario = listaSalarioEmpleados.FirstOrDefault(s => s.PkIdSalario == idSalario);

            if (salario != null)
            {
                // Mostrar datos en los TextBox
                Txt_id_salario.Text = salario.PkIdSalario.ToString();
                Txt_id_empl_salario.Text = salario.FkIdEmpleado.ToString();
                Txt_monto.Text = salario.MontoSalario.ToString("F2");
                Txt_fechainicio_salario.Text = salario.FechaInicioSalario.ToString("yyyy-MM-dd");
                Txt_fechafin_salario.Text = salario.FechaFinSalario.ToString("yyyy-MM-dd");

                Rdb_activo_salario.Checked = salario.EstadoSalario;
                Rdb_inactivo_salario.Checked = !salario.EstadoSalario;
            }
            else
            {
                MessageBox.Show("No se encontró el salario seleccionado.");
            }
        }

        private void Cbo_mostrar_datos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_guardar_salario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Txt_id_salario.Text, out int idSalario))
                {
                    MessageBox.Show("ID de salario no válido");
                    return;
                }

                if (!int.TryParse(Txt_id_empl_salario.Text, out int idEmpleado))
                {
                    MessageBox.Show("ID de empleado no válido");
                    return;
                }

                if (!float.TryParse(Txt_monto.Text, out float monto))
                {
                    MessageBox.Show("Monto no válido");
                    return;
                }

                if (!DateTime.TryParse(Txt_fechainicio_salario.Text, out DateTime fechaInicio))
                {
                    MessageBox.Show("Fecha inicio no válida");
                    return;
                }

                if (!DateTime.TryParse(Txt_fechafin_salario.Text, out DateTime fechaFin))
                {
                    MessageBox.Show("Fecha fin no válida");
                    return;
                }

                bool estado = Rdb_activo_salario.Checked;

                // ✅ Aquí llamamos al método correcto del controlador
                controlador.InsertarSalarioEmpleado(idSalario, idEmpleado, monto, fechaInicio, fechaFin, estado);

                MessageBox.Show("Salario guardado correctamente");
                CargarSalarioEmpleados();
                func_ConfigurarComboBoxSalarios();
                func_LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar salario: " + ex.Message);
            }

            func_ConfiguracionInicial();
        }



        private void Btn_modificar_salario_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_id_salario.Text, out int id))
            {
                MessageBox.Show("ID no válido");
                return;
            }

            bool exito = controlador.ActualizarSalario(
                id,
                int.Parse(Txt_id_empl_salario.Text),
                float.Parse(Txt_monto.Text),
                DateTime.Parse(Txt_fechainicio_salario.Text),
                DateTime.Parse(Txt_fechafin_salario.Text),
                Rdb_activo_salario.Checked
            );

            MessageBox.Show(exito ? "Salario modificado" : "Error al modificar");
            CargarSalarioEmpleados();
            func_ConfigurarComboBoxSalarios();
            func_LimpiarCampos();
        }

        private void Btn_eliminar_salario_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_id_salario.Text, out int id))
            {
                MessageBox.Show("ID no válido");
                return;
            }

            bool exito = controlador.BorrarSalario(id);
            MessageBox.Show(exito ? "Salario eliminado" : "Error al eliminar");
            CargarSalarioEmpleados();
            func_ConfigurarComboBoxSalarios();
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        private void func_LimpiarCampos()
        {
            Txt_id_salario.Clear();
            Txt_id_empl_salario.Clear();
            Txt_monto.Clear();
            Txt_fechainicio_salario.Clear();
            Txt_fechafin_salario.Clear();
            Rdb_activo_salario.Checked = false;
            Rdb_inactivo_salario.Checked = false;
        }

        private void Btn_salir_salario_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Btn_nuevo_salario_Click(object sender, EventArgs e)
        {

            Btn_guardar_salario.Enabled = true;
            Btn_modificar_salario.Enabled = false;
            Btn_eliminar_salario.Enabled = false;

            Txt_id_salario.Enabled = true;
        }

        private void Btn_buscar_salario_Click_1(object sender, EventArgs e)
        {
            string busqueda = Cbo_mostrar_datos.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }

            Cls_SalarioEmpleados salarioEncontrado = null;

            // Intentar buscar por ID (asumiendo que el ID es lo primero antes de un espacio o guion)
            if (int.TryParse(busqueda.Split(' ')[0].Trim(), out int id))
            {
                salarioEncontrado = listaSalarioEmpleados.FirstOrDefault(s => s.PkIdSalario == id);
            }

            // Si no se encontró por ID, buscar por nombre completo
            if (salarioEncontrado == null)
            {
                salarioEncontrado = listaSalarioEmpleados.FirstOrDefault(s =>
                    $"{s.NombresEmpleado} {s.ApellidosEmpleado}".Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (salarioEncontrado != null)
            {
                MostrarSalario(salarioEncontrado);
                Btn_modificar_salario.Enabled = true;
                Btn_eliminar_salario.Enabled = true;
                Btn_guardar_salario.Enabled = false;
            }
            else
            {
                MessageBox.Show("Salario no encontrado");
                func_LimpiarCampos();
            }

        }
    }
}