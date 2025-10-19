//Cesar Armando Estrada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.Data;
using System.Data.Odbc;

namespace Capa_Controlador_Seguridad
{
    public class Cls_AplicacionControlador
    {
        private Cls_AplicacionDAO daoAplicacion = new Cls_AplicacionDAO();
        // Método nuevo para obtener aplicaciones como DataTable (para la vista)
        public DataTable ObtenerAplicacionesDataTable()
        {
            var aplicaciones = daoAplicacion.fun_ObtenerAplicaciones();
            DataTable dt = new DataTable();
            dt.Columns.Add("iPkIdAplicacion", typeof(int));
            dt.Columns.Add("sNombreAplicacion", typeof(string));
            dt.Columns.Add("sDescripcionAplicacion", typeof(string));
            dt.Columns.Add("bEstadoAplicacion", typeof(bool));

            foreach (var app in aplicaciones)
            {
                dt.Rows.Add(app.iPkIdAplicacion, app.sNombreAplicacion,
                           app.sDescripcionAplicacion, app.bEstadoAplicacion);
            }
            return dt;
        }

        // Método para buscar aplicación que devuelve DataRow (no el modelo directo)
        public (bool success, DataRow aplicacion, string message) BuscarAplicacion(string criterioBusqueda)
        {
            var validacion = ValidarBusqueda(criterioBusqueda);
            if (!validacion.success)
                return (false, null, validacion.message);

            Cls_Aplicacion appEncontrada = null;

            if (criterioBusqueda.Contains("-"))
            {
                string[] partes = criterioBusqueda.Split('-');
                if (partes.Length >= 1 && int.TryParse(partes[0].Trim(), out int idFromCombo))
                {
                    appEncontrada = BuscarAplicacionPorId(idFromCombo);
                }
            }

            if (appEncontrada == null && int.TryParse(criterioBusqueda, out int id))
            {
                appEncontrada = BuscarAplicacionPorId(id);
            }

            if (appEncontrada == null)
            {
                appEncontrada = BuscarAplicacionPorNombre(criterioBusqueda.Trim());
            }

            if (appEncontrada != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("iPkIdAplicacion", typeof(int));
                dt.Columns.Add("iFkIdReporte", typeof(int));
                dt.Columns.Add("sNombreAplicacion", typeof(string));
                dt.Columns.Add("sDescripcionAplicacion", typeof(string));
                dt.Columns.Add("bEstadoAplicacion", typeof(bool));

                dt.Rows.Add(appEncontrada.iPkIdAplicacion, appEncontrada.iFkIdReporte,
                           appEncontrada.sNombreAplicacion, appEncontrada.sDescripcionAplicacion,
                           appEncontrada.bEstadoAplicacion);

                return (true, dt.Rows[0], "Aplicación encontrada");
            }
            else
            {
                return (false, null, "Aplicación no encontrada");
            }
        }

        public List<Cls_Aplicacion> ObtenerTodasLasAplicaciones()
        {
            return daoAplicacion.fun_ObtenerAplicaciones();
        }

        // Método de validación principal que incluye todos los campos
        public (bool success, string message) ValidarDatosCompletosAplicacion(
    int iIdAplicacion,
    string sNombre,
    string sDescripcion,
    int? iIdModulo = null,
    int? iIdReporte = null,
    bool esModificacion = false)
        {
            // Validación de ID
            if (iIdAplicacion <= 0)
                return (false, "Ingrese un ID válido (mayor a 0).");

            // Validación de nombre
            if (string.IsNullOrWhiteSpace(sNombre))
                return (false, "Debe ingresar el nombre de la aplicación.");

            if (sNombre.Length > 50)
                return (false, "El nombre de la aplicación no puede exceder 50 caracteres.");

            // Validación de descripción
            if (string.IsNullOrWhiteSpace(sDescripcion))
                return (false, "Debe ingresar la descripción de la aplicación.");

            if (sDescripcion.Length > 255)
                return (false, "La descripción no puede exceder 255 caracteres.");

            // Validación de módulo (para inserción) - SOLO EN MODO NUEVO
            if (!esModificacion && (!iIdModulo.HasValue || iIdModulo.Value <= 0))
                return (false, "Debe seleccionar un módulo válido.");

            // En modo modificación, el módulo NO se valida porque no se puede cambiar
            // Esto mantiene la regla de negocio en el controlador

            // Validación de reporte (si se proporciona)
            if (iIdReporte.HasValue && iIdReporte.Value < 0)
                return (false, "ID de reporte inválido.");

            return (true, "Validación exitosa");
        }

        // Validación para búsqueda
        public (bool success, string message) ValidarBusqueda(string criterioBusqueda)
        {
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
                return (false, "Ingrese un ID o nombre para buscar");

            if (criterioBusqueda.Length > 50)
                return (false, "El criterio de búsqueda es demasiado largo");

            return (true, "Válido");
        }

        public (int resultado, string mensaje) InsertarAplicacion(
            int iIdAplicacion,
            string sNombre,
            string sDescripcion,
            bool bEstado,
            int? iIdReporte = null,
            int? iIdModulo = null)
        {
            Console.WriteLine($"DEBUG Controlador: IDReporte = {iIdReporte}");

            // Validación completa
            var validacion = ValidarDatosCompletosAplicacion(iIdAplicacion, sNombre, sDescripcion, iIdModulo, iIdReporte, false);
            if (!validacion.success)
                return (0, validacion.message);

            // Verificar si el ID ya existe
            if (BuscarAplicacionPorId(iIdAplicacion) != null)
                return (0, "El ID ya existe, por favor ingrese otro.");

            // Verificar si el nombre ya existe
            if (BuscarAplicacionPorNombre(sNombre) != null)
                return (0, "Ya existe una aplicación con ese nombre.");

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

        public (bool success, string message) ActualizarAplicacion(
            int iIdAplicacion,
            string sNombre,
            string sDescripcion,
            bool bEstado,
            int? iIdReporte = null)
        {
            // Validación para modificación (módulo no requerido)
            var validacion = ValidarDatosCompletosAplicacion(iIdAplicacion, sNombre, sDescripcion, null, iIdReporte, true);
            if (!validacion.success)
                return (false, validacion.message);

            // Verificar que la aplicación exista
            var aplicacionExistente = BuscarAplicacionPorId(iIdAplicacion);
            if (aplicacionExistente == null)
                return (false, "No existe una aplicación con ese ID para modificar.");

            // Verificar nombre duplicado (excluyendo la aplicación actual)
            var aplicacionMismoNombre = BuscarAplicacionPorNombre(sNombre);
            if (aplicacionMismoNombre != null && aplicacionMismoNombre.iPkIdAplicacion != iIdAplicacion)
                return (false, "Ya existe otra aplicación con ese nombre.");

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

        public (bool success, string message) EliminarAplicacion(int iIdAplicacion)
        {
            if (iIdAplicacion <= 0)
                return (false, "Ingrese un ID válido para eliminar.");

            if (TieneRelaciones(iIdAplicacion))
            {
                return (false,
                    "*Imposible Eliminar.* Esta aplicación se encuentra relacionada con uno o más módulos o permisos, lo que afectaría la integridad referencial del sistema. Por favor, inspeccione primero las relaciones (asignaciones) de la aplicación.");
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
            if (string.IsNullOrWhiteSpace(sNombre))
                return null;

            return daoAplicacion.fun_ObtenerAplicaciones()
                                .FirstOrDefault(a =>
                                    a.sNombreAplicacion.Trim().Equals(sNombre.Trim(), StringComparison.OrdinalIgnoreCase));
        }


        public bool TieneRelaciones(int iIdAplicacion)
        {
            return daoAplicacion.fun_VerificarRelaciones(iIdAplicacion);
        }

        public DataTable ObtenerReportes()
        {
            return daoAplicacion.ObtenerReportes();
        }

        // También agrega este método de validación si lo necesitas
        public (bool success, string message) ValidarReporte(int idReporte)
        {
            if (idReporte <= 0)
                return (false, "ID de reporte inválido");

            var reportes = ObtenerReportes();
            bool existe = false;
            foreach (DataRow row in reportes.Rows)
            {
                if ((int)row["Pk_Id_Reporte"] == idReporte)
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
                return (false, "El reporte seleccionado no existe");

            return (true, "Válido");
        }
    }
}