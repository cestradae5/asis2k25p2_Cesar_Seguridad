// Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025
using System;
using System.Data;
using System.Drawing.Printing;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_BitacoraControlador
    {
        private readonly Cls_SentenciasBitacora sentencias = new Cls_SentenciasBitacora();

        // Consultar toda la bitácora
        public DataTable MostrarBitacora()
        {
            return sentencias.Listar();
        }

        // Consultar por fecha
        public DataTable BuscarPorFecha(DateTime fecha)
        {
            return sentencias.ConsultarPorFecha(fecha);
        }

        // Consultar por rango
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin)
        {
            return sentencias.ConsultarPorRango(inicio, fin);
        }

        // Consultar por usuario
        public DataTable BuscarPorUsuario(int idUsuario)
        {
            return sentencias.ConsultarPorUsuario(idUsuario);
        }

        // Listar usuarios
        public DataTable ObtenerUsuarios()
        {
            return sentencias.ListarUsuarios();
        }

        // Guardar acción en la bitácora
        public void RegistrarAccion(int idUsuario, int? idAplicacion, int? idListaTabla, string accion, bool estadoLogin)
        {
            sentencias.InsertarBitacora(idUsuario, idAplicacion, idListaTabla, accion, estadoLogin);
        }

        // Exportar a CSV
        public void ExportarCsv(string rutaArchivo)
        {
            sentencias.ExportarCsv(rutaArchivo);
        }

        // Crear documento para imprimir
        public PrintDocument CrearDocumentoImpresion()
        {
            return sentencias.CrearDocumentoImpresion();
        }
    }
}
