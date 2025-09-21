using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaControlador;
using CapaModelo;

//Brandon Alexander Hernandez Salguero 0901-22-9663
namespace CapaVista
{
    public partial class frmPerfiles : Form
    {
        private Cls_PerfilesControlador controlador = new Cls_PerfilesControlador();
        private List<Cls_Perfiles> listaPerfiles = new List<Cls_Perfiles>();

        public frmPerfiles()
        {
            InitializeComponent();
            fun_CargarPerfiles();
            fun_ConfigurarComboBoxPerfiles();
            fun_ConfigurarComboBoxTipoPerfil();
            fun_Configuracioninicial();
            
            
            

        }

        private void fun_Configuracioninicial()
        {
            Btn_guardar.Enabled = false;
            Txt_idperfil.Enabled = false;
            Btn_Eliminar.Enabled = false;
            Btn_nuevo.Enabled = true;
            Btn_cancelar.Enabled = true;
            Btn_modificar.Enabled = false;
        }
        private void fun_CargarPerfiles()
        {
            listaPerfiles = controlador.listObtenerTodosLosPerfiles();
        }

        private void fun_ConfigurarComboBoxPerfiles()
        {
            Cbo_perfiles.Items.Clear();
            Cbo_perfiles.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_perfiles.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaPerfiles.Select(p => p.pk_id_perfil.ToString()).ToArray());
            autoComplete.AddRange(listaPerfiles.Select(p => p.puesto_perfil).ToArray());
            Cbo_perfiles.AutoCompleteCustomSource = autoComplete;

            // Display y Value
            Cbo_perfiles.DisplayMember = "Display";
            Cbo_perfiles.ValueMember = "Id";
            foreach (var perfil in listaPerfiles)
            {
                Cbo_perfiles.Items.Add(new
                {
                    Display = $"{perfil.pk_id_perfil} - {perfil.puesto_perfil}",
                    Id = perfil.pk_id_perfil
                });
            }
        }

        private void fun_ConfigurarComboBoxTipoPerfil()
        {
            Cbo_tipoperfil.Items.Clear();
            Cbo_tipoperfil.Items.Add("0");
            Cbo_tipoperfil.Items.Add("1");
            Cbo_tipoperfil.SelectedIndex = -1;
        }

        private void fun_MostrarPerfil(Cls_Perfiles perfil)
        {
            Txt_idperfil.Text = perfil.pk_id_perfil.ToString();
            Txt_puesto.Text = perfil.puesto_perfil;
            Txt_descripcion.Text = perfil.descripcion_perfil;
            Cbo_tipoperfil.Text = perfil.tipo_perfil.ToString();
            Rdb_Habilitado.Checked = perfil.estado_perfil;
            Rdb_inhabilitado.Checked = !perfil.estado_perfil;
        }


            

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
              Btn_nuevo.Enabled = false;
            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = false;
            Txt_idperfil.Enabled = false;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_puesto.Text) ||
                    string.IsNullOrWhiteSpace(Txt_descripcion.Text) ||
                    string.IsNullOrWhiteSpace(Cbo_tipoperfil.Text))
                {
                    MessageBox.Show("Complete todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool estado = Rdb_Habilitado.Checked;
                int tipo;
                if (!int.TryParse(Cbo_tipoperfil.Text, out tipo) || (tipo != 0 && tipo != 1))
                {
                    MessageBox.Show("Tipo de perfil inválido. Debe ser 0 o 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = controlador.bInsertarPerfil(Txt_puesto.Text, Txt_descripcion.Text, estado, tipo);

                if (exito)
                {
                    MessageBox.Show("Perfil guardado correctamente");

                    // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                    Cls_BitacoraControlador bit = new Cls_BitacoraControlador();
                    bit.RegistrarAccion(Cls_sesion.iUsuarioId, 1, "Guardar perfil", true);
                }
                else
                {
                    MessageBox.Show("Error al guardar perfil");
                }

                fun_CargarPerfiles();
                fun_ConfigurarComboBoxPerfiles();
                fun_LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            fun_Configuracioninicial();
        }


        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_idperfil.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Txt_puesto.Text) ||
                string.IsNullOrWhiteSpace(Txt_descripcion.Text) ||
                Cbo_tipoperfil.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos antes de modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool estado = Rdb_Habilitado.Checked;
            int tipo;
            if (!int.TryParse(Cbo_tipoperfil.Text, out tipo) || (tipo != 0 && tipo != 1))
            {
                MessageBox.Show("Tipo de perfil inválido. Debe ser 0 o 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = controlador.bActualizarPerfil(id, Txt_puesto.Text, Txt_descripcion.Text, estado, tipo);

            if (exito)
            {
                MessageBox.Show("Perfil modificado correctamente");

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                Cls_BitacoraControlador bit = new Cls_BitacoraControlador();
                bit.RegistrarAccion(Cls_sesion.iUsuarioId, 1, "Modificar perfil", true);
            }
            else
            {
                MessageBox.Show("Error al modificar perfil");
            }

            fun_CargarPerfiles();
            fun_ConfigurarComboBoxPerfiles();
            fun_LimpiarCampos();
        }



        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            fun_LimpiarCampos();
            fun_Configuracioninicial();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void fun_LimpiarCampos()
        {
            Txt_idperfil.Clear();
            Txt_puesto.Clear();
            Txt_descripcion.Clear();
            Cbo_tipoperfil.SelectedIndex = -1;
            Rdb_Habilitado.Checked = false;
            Rdb_inhabilitado.Checked = false;
            
        }



        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            string busqueda = Cbo_perfiles.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre de perfil para buscar");
                return;
            }

            Cls_Perfiles perfilEncontrado = null;

            // Buscar por ID si es numérico
            if (int.TryParse(busqueda.Split('-')[0].Trim(), out int id))
            {
                perfilEncontrado = listaPerfiles.FirstOrDefault(p => p.pk_id_perfil == id);
            }
            // Si no encontró por ID, buscar por nombre
            if (perfilEncontrado == null)
            {
                perfilEncontrado = listaPerfiles.FirstOrDefault(p =>
                    p.puesto_perfil.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }
            if (perfilEncontrado != null)
            {
                fun_MostrarPerfil(perfilEncontrado);
                Btn_nuevo.Enabled = false;
                Btn_guardar.Enabled = false;
                Btn_modificar.Enabled = true;
                Txt_idperfil.Enabled = false;
                Txt_idperfil.Enabled = false;
                Btn_Eliminar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Perfil no encontrado");
                fun_LimpiarCampos();
            }
        
    }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Txt_idperfil.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido para eliminar.");
                return;
            }

            bool exito = controlador.bBorrarPerfil(id);

            if (exito)
            {
                MessageBox.Show("Perfil eliminado");

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                Cls_BitacoraControlador bit = new Cls_BitacoraControlador();
                bit.RegistrarAccion(Cls_sesion.iUsuarioId, 1, "Eliminar perfil", true);
            }
            else
            {
                MessageBox.Show("Error al eliminar perfil");
            }

            fun_CargarPerfiles();
            Cbo_perfiles.Items.Clear();
            fun_ConfigurarComboBoxPerfiles();
            fun_LimpiarCampos();
            fun_Configuracioninicial();
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
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Libera el mouse
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Simula arrastre
            }

        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frm_reporte_perfiles frm = new frm_reporte_perfiles();
            frm.Show();
        }
    }
}