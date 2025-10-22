// Pablo Quiroa 0901-22-2929
using Capa_Controlador_Seguridad;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Usuario : Form
    {
        // VARIABLES GLOBALES
        private Cls_Usuario_Controlador gClsUsuarioControlador = new Cls_Usuario_Controlador();
        private Cls_EmpleadoControlador gClsEmpleadoControlador = new Cls_EmpleadoControlador();

        private List<string> gLstEmpleadosDisplay = new List<string>();
        private List<int> gLstEmpleadosIds = new List<int>();

        private int idUsuarioSeleccionado = 0;

        // CONSTRUCTOR
        //cambios cesar estrada
        public Frm_Usuario()
        {
            InitializeComponent();

            Txt_Contraseña.UseSystemPasswordChar = true;
            Txt_ConfirmarContraseña.UseSystemPasswordChar = true;

            CargarEmpleados();
            ConfigurarComboBoxEmpleados();

            ConfiguracionInicial();
        }

        // CONFIGURACION INICIAL
        private void ConfiguracionInicial()
        {
            Btn_Guardar.Enabled = false;
        }

        // CARGA DE DATOS
        //cambios cesar estrada
        private void CargarEmpleados()
        {
            // El Controlador SÍ usa el Modelo, pero la Vista NO
            var empleadosData = gClsEmpleadoControlador.fun_ObtenerEmpleadosParaComboBox();
            gLstEmpleadosDisplay.Clear();
            gLstEmpleadosIds.Clear();

            foreach (var empData in empleadosData)
            {
                gLstEmpleadosDisplay.Add(empData.Display);
                gLstEmpleadosIds.Add(empData.Id);
            }
        }

        //cambios cesar estrada
        private void ConfigurarComboBoxEmpleados()
        {
            Cbo_Empleado.Items.Clear();
            foreach (var display in gLstEmpleadosDisplay)
            {
                Cbo_Empleado.Items.Add(display);
            }
        }

        // BOTONES
        //cambios cesar estrada
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Cbo_Empleado.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iFkIdEmpleado = gLstEmpleadosIds[Cbo_Empleado.SelectedIndex];

            // El Controlador recibe los datos y usa el Modelo internamente
            var gResultado = gClsUsuarioControlador.InsertarUsuario(
                iFkIdEmpleado,
                Txt_Nombre.Text,
                Txt_Contraseña.Text,
                Txt_ConfirmarContraseña.Text
            );

            MessageBox.Show(gResultado.sMensaje,
                            gResultado.bExito ? "Éxito" : "Error",
                            MessageBoxButtons.OK,
                            gResultado.bExito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (gResultado.bExito)
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
            frmReporte_Usuario gFrm = new frmReporte_Usuario();
            gFrm.Show();
        }

        // FUNCIONES DE APOYO
        private void LimpiarCampos()
        {
            Cbo_Empleado.SelectedIndex = -1;
            Txt_Nombre.Clear();
            Txt_Contraseña.Clear();
            Txt_ConfirmarContraseña.Clear();
            Txt_ConfirmarContraseña.BackColor = System.Drawing.Color.White;
            idUsuarioSeleccionado = 0;
        }

        // PERMITIR MOVER EL FORMULARIO
        public const int iWM_NCLBUTTONDOWN = 0xA1;
        public const int iHTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int iMsg, int iWParam, int iLParam);

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, iWM_NCLBUTTONDOWN, iHTCAPTION, 0);
            }
        }

        private void Pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EVENTOS DE CAMPOS
        private void Txt_Nombre_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_Contraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Txt_ConfirmarContraseña_TextChanged(object sender, EventArgs e) => ValidarCampos();
        private void Cbo_Empleado_SelectedIndexChanged(object sender, EventArgs e) => ValidarCampos();

        // VALIDACIÓN VISUAL ACTUALIZADA
        private void ValidarCampos()
        {
            bool bCamposLlenos =
                Cbo_Empleado.SelectedIndex >= 0 &&
                !string.IsNullOrWhiteSpace(Txt_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(Txt_Contraseña.Text) &&
                !string.IsNullOrWhiteSpace(Txt_ConfirmarContraseña.Text);

            bool bPuedeGuardar = false;

            if (bCamposLlenos)
            {
                int iFkIdEmpleado = gLstEmpleadosIds[Cbo_Empleado.SelectedIndex];
                bPuedeGuardar = gClsUsuarioControlador.PuedeGuardarUsuario(
                    iFkIdEmpleado,
                    Txt_Nombre.Text,
                    Txt_Contraseña.Text,
                    Txt_ConfirmarContraseña.Text
                );
            }

            Btn_Guardar.Enabled = bPuedeGuardar;

            Txt_ConfirmarContraseña.BackColor =
                (!bPuedeGuardar && Txt_ConfirmarContraseña.Text.Length > 0)
                ? System.Drawing.Color.LightCoral
                : System.Drawing.Color.White;
        }

        // CHECKBOX PARA CONFIRMAR LA CONTRASEÑA
        private void Chk_ConfirmarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            bool bMostrar = Chk_ConfirmarContraseña.Checked;

            Txt_Contraseña.UseSystemPasswordChar = !bMostrar;
            Txt_ConfirmarContraseña.UseSystemPasswordChar = !bMostrar;
        }
    }
}
// Pablo Quiroa 0901-22-2929 12/10/2025 