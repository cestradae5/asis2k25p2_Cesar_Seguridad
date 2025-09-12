using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
using System.Data;



namespace CapaControlador
{
    public class Cls_AsignacionModuloAplicacionControlador
    {
        private Cls_AsignacionModuloAplicacionDAO dao = new Cls_AsignacionModuloAplicacionDAO();

        public bool GuardarAsignacion(int idModulo, int idAplicacion)
        {
            if (dao.ExisteAsignacion(idModulo, idAplicacion))
                return false;

            return dao.InsertarAsignacion(idModulo, idAplicacion) > 0;
        }

        public DataTable ObtenerAsignaciones()
        {
            return dao.ObtenerAsignaciones();
        }
        public int? ObtenerModuloPorAplicacion(int idAplicacion)
        {
            DataTable dt = dao.ObtenerAsignaciones();

            var fila = dt.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["fk_id_aplicacion"]) == idAplicacion);

            if (fila != null)
                return Convert.ToInt32(fila["fk_id_modulo"]);

            return null; // no tiene módulo asignado
        }

    }
}
