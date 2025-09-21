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
                SELECT  b.Pk_Id_Bitacora      AS id,
                        COALESCE(u.Cmp_Nombre_Usuario,'')    AS usuario,
                        COALESCE(a.Cmp_Nombre_Aplicacion,'') AS aplicacion,
                        b.Cmp_Fecha          AS fecha,
                        b.Cmp_Accion         AS accion,
                        b.Cmp_Ip             AS ip,
                        b.Cmp_Nombre_Pc      AS equipo,
                        CASE b.Cmp_Login_Estado
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u    ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                ORDER BY b.Cmp_Fecha DESC, b.Pk_Id_Bitacora DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por una fecha
        public DataTable ConsultarPorFecha(DateTime fecha)
        {
            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora      AS id,
                        u.Cmp_Nombre_Usuario  AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha           AS fecha,
                        b.Cmp_Accion          AS accion,
                        b.Cmp_Ip              AS ip,
                        b.Cmp_Nombre_Pc       AS equipo,
                        CASE b.Cmp_Login_Estado
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u    ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE DATE(b.Cmp_Fecha) = '{fecha:yyyy-MM-dd}'
                ORDER BY b.Cmp_Fecha DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por rango
        public DataTable ConsultarPorRango(DateTime inicio, DateTime fin)
        {
            DateTime finExclusivo = fin.Date.AddDays(1);

            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora AS id,
                        u.Cmp_Nombre_Usuario AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha          AS fecha,
                        b.Cmp_Accion         AS accion,
                        b.Cmp_Ip             AS ip,
                        b.Cmp_Nombre_Pc      AS equipo,
                        CASE b.Cmp_Login_Estado WHEN 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u    ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE b.Cmp_Fecha >= '{inicio:yyyy-MM-dd}'
                  AND b.Cmp_Fecha  < '{finExclusivo:yyyy-MM-dd}'
                ORDER BY b.Cmp_Fecha DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Consultar por usuario
        public DataTable ConsultarPorUsuario(int idUsuario)
        {
            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora AS id,
                        u.Cmp_Nombre_Usuario AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha          AS fecha,
                        b.Cmp_Accion         AS accion,
                        b.Cmp_Ip             AS ip,
                        b.Cmp_Nombre_Pc      AS equipo,
                        CASE b.Cmp_Login_Estado
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE b.Fk_Id_Usuario = {idUsuario}
                ORDER BY b.Cmp_Fecha DESC;";

            return dao.EjecutarConsulta(sSql);
        }

        // Insertar en bitácora
        public void InsertarBitacora(int idUsuario, int idAplicacion, string accion, bool estadoLogin)
        {
            string idApp = (idAplicacion == 0) ? "NULL" : idAplicacion.ToString();

            string sSql = $@"
                INSERT INTO Tbl_Bitacora
                (Fk_Id_Usuario, Fk_Id_Aplicacion, Cmp_Fecha, Cmp_Accion, Cmp_Ip, Cmp_Nombre_Pc, Cmp_Login_Estado)
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
