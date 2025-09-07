using System;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    /* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 * */
    public partial class frmPerfiles : Form
    {
        ControladorPerfiles controlador = new ControladorPerfiles();

        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            Btn_guardar.Enabled = false;
            Btn_modificar.Enabled = false;
        }

        private void LlenarCombos()
        {
            // Llenar ComboBox de Perfiles como string[]
            Cbo_perfiles.Items.Clear();
            string[] perfiles = controlador.ItemsPerfiles();
            foreach (var item in perfiles)
            {
                if (!string.IsNullOrEmpty(item))
                    Cbo_perfiles.Items.Add(item);
            }
            Cbo_perfiles.SelectedIndex = Cbo_perfiles.Items.Count > 0 ? 0 : -1;

            // Llenar ComboBox de Tipos de Perfil como string[]
            Cbo_tipoperfil.Items.Clear();
            string[] tipos = controlador.ItemsTipos();
            foreach (var item in tipos)
            {
                if (!string.IsNullOrEmpty(item))
                    Cbo_tipoperfil.Items.Add(item);
            }
            Cbo_tipoperfil.SelectedIndex = Cbo_tipoperfil.Items.Count > 0 ? 0 : -1;

            // Opcional: Autocompletado
            var autoColeccion = new AutoCompleteStringCollection();
            autoColeccion.AddRange(perfiles);
            Cbo_perfiles.AutoCompleteCustomSource = autoColeccion;
            Cbo_perfiles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_perfiles.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_nuevo.Enabled = false;
            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = false;
            Txt_idperfil.Enabled = true;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_idperfil.Text) ||
                    string.IsNullOrWhiteSpace(Txt_puesto.Text) ||
                    string.IsNullOrWhiteSpace(Txt_descripcion.Text) ||
                    string.IsNullOrWhiteSpace(Cbo_tipoperfil.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Rdb_Habilitado.Checked && !Rdb_inhabilitado.Checked)
                {
                    MessageBox.Show("Por favor, seleccione un estado (Habilitado o Inhabilitado).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(Txt_idperfil.Text);
                string puesto = Txt_puesto.Text;
                string descripcion = Txt_descripcion.Text;
                bool habilitado = Rdb_Habilitado.Checked;
                bool inhabilitado = Rdb_inhabilitado.Checked;

                // Validación de tipo de perfil 0 o 1
                int tipo;
                if (!int.TryParse(Cbo_tipoperfil.Text, out tipo) || (tipo != 0 && tipo != 1))
                {
                    MessageBox.Show("El tipo de perfil es inválido. Debe ser 0 o 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cbo_tipoperfil.Focus();
                    return;
                }

                if (controlador.InsertarPerfil(id, puesto, descripcion, habilitado, inhabilitado, tipo))
                {
                    MessageBox.Show("¡Datos guardados exitosamente!");
                    LlenarCombos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el perfil. Verifique que el ID no exista ya.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Btn_nuevo.Enabled = true;
                Btn_guardar.Enabled = false;
                Btn_modificar.Enabled = false;
                Txt_idperfil.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_idperfil.Text) ||
                    string.IsNullOrWhiteSpace(Txt_puesto.Text) ||
                    string.IsNullOrWhiteSpace(Txt_descripcion.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Rdb_Habilitado.Checked && !Rdb_inhabilitado.Checked)
                {
                    MessageBox.Show("Por favor, seleccione un estado (Habilitado o Inhabilitado).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(Txt_idperfil.Text);
                string puesto = Txt_puesto.Text;
                string descripcion = Txt_descripcion.Text;
                bool habilitado = Rdb_Habilitado.Checked;
                bool inhabilitado = Rdb_inhabilitado.Checked;

                // Validación de tipo de perfil 0 o 1
                int tipo;
                if (!int.TryParse(Cbo_tipoperfil.Text, out tipo) || (tipo != 0 && tipo != 1))
                {
                    MessageBox.Show("El tipo de perfil es inválido. Debe ser 0 o 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cbo_tipoperfil.Focus();
                    return;
                }

                if (controlador.ModificarPerfil(id, puesto, descripcion, habilitado, inhabilitado, tipo))
                {
                    MessageBox.Show("¡Datos modificados exitosamente!");
                    LlenarCombos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Btn_nuevo.Enabled = true;
                Btn_guardar.Enabled = false;
                Btn_modificar.Enabled = false;
                Txt_idperfil.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al modificar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_nuevo.Enabled = true;
            Btn_guardar.Enabled = false;
            Btn_modificar.Enabled = false;
            Txt_idperfil.Enabled = false;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_perfiles.SelectedValue != null)
            {
                int idPerfil = Convert.ToInt32(Cbo_perfiles.SelectedValue);
                var row = controlador.BuscarPerfil(idPerfil);
                if (row != null)
                {
                    Txt_idperfil.Text = row["pk_id_perfil"].ToString();
                    Txt_puesto.Text = row["puesto_perfil"].ToString();
                    Txt_descripcion.Text = row["descripcion_perfil"].ToString();

                    if (row["tipo_perfil"] != DBNull.Value)
                        Cbo_tipoperfil.SelectedIndex = ((bool)row["tipo_perfil"]) ? 0 : 1;
                    else
                        Cbo_tipoperfil.SelectedIndex = -1;

                    Rdb_Habilitado.Checked = (bool)row["habilitado_perfil"];
                    Rdb_inhabilitado.Checked = (bool)row["inabilitado_perfil"];

                    Btn_nuevo.Enabled = false;
                    Btn_guardar.Enabled = false;
                    Btn_modificar.Enabled = true;
                    Txt_idperfil.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontró el perfil seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LimpiarCampos()
        {
            Txt_idperfil.Text = "";
            Txt_puesto.Text = "";
            Txt_descripcion.Text = "";
            Cbo_tipoperfil.SelectedIndex = -1;
            Rdb_Habilitado.Checked = false;
            Rdb_inhabilitado.Checked = false;
        }
    }
}
