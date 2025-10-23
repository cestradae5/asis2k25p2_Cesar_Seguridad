using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

// Nombre: Danilo Mazariegos Codigo:0901-19-25059
namespace Capa_Vista_Seguridad
{
    public partial class Frm_Modulo : Form
    {
        private readonly Cls_Modulos_Controlador cm = new Cls_Modulos_Controlador(); // Controlador de módulos
        private Frm_Reporte_modulos frmReporte = null; // Ventana de reportes

        public Frm_Modulo()
        {
            InitializeComponent();

            this.Btn_guardar.Click -= Btn_guardar_Click;
            this.Btn_guardar.Click += Btn_guardar_Click;

            this.Btn_Modificar.Click -= Btn_Modificar_Click;
            this.Btn_Modificar.Click += Btn_Modificar_Click;

            this.Btn_eliminar.Click -= Btn_eliminar_Click;
            this.Btn_eliminar.Click += Btn_eliminar_Click;

            this.Btn_buscar.Click -= Btn_buscar_Click;
            this.Btn_buscar.Click += Btn_buscar_Click;

            this.Btn_nuevo.Click -= Btn_nuevo_Click;
            this.Btn_nuevo.Click += Btn_nuevo_Click;

            this.Load -= frmModulo_Load;
            this.Load += frmModulo_Load;
        }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            fun_CargarComboBox();
        }

        private void fun_CargarComboBox()
        {
            Cbo_busqueda.Items.Clear();
            var items = cm.ItemsModulos();
            if (items != null && items.Length > 0)
                Cbo_busqueda.Items.AddRange(items);
        }

        //boton guardar, guarda la informacion nueva
        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            var resultado = cm.GuardarModulo(
                Txt_id.Text,
                Txt_nombre.Text,
                Txt_descripcion.Text,
                Rdb_habilitado.Checked
            );

            MessageBox.Show(resultado.Message);

            if (resultado.Success)
            {
                fun_CargarComboBox();
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
        }

        //modificacion de los modulos ya creados
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            var resultado = cm.ModificarModulo(
                Txt_id.Text,
                Txt_nombre.Text,
                Txt_descripcion.Text,
                Rdb_habilitado.Checked
            );

            if (!resultado.ConfirmedByUser)
            {
                
                return;
            }

            MessageBox.Show(resultado.Message);

            if (resultado.Success)
            {
                fun_CargarComboBox();
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
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
            var resultado = cm.EliminarModulo(Txt_id.Text, Txt_nombre.Text);

            MessageBox.Show(resultado.Message);

            if (resultado.Success)
            {
                fun_CargarComboBox();
                fun_LimpiarCampos();
                Txt_id.Enabled = true;
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            var seleccionado = Cbo_busqueda.SelectedItem?.ToString();
            var resultado = cm.BuscarModuloDesdeCombo(seleccionado);

            if (!resultado.Success || resultado.Modulo == null)
            {
                MessageBox.Show(resultado.Message);
                return;
            }

            Txt_id.Text = resultado.Modulo.Pk_Id_Modulo.ToString();
            Txt_nombre.Text = resultado.Modulo.Cmp_Nombre_Modulo;
            Txt_descripcion.Text = resultado.Modulo.Cmp_Descripcion_Modulo;

            Rdb_habilitado.Checked = resultado.Modulo.Cmp_Estado_Modulo == 1;
            Rdb_inabilitado.Checked = resultado.Modulo.Cmp_Estado_Modulo == 0;

            Txt_id.Enabled = false;
            Cbo_busqueda.SelectedIndex = -1;
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

        //-Arrastrar ventana
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
