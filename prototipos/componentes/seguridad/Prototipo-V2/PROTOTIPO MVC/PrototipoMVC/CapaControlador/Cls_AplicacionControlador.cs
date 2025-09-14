//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_AplicacionControlador
    {
        private Cls_AplicacionDAO daoAplicacion = new Cls_AplicacionDAO();


        public int InsertarAplicacion(int idAplicacion, string nombre, string descripcion, bool estado, int? idReporte = null)
        {
            Cls_Aplicacion nuevaApp = new Cls_Aplicacion
            {
                PkIdAplicacion = idAplicacion,
                NombreAplicacion = nombre,
                DescripcionAplicacion = descripcion,
                EstadoAplicacion = estado,
                FkIdReporte = idReporte
            };

            return daoAplicacion.InsertarAplicacion(nuevaApp);
        }

        // Actualizar aplicación existente
        public bool ActualizarAplicacion(int idAplicacion, string nombre, string descripcion, bool estado, int? idReporte = null)
        {
            Cls_Aplicacion appActualizada = new Cls_Aplicacion
            {
                PkIdAplicacion = idAplicacion,
                NombreAplicacion = nombre,
                DescripcionAplicacion = descripcion,
                EstadoAplicacion = estado,
                FkIdReporte = idReporte
            };

            return daoAplicacion.ActualizarAplicacion(appActualizada) > 0;
        }

        // Eliminar aplicación por ID
        public bool BorrarAplicacion(int idAplicacion)
        {
            return daoAplicacion.BorrarAplicacion(idAplicacion) > 0;
        }

        // Buscar aplicación por ID
        public Cls_Aplicacion BuscarAplicacionPorId(int idAplicacion)
        {
            return daoAplicacion.Query(idAplicacion);
        }

        // Buscar aplicación por nombre
        public Cls_Aplicacion BuscarAplicacionPorNombre(string nombre)
        {
            return daoAplicacion.ObtenerAplicaciones()
                                .FirstOrDefault(a =>
                                    a.NombreAplicacion.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}


