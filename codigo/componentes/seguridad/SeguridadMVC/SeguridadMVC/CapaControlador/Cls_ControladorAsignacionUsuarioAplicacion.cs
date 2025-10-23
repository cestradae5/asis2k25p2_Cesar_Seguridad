using System.Data;
using Capa_Modelo_Seguridad;
using System.Windows.Forms;
using System;

namespace Capa_Controlador_Seguridad
{
    public class Cls_ControladorAsignacionUsuarioAplicacion
    {
        Cls_SentenciaAsignacionUsuarioAplicacion model = new Cls_SentenciaAsignacionUsuarioAplicacion();

        // Métodos existentes (sin cambios)
        public DataTable ObtenerUsuarios() => model.fun_ObtenerUsuarios();
        public DataTable ObtenerModulos() => model.fun_ObtenerModulos();
        public DataTable ObtenerAplicacionesPorModulo(int idModulo) => model.fun_ObtenerAplicacionesPorModulo(idModulo);
        public DataTable ObtenerPermisosPorUsuario(int idUsuario) => model.fun_ObtenerPermisosPorUsuario(idUsuario);
        public DataTable ObtenerPermisosPorUsuarioYModulo(int idUsuario, int idModulo) => model.fun_bbtener_permisos_por_usuario_modulo(idUsuario, idModulo);

        public bool InsertarPermisoUsuarioAplicacion(int iIdUsuario, int iIdModulo, int iIdAplicacion,
                                                     bool bIngresar, bool bConsultar, bool bModificar,
                                                     bool bEliminar, bool bImprimir)
        {
            int filas = model.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                               bIngresar, bConsultar, bModificar,
                                                               bEliminar, bImprimir);
            return filas > 0;
        }

        // NUEVOS MÉTODOS para manejar la lógica de negocio

        public bool ValidarYAgregarPermiso(DataGridView dgv, int iIdUsuario, int iIdModulo, int iIdAplicacion, string sUsuario, string sAplicacion)
        {
            // Validar si ya existe el permiso (lógica de negocio)
            bool bExiste = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                int u = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int m = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int a = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                if (u == iIdUsuario && m == iIdModulo && a == iIdAplicacion)
                {
                    bExiste = true;
                    break;
                }
            }

            if (!bExiste)
            {
                dgv.Rows.Add(sUsuario, sAplicacion, false, false, false, false, false, iIdUsuario, iIdModulo, iIdAplicacion);
                return true;
            }
            else
            {
                MessageBox.Show("Este usuario ya tiene esa aplicación asignada. Solo modifique los permisos.");
                return false;
            }
        }

        public (int Insertados, int Actualizados) ProcesarPermisos(DataGridView dgv, Cls_Registrar_Permisos_Bitacora registrarBitacora)
        {
            int iInsertados = 0;
            int iActualizados = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                int iIdUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                int iIdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                int iIdAplicacion = Convert.ToInt32(row.Cells["IdAplicacion"].Value);

                bool bIngresar = Convert.ToBoolean(row.Cells["Ingresar"].Value ?? false);
                bool bConsultar = Convert.ToBoolean(row.Cells["Consultar"].Value ?? false);
                bool bModificar = Convert.ToBoolean(row.Cells["Modificar"].Value ?? false);
                bool bEliminar = Convert.ToBoolean(row.Cells["Eliminar"].Value ?? false);
                bool bImprimir = Convert.ToBoolean(row.Cells["Imprimir"].Value ?? false);

                // Registrar en bitácora
                var gPermisosActuales = new Cls_Permisos
                {
                    bIngresar = bIngresar,
                    bConsultar = bConsultar,
                    bModificar = bModificar,
                    bEliminar = bEliminar,
                    bImprimir = bImprimir
                };

                registrarBitacora.fun_CompararYRegistrar(
                    Cls_Usuario_Conectado.iIdUsuario,
                    iIdUsuario,
                    iIdModulo,
                    iIdAplicacion,
                    row.Cells["Usuario"].Value.ToString(),
                    row.Cells["Aplicacion"].Value.ToString(),
                    gPermisosActuales
                );

                // Lógica de negocio para insertar o actualizar
                if (model.ExistePermiso(iIdUsuario, iIdModulo, iIdAplicacion))
                {
                    model.ActualizarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                              bIngresar, bConsultar, bModificar,
                                                              bEliminar, bImprimir);
                    iActualizados++;
                }
                else
                {
                    model.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                            bIngresar, bConsultar, bModificar,
                                                            bEliminar, bImprimir);
                    iInsertados++;
                }
            }

            return (iInsertados, iActualizados);
        }

        public void QuitarPermiso(DataGridView dgv, Cls_BitacoraControlador ctrlBitacora)
        {
            int idAplicacion = Convert.ToInt32(dgv.CurrentRow.Cells["IdAplicacion"].Value);
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            string sUsuario = dgv.CurrentRow.Cells["Usuario"].Value.ToString();
            string sAplicacion = dgv.CurrentRow.Cells["Aplicacion"].Value.ToString();

            dgv.Rows.Remove(dgv.CurrentRow);

            ctrlBitacora.RegistrarAccion(idUsuario, idAplicacion,
                $"Al usuario '{sUsuario}' se le quitarán todos los permisos en la aplicación '{sAplicacion}'", true);
        }

        public bool CargarPermisosUsuario(DataGridView dgv, int idUsuario)
        {
            DataTable dtPermisos = ObtenerPermisosPorUsuario(idUsuario);
            dgv.Rows.Clear();

            if (dtPermisos.Rows.Count > 0)
            {
                foreach (DataRow row in dtPermisos.Rows)
                {
                    dgv.Rows.Add(
                        row["nombre_usuario"].ToString(),
                        row["nombre_aplicacion"].ToString(),
                        Convert.ToBoolean(row["ingresar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["consultar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["modificar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["eliminar_permiso_aplicacion_usuario"]),
                        Convert.ToBoolean(row["imprimir_permiso_aplicacion_usuario"]),
                        row["fk_id_usuario"],
                        row["iFk_id_modulo"],
                        row["iFk_id_aplicacion"]
                    );
                }
                return true;
            }
            return false;
        }
    }
}