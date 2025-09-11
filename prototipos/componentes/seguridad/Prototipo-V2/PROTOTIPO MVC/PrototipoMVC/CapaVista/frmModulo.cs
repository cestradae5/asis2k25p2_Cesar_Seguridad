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

namespace CapaVista
{
    public partial class frmModulo : Form
    {
        // Instancia del controlador
        ControladorModulos cm = new ControladorModulos();

        public frmModulo()
        {
            InitializeComponent();
        }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            // Cargar ComboBox con los módulos
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            Cbo_busqueda.Items.Clear();
            string[] items = cm.ItemsModulos();
            foreach (var item in items)
            {
                Cbo_busqueda.Items.Add(item);
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrEmpty(Txt_id.Text) || string.IsNullOrEmpty(Txt_nombre.Text))
            {
                MessageBox.Show("Debe ingresar Id y Nombre.");
                return;
            }

            if (!int.TryParse(Txt_id.Text, out int id))
            {
                MessageBox.Show("Id debe ser un número.");
                return;
            }

            string nombre = Txt_nombre.Text;
            string descripcion = Txt_descripcion.Text;

            // Validar los RadioButtons -> ahora solo 1 columna estado_modulo
            byte estado = (Rdb_habilitado.Checked) ? (byte)1 : (byte)0;

            DataRow dr = cm.BuscarModulo(id);
            bool resultado = false;
            if (dr == null)
            {
                // Insertar
                resultado = cm.InsertarModulo(id, nombre, descripcion, estado);
            }
            else
            {
                // Modificar
                resultado = cm.ModificarModulo(id, nombre, descripcion, estado);
            }

            if (resultado)
            {
                MessageBox.Show("Guardado correctamente!");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Error al guardar el módulo.");
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            MessageBox.Show("Campos listos para nuevo registro");
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_id.Text))
            {
                MessageBox.Show("Ingrese el Id del módulo a eliminar.");
                return;
            }

            if (!int.TryParse(Txt_id.Text, out int id))
            {
                MessageBox.Show("Id debe ser un número.");
                return;
            }

            bool resultado = cm.EliminarModulo(id); // Elimina físicamente
            if (resultado)
            {
                MessageBox.Show("Módulo eliminado correctamente.");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Error al eliminar módulo.");
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_busqueda.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un módulo para buscar.");
                return;
            }

            string seleccionado = Cbo_busqueda.SelectedItem.ToString();
            int id = int.Parse(seleccionado.Split('-')[0].Trim());

            DataRow dr = cm.BuscarModulo(id);
            if (dr != null)
            {
                Txt_id.Text = dr["pk_id_modulo"].ToString();
                Txt_nombre.Text = dr["nombre_modulo"].ToString();
                Txt_descripcion.Text = dr["descripcion_modulo"].ToString();

                bool estado = Convert.ToBoolean(dr["estado_modulo"]);
                Rdb_habilitado.Checked = estado;
                Rdb_inabilitado.Checked = !estado;
            }
            else
            {
                MessageBox.Show("Módulo no encontrado.");
            }
        }
    }
}
