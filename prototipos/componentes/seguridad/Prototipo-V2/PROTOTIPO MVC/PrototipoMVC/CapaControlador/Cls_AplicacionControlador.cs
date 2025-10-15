//Cesar Armando Estrada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_AplicacionControlador
    {
        private Cls_AplicacionDAO daoAplicacion = new Cls_AplicacionDAO();

        public List<Cls_Aplicacion> ObtenerTodasLasAplicaciones()
        {
            return daoAplicacion.fun_ObtenerAplicaciones();
        }

        public (bool success, string message) ValidarDatosAplicacion(int iIdAplicacion, string sNombre, string sDescripcion)
        {
            if (iIdAplicacion <= 0)
                return (false, "Ingrese un ID válido.");

            if (string.IsNullOrWhiteSpace(sNombre))
                return (false, "Debe ingresar el nombre de la aplicación.");

            if (string.IsNullOrWhiteSpace(sDescripcion))
                return (false, "Debe ingresar la descripción de la aplicación.");

            if (sNombre.Length > 50)
                return (false, "Cadena muy larga en el campo 'Nombre de aplicación' (máx. 50).");

            if (sDescripcion.Length > 255)
                return (false, "Cadena muy larga en el campo 'Descripción' (máx. 255).");

            return (true, "Validación exitosa");
        }

        public (int resultado, string mensaje) InsertarAplicacion(int iIdAplicacion, string sNombre, string sDescripcion, bool bEstado, int? iIdReporte = null)
        {
            var validacion = ValidarDatosAplicacion(iIdAplicacion, sNombre, sDescripcion);
            if (!validacion.success)
                return (0, validacion.message);

            if (BuscarAplicacionPorId(iIdAplicacion) != null)
                return (0, "El ID ya existe, por favor ingrese otro.");

            Cls_Aplicacion nuevaApp = new Cls_Aplicacion
            {
                iPkIdAplicacion = iIdAplicacion,
                sNombreAplicacion = sNombre,
                sDescripcionAplicacion = sDescripcion,
                bEstadoAplicacion = bEstado,
                iFkIdReporte = iIdReporte
            };

            int resultado = daoAplicacion.pro_InsertarAplicacion(nuevaApp);
            return (resultado, resultado > 0 ? "Aplicación guardada correctamente." : "Error al guardar la aplicación.");
        }

        public (bool success, string message) ActualizarAplicacion(int iIdAplicacion, string sNombre, string sDescripcion, bool bEstado, int? iIdReporte = null)
        {
            var validacion = ValidarDatosAplicacion(iIdAplicacion, sNombre, sDescripcion);
            if (!validacion.success)
                return (false, validacion.message);

            if (BuscarAplicacionPorId(iIdAplicacion) == null)
                return (false, "No existe una aplicación con ese ID para modificar.");

            Cls_Aplicacion appActualizada = new Cls_Aplicacion
            {
                iPkIdAplicacion = iIdAplicacion,
                sNombreAplicacion = sNombre,
                sDescripcionAplicacion = sDescripcion,
                bEstadoAplicacion = bEstado,
                iFkIdReporte = iIdReporte
            };

            bool exito = daoAplicacion.pro_ActualizarAplicacion(appActualizada) > 0;
            return (exito, exito ? "Aplicación modificada correctamente." : "Error al modificar la aplicación.");
        }

        // Método comentado ya que el botón de eliminar no se usará
        
        public (bool success, string message) EliminarAplicacion(int iIdAplicacion)
        {
            if (iIdAplicacion <= 0)
                return (false, "Ingrese un ID válido para eliminar.");

            if (TieneRelaciones(iIdAplicacion))
            {
                return (false, 
                    "**Imposible Eliminar.** Esta aplicación se encuentra relacionada con uno o más módulos o permisos, lo que afectaría la integridad referencial del sistema. Por favor, inspeccione primero las relaciones (asignaciones) de la aplicación.");
            }

            bool exito = daoAplicacion.pro_BorrarAplicacion(iIdAplicacion) > 0;
            return (exito, exito ? "Aplicación eliminada exitosamente." : "Error al eliminar la aplicación.");
        }

        // Método para compatibilidad con código existente
        public bool BorrarAplicacion(int iIdAplicacion)
        {
            return daoAplicacion.pro_BorrarAplicacion(iIdAplicacion) > 0;
        }
        

        public Cls_Aplicacion BuscarAplicacionPorId(int iIdAplicacion)
        {
            return daoAplicacion.fun_buscar_aplicacion(iIdAplicacion);
        }

        public Cls_Aplicacion BuscarAplicacionPorNombre(string sNombre)
        {
            return daoAplicacion.fun_ObtenerAplicaciones()
                                .FirstOrDefault(a =>
                                    a.sNombreAplicacion.Equals(sNombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool TieneRelaciones(int iIdAplicacion)
        {
            return daoAplicacion.fun_VerificarRelaciones(iIdAplicacion);
        }
    }
}