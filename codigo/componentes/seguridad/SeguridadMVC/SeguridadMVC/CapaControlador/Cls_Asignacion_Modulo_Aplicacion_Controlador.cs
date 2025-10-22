using System;
using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_Asignacion_Modulo_Aplicacion_Controlador
    {
        private Cls_Asignacion_Modulo_AplicacionDAO dao = new Cls_Asignacion_Modulo_AplicacionDAO();

        public (bool success, string message) ValidarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            // Validación movida aquí desde la vista
            if (iIdModulo <= 0)
                return (false, "Debe seleccionar un módulo válido.");

            if (iIdAplicacion <= 0)
                return (false, "Debe tener una aplicación válida.");

            return (true, "Validación exitosa");
        }

        // Método mejorado con validación completa
        public (bool success, string message) GuardarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            var validacion = ValidarAsignacion(iIdModulo, iIdAplicacion);
            if (!validacion.success)
                return (false, validacion.message);

            // Verificar si la aplicación existe
            var appCtrl = new Cls_AplicacionControlador();
            if (appCtrl.BuscarAplicacionPorId(iIdAplicacion) == null)
                return (false, "La aplicación no existe.");

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

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Fk_id_aplicacion"]) == iIdAplicacion)
                {
                    return Convert.ToInt32(row["Fk_id_modulo"]);
                }
            }

            return null;
        }
    }
}