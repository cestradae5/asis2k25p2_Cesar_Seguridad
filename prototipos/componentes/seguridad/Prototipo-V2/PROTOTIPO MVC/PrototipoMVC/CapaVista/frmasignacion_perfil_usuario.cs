using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    /* Brandon Alexander Hernandez Salguero
     * 0901-22-9663
     */
    public partial class frmasignacion_perfil_usuario : Form
    {
        Cls_asignacion_perfil_usuarioControlador controlador = new Cls_asignacion_perfil_usuarioControlador();
        Cls_asignacion_perfil_usuarioDAO modelo = new Cls_asignacion_perfil_usuarioDAO();
        private List<Cls_asignacion_perfil_usuario> asignacionesPendientes = new List<Cls_asignacion_perfil_usuario>();

        // DataTables para lookup de nombres
        private DataTable dtUsuarios;
        private DataTable dtPerfiles;

        public frmasignacion_perfil_usuario()
        {
            InitializeComponent();
        }

        private void frmasignacion_perfil_usuario_Load(object sender, EventArgs e)
        {
            // Llenar ComboBox Usuarios y guardar DataTable
            dtUsuarios = controlador.datObtenerUsuarios();
            Cbo_usuario.DataSource = dtUsuarios.Copy();
            Cbo_usuario.DisplayMember = "nombre_usuario";
            Cbo_usuario.ValueMember = "pk_id_usuario";
            Cbo_usuario.SelectedIndex = -1;

            Cbo_usuarios2.DataSource = dtUsuarios.Copy();
            Cbo_usuarios2.DisplayMember = "nombre_usuario";
            Cbo_usuarios2.ValueMember = "pk_id_usuario";
            Cbo_usuarios2.SelectedIndex = -1;

            
            dtPerfiles = controlador.datObtenerPerfiles();
            Cbo_perfil.DataSource = dtPerfiles.Copy();
            Cbo_perfil.DisplayMember = "puesto_perfil";
            Cbo_perfil.ValueMember = "pk_id_perfil";
            Cbo_perfil.SelectedIndex = -1;
        }

        private void Cbo_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_usuario.SelectedIndex != -1 && Cbo_usuario.SelectedValue != null)
            {
                int idUsuario;
                
                if (Cbo_usuario.SelectedValue is DataRowView drv)
                {
                    idUsuario = Convert.ToInt32(drv["pk_id_usuario"]);
                }
                else
                {
                    idUsuario = Convert.ToInt32(Cbo_usuario.SelectedValue);
                }

                DataTable dt = modelo.datObtenerPerfilesPorUsuario(idUsuario);
                Dgv_consulta.DataSource = dt;
            }
            else
            {
                Dgv_consulta.DataSource = null;
            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (Cbo_usuarios2.SelectedIndex == -1 || Cbo_perfil.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un usuario y un perfil.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(Cbo_usuarios2.SelectedValue);
            int idPerfil = Convert.ToInt32(Cbo_perfil.SelectedValue);

   
            if (asignacionesPendientes.Any(x => x.fk_id_usuario == idUsuario && x.fk_id_perfil == idPerfil))
            {
                MessageBox.Show("Esta asignación ya está en la lista.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            asignacionesPendientes.Add(new Cls_asignacion_perfil_usuario(idUsuario, idPerfil));
            fun_RefrescarAsignacionesPendientes();
        }

        private void fun_RefrescarAsignacionesPendientes()
        {
            Dgv_asignaciones.DataSource = null;
            var lista = asignacionesPendientes
                .Select(x => new
                {
                    Usuario = dtUsuarios.Select($"pk_id_usuario = {x.fk_id_usuario}").FirstOrDefault()?["nombre_usuario"]?.ToString() ?? x.fk_id_usuario.ToString(),
                    Perfil = dtPerfiles.Select($"pk_id_perfil = {x.fk_id_perfil}").FirstOrDefault()?["puesto_perfil"]?.ToString() ?? x.fk_id_perfil.ToString()
                }).ToList();

            Dgv_asignaciones.DataSource = lista;
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            int guardados = 0;
            foreach (var asignacion in asignacionesPendientes)
            {
                if (controlador.bInsertar(asignacion.fk_id_usuario, asignacion.fk_id_perfil))
                    guardados++;
            }
            MessageBox.Show($"Se guardaron {guardados} asignaciones correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            asignacionesPendientes.Clear();
            fun_RefrescarAsignacionesPendientes();
        }


        private void Btn_eliminar_asignacion_Click_1(object sender, EventArgs e)
        {
            
            if (Dgv_asignaciones.CurrentRow != null)
            {
                
                string snombreUsuario = Dgv_asignaciones.CurrentRow.Cells["Usuario"].Value.ToString();
                string snombrePerfil = Dgv_asignaciones.CurrentRow.Cells["Perfil"].Value.ToString();

                
                var usuarioRow = dtUsuarios.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("nombre_usuario") == snombreUsuario);
                var perfilRow = dtPerfiles.AsEnumerable()
                    .FirstOrDefault(r => r.Field<string>("puesto_perfil") == snombrePerfil);

                if (usuarioRow != null && perfilRow != null)
                {
                    int idUsuario = usuarioRow.Field<int>("pk_id_usuario");
                    int idPerfil = perfilRow.Field<int>("pk_id_perfil");

                    
                    asignacionesPendientes.RemoveAll(x => x.fk_id_usuario == idUsuario && x.fk_id_perfil == idPerfil);

                    
                    fun_RefrescarAsignacionesPendientes();
                }
            }
        }

        private void Btn_eliminar_consulta_Click(object sender, EventArgs e)
        {
            Dgv_consulta.DataSource = null;
        }
    }
}