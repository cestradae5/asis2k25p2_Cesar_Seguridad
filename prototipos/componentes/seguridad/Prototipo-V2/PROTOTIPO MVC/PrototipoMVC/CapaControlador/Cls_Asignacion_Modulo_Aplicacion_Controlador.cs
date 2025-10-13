using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.Data;



namespace Capa_Controlador_Seguridad
{
    public class Cls_Asignacion_Modulo_Aplicacion_Controlador
    {
        private Cls_Asignacion_Modulo_AplicacionDAO dao = new Cls_Asignacion_Modulo_AplicacionDAO();

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
                        .FirstOrDefault(r => Convert.ToInt32(r["iFk_id_aplicacion"]) == iIdAplicacion);

            if (fila != null)
                return Convert.ToInt32(fila["iFk_id_modulo"]);

            return null; // no tiene módulo asignado
        }

    }
}
