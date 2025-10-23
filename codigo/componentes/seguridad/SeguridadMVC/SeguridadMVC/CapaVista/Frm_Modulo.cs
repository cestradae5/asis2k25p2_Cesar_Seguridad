using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

// Nombre: Danilo Mazariegos Codigo:0901-19-25059
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Modulo : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Para registrar acciones en la bitácora
        Cls_Modulos_Controlador cm = new Cls_Modulos_Controlador(); // Controlador de módulos

        private Frm_Reporte_modulos frmReporte = null; // Ventana de reportes

        public Frm_Modulo()
        {
            InitializeComponent();

         
            this.Btn_guardar.Click -= Btn_guardar_Click;
            this.Btn_guardar.Click += Btn_guardar_Click;

            this.Btn_Modificar.Click -= Btn_Modificar_Click;
            this.Btn_Modificar.Click += Btn_Modificar_Click;

       
        }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            fun_CargarComboBox(); // Llena el combo de búsqueda al cargar
        }

        private void fun_CargarComboBox()
        {
            Cbo_busqueda.Items.Clear();
            string[] items = cm.ItemsModulos();
            foreach (var item in items) Cbo_busqueda.Items.Add(item);
        }

        //boton guardar, guarda la informacion nueva
        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_id.Text) || string.IsNullOrEmpty(Txt_nombre.Text) || string.IsNullOrEmpty(Txt_descripcion.Text))
            {
                MessageBox.Show("Debe ingresar Id, Nombre y Descripción.");
                return;
            }
            if (!int.TryParse(Txt_id.Text, out int Pk_Id_Modulo))
            {
                MessageBox.Show("El Id debe ser un número.");
                return;
            }

            string sCmp_Nombre_Modulo = Txt_nombre.Text;
            string sCmp_Descripcion_Modulo = Txt_descripcion.Text;
            byte btCmp_Estado_Modulo = (Rdb_habilitado.Checked) ? (byte)1 : (byte)0;

            // funcion para la busqueda de modulos creados

            DataRow dr = cm.BuscarModulo(Pk_Id_Modulo);
            if (dr != null)
            {
                MessageBox.Show("Ya existe un módulo con este Id. Use el botón Modificar para actualizarlo.");
                return;
            }

            bool bResultado = cm.InsertarModulo(Pk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);

            if (bResultado)
            {
                MessageBox.Show("Módulo guardado correctamente.");
                fun_CargarComboBox();
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Guardó el módulo: {Txt_nombre.Text}", true);
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al guardar el módulo.");
            }
        }

     //modificacion de los modulos ya creados
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
         

            if (string.IsNullOrEmpty(Txt_id.Text) || string.IsNullOrEmpty(Txt_nombre.Text) || string.IsNullOrEmpty(Txt_descripcion.Text))
            {
                MessageBox.Show("Debe ingresar Id, Nombre y Descripción.");
                return;
            }
            if (!int.TryParse(Txt_id.Text, out int Pk_Id_Modulo))
            {
                MessageBox.Show("El Id debe ser un número.");
                return;
            }

            string sCmp_Nombre_Modulo = Txt_nombre.Text;
            string sCmp_Descripcion_Modulo = Txt_descripcion.Text;
            byte btCmp_Estado_Modulo = (Rdb_habilitado.Checked) ? (byte)1 : (byte)0;

            DataRow dr = cm.BuscarModulo(Pk_Id_Modulo);
            if (dr == null)
            {
                MessageBox.Show("No existe un módulo con este Id. Use Guardar para crear uno nuevo.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea actualizar la información de este módulo?",
                "Confirmar modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (respuesta == DialogResult.No) return;

            bool bResultado = cm.ModificarModulo(Pk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);

            if (bResultado)
            {
                MessageBox.Show("Módulo modificado correctamente.");
                fun_CargarComboBox();
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Modificó el módulo: {Txt_nombre.Text}", true);
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al modificar el módulo.");
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Txt_id.Enabled = true;
            MessageBox.Show("Campos listos para nuevo registro");
        }

        //se utiliza para eliminar modulos que no esten siendo utilizados
        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_id.Text)) { MessageBox.Show("Ingrese el Id del módulo a eliminar."); return; }
            if (!int.TryParse(Txt_id.Text, out int Pk_Id_Modulo)) { MessageBox.Show("El Id debe ser un número."); return; }
            if (cm.ModuloEnUso(Pk_Id_Modulo)) { MessageBox.Show("No se puede eliminar el módulo porque está siendo utilizado en una aplicación."); return; }

            bool bResultado = cm.EliminarModulo(Pk_Id_Modulo);
            if (bResultado)
            {
                MessageBox.Show("Módulo eliminado correctamente.");
                fun_CargarComboBox();
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario, 1, $"Eliminó el módulo: {Txt_nombre.Text}", true);
                fun_LimpiarCampos(); Txt_id.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al eliminar módulo.");
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_busqueda.SelectedItem == null) { MessageBox.Show("Seleccione un módulo para buscar."); return; }

            string sSeleccionado = Cbo_busqueda.SelectedItem.ToString();
            int Pk_Id_Modulo = int.Parse(sSeleccionado.Split('-')[0].Trim());

            DataRow dr = cm.BuscarModulo(Pk_Id_Modulo);
            if (dr != null)
            {
                Txt_id.Text = dr["Pk_Id_Modulo"].ToString();
                Txt_nombre.Text = dr["Cmp_Nombre_Modulo"].ToString();
                Txt_descripcion.Text = dr["Cmp_Descripcion_Modulo"].ToString();

                bool bEstado = Convert.ToBoolean(dr["Cmp_Estado_Modulo"]);
                Rdb_habilitado.Checked = bEstado;
                Rdb_inabilitado.Checked = !bEstado;

                Txt_id.Enabled = false;
                Cbo_busqueda.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Módulo no encontrado.");
            }
        }

        private void fun_LimpiarCampos()
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Cbo_busqueda.SelectedIndex = -1;
        }

        // --- Arrastrar ventana ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pic_Cerrar_Click(object sender, EventArgs e) => this.Close();

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
            if (frmReporte == null || frmReporte.IsDisposed)
            {
                frmReporte = new Frm_Reporte_modulos();
                frmReporte.FormClosed += (s, args) => frmReporte = null;
                frmReporte.Show();
            }
            else
            {
                frmReporte.BringToFront();
            }
        }
    }
}
