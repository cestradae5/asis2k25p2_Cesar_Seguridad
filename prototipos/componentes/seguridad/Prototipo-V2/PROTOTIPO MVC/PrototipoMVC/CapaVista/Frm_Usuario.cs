// Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Usuario : Form
    {
        // Variables globales del formulario
        private Cls_UsuarioControlador gClsUsuarioControlador = new Cls_UsuarioControlador();
        private Cls_EmpleadoControlador gClsEmpleadoControlador = new Cls_EmpleadoControlador();
        private List<string> gLstEmpleadosDisplay = new List<string>();
        private List<int> gLstEmpleadosIds = new List<int>();
        private int iIdUsuarioSeleccionado = 0;

        public Frm_Usuario()
        {
            InitializeComponent();
            Txt_Contraseña.UseSystemPasswordChar = true;
            Txt_ConfirmarContraseña.UseSystemPasswordChar = true;

            CargarEmpleados();
            ConfigurarComboBoxEmpleados();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Btn_Guardar.Enabled = false;
            Btn_Nuevo.Enabled = true;
        }

        private void CargarEmpleados()
        {
            var lstEmpleados = gClsEmpleadoControlador.ObtenerTodosLosEmpleados();
            gLstEmpleadosDisplay.Clear();
            gLstEmpleadosIds.Clear();

            foreach (var emp in lstEmpleados)
            {
                gLstEmpleadosDisplay.Add($"{emp.iPkIdEmpleado} - {emp.sNombresEmpleado} {emp.sApellidosEmpleado}");
                gLstEmpleadosIds.Add(emp.iPkIdEmpleado);
            }
        }

        private void ConfigurarComboBoxEmpleados()
        {
            Cbo_Empleado.Items.Clear();
            for (int i = 0; i < gLstEmpleadosDisplay.Count; i++)
            {
                Cbo_Empleado.Items.Add(gLstEmpleadosDisplay[i]);
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_Guardar.Enabled = true;
            iIdUsuarioSeleccionado = 0;
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Cbo_Empleado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iFkIdEmpleado = gLstEmpleadosIds[Cbo_Empleado.SelectedIndex];

            var resultado = gClsUsuarioControlador.InsertarUsuario(
                iFkIdEmpleado,
                Txt_Nombre.Text,
                Txt_Contraseña.Text,
                Txt_ConfirmarContraseña.Text
            );

            MessageBox.Show(resultado.sMensaje,
                            resultado.bExito ? "Éxito" : "Error",
                            MessageBoxButtons.OK,
                            resultado.bExito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (resultado.bExito)
            {
                LimpiarCampos();
                ConfiguracionInicial();
            }
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ConfiguracionInicial();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmReporte_Usuario frm = new frmReporte_Usuario();
            frm.Show();
        }

        private void LimpiarCampos()
        {
            Cbo_Empleado.SelectedIndex = -1;
            Txt_Nombre.Clear();
            Txt_Contraseña.Clear();
            Txt_ConfirmarContraseña.Clear();
            Txt_ConfirmarContraseña.BackColor = System.Drawing.Color.White;
            iIdUsuarioSeleccionado = 0;
        }

        // Panel superior para mover la ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_Nombre_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_Contraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_ConfirmarContraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Cbo_Empleado_SelectedIndexChanged(object sender, EventArgs e) => ValidarCampos();

        private void ValidarCampos()
        {
            bool bCamposLlenos =
                Cbo_Empleado.SelectedIndex >= 0 &&
                !string.IsNullOrWhiteSpace(Txt_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(Txt_Contraseña.Text) &&
                !string.IsNullOrWhiteSpace(Txt_ConfirmarContraseña.Text);

            bool bContrasenasCoinciden = Txt_Contraseña.Text == Txt_ConfirmarContraseña.Text;

            Btn_Guardar.Enabled = bCamposLlenos && bContrasenasCoinciden;

            Txt_ConfirmarContraseña.BackColor =
                (!bContrasenasCoinciden && Txt_ConfirmarContraseña.Text.Length > 0)
                ? System.Drawing.Color.LightCoral
                : System.Drawing.Color.White;
        }


    }
}
