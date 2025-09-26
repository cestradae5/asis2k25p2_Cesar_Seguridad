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
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Modulo : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); //Bitacora

        // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
        private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

        private int moduloId = -1;
        private int aplicacionId = -1;

        // Tupla para los permisos actuales
        private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;

        // Instancia del controlador
        Cls_ModulosControlador cm = new Cls_ModulosControlador();

        public Frm_Modulo()
        {
            InitializeComponent();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
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
                // Valida  que no existe un Id repetido
                if (cm.BuscarModulo(id) != null)
                {
                    MessageBox.Show("El Id ingresado ya existe. Use otro.");
                    return;
                }

                // Insertar
                resultado = cm.InsertarModulo(id, nombre, descripcion, estado);
            }
            else
            {
                // Modificar 
                resultado = cm.ModificarModulo(id, nombre, descripcion, estado);
            }

            if (resultado)
            {
                MessageBox.Show("Guardado correctamente!");
                CargarComboBox();

                // Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Guardar módulo", true);

                //Limpiar campos después de guardar
                LimpiarCampos();
                Txt_id.Enabled = true; // Reactivar para nuevos registros
            }
            else
            {
                MessageBox.Show("Error al guardar el módulo.");
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
         // elimina un dato
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

            // Verificar si el módulo está en uso
            if (cm.ModuloEnUso(id))
            {
                MessageBox.Show("No se puede eliminar el módulo porque está siendo utilizado en una aplicación.");
                return;
            }

            bool resultado = cm.EliminarModulo(id); // Elimina físicamente
            if (resultado)
            {
                MessageBox.Show("Módulo eliminado correctamente.");
                CargarComboBox();

                // Registrar en Bitácora - Arón Ricardo Esquit Silva 0901-22-13036
                ctrlBitacora.RegistrarAccion(Cls_UsuarioConectado.iIdUsuario, 1, "Eliminar módulo", true);

                // Limpiar campos después de eliminar
                LimpiarCampos();
                Txt_id.Enabled = true; // Rehabilitar el Id después de eliminar
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
             
                Txt_id.Text = dr["Pk_Id_Modulo"].ToString();
                Txt_nombre.Text = dr["Cmp_Nombre_Modulo"].ToString();
                Txt_descripcion.Text = dr["Cmp_Descripcion_Modulo"].ToString();

                bool estado = Convert.ToBoolean(dr["Cmp_Estado_Modulo"]);
                Rdb_habilitado.Checked = estado;
                Rdb_inabilitado.Checked = !estado;

                //  Bloquear el Id para que no pueda ser modificado si esta en uso
                Txt_id.Enabled = false;

                // Limpiar el ComboBox después de buscar
                Cbo_busqueda.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Módulo no encontrado.");
            }
        }

        // limpia TextBox, RadioButtons y ComboBox
        private void LimpiarCampos()
        {
            Txt_id.Clear();
            Txt_nombre.Clear();
            Txt_descripcion.Clear();
            Rdb_habilitado.Checked = false;
            Rdb_inabilitado.Checked = false;
            Cbo_busqueda.SelectedIndex = -1;
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
            Frm_Reporte_modulos frm = new Frm_Reporte_modulos();
            frm.Show();
        }

        //0901-21-1115 Marcos Andres Velasquez Alcánatara

        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            string nombreModulo = "RHM";
            string nombreAplicacion = "Empleados";
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
                Btn_buscar.Enabled = false;
                Btn_reporte.Enabled = false;
                Btn_guardar.Enabled = false;
                Btn_eliminar.Enabled = false;
                Btn_nuevo.Enabled = false;
                return;
            }

            var p = permisosActuales.Value;

            Btn_buscar.Enabled = p.consultar;
            Btn_reporte.Enabled = p.consultar;
            Btn_guardar.Enabled = p.ingresar;
            Btn_eliminar.Enabled = p.eliminar;
            Btn_nuevo.Enabled = p.ingresar;
        }
    }
}
