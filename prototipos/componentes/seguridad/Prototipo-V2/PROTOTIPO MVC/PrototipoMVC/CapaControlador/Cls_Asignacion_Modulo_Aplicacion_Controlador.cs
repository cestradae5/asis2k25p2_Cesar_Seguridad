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

        // Validación para asignación
        public (bool success, string message) ValidarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            if (iIdModulo <= 0)
                return (false, "Debe seleccionar un módulo válido.");

            if (iIdAplicacion <= 0)
                return (false, "Debe tener una aplicación válida.");

            return (true, "Validación exitosa");
        }

        public (bool success, string message) GuardarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            // Validar la asignación
            var validacion = ValidarAsignacion(iIdModulo, iIdAplicacion);
            if (!validacion.success)
                return (false, validacion.message);

            if (dao.ExisteAsignacion(iIdModulo, iIdAplicacion))
                return (false, "La asignación ya existe.");

            bool resultado = dao.InsertarAsignacion(iIdModulo, iIdAplicacion) > 0;
            return (resultado, resultado ? "Asignación guardada correctamente." : "Error al guardar la asignación.");
        }

        public DataTable ObtenerAsignaciones()
        {
            return dao.ObtenerAsignaciones();
        }

        public int? ObtenerModuloPorAplicacion(int iIdAplicacion)
        {
            DataTable dt = dao.ObtenerAsignaciones();

            var fila = dt.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["Fk_id_aplicacion"]) == iIdAplicacion);

            if (fila != null)
                return Convert.ToInt32(fila["Fk_id_modulo"]);

            return null; // no tiene módulo asignado
        }
    }
}