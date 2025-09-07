using System;
using System.Windows.Forms;
using CapaControlador;
using System.Data;

namespace CapaVista
{
    public partial class frmasignacion_aplicacion_usuario : Form
    {
        ControladorAsignacionUsuarioAplicacion controlador = new ControladorAsignacionUsuarioAplicacion();
        /* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 * */
        public frmasignacion_aplicacion_usuario()
        {
            InitializeComponent();
            this.Load += frmAsignacion_aplicacion_usuario_Load;
        }

        private void frmAsignacion_aplicacion_usuario_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox Usuarios
            DataTable dtUsuarios = controlador.ObtenerUsuarios();
            Cbo_Usuarios.DataSource = dtUsuarios;
            Cbo_Usuarios.DisplayMember = "nombre_usuario";
            Cbo_Usuarios.ValueMember = "pk_id_usuario";
            Cbo_Usuarios.SelectedIndex = -1;

            // Llenar ComboBox Modulos
            DataTable dtModulos = controlador.ObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "nombre_modulo";
            Cbo_Modulos.ValueMember = "pk_id_modulo";
            Cbo_Modulos.SelectedIndex = -1;

            // Inicializar DataGridView Permisos
            InicializarDataGridView();
        }

        private void InicializarDataGridView()
        {
            Dgv_Permisos.Columns.Clear();
            Dgv_Permisos.Columns.Add("Usuario", "Usuario");
            Dgv_Permisos.Columns.Add("Aplicacion", "Aplicación");
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" });
        }

        private void Cbo_Modulos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Cbo_Modulos.SelectedValue != null)
            {
                int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);
                DataTable dtAplicaciones = controlador.ObtenerAplicacionesPorModulo(idModulo);

                Cbo_Aplicaciones.DataSource = dtAplicaciones;
                Cbo_Aplicaciones.DisplayMember = "nombre_aplicacion";
                Cbo_Aplicaciones.ValueMember = "pk_id_aplicacion";
                Cbo_Aplicaciones.SelectedIndex = -1;
            }
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (Cbo_Usuarios.SelectedIndex == -1 || Cbo_Modulos.SelectedIndex == -1 || Cbo_Aplicaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione usuario, módulo y aplicación.");
                return;
            }

            string usuario = Cbo_Usuarios.Text;
            string aplicacion = Cbo_Aplicaciones.Text;

            // Agregar fila al DataGridView con permisos por defecto (false)
            Dgv_Permisos.Rows.Add(usuario, aplicacion, false, false, false, false, false);

            // Limpiar selección de los ComboBox
            Cbo_Usuarios.SelectedIndex = -1;
            Cbo_Modulos.SelectedIndex = -1;
            Cbo_Aplicaciones.DataSource = null;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_agregar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
