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
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();  //Controlador de Bitacora
        private Cls_ControladorAsignacionUsuarioAplicacion controladorPermisos = new Cls_ControladorAsignacionUsuarioAplicacion();
        private int iIChildFormNumber = 0;

        public enum MenuOpciones
        {
            Archivo,
            Catalogos,
            Procesos,
            Reportes,
            Herramientas,
            Ayuda,
            Asignaciones,
            Modulos
        }

        private Dictionary<MenuOpciones, ToolStripMenuItem> menuItems;



        public Frm_Seguridad()
        {
            InitializeComponent();
            InicializarMenuItems();
            fun_inicializar_botones_por_defecto();
            fun_habilitar_botones_por_permisos(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario);

            // Suscribirse al evento FormClosing
            this.FormClosing += Frm_Seguridad_FormClosing;
        }
        private void Frm_Seguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Cierra todo el programa
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
                { MenuOpciones.Ayuda, ayudaToolStripMenuItem },
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
                    case MenuOpciones.Ayuda:
                        menuItems[opcion].Enabled = true;
                        break;
                    default:
                        menuItems[opcion].Enabled = false;
                        break;
                }
            }
        }

        public void fun_habilitar_botones_por_permisos(int iIdUsuario)
        {
            // Inicializar todo deshabilitado
            fun_inicializar_botones_por_defecto();

            // Obtener permisos desde el Controlador
            DataTable dtPermisos = controladorPermisos.ObtenerPermisosPorUsuario(iIdUsuario);

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
                {306, asignacionDeAplicacionAUsuarioToolStripMenuItem}
            };

            Dictionary<int, ToolStripMenuItem> mapaAsignaciones = new Dictionary<int, ToolStripMenuItem>
            {
                {306, asignacionDeAplicacionAUsuarioToolStripMenuItem},
                {307, asignacionDeAplicacionAPerfilesToolStripMenuItem},
                {308, asignacionPerfilesToolStripMenuItem}
            };

            // Inicializar submenús deshabilitados
            foreach (var sub in mapaCatalogos.Values) sub.Enabled = false;
            foreach (var sub in mapaProcesos.Values) sub.Enabled = false;
            foreach (var sub in mapaAsignaciones.Values) sub.Enabled = false;

            // Recorrer permisos
            foreach (DataRow row in dtPermisos.Rows)
            {
                int idModulo = Convert.ToInt32(row["fk_id_modulo"]);
                int idAplicacion = Convert.ToInt32(row["fk_id_aplicacion"]);

                // Solo idModulo = 4 y idAplicacion 301-308
                if (idModulo == 4 && idAplicacion >= 301 && idAplicacion <= 308)
                {
                    if (mapaCatalogos.ContainsKey(idAplicacion))
                        mapaCatalogos[idAplicacion].Enabled = true;

                    if (mapaProcesos.ContainsKey(idAplicacion))
                        mapaProcesos[idAplicacion].Enabled = true;

                    if (mapaAsignaciones.ContainsKey(idAplicacion))
                        mapaAsignaciones[idAplicacion].Enabled = true;
                }
            }

            // Habilitar menús principales solo si algún submenú está habilitado
            if (mapaCatalogos.Values.Any(m => m.Enabled)) menuItems[MenuOpciones.Catalogos].Enabled = true;
            if (mapaProcesos.Values.Any(m => m.Enabled)) menuItems[MenuOpciones.Procesos].Enabled = true;
            if (mapaAsignaciones.Values.Any(m => m.Enabled)) menuItems[MenuOpciones.Asignaciones].Enabled = true;

            // Modulos siempre habilitar si tiene algún permiso del módulo 4
            if (mapaCatalogos.ContainsKey(304) && mapaCatalogos[304].Enabled)
                menuItems[MenuOpciones.Modulos].Enabled = true;
        }

        // NUEVO MÉTODO PARA CERRAR HIJOS
        //Brandon Alexander Hernandez Salguero  0901-22-9663
        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        // MODIFICA TODOS LOS HANDLERS PARA ABRIR HIJOS
        //Brandon Alexander Hernandez Salguero 0901-22-9663

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

        // Los formularios que NO son MDI (ShowDialog) NO necesitan cerrar hijos.
        private void Btn_Aplicacion_Click_1(object sender, EventArgs e)
        {
            // 1. Cierra todos los formularios hijos MDI existentes (incluyendo Frm_Modulo si está abierto)
            CerrarFormulariosHijos();

            // 2. Crea la nueva instancia del formulario
            FrmAplicacion formAplicacion = new FrmAplicacion();

            // 3. Establece el formulario de Seguridad (this) como el padre MDI
            formAplicacion.MdiParent = this;

            // 4. Muestra el formulario como un hijo MDI
            formAplicacion.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_cambiar_contrasena ventana = new Frm_cambiar_contrasena(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario);
            ventana.Show();
        }

        // Los que no abren formularios hijos no requieren cambio:
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
            Frm_Principal ventanaPrincipal = new Frm_Principal();
            ventanaPrincipal.Show();
        }

        private void btn_aplicacion_Click(object sender, EventArgs e) { }
        private void asignacionesToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void asignacionDeAplicacionAPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Frm_PermisosPerfiles asig_app_user = new Frm_PermisosPerfiles();
            asig_app_user.MdiParent = this;
            asig_app_user.Show();
        }

    }
}
