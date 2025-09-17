/// Autor: Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025
using System;
using System.Data;
using System.Net;

namespace CapaModelo
{
    public class Cls_SentenciasBitacora
    {
        // Instancia del DAO para ejecutar consultas
        private readonly Cls_BitacoraDao dao = new Cls_BitacoraDao();

        // Obtener la IP del equipo
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

        // Obtener el nombre de la computadora
        private string ObtenerNombrePc()
        {
            return Environment.MachineName;
        }

        // Fecha actual formateada
        private string FechaActual()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // Listar bitácora completa 
        public DataTable Listar()
        {
            string sSql = @"
                SELECT  b.pk_id_bitacora        AS id,
                        COALESCE(u.nombre_usuario,'')    AS usuario,
                        COALESCE(a.nombre_aplicacion,'') AS aplicacion,
                        b.fecha_bitacora        AS fecha,
                        b.accion_bitacora       AS accion,
                        b.ip_bitacora           AS ip,
                        b.nombre_pc_bitacora    AS equipo,
                        CASE b.login_estado_bitacora
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u    ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                ORDER BY b.fecha_bitacora DESC, b.pk_id_bitacora DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por una fecha
        public DataTable ConsultarPorFecha(DateTime fecha)
        {
            string sSql = $@"
                SELECT  b.pk_id_bitacora        AS id,
                        u.nombre_usuario        AS usuario,
                        a.nombre_aplicacion     AS aplicacion,
                        b.fecha_bitacora        AS fecha,
                        b.accion_bitacora       AS accion,
                        b.ip_bitacora           AS ip,
                        b.nombre_pc_bitacora    AS equipo,
                        CASE b.login_estado_bitacora
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u    ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                WHERE DATE(b.fecha_bitacora) = '{fecha:yyyy-MM-dd}'
                ORDER BY b.fecha_bitacora DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por rango
        public DataTable ConsultarPorRango(DateTime inicio, DateTime fin)
        {
            // fin exclusivo = día siguiente (incluye todo el día fin)
            DateTime finExclusivo = fin.Date.AddDays(1);

            string sSql = $@"
                SELECT  b.pk_id_bitacora AS id,
                        u.nombre_usuario AS usuario,
                        a.nombre_aplicacion AS aplicacion,
                        b.fecha_bitacora AS fecha,
                        b.accion_bitacora AS accion,
                        b.ip_bitacora AS ip,
                        b.nombre_pc_bitacora AS equipo,
                        CASE b.login_estado_bitacora WHEN 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u    ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                WHERE b.fecha_bitacora >= '{inicio:yyyy-MM-dd}'
                  AND b.fecha_bitacora  < '{finExclusivo:yyyy-MM-dd}'
                ORDER BY b.fecha_bitacora DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por usuario
        public DataTable ConsultarPorUsuario(int idUsuario)
        {
            string sSql = $@"
                SELECT  b.pk_id_bitacora AS id,
                        u.nombre_usuario AS usuario,
                        a.nombre_aplicacion AS aplicacion,
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
                WHERE b.fk_id_usuario = {idUsuario}
                ORDER BY b.fecha_bitacora DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            string sSql = @"
                SELECT pk_id_usuario, nombre_usuario
                FROM tbl_USUARIO
                WHERE estado_usuario <> 'Bloqueado';";

            return dao.EjecutarConsulta(sSql);
        }

        // Insertar en bitácora
        public void InsertarBitacora(int idUsuario, int idAplicacion, string accion, bool estadoLogin)
        {
            string idApp = (idAplicacion == 0) ? "NULL" : idAplicacion.ToString();

            string sSql = $@"
                INSERT INTO tbl_BITACORA
                (fk_id_usuario, fk_id_aplicacion, fecha_bitacora, accion_bitacora, ip_bitacora, nombre_pc_bitacora, login_estado_bitacora)
                VALUES ({idUsuario}, {idApp}, '{FechaActual()}', '{accion}', '{ObtenerIP()}', '{ObtenerNombrePc()}', {(estadoLogin ? 1 : 0)});";

            dao.EjecutarComando(sSql);
        }

        // Registrar inicio de sesión en la bitácora
        public void RegistrarInicioSesion(int idUsuario, int idAplicacion = 0)
        {
            Cls_UsuarioConectado.IniciarSesion(idUsuario, "nombre_usuario");
            InsertarBitacora(idUsuario, idAplicacion, "Ingreso", Cls_UsuarioConectado.bLoginEstado);
        }

        // Registrar cierre de sesión en la bitácora
        public void RegistrarCierreSesion(int idUsuario, int idAplicacion = 0)
        {
            InsertarBitacora(idUsuario, idAplicacion, "Cierre de sesión", false);
            Cls_UsuarioConectado.CerrarSesion();
        }
    }
}
