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
        
        // VARIABLES GLOBALES
        
        private Cls_UsuarioControlador gClsUsuarioControlador = new Cls_UsuarioControlador();
        private Cls_EmpleadoControlador gClsEmpleadoControlador = new Cls_EmpleadoControlador();
        private Cls_BitacoraControlador gCtrlBitacora = new Cls_BitacoraControlador(); // se puede mantener aunque ya no lo uses aquí

        private List<string> gLstEmpleadosDisplay = new List<string>();
        private List<int> gLstEmpleadosIds = new List<int>();
        private List<string> gLstUsuariosDisplay = new List<string>();
        private List<int> gLstUsuariosIds = new List<int>();

        private int iIdUsuarioSeleccionado = 0;

      
        // CONSTRUCTOR
        
        public Frm_Usuario()
        {
            InitializeComponent();

            Txt_Contraseña.UseSystemPasswordChar = true;
            Txt_ConfirmarContraseña.UseSystemPasswordChar = true;

            CargarEmpleados();
            ConfigurarComboBoxEmpleados();

            CargarUsuarios();
            ConfigurarComboBoxUsuarios();

            ConfiguracionInicial();
        }

        
        // CONFIGURACION INICIAL
        
        private void ConfiguracionInicial()
        {
            Btn_Guardar.Enabled = false;
        }

       
        // CARGA DE DATOS
        
        private void CargarEmpleados()
        {
            var lstEmpleados = gClsEmpleadoControlador.fun_ObtenerTodosLosEmpleados();
            gLstEmpleadosDisplay.Clear();
            gLstEmpleadosIds.Clear();

            foreach (var gEmp in lstEmpleados)
            {
                gLstEmpleadosDisplay.Add($"{gEmp.iPkIdEmpleado} - {gEmp.sNombresEmpleado} {gEmp.sApellidosEmpleado}");
                gLstEmpleadosIds.Add(gEmp.iPkIdEmpleado);
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

        private void CargarUsuarios()
        {
            var lstUsuarios = gClsUsuarioControlador.ObtenerTodosLosUsuarios();
            gLstUsuariosDisplay.Clear();
            gLstUsuariosIds.Clear();

            foreach (var gUsr in lstUsuarios)
            {
                gLstUsuariosDisplay.Add($"{gUsr.iPkIdUsuario} - {gUsr.sNombreUsuario}");
                gLstUsuariosIds.Add(gUsr.iPkIdUsuario);
            }
        }

        private void ConfigurarComboBoxUsuarios()
        {
            Cbo_Usuarios.Items.Clear();
            for (int i = 0; i < gLstUsuariosDisplay.Count; i++)
            {
                Cbo_Usuarios.Items.Add(gLstUsuariosDisplay[i]);
            }
        }

       
        
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Cbo_Empleado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iFkIdEmpleado = gLstEmpleadosIds[Cbo_Empleado.SelectedIndex];

            // Llamada al controlador (el controlador ahora hace validaciones y registra bitácora internamente)
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
                CargarUsuarios();
                ConfigurarComboBoxUsuarios();
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

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_Usuarios.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int iIdUsuario = gLstUsuariosIds[Cbo_Usuarios.SelectedIndex];
            var gUsuario = gClsUsuarioControlador.BuscarUsuarioPorId(iIdUsuario);

            if (gUsuario != null)
            {
                Txt_Nombre.Text = gUsuario.sNombreUsuario;
                Txt_Contraseña.Text = gUsuario.sContrasenaUsuario;
                Txt_ConfirmarContraseña.Text = gUsuario.sContrasenaUsuario;
                iIdUsuarioSeleccionado = gUsuario.iPkIdUsuario;
            }
            else
            {
                MessageBox.Show("No se pudo cargar la información del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void Cbo_Usuarios_SelectedIndexChanged(object sender, EventArgs e) { }

        
        // VALIDACIÓN VISUAL
        
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

// Pablo Quiroa 0901-22-2929 12/10/2025