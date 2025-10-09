using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;
//Brandon Alexander Hernandez Salguero - 0901-22-9663

namespace Capa_Vista_Seguridad
{
    public partial class Frm_PermisosPerfiles : Form
    {
        Cls_AplicacionControlador appControlador = new Cls_AplicacionControlador();
        Cls_Asignacion_Permiso_PerfilControador controlador = new Cls_Asignacion_Permiso_PerfilControador();
        Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Bitacora

        public Frm_PermisosPerfiles()
        {
            InitializeComponent();
            Dgv_Permisos.AllowUserToAddRows = false;
        }

        private void InicializarDataGridView()
        {
            Dgv_Permisos.Columns.Clear();
            Dgv_Permisos.Rows.Clear();

            Dgv_Permisos.Columns.Add("Perfil", "Perfil");
            Dgv_Permisos.Columns.Add("Aplicacion", "Aplicación");
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Ingresar", HeaderText = "Ingresar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Consultar", HeaderText = "Consultar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Modificar", HeaderText = "Modificar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Eliminar", HeaderText = "Eliminar" });
            Dgv_Permisos.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Imprimir", HeaderText = "Imprimir" });

            // IDs ocultos
            Dgv_Permisos.Columns.Add("IdPerfil", "IdPerfil");
            Dgv_Permisos.Columns["IdPerfil"].Visible = false;
            Dgv_Permisos.Columns.Add("IdModulo", "IdModulo");
            Dgv_Permisos.Columns["IdModulo"].Visible = false;
            Dgv_Permisos.Columns.Add("IdAplicacion", "IdAplicacion");
            Dgv_Permisos.Columns["IdAplicacion"].Visible = false;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPermisosPerfiles_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox Perfiles
            DataTable dtPerfiles = controlador.datObtenerPerfiles();
            Cbo_perfiles.DataSource = dtPerfiles;
            Cbo_perfiles.DisplayMember = "Cmp_Puesto_Perfil";
            Cbo_perfiles.ValueMember = "Pk_Id_Perfil";
            Cbo_perfiles.SelectedIndex = -1;

            // Llenar ComboBox Modulos
            DataTable dtModulos = controlador.datObtenerModulos();
            Cbo_Modulos.DataSource = dtModulos;
            Cbo_Modulos.DisplayMember = "Cmp_Nombre_Modulo";
            Cbo_Modulos.ValueMember = "Pk_Id_Modulo";
            Cbo_Modulos.SelectedIndex = -1;

            Cbo_Modulos.SelectedIndexChanged += Cbo_Modulos_SelectedIndexChanged;
            Cbo_aplicaciones.DataSource = null;
            Cbo_aplicaciones.Items.Clear();
            InicializarDataGridView();

            Dgv_Permisos.CellBeginEdit += Dgv_Permisos_CellBeginEdit;
            Dgv_Permisos.CellClick += Dgv_Permisos_CellClick;
        }

        private void Cbo_Modulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbo_aplicaciones.DataSource = null;
            Cbo_aplicaciones.Items.Clear();

            if (Cbo_Modulos.SelectedValue != null && !(Cbo_Modulos.SelectedValue is DataRowView))
            {
                int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);
                DataTable dtAplicacionFiltrada = controlador.datObtenerAplicacionesPorModulo(idModulo);

                Cbo_aplicaciones.DataSource = dtAplicacionFiltrada;
                Cbo_aplicaciones.DisplayMember = "Cmp_Nombre_Aplicacion";
                Cbo_aplicaciones.ValueMember = "Pk_Id_Aplicacion";
                Cbo_aplicaciones.SelectedIndex = -1;
            }
            else
            {
                Cbo_aplicaciones.DataSource = null;
                Cbo_aplicaciones.Items.Clear();
            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (Cbo_perfiles.SelectedIndex == -1 || Cbo_Modulos.SelectedIndex == -1 || Cbo_aplicaciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Perfil, Módulo y Aplicación.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string perfilNombre = Cbo_perfiles.Text;
            string aplicacionNombre = Cbo_aplicaciones.Text;
            int idPerfil = Convert.ToInt32(Cbo_perfiles.SelectedValue);
            int idAplicacion = Convert.ToInt32(Cbo_aplicaciones.SelectedValue);
            int idModulo = Convert.ToInt32(Cbo_Modulos.SelectedValue);

            // Verifica si ya existe la fila (evita duplicados)
            bool existe = false;
            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;
                int iperfil = Convert.ToInt32(row.Cells["IdPerfil"].Value);
                int imodulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iaplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);
                if (iperfil == idPerfil && imodulo == idModulo && iaplicacion == idAplicacion)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                Dgv_Permisos.Rows.Add(
                    perfilNombre,
                    aplicacionNombre,
                    false, false, false, false, false, // Permisos iniciales
                    idPerfil,
                    idModulo,
                    idAplicacion
                );

                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, idAplicacion, "Asignación Permisos Perfil - Agregar", true);
            }
            else
            {
                MessageBox.Show("Este Perfil ya tiene la aplicación asignada, solo modifique los permisos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_insertar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.Rows.Count == 0 || (Dgv_Permisos.Rows.Count == 1 && Dgv_Permisos.AllowUserToAddRows && Dgv_Permisos.Rows[0].IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un registro de asignación para insertar o actualizar.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int insertados = 0;
            int actualizados = 0;

            foreach (DataGridViewRow row in Dgv_Permisos.Rows)
            {
                if (row.IsNewRow) continue;

                int iperfil = Convert.ToInt32(row.Cells["IdPerfil"].Value);
                int imodulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iaplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);
                bool ingresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false);
                bool consultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool modificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool eliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool imprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                if (controlador.bExistePermisoPerfil(iperfil, imodulo, iaplicacion))
                {
                    controlador.iActualizarPermisoPerfilAplicacion(iperfil, imodulo, iaplicacion, ingresar, consultar, modificar, eliminar, imprimir);
                    actualizados++;
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, iaplicacion, "Asignación aplicación a perfil - Actualizar", true);
                }
                else
                {
                    controlador.iInsertarPermisoPerfilAplicacion(iperfil, imodulo, iaplicacion, ingresar, consultar, modificar, eliminar, imprimir);
                    insertados++;
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, iaplicacion, "Asignación aplicación a perfil - Insertar", true);
                }
            }
            MessageBox.Show($"Se insertaron {insertados} registros y se actualizaron {actualizados} registros correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dgv_Permisos.Rows.Clear();
        }

        private void Btn_quitar_Click(object sender, EventArgs e)
        {
            if (Dgv_Permisos.CurrentRow != null && !Dgv_Permisos.CurrentRow.IsNewRow)
            {
                int idaplicacion = Convert.ToInt32(Dgv_Permisos.CurrentRow.Cells["IdAplicacion"].Value);
                ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, idaplicacion, "Asignación Perfil a Usuario - Quitar", true);
                Dgv_Permisos.Rows.Remove(Dgv_Permisos.CurrentRow);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para quitar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Dgv_Permisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea encabezado o fila nueva
            if (e.RowIndex < 0) return;
            var row = Dgv_Permisos.Rows[e.RowIndex];

            var idPerfil = row.Cells["IdPerfil"].Value?.ToString();
            var idAplicacion = row.Cells["IdAplicacion"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(idPerfil) || string.IsNullOrWhiteSpace(idAplicacion))
            {
                MessageBox.Show("No tiene aplicación y perfil seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Dgv_Permisos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (Dgv_Permisos.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                var row = Dgv_Permisos.Rows[e.RowIndex];

                if (row.IsNewRow)
                {
                    e.Cancel = true;
                    MessageBox.Show("No tiene aplicación y perfil seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idPerfil = row.Cells["IdPerfil"].Value?.ToString();
                var idAplicacion = row.Cells["IdAplicacion"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(idPerfil) || string.IsNullOrWhiteSpace(idAplicacion))
                {
                    e.Cancel = true;
                    MessageBox.Show("No tiene aplicación y perfil seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Pic_Cerrar_Click(object sender, EventArgs e) => this.Close();

        private void Pnl_Superior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Cbo_perfiles.SelectedIndex == -1 || Cbo_perfiles.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un perfil para buscar sus permisos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InicializarDataGridView();

            try
            {
                int idPerfil = Convert.ToInt32(Cbo_perfiles.SelectedValue);
                DataTable dtPermisos = controlador.datObtenerPermisosPorPerfil(idPerfil);

                if (dtPermisos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPermisos.Rows)
                    {
                        Dgv_Permisos.Rows.Add(
                            row["nombre_perfil"].ToString(),
                            row["nombre_aplicacion"].ToString(),
                            Convert.ToBoolean(row["ingresar_permiso_aplicacion_perfil"]),
                            Convert.ToBoolean(row["consultar_permiso_aplicacion_perfil"]),
                            Convert.ToBoolean(row["modificar_permiso_aplicacion_perfil"]),
                            Convert.ToBoolean(row["eliminar_permiso_aplicacion_perfil"]),
                            Convert.ToBoolean(row["imprimir_permiso_aplicacion_perfil"]),
                            row["fk_id_perfil"],
                            row["fk_id_modulo"],
                            row["fk_id_aplicacion"]
                        );
                    }
                    ctrlBitacora.RegistrarAccion(Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario, 0, "Permisos Perfil - Consulta", true);
                    MessageBox.Show($"Permisos cargados correctamente. Se encontraron {dtPermisos.Rows.Count} registros.", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El perfil seleccionado no tiene permisos asignados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}