using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class FrmUsuario : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        private Cls_UsuarioControlador usuarioControlador = new Cls_UsuarioControlador();
        private Cls_EmpleadoControlador empleadoControlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaEmpleados = new List<Cls_Empleado>();
        private int idUsuarioSeleccionado = 0; // Para saber si modificamos un usuario existente

        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;



        public FrmUsuario()
        {
            InitializeComponent();
            CargarEmpleados();
            ConfigurarComboBoxEmpleados();
            ConfiguracionInicial();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
        }

        private void ConfiguracionInicial()
        {
            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = false;
            Btn_Nuevo.Enabled = true;
        }

        private void CargarEmpleados()
        {
            listaEmpleados = empleadoControlador.ObtenerTodosLosEmpleados();
        }

        private void ConfigurarComboBoxEmpleados()
        {
            Cbo_Empleado.DisplayMember = "Display";
            Cbo_Empleado.ValueMember = "Id";

            foreach (var emp in listaEmpleados)
            {
                Cbo_Empleado.Items.Add(new
                {
                    Display = $"{emp.PkIdEmpleado} - {emp.NombresEmpleado} {emp.ApellidosEmpleado}",
                    Id = emp.PkIdEmpleado
                });
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_Guardar.Enabled = false; // habilitar solo si hay texto
            Btn_Modificar.Enabled = false;
            idUsuarioSeleccionado = 0;
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cbo_Empleado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selected = (dynamic)Cbo_Empleado.SelectedItem;
                int fkIdEmpleado = selected.Id;

                // Hashear la contraseña
                string contraseñaHasheada = SeguridadHash.HashearSHA256(Txt_Contraseña.Text);

                usuarioControlador.InsertarUsuario(
                    fkIdEmpleado,
                    Txt_Nombre.Text,
                    contraseñaHasheada,
                    0,
                    true,
                    DateTime.Now,
                    DateTime.Now,
                    false
                );

                MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Guardar usuario", true);

                LimpiarCampos();
                ConfiguracionInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione primero un usuario para modificar");
                return;
            }

            try
            {
                var selected = (dynamic)Cbo_Empleado.SelectedItem;
                int fkIdEmpleado = selected.Id;

                string contraseñaHasheada = SeguridadHash.HashearSHA256(Txt_Contraseña.Text);

                usuarioControlador.ActualizarUsuario(
                    idUsuarioSeleccionado,
                    fkIdEmpleado,
                    Txt_Nombre.Text,
                    contraseñaHasheada,
                    0,
                    true,
                    DateTime.Now,
                    DateTime.Now,
                    false
                );

                MessageBox.Show("Usuario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Modificar usuario", true);

                LimpiarCampos();
                ConfiguracionInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LimpiarCampos()
        {
            Cbo_Empleado.SelectedIndex = -1;
            Txt_Nombre.Clear();
            Txt_Contraseña.Clear();
            idUsuarioSeleccionado = 0;
        }

        //aqui es para validar los campos

        private void Txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Txt_Contraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Cbo_Empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            Btn_Guardar.Enabled =
                Cbo_Empleado.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(Txt_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(Txt_Contraseña.Text);
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
            frmReporte_Usuario frm = new frmReporte_Usuario();
            frm.Show();
        }


        //0901-21-1115 Marcos Andres Velasquez Alcánatara -- permisos script
        //0901-22-9663 Brandon Alexander Hernandez Salguero --  asignacion Modulos y aplicaciones


        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {

            string nombreModulo = "Seguridad";
            string nombreAplicacion = "Administracion";
            aplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(nombreAplicacion);
            moduloId = permisoUsuario.ObtenerIdModuloPorNombre(nombreModulo);
            AplicarPermisosUsuario();
        }

        private void AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado
            if (aplicacionId == -1 || moduloId == -1)
            {
                permisosActuales = null;
                ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);
            permisosActuales = permisos;
            ActualizarEstadoBotonesSegunPermisos();
        }

        // Centraliza el habilitado/deshabilitado de botones según permisos y estado de navegación
        private void ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
        {
            if (!permisosActuales.HasValue)
            {
                Btn_Nuevo.Enabled = false;
                Btn_reporte.Enabled = false;
                Btn_Guardar.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Limpiar.Enabled = false;


                return;
            }

            var p = permisosActuales.Value;


            Btn_Nuevo.Enabled = p.ingresar;
            Btn_reporte.Enabled = p.imprimir|| p.consultar;
            Btn_Guardar.Enabled = p.ingresar || p.modificar;
            Btn_Modificar.Enabled = p.modificar;
            Btn_Limpiar.Enabled = p.modificar|| p.ingresar ||p.eliminar;

        }


    }
}




