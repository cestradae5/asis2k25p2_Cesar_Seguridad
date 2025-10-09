//Cesar Armando Estrtada Elias 0901-22-10153
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

        public int InsertarAplicacion(int idAplicacion, string sNombre, string sDescripcion, bool bEstado, int? iIdReporte = null)
        {
            Cls_Aplicacion nuevaApp = new Cls_Aplicacion
            {
                iPkIdAplicacion = idAplicacion,
                sNombreAplicacion = sNombre,
                sDescripcionAplicacion = sDescripcion,
                bEstadoAplicacion = bEstado,
                iFkIdReporte = iIdReporte
            };

            return daoAplicacion.pro_InsertarAplicacion(nuevaApp);
        }

        // Actualizar aplicación existente
        public bool ActualizarAplicacion(int idAplicacion, string sNombre, string sDescripcion, bool bEstado, int? iIdReporte = null)
        {
            Cls_Aplicacion appActualizada = new Cls_Aplicacion
            {
                iPkIdAplicacion = idAplicacion,
                sNombreAplicacion = sNombre,
                sDescripcionAplicacion = sDescripcion,
                bEstadoAplicacion = bEstado,
                iFkIdReporte = iIdReporte
            };

            return daoAplicacion.pro_ActualizarAplicacion(appActualizada) > 0;
        }

        // Eliminar aplicación por ID
        public bool BorrarAplicacion(int iIdAplicacion)
        {
            return daoAplicacion.pro_BorrarAplicacion(iIdAplicacion) > 0;
        }

        // Buscar aplicación por ID
        public Cls_Aplicacion BuscarAplicacionPorId(int iIdAplicacion)
        {
            return daoAplicacion.fun_buscar_aplicacion(iIdAplicacion);
        }

        // Buscar aplicación por sNombre
        public Cls_Aplicacion BuscarAplicacionPorNombre(string sNombre)
        {
            return daoAplicacion.fun_ObtenerAplicaciones()
                                .FirstOrDefault(a =>
                                    a.sNombreAplicacion.Equals(sNombre, StringComparison.OrdinalIgnoreCase));
        }
        // Verificar si la aplicación tiene relaciones de llave foránea
        public bool TieneRelaciones(int iIdAplicacion)
        {
            return daoAplicacion.fun_VerificarRelaciones(iIdAplicacion);
        }
    }
}


