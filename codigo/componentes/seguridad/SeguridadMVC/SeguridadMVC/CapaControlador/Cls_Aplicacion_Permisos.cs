using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    //Carlo Sosa 0901-22-1106 15/10/2025
    //Brandon Hernandez 0901-22-9663 15/10/2025
    public class Cls_Aplicacion_Permisos
    {
        public static (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)
            ObtenerPermisosCombinados(int idUsuario, int idAplicacion, int idModulo, int idPerfil)
        {
            var permisoUsuario = new Cls_Permiso_Usuario();
            var permisoPerfilDAO = new Cls_Asignacion_Permiso_PerfilesDAO();

            // Permisos por USUARIO
            bool pIngUsuario = false, pConUsuario = false, pModUsuario = false, pEliUsuario = false, pImpUsuario = false;
            var pu = permisoUsuario.ConsultarPermisos(idUsuario, idAplicacion, idModulo);
            if (pu.HasValue)
            {
                pIngUsuario = pu.Value.ingresar;
                pConUsuario = pu.Value.consultar;
                pModUsuario = pu.Value.modificar;
                pEliUsuario = pu.Value.eliminar;
                pImpUsuario = pu.Value.imprimir;
            }

            // Permisos por PERFIL
            bool pIngPerfil = false, pConPerfil = false, pModPerfil = false, pEliPerfil = false, pImpPerfil = false;
            var dt = permisoPerfilDAO.ObtenerPermisosPerfilAplicacion(idPerfil, idAplicacion);
            if (dt != null && dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];

                pIngPerfil = GetBool(r, "Cmp_Ingresar_Permisos_Aplicacion_Perfil", "bIngresar_permiso_aplicacion_perfil", "ingresar_permiso_aplicacion_perfil", "bIngresar", "ingresar");
                pConPerfil = GetBool(r, "Cmp_Consultar_Permisos_Aplicacion_Perfil", "bConsultar_permiso_aplicacion_perfil", "consultar_permiso_aplicacion_perfil", "bConsultar", "consultar");
                pModPerfil = GetBool(r, "Cmp_Modificar_Permisos_Aplicacion_Perfil", "bModificar_permiso_aplicacion_perfil", "modificar_permiso_aplicacion_perfil", "bModificar", "modificar");
                pEliPerfil = GetBool(r, "Cmp_Eliminar_Permisos_Aplicacion_Perfil", "bEliminar_permiso_aplicacion_perfil", "eliminar_permiso_aplicacion_perfil", "bEliminar", "eliminar");
                pImpPerfil = GetBool(r, "Cmp_Imprimir_Permisos_Aplicacion_Perfil", "bImprimir_permiso_aplicacion_perfil", "imprimir_permiso_aplicacion_perfil", "bImprimir", "imprimir");
            }

            // Combinación lógica (OR)
            bool ingresar = pIngUsuario || pIngPerfil;
            bool consultar = pConUsuario || pConPerfil;
            bool modificar = pModUsuario || pModPerfil;
            bool eliminar = pEliUsuario || pEliPerfil;
            bool imprimir = pImpUsuario || pImpPerfil;

            return (ingresar, consultar, modificar, eliminar, imprimir);
        }

        private static bool GetBool(DataRow r, params string[] posiblesNombres)
        {
            foreach (var n in posiblesNombres)
                if (r.Table.Columns.Contains(n))
                    return AsBool(r[n]);
            return false;
        }

        private static bool AsBool(object value)
        {
            if (value == null || value == DBNull.Value) return false;
            if (value is bool b) return b;
            if (value is byte by) return by != 0;
            if (value is short s) return s != 0;
            if (value is int i) return i != 0;
            if (value is long l) return l != 0L;
            var str = value.ToString().Trim();
            if (str == "1") return true;
            if (str == "0" || str == "") return false;
            bool.TryParse(str, out var rb);
            return rb;
        }
    }
}