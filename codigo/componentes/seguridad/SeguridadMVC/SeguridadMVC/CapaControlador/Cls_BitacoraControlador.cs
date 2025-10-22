//Inicio de código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025
using System;
using System.Data;
using System.IO;
using System.Text;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_BitacoraControlador
    {
        private readonly Cls_Sentencias_Bitacora ctrlSentencias = new Cls_Sentencias_Bitacora();

        // Consultas

        public DataTable MostrarBitacora()
        {
            try
            {
                return ctrlSentencias.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la Bitácora: " + ex.Message);
            }
        }

        //Busca por fecha
        public DataTable BuscarPorFecha(DateTime fecha)
        {
            try
            {
                return ctrlSentencias.ConsultarPorFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar por fecha: " + ex.Message);
            }
        }

        //Buscar por rango de fechas
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin)
        {
            try
            {
                return ctrlSentencias.ConsultarPorRango(inicio, fin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar por rango de fechas: " + ex.Message);
            }
        }

        //Busca usuarios
        public DataTable BuscarPorUsuario(int iIdUsuario)
        {
            try
            {
                return ctrlSentencias.ConsultarPorUsuario(iIdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar por usuario: " + ex.Message);
            }
        }

        //Muestra los usuarios
        public DataTable ObtenerUsuarios()
        {
            try
            {
                return ctrlSentencias.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios: " + ex.Message);
            }
        }

        // Registros
        public void RegistrarAccion(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstado)
        {
            try
            {
                ctrlSentencias.InsertarBitacora(iIdUsuario, iIdAplicacion, sAccion, bEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la acción en la Bitácora: " + ex.Message);
            }
        }

        //Registrar incio de sesión
        public void RegistrarInicioSesion(int iIdUsuario)
        {
            try
            {
                //Cls_UsuarioConectado.IniciarSesion(iIdUsuario, "UsuarioActual", Cls_UsuarioConectado.iIdPerfil);
                ctrlSentencias.RegistrarInicioSesion(iIdUsuario, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar inicio de sesión: " + ex.Message);
            }
        }

        public void RegistrarCierreSesion(int iIdUsuario)
        {
            try
            {
                ctrlSentencias.RegistrarCierreSesion(iIdUsuario, 0);
                Cls_Usuario_Conectado.CerrarSesion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar cierre de sesión: " + ex.Message);
            }
        }

        // Exportar

        public void ExportarBitacora(DataTable dt, string rutaArchivo)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("No hay datos disponibles para exportar.");

                var sb = new StringBuilder();

                // Encabezados
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(dt.Columns[i].ColumnName);
                }
                sb.AppendLine();

                // Filas
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0) sb.Append(',');
                        sb.Append(row[i]?.ToString().Replace(",", " "));
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al exportar la Bitácora: " + ex.Message);
            }
        }

       // Datos generales

        public DataTable ObtenerBitacora()
        {
            try
            {
                return ctrlSentencias.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Bitácora: " + ex.Message);
            }
        }
    }
}

//Fin del código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025
