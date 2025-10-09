using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.Data;



namespace Capa_Controlador_Seguridad
{
    public class Cls_AsignacionModuloAplicacionControlador
    {
        private Cls_AsignacionModuloAplicacionDAO dao = new Cls_AsignacionModuloAplicacionDAO();

        public bool GuardarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            if (dao.ExisteAsignacion(iIdModulo, iIdAplicacion))
                return false;

            return dao.InsertarAsignacion(iIdModulo, iIdAplicacion) > 0;
        }

        public DataTable ObtenerAsignaciones()
        {
            return dao.ObtenerAsignaciones();
        }
        public int? ObtenerModuloPorAplicacion(int iIdAplicacion)
        {
            DataTable dt = dao.ObtenerAsignaciones();

            var fila = dt.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["fk_id_aplicacion"]) == iIdAplicacion);

            if (fila != null)
                return Convert.ToInt32(fila["fk_id_modulo"]);

            return null; // no tiene módulo asignado
        }

    }
}
