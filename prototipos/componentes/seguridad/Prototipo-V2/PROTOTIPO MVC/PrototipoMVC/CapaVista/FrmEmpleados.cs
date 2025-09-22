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
    public partial class frmEmpleados : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacroa
        private Cls_EmpleadoControlador controlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaEmpleados = new List<Cls_Empleado>();

        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Guardamos el objeto permisos actual para usarlo en todo el form
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;

        public frmEmpleados()
        {
            InitializeComponent();
            CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_ConfiguracionInicial();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
        }

        /// <summary>
        /// Consulta los IDs de módulo y aplicación por nombre y aplica los permisos del usuario logueado.
        /// </summary>
        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            string nombreModulo = "Empleados";     // nombre exacto en tbl_MODULO
            string nombreAplicacion = "Empleados"; // nombre exacto en tbl_APLICACION

            aplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(nombreAplicacion);
            moduloId = permisoUsuario.ObtenerIdModuloPorNombre(nombreModulo);

            AplicarPermisosUsuario();
        }

        private void AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado

            if (aplicacionId == -1 || moduloId == -1)
            {
                // Si no se encontraron los IDs, deshabilita todo
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
            // Si no hay permisos, todo deshabilitado
            if (!permisosActuales.HasValue)
            {
                Btn_guardar_empleado.Enabled = false;
                Btn_modificar_empleado.Enabled = false;
                Btn_eliminar_empleado.Enabled = false;
                Btn_nuevo_empleado.Enabled = false;
                Btn_buscar_empleado.Enabled = false;
                
                return;
            }

            var p = permisosActuales.Value;

            // Siempre puedes buscar si tienes consultar
            Btn_buscar_empleado.Enabled = p.consultar;

            // "Nuevo" y "Guardar" dependen de ingresar
            Btn_nuevo_empleado.Enabled = p.ingresar;
            Btn_guardar_empleado.Enabled = false; // Solo habilitado en flujo de "nuevo" o "guardar"

            // Modificar y eliminar solo si hay un empleado cargado y el permiso existe
            Btn_modificar_empleado.Enabled = empleadoCargado && p.modificar;
            Btn_eliminar_empleado.Enabled = empleadoCargado && p.eliminar;


        }

        private void func_ConfiguracionInicial()
        {
            // Por defecto, ningún empleado está cargado
            ActualizarEstadoBotonesSegunPermisos(empleadoCargado: false);
            Btn_cancelar.Enabled = true;
            Txt_id_empleado.Enabled = false;
        }

        private void func_CargarEmpleados()
        {
            listaEmpleados = controlador.ObtenerTodosLosEmpleados();
        }

        private void CargarEmpleados()
        {
            listaEmpleados = controlador.ObtenerTodosLosEmpleados();
        }

        private void func_ConfigurarComboBoxEmpleados()
        {
            Cbo_mostrar_empleado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_mostrar_empleado.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaEmpleados.Select(a => a.PkIdEmpleado.ToString()).ToArray());
            autoComplete.AddRange(listaEmpleados.Select(a => a.NombresEmpleado).ToArray());
            Cbo_mostrar_empleado.AutoCompleteCustomSource = autoComplete;

            Cbo_mostrar_empleado.DisplayMember = "Display";
            Cbo_mostrar_empleado.ValueMember = "Id";

            Cbo_mostrar_empleado.Items.Clear();
            foreach (var emp in listaEmpleados)
            {
                Cbo_mostrar_empleado.Items.Add(new
                {
                    Display = $"{emp.PkIdEmpleado} - {emp.NombresEmpleado} {emp.ApellidosEmpleado}",
                    Id = emp.PkIdEmpleado
                });
            }
        }

        private void MostrarEmpleado(Cls_Empleado emp)
        {
            Txt_id_empleado.Text = emp.PkIdEmpleado.ToString();
            Txt_nombre_empleado.Text = emp.NombresEmpleado;
            Txt_apellido_empleado.Text = emp.ApellidosEmpleado;
            Txt_dpi_empleados.Text = emp.DpiEmpleado.ToString();
            Txt_nit_empleados.Text = emp.NitEmpleado.ToString();
            Txt_correo_empleado.Text = emp.CorreoEmpleado;
            Txt_telefono_empleado.Text = emp.TelefonoEmpleado;
            Txt_fechaNac_empleado.Text = emp.FechaNacimientoEmpleado.ToString("yyyy-MM-dd");
            Txt_fechaContra_empleado.Text = emp.FechaContratacionEmpleado.ToString("yyyy-MM-dd");
            Rdb_masculino_empleado.Checked = emp.GeneroEmpleado;
            Rdb_femenino_empleado.Checked = !emp.GeneroEmpleado;
        }

        private void Txt_id_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_nombre_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_dpi_empleados_TextChanged(object sender, EventArgs e) { }
        private void Txt_fechaNac_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_apellido_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_nit_empleados_TextChanged(object sender, EventArgs e) { }
        private void Txt_fechaContra_empleado_TextChanged(object sender, EventArgs e) { }
        private void Txt_correo_empleado_TextChanged(object sender, EventArgs e) { }
        private void Rdb_masculino_empleado_CheckedChanged(object sender, EventArgs e) { }
        private void Rdb_femenino_empleado_CheckedChanged(object sender, EventArgs e) { }

        // Al buscar, sólo habilitar modificar/eliminar si hay permiso
        private void Btn_buscar_empleado_Click(object sender, EventArgs e)
        {
            string busqueda = Cbo_mostrar_empleado.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }

            Cls_Empleado empEncontrado = null;

            if (int.TryParse(busqueda.Split('-')[0].Trim(), out int id))
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a => a.PkIdEmpleado == id);
            }

            if (empEncontrado == null)
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a =>
                    a.NombresEmpleado.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (empEncontrado != null)
            {
                MostrarEmpleado(empEncontrado);
                // Actualiza botones según permisos y que hay un empleado cargado
                ActualizarEstadoBotonesSegunPermisos(empleadoCargado: true);
            }
            else
            {
                MessageBox.Show("Empleado no encontrado");
                func_LimpiarCampos();
                ActualizarEstadoBotonesSegunPermisos(empleadoCargado: false);
            }
        }

        // Botón nuevo: solo limpia y deja listo para guardar si tienes permiso
        private void Btn_nuevo_empleado_Click(object sender, EventArgs e)
        {
            if (!permisosActuales.HasValue || !permisosActuales.Value.ingresar)
            {
                MessageBox.Show("No tienes permisos para agregar nuevos empleados.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            func_LimpiarCampos();
            Btn_guardar_empleado.Enabled = true;
            Btn_modificar_empleado.Enabled = false;
            Btn_eliminar_empleado.Enabled = false;
            Txt_id_empleado.Enabled = true;
        }

        // Botón modificar: solo si tienes permiso
        private void Btn_modificar_empleado_Click(object sender, EventArgs e)
        {
            if (!permisosActuales.HasValue || !permisosActuales.Value.modificar)
            {
                MessageBox.Show("No tienes permisos para modificar empleados.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(Txt_id_empleado.Text, out id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            bool exito = controlador.ActualizarEmpleado(
                id,
                Txt_nombre_empleado.Text,
                Txt_apellido_empleado.Text,
                long.Parse(Txt_dpi_empleados.Text),
                long.Parse(Txt_nit_empleados.Text),
                Txt_correo_empleado.Text,
                Txt_telefono_empleado.Text,
                Rdb_masculino_empleado.Checked,
                DateTime.Parse(Txt_fechaNac_empleado.Text),
                DateTime.Parse(Txt_fechaContra_empleado.Text)
            );

            MessageBox.Show(exito ? "Empleado modificado correctamente" : "Error al modificar empleado");
            //Registrar en Bitácora - Arón Ricardo Esquit Silva
            ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, aplicacionId, "Modificar empleado", true);
            func_CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_LimpiarCampos();
            ActualizarEstadoBotonesSegunPermisos(empleadoCargado: false);
        }

        // Botón eliminar: solo si tienes permiso
        private void Btn_eliminar_empleado_Click(object sender, EventArgs e)
        {
            if (!permisosActuales.HasValue || !permisosActuales.Value.eliminar)
            {
                MessageBox.Show("No tienes permisos para eliminar empleados.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(Txt_id_empleado.Text, out int id))
            {
                MessageBox.Show("ID no válido");
                return;
            }

            bool exito = controlador.BorrarEmpleado(id);
            MessageBox.Show(exito ? "Empleado eliminado" : "Error al eliminar");
            //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901 - 22 - 13036
            ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, aplicacionId, "Eliminar empleado", true);

            func_CargarEmpleados();
            func_ConfigurarComboBoxEmpleados();
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            func_LimpiarCampos();
            func_ConfiguracionInicial();
        }

        // Guardar: solo si tienes permiso de ingresar
        private void Btn_guardar_empleado_Click(object sender, EventArgs e)
        {
            if (!permisosActuales.HasValue || !permisosActuales.Value.ingresar)
            {
                MessageBox.Show("No tienes permisos para guardar empleados.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!int.TryParse(Txt_id_empleado.Text, out int idEmpleado))
                {
                    MessageBox.Show("ID no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(Txt_dpi_empleados.Text, out long dpi))
                {
                    MessageBox.Show("DPI no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(Txt_nit_empleados.Text, out long nit))
                {
                    MessageBox.Show("NIT no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(Txt_fechaNac_empleado.Text, out DateTime fechaNacimiento))
                {
                    MessageBox.Show("Fecha de nacimiento no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(Txt_fechaContra_empleado.Text, out DateTime fechaContratacion))
                {
                    MessageBox.Show("Fecha de contratación no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var emp = new Cls_Empleado
                {
                    PkIdEmpleado = idEmpleado,
                    NombresEmpleado = Txt_nombre_empleado.Text,
                    ApellidosEmpleado = Txt_apellido_empleado.Text,
                    DpiEmpleado = dpi,
                    NitEmpleado = nit,
                    CorreoEmpleado = Txt_correo_empleado.Text,
                    TelefonoEmpleado = Txt_telefono_empleado.Text,
                    GeneroEmpleado = Rdb_masculino_empleado.Checked,
                    FechaNacimientoEmpleado = fechaNacimiento,
                    FechaContratacionEmpleado = fechaContratacion
                };

                controlador.InsertarEmpleado(
                    emp.PkIdEmpleado,
                    emp.NombresEmpleado,
                    emp.ApellidosEmpleado,
                    emp.DpiEmpleado,
                    emp.NitEmpleado,
                    emp.CorreoEmpleado,
                    emp.TelefonoEmpleado,
                    emp.GeneroEmpleado,
                    emp.FechaNacimientoEmpleado,
                    emp.FechaContratacionEmpleado
                );

                MessageBox.Show("Empleado guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901 -22- 13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, aplicacionId, "Guardar empleado", true);


                CargarEmpleados();
                func_ConfigurarComboBoxEmpleados();
                func_LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            func_ConfiguracionInicial();
        }

        private void func_LimpiarCampos()
        {
            Txt_id_empleado.Clear();
            Txt_nombre_empleado.Clear();
            Txt_apellido_empleado.Clear();
            Txt_dpi_empleados.Clear();
            Txt_nit_empleados.Clear();
            Txt_correo_empleado.Clear();
            Txt_telefono_empleado.Clear();
            Txt_fechaNac_empleado.Clear();
            Txt_fechaContra_empleado.Clear();
            Rdb_masculino_empleado.Checked = false;
            Rdb_femenino_empleado.Checked = false;
        }

        private void Btn_salario_empleados_Click(object sender, EventArgs e)
        {
            frmSalarioEmpleados formSalarioEmpleado = new frmSalarioEmpleados();
            formSalarioEmpleado.Show();
        }

        private void Btn_salir_empleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Panel superior
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
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            frmReporte_Empleados frm = new frmReporte_Empleados();
            frm.Show();
        }
    }
}