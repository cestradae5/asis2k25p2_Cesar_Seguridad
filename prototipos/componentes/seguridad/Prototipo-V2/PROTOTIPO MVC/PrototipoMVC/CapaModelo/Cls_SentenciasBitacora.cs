// Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025


using System;
using System.Data;
using System.Linq;
using System.Net;
using System.IO;                // Para StreamWriter
using System.Text;              // Para Encoding
using System.Drawing;             // Para gráficos
using System.Drawing.Printing;  // Para PrintDocument


namespace CapaModelo
{
    public class Cls_SentenciasBitacora
    {
        private readonly Cls_BitacoraDao dao = new Cls_BitacoraDao();

        // Obtener IP del equipo
        private string ObtenerIP()
        {
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        // Obtener nombre de la PC
        private string ObtenerNombrePc()
        {
            return Environment.MachineName;
        }

        // Fecha actual
        private string FechaActual()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // Listar bitácora completa
        public DataTable Listar()
        {
            string sSql = @"
                SELECT b.pk_id_bitacora AS id,
                       COALESCE(u.nombre_usuario,'') AS usuario,
                       COALESCE(a.nombre_aplicacion,'') AS aplicacion,
                       COALESCE(t.nombre_tabla,'') AS tabla,
                       b.fecha_bitacora AS fecha,
                       b.accion_bitacora AS accion,
                       b.ip_bitacora AS ip,
                       b.nombre_pc_bitacora AS equipo,
                       CASE b.login_estado_bitacora
                            WHEN 1 THEN 'Conectado'
                            ELSE 'Desconectado'
                       END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                LEFT JOIN tbl_LISTA_TABLAS t ON t.pk_id_lista_tabla = b.fk_id_lista_tabla
                ORDER BY b.fecha_bitacora DESC, b.pk_id_bitacora DESC;";
            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por fecha
        public DataTable ConsultarPorFecha(DateTime fecha)
        {
            string sSql = $@"
                SELECT b.pk_id_bitacora AS id,
                       u.nombre_usuario AS usuario,
                       a.nombre_aplicacion AS aplicacion,
                       t.nombre_tabla AS tabla,
                       b.fecha_bitacora AS fecha,
                       b.accion_bitacora AS accion,
                       b.ip_bitacora AS ip,
                       b.nombre_pc_bitacora AS equipo,
                       CASE b.login_estado_bitacora
                            WHEN 1 THEN 'Conectado'
                            ELSE 'Desconectado'
                       END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                LEFT JOIN tbl_LISTA_TABLAS t ON t.pk_id_lista_tabla = b.fk_id_lista_tabla
                WHERE DATE(b.fecha_bitacora) = '{fecha:yyyy-MM-dd}'
                ORDER BY b.fecha_bitacora DESC;";
            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por rango de fechas
        public DataTable ConsultarPorRango(DateTime inicio, DateTime fin)
        {
            string sSql = $@"
                SELECT b.pk_id_bitacora AS id,
                       u.nombre_usuario AS usuario,
                       a.nombre_aplicacion AS aplicacion,
                       t.nombre_tabla AS tabla,
                       b.fecha_bitacora AS fecha,
                       b.accion_bitacora AS accion,
                       b.ip_bitacora AS ip,
                       b.nombre_pc_bitacora AS equipo,
                       CASE b.login_estado_bitacora
                            WHEN 1 THEN 'Conectado'
                            ELSE 'Desconectado'
                       END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                LEFT JOIN tbl_LISTA_TABLAS t ON t.pk_id_lista_tabla = b.fk_id_lista_tabla
                WHERE b.fecha_bitacora BETWEEN '{inicio:yyyy-MM-dd} 00:00:00' 
                                          AND '{fin:yyyy-MM-dd} 23:59:59'
                ORDER BY b.fecha_bitacora DESC;";
            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por usuario
        public DataTable ConsultarPorUsuario(int idUsuario)
        {
            string sSql = $@"
                SELECT b.pk_id_bitacora AS id,
                       u.nombre_usuario AS usuario,
                       a.nombre_aplicacion AS aplicacion,
                       t.nombre_tabla AS tabla,
                       b.fecha_bitacora AS fecha,
                       b.accion_bitacora AS accion,
                       b.ip_bitacora AS ip,
                       b.nombre_pc_bitacora AS equipo,
                       CASE b.login_estado_bitacora
                            WHEN 1 THEN 'Conectado'
                            ELSE 'Desconectado'
                       END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                LEFT JOIN tbl_LISTA_TABLAS t ON t.pk_id_lista_tabla = b.fk_id_lista_tabla
                WHERE b.fk_id_usuario = {idUsuario}
                ORDER BY b.fecha_bitacora DESC;";
            return dao.EjecutarConsulta(sSql);
        }

        // Listar usuarios
        public DataTable ListarUsuarios()
        {
            string sSql = "SELECT pk_id_usuario AS id, nombre_usuario AS usuario FROM tbl_USUARIO;";
            return dao.EjecutarConsulta(sSql);
        }

        // Insertar en bitácora
        public void InsertarBitacora(int idUsuario, int? idAplicacion, int? idListaTabla, string accion, bool estadoLogin)
        {
            string sSql = $@"
                INSERT INTO tbl_BITACORA
                (fk_id_usuario, fk_id_aplicacion, fk_id_lista_tabla, fecha_bitacora, accion_bitacora, ip_bitacora, nombre_pc_bitacora, login_estado_bitacora)
                VALUES ({idUsuario}, 
                        {(idAplicacion.HasValue ? idAplicacion.Value.ToString() : "NULL")},
                        {(idListaTabla.HasValue ? idListaTabla.Value.ToString() : "NULL")},
                        '{FechaActual()}',
                        '{accion}',
                        '{ObtenerIP()}',
                        '{ObtenerNombrePc()}',
                        {(estadoLogin ? 1 : 0)})";
            dao.EjecutarConsulta(sSql);
        }

        // Exportar a CSV
        public void ExportarCsv(string rutaArchivo)
        {
            DataTable dt = Listar();
            using (StreamWriter sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName).ToArray();
                sw.WriteLine(string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sw.WriteLine(string.Join(",", fields));
                }
            }
        }

        // Crear documento para imprimir
        public PrintDocument CrearDocumentoImpresion()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (sender, e) =>
            {
                Font font = new Font("Arial", 10);
                float y = 20;

                e.Graphics.DrawString("Reporte de Bitácora", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new PointF(20, y));
                y += 40;

                DataTable dt = Listar();
                foreach (DataRow row in dt.Rows)
                {
                    string linea = $"{row["fecha"]} | {row["usuario"]} | {row["aplicacion"]} | {row["tabla"]} | {row["accion"]} | {row["estado"]}";
                    e.Graphics.DrawString(linea, font, Brushes.Black, new PointF(20, y));
                    y += 20;
                }
            };
            return doc;
        }
    }
}
