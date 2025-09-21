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
using CapaControlador;
using CapaModelo;

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

            byte estado = (Rdb_habilitado.Checked) ? (byte)1 : (byte)0;


            DataRow dr = cm.BuscarModulo(id);
            bool resultado = false;


            if (dr == null)
            {
                //  Validar que no exista otro módulo con el mismo id
                if (cm.BuscarModulo(id) != null)
                {
                    MessageBox.Show("El Id ya está en uso. Por favor cambie el Id.");
                    return;
                }

                // Insertar
                resultado = cm.InsertarModulo(id, nombre, descripcion, estado);
            }
            else
            {
                //  En modo modificar: no se puede cambiar el Id
                if (Txt_id.ReadOnly == false)
                {
                    Txt_id.ReadOnly = true; // Bloquear si alguien lo desbloqueó
                }

                resultado = cm.ModificarModulo(id, nombre, descripcion, estado);
            }

            if (resultado)
            {
                MessageBox.Show("Guardado correctamente!");
                CargarComboBox();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el módulo.");
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Txt_id.ReadOnly = false;
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

            if (cm.ModuloEnUso(id))
            {
                MessageBox.Show("No se puede eliminar el módulo porque está siendo utilizado en una aplicación.");
                return;
            }

            bool resultado = cm.EliminarModulo(id);
            if (resultado)
            {
                MessageBox.Show("Módulo eliminado correctamente.");
                CargarComboBox();
                LimpiarCampos();

                //Registrar en Bitácora - Arón Ricardo Esquit Silva
                Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Eliminar módulo", true);
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
                // 🔹 Cambié los nombres de columnas para que coincidan con la nueva BD
                Txt_id.Text = dr["Pk_Id_Modulo"].ToString();
                Txt_id.ReadOnly = true; //bloquear edición de ID al modificar
                Txt_nombre.Text = dr["Cmp_Nombre_Modulo"].ToString();
                Txt_descripcion.Text = dr["Cmp_Descripcion_Modulo"].ToString();

                bool estado = Convert.ToBoolean(dr["Cmp_Estado_Modulo"]);
                Rdb_habilitado.Checked = estado;
                Rdb_inabilitado.Checked = !estado;

                Cbo_busqueda.SelectedIndex = -1;

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Guardar módulo", true);

            }
            else
            {
                MessageBox.Show("Módulo no encontrado.");
            }
        }

        private void LimpiarCampos()
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Txt_id.ReadOnly = false;
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

        private void Pnl_Superior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt_nombre_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica si necesitas reaccionar cuando cambia el texto
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmReporte_modulo frm = new frmReporte_modulo();
            frm.Show();
        }
    }
}
