// Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Usuario : Form
    {
        // Variables globales del formulario
        private Cls_UsuarioControlador gClsUsuarioControlador = new Cls_UsuarioControlador();
        private Cls_EmpleadoControlador gClsEmpleadoControlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> gLstEmpleados = new List<Cls_Empleado>();
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

        // Cargamos los empleados desde el controlador
        private void CargarEmpleados()
        {
            gLstEmpleados = gClsEmpleadoControlador.ObtenerTodosLosEmpleados();
        }

        // Configuramos ComboBox de empleados
        private void ConfigurarComboBoxEmpleados()
        {
            Cbo_Empleado.DisplayMember = "Display";
            Cbo_Empleado.ValueMember = "Id";

            foreach (var emp in gLstEmpleados)
            {
                Cbo_Empleado.Items.Add(new
                {
                    Display = $"{emp.iPkIdEmpleado} - {emp.sNombresEmpleado} {emp.sApellidosEmpleado}",
                    Id = emp.iPkIdEmpleado
                });
            }
        }

        // Botón Nuevo
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_Guardar.Enabled = true;
            iIdUsuarioSeleccionado = 0;
        }

        // Botón Guardar
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Cbo_Empleado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selected = (dynamic)Cbo_Empleado.SelectedItem;
            int iFkIdEmpleado = selected.Id;

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

        // Botón Limpiar
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ConfiguracionInicial();
        }

        // Botón Salir
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón Reporte
        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmReporte_Usuario frm = new frmReporte_Usuario();
            frm.Show();
        }

        // Limpiar campos del formulario
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

        // Eventos para validar campos y habilitar botones
        private void Txt_Nombre_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_Contraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_ConfirmarContraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Cbo_Empleado_SelectedIndexChanged(object sender, EventArgs e) => ValidarCampos();

        private void ValidarCampos()
        {
            bool bCamposLlenos =
                Cbo_Empleado.SelectedItem != null &&
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
