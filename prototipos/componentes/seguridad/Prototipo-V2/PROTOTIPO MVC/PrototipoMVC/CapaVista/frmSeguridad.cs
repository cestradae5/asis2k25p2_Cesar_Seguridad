using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Modelo_Seguridad;
using Capa_Controlador_Seguridad;


namespace Capa_Vista_Seguridad
{
    public partial class frmSeguridad : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador();
        private int iIChildFormNumber = 0;

        //Ruben Armando Lopez Luch
        //0901-20-4620
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
        // fin -> Ruben Armando Lopez Luch

        public frmSeguridad()
        {
            InitializeComponent();
            InicializarMenuItems();
            fun_inicializar_botones_por_defecto();
            fun_habilitar_botones_por_permisos(Cls_UsuarioConectado.iIdUsuario);
        }

        //Ruben Armando Lopez Luch
        //0901-20-4620
        private void InicializarMenuItems()
        {
            menuItems = new Dictionary<MenuOpciones, ToolStripMenuItem>
            {
                { MenuOpciones.Archivo, archivoToolStripMenuItem },
                { MenuOpciones.Catalogos, catálogosToolStripMenuItem },
                { MenuOpciones.Procesos, procesosToolStripMenuItem },
                { MenuOpciones.Reportes, reportesToolStripMenuItem },
                { MenuOpciones.Herramientas, herramientasToolStripMenuItem },
                { MenuOpciones.Ayuda, ayudaToolStripMenuItem },
                { MenuOpciones.Asignaciones, asignacionesToolStripMenuItem },
                
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
            fun_inicializar_botones_por_defecto();
            SentenciaAsignacionUsuarioAplicacion modelo = new SentenciaAsignacionUsuarioAplicacion();
            DataTable dtPermisos = modelo.ObtenerPermisosPorUsuario(iIdUsuario);
            bool bTienePermisoSeguridad = dtPermisos.AsEnumerable()
                .Any(row => row["nombre_modulo"].ToString() == "Seguridad");
            if (bTienePermisoSeguridad)
            {
                menuItems[MenuOpciones.Catalogos].Enabled = true;
                menuItems[MenuOpciones.Procesos].Enabled = true;
                menuItems[MenuOpciones.Reportes].Enabled = true;
                menuItems[MenuOpciones.Asignaciones].Enabled = true;
            }
        }

        public void fun_babilitar_botones_seguridad(string sModulo)
        {
            if (sModulo == "Seguridad")
            {
                menuItems[MenuOpciones.Catalogos].Enabled = true;
                menuItems[MenuOpciones.Procesos].Enabled = true;
                menuItems[MenuOpciones.Reportes].Enabled = true;
                menuItems[MenuOpciones.Asignaciones].Enabled = true;
                menuItems[MenuOpciones.Modulos].Enabled = true;
            }
            else
            {
                fun_inicializar_botones_por_defecto();
            }
        }

        // fin -> Ruben Armando Lopez Luch
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + iIChildFormNumber++;
            childForm.Show();
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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

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
            ctrlBitacora.RegistrarCierreSesion(Cls_UsuarioConectado.iIdUsuario);
            frmPrincipal ventanaPrincipal = new frmPrincipal();
            ventanaPrincipal.Show();
            this.Close();
        }

        private void btn_aplicacion_Click(object sender, EventArgs e)
        {

        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados formEmpleado = new frmEmpleados();
            formEmpleado.Show();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asignacionDeAplicacionAUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmasignacion_aplicacion_usuario asig_app_user = new frmasignacion_aplicacion_usuario();
            asig_app_user.Show();
        }

        private void asignacionPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmasignacion_perfil_usuario asig_perfil = new frmasignacion_perfil_usuario();
            asig_perfil.Show();
        }

        private void perfilesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPerfiles perfiles = new frmPerfiles();
            perfiles.Show();
        }

        private void modulosDeCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModulo formModulo = new frmModulo();
            formModulo.MdiParent = this;
            formModulo.Show();
        }

        private void Btn_Aplicacion_Click_1(object sender, EventArgs e)
        {
            FrmAplicacion formAplicacion = new FrmAplicacion();
            formAplicacion.Show();
        }

        private void Btn_Bitacora_Click(object sender, EventArgs e)
        {
            Frm_Bitacora frm = new Frm_Bitacora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmpleados formEmpleado = new frmEmpleados();
            formEmpleado.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_cambiar_contrasena ventana = new frm_cambiar_contrasena(Cls_sesion.iUsuarioId);
            ventana.Show();
        }

        private void asignacionPermisoPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPermisosPerfiles permisoperfil = new FrmPermisosPerfiles();
            permisoperfil.Show();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmModulo modulo = new frmModulo();
            modulo.Show();
        }
    }
}
