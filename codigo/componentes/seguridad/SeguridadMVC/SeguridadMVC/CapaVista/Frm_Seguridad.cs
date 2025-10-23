using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Seguridad : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        private Cls_ControladorAsignacionUsuarioAplicacion controladorPermisos = new Cls_ControladorAsignacionUsuarioAplicacion();
        private Cls_Asignacion_Permiso_PerfilControlador controladorPermisosPerfil = new Cls_Asignacion_Permiso_PerfilControlador();
        private int iIChildFormNumber = 0;

        public enum MenuOpciones
        {
            Archivo,
            Catalogos,
            Procesos,
            Reportes,
            Herramientas,
            Asignaciones,
            Modulos
        }

        private Dictionary<MenuOpciones, ToolStripMenuItem> menuItems;

        public Frm_Seguridad()
        {
            InitializeComponent();
            InicializarMenuItems();
            fun_inicializar_botones_por_defecto();

            this.Load += Frm_Seguridad_Load;

            fun_habilitar_botones_por_permisos_combinados(
                Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario,
                Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdPerfil
            );

            this.FormClosing += Frm_Seguridad_FormClosing;
        }
        private void Frm_Seguridad_Load(object sender, EventArgs e)
        {
            // Mostrar usuario conectado en StatusStrip
            toolStripStatusLabel.Text = $"Estado: Conectado | Usuario: {Capa_Controlador_Seguridad.Cls_Usuario_Conectado.sNombreUsuario}";

            // El resto de tu código de carga...
            fun_inicializar_botones_por_defecto();
            fun_habilitar_botones_por_permisos_combinados(
                Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario,
                Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdPerfil
            );
        }
        private void Frm_Seguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void InicializarMenuItems()
        {
            menuItems = new Dictionary<MenuOpciones, ToolStripMenuItem>
            {
                { MenuOpciones.Archivo, archivoToolStripMenuItem },
                { MenuOpciones.Catalogos, catálogosToolStripMenuItem },
                { MenuOpciones.Procesos, procesosToolStripMenuItem },
                { MenuOpciones.Herramientas, herramientasToolStripMenuItem },
                { MenuOpciones.Asignaciones, asignacionesToolStripMenuItem },
                { MenuOpciones.Modulos, modulosToolStripMenuItem }
            };
        }

        public void fun_inicializar_botones_por_defecto()
        {
            foreach (var opcion in menuItems.Keys)
            {
                switch (opcion)
                {
                    case MenuOpciones.Archivo:
                    case MenuOpciones.Herramientas:
                        menuItems[opcion].Enabled = true;
                        break;
                    default:
                        menuItems[opcion].Enabled = false;
                        break;
                }
            }
        }

        // 0901-20-4620 Ruben Lopez 12/10/25
        //0901-22-9663 Brandon Hernandez 12/10/25
        public void fun_habilitar_botones_por_permisos_combinados(int iIdUsuario, int iIdPerfil)
        {
            // Diccionarios de idAplicacion -> submenú
            Dictionary<int, ToolStripMenuItem> mapaCatalogos = new Dictionary<int, ToolStripMenuItem>
            {
                {301, empleadosToolStripMenuItem1},
                {302, usuariosToolStripMenuItem},
                {303, perfilesToolStripMenuItem},
                {304, modulosToolStripMenuItem},
                {305, Btn_Aplicacion}
            };

            Dictionary<int, ToolStripMenuItem> mapaProcesos = new Dictionary<int, ToolStripMenuItem>
            {
                {309, procesosToolStripMenuItem }
            };

            Dictionary<int, ToolStripMenuItem> mapaAsignaciones = new Dictionary<int, ToolStripMenuItem>
            {
                {306, asignacionDeAplicacionAUsuarioToolStripMenuItem},
                {307, asignacionDeAplicacionAPerfilesToolStripMenuItem},
                {308, asignacionPerfilesToolStripMenuItem}
            };

            // 1. DESHABILITA TODOS LOS SUBMENÚS ANTES DE HABILITAR PERMISOS
            foreach (var sub in mapaCatalogos.Values) sub.Enabled = false;
            foreach (var sub in mapaProcesos.Values) sub.Enabled = false;
            foreach (var sub in mapaAsignaciones.Values) sub.Enabled = false;

            // 2. Permisos por perfil (primer filtro)
            DataTable dtPermisosPerfil = controladorPermisosPerfil.datObtenerPermisosPorPerfil(iIdPerfil);
            foreach (DataRow row in dtPermisosPerfil.Rows)
            {
                int idModulo = Convert.ToInt32(row["iFk_id_modulo"]);
                int idAplicacion = Convert.ToInt32(row["iFk_id_aplicacion"]);
                if (idModulo == 4 && idAplicacion >= 301 && idAplicacion <= 309)
                {
                    if (mapaCatalogos.ContainsKey(idAplicacion))
                        mapaCatalogos[idAplicacion].Enabled = true;
                    if (mapaProcesos.ContainsKey(idAplicacion))
                        mapaProcesos[idAplicacion].Enabled = true;
                    if (mapaAsignaciones.ContainsKey(idAplicacion))
                        mapaAsignaciones[idAplicacion].Enabled = true;
                }
            }

            // 3. Permisos por usuario (segundo filtro - suma, nunca deshabilita)
            DataTable dtPermisosUsuario = controladorPermisos.ObtenerPermisosPorUsuario(iIdUsuario);
            foreach (DataRow row in dtPermisosUsuario.Rows)
            {
                int idModulo = Convert.ToInt32(row["iFk_id_modulo"]);
                int idAplicacion = Convert.ToInt32(row["iFk_id_aplicacion"]);
                if (idModulo == 4 && idAplicacion >= 301 && idAplicacion <= 309)
                {
                    if (mapaCatalogos.ContainsKey(idAplicacion))
                        mapaCatalogos[idAplicacion].Enabled = true;
                    if (mapaProcesos.ContainsKey(idAplicacion))
                        mapaProcesos[idAplicacion].Enabled = true;
                    if (mapaAsignaciones.ContainsKey(idAplicacion))
                        mapaAsignaciones[idAplicacion].Enabled = true;
                }
            }

            // 4. Habilita menús principales solo si algún submenú está habilitado
            menuItems[MenuOpciones.Catalogos].Enabled = mapaCatalogos.Values.Any(m => m.Enabled);
            menuItems[MenuOpciones.Procesos].Enabled = mapaProcesos.Values.Any(m => m.Enabled);
            menuItems[MenuOpciones.Asignaciones].Enabled = mapaAsignaciones.Values.Any(m => m.Enabled);

            // Modulos siempre habilitar si tiene algún permiso del módulo 4
            menuItems[MenuOpciones.Modulos].Enabled = mapaCatalogos.ContainsKey(304) && mapaCatalogos[304].Enabled;
        }

        // --- El resto de tus métodos siguen igual ---
        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + iIChildFormNumber++;
            childForm.Show();
        }
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Empleados formEmpleado = new Frm_Empleados();
            formEmpleado.MdiParent = this;
            formEmpleado.Show();
        }
        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Empleados formEmpleado = new Frm_Empleados();
            formEmpleado.MdiParent = this;
            formEmpleado.Show();
        }
        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Perfiles perfiles = new Frm_Perfiles();
            perfiles.MdiParent = this;
            perfiles.Show();
        }
        private void perfilesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Perfiles perfiles = new Frm_Perfiles();
            perfiles.MdiParent = this;
            perfiles.Show();
        }
        private void modulosDeCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Modulo formModulo = new Frm_Modulo();
            formModulo.MdiParent = this;
            formModulo.Show();
        }
        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Modulo modulo = new Frm_Modulo();
            modulo.MdiParent = this;
            modulo.Show();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Usuario frm = new Frm_Usuario();
            frm.MdiParent = this;
            frm.Show();
        }
        private void Btn_Bitacora_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Bitacora frm = new Frm_Bitacora();
            frm.MdiParent = this;
            frm.Show();
        }
        private void asignacionDeAplicacionAUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_asignacion_aplicacion_usuario asig_app_user = new Frm_asignacion_aplicacion_usuario();
            asig_app_user.MdiParent = this;
            asig_app_user.Show();
        }
        private void asignacionPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_asignacion_perfil_usuario asig_perfil = new Frm_asignacion_perfil_usuario();
            asig_perfil.MdiParent = this;
            asig_perfil.Show();
        }
        private void Btn_Aplicacion_Click_1(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            FrmAplicacion formAplicacion = new FrmAplicacion();
            formAplicacion.MdiParent = this;
            formAplicacion.Show();
        }
        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_cambiar_contrasena ventana = new Frm_cambiar_contrasena(Capa_Controlador_Seguridad.Cls_Usuario_Conectado.iIdUsuario);
            ventana.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Principal ventanaPrincipal = new Frm_Principal();
            ventanaPrincipal.ShowDialog();
            this.Close();
        }
        private void btn_aplicacion_Click(object sender, EventArgs e) { }
        private void asignacionesToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void asignacionDeAplicacionAPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_Permisos_Perfiles asig_app_user = new Frm_Permisos_Perfiles();
            asig_app_user.MdiParent = this;
            asig_app_user.Show();
        }

        private void Pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
