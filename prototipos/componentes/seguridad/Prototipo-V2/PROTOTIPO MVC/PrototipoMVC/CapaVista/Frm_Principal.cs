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
    public partial class Frm_Principal : Form
    {
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); //Controlador de bitacora
        private int childFormNumber = 0;
        private Cls_ControladorAsignacionUsuarioAplicacion ctrlSeguridad;

        private int iIdUsuario;
        private string sNombreUsuario;

        public Frm_Principal()
        {
            InitializeComponent();
            ctrlSeguridad = new Cls_ControladorAsignacionUsuarioAplicacion();
            this.Load += frmPrincipal_Load;
            // Suscribirse al evento FormClosing
            this.FormClosing += Frm_principal_FormClosing;
        }
        private void Frm_principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmación opcional

            // Cierra toda la aplicación
            Application.Exit();

        }

        public Frm_Principal(string nombreUsuario, int idUsuario)
        {
            InitializeComponent();
            ctrlSeguridad = new Cls_ControladorAsignacionUsuarioAplicacion();

            sNombreUsuario = nombreUsuario;
            iIdUsuario = idUsuario;

            this.Load += frmPrincipal_Load;
        }


        // Ruben Armando Lopez Luch
        // 0901-20-4620
        // Activar solo Seguridad
        private void fun_activar_menus_por_permiso(int iIdUsuario)
        {
            var permisos = ctrlSeguridad.ObtenerPermisosPorUsuario(iIdUsuario);

            foreach (DataRow fila in permisos.Rows)
            {
                string sNombreModulo = fila["nombre_aplicacion"].ToString();

                if (sNombreModulo == "Seguridad")
                {
                    seguridadToolStripMenuItem.Enabled = true;
                }
            }
        }
        // fin -> Ruben Armando Lopez Luch

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
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
            // Registrar en bitácora //Aron Ricardo Esquit Silva   0901-22-13036
            ctrlBitacora.RegistrarCierreSesion(Cls_UsuarioConectado.iIdUsuario);
            Frm_Login ventana = new Frm_Login();
            ventana.Show();
            this.Hide();
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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Seguridad formSeguridad = new Frm_Seguridad();
            formSeguridad.Show();
            this.Hide();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            // Mostrar usuario conectado en StatusStrip usando la clase estática Cls_UsuarioConectado
            // Esto asegura que siempre se muestre el nombre correcto del usuario real
            toolStripStatusLabel1.Text = $"Estado: Conectado | Usuario: {Cls_UsuarioConectado.sNombreUsuario}";

            // Activar menús según permisos del usuario
            fun_activar_menus_por_permiso(Cls_UsuarioConectado.iIdUsuario);
        }

    }

}
