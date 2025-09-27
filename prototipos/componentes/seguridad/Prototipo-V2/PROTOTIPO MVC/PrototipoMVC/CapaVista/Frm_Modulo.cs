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

     

        // Instancia del controlador
        Cls_ModulosControlador cm = new Cls_ModulosControlador();

        public Frm_Modulo()
        {
            InitializeComponent();
            fun_ConfigurarIdsDinamicamenteYAplicarPermisos();
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


        //Marcos Andres Velásquez Alcántara
        //Carnet: 0901-21-1115

        private Cls_PermisoUsuario gPermisoUsuario = new Cls_PermisoUsuario();

        private List<(int iModuloId, int iAplicacionId)> gParesModuloAplicacion = new List<(int, int)>();

        private Dictionary<(int moduloId, int aplicacionId), (bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)> gPermisosPorModuloApp
            = new Dictionary<(int, int), (bool, bool, bool, bool, bool)>();


        private void fun_ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            int usuarioId = Cls_sesion.iUsuarioId;

            var sParesNombres = new List<(string sModulo, string sAplicacion)>
    {
        
        ("Seguridad", "Empleados"),
         ("Seguridad", "Gestion de empleado"),
        ("Seguridad", "Administracion"),
    };

            foreach (var (sNombreModulo, sNombreAplicacion) in sParesNombres)
            {
                int idModulo = gPermisoUsuario.ObtenerIdModuloPorNombre(sNombreModulo);
                int idAplicacion = gPermisoUsuario.ObtenerIdAplicacionPorNombre(sNombreAplicacion);

                if (idModulo != -1 && idAplicacion != -1)
                {
                    gParesModuloAplicacion.Add((idModulo, idAplicacion));
                }
            }

            fun_AplicarPermisosUsuario(usuarioId);
        }

        private void fun_AplicarPermisosUsuario(int usuarioId)
        {
            foreach (var (moduloId, aplicacionId) in gParesModuloAplicacion)
            {
                var bPermisos = gPermisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);

                if (bPermisos != null)
                {
                    gPermisosPorModuloApp[(moduloId, aplicacionId)] = bPermisos.Value;
                }
            }

            fun_CombinarPermisosYActualizarBotones();
        }

        private void fun_CombinarPermisosYActualizarBotones()
        {
            bool bIngresar = false;
            bool bConsultar = false;
            bool bModificar = false;
            bool bEliminar = false;

            foreach (var bPermiso in gPermisosPorModuloApp.Values)
            {
                bIngresar |= bPermiso.bIngresar;
                bConsultar |= bPermiso.bConsultar;
                bModificar |= bPermiso.bModificar;
                bEliminar |= bPermiso.bEliminar;
            }

            


            Btn_buscar.Enabled = bConsultar;
            Btn_reporte.Enabled = bConsultar;
            Btn_guardar.Enabled = bIngresar;
            Btn_eliminar.Enabled = bEliminar;
            Btn_nuevo.Enabled = bIngresar;
        }



       
        
    }
}
