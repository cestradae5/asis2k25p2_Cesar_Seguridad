//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using System.Net;

namespace CapaModelo
{
    public class Cls_SentenciasBitacora
    {
        private readonly Cls_BitacoraDao ctrlBitacoraDao = new Cls_BitacoraDao();

        //Obtener ip
        private string ObtenerIp()
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

        //Obtener nombre
        private string ObtenerNombrePc()
        {
            return Environment.MachineName;
        }

        //Fecha actual
        private string FechaActual()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //Mostrar la tabla
        public DataTable Listar()
        {
            string sSql = @"
                SELECT  b.Pk_Id_Bitacora        AS id,
                        COALESCE(u.Cmp_Nombre_Usuario,'')    AS usuario,
                        COALESCE(a.Cmp_Nombre_Aplicacion,'') AS aplicacion,
                        b.Cmp_Fecha        AS fecha,
                        b.Cmp_Accion       AS accion,
                        b.Cmp_Ip           AS ip,
                        b.Cmp_Nombre_Pc    AS equipo,
                        CASE b.Cmp_Login_Estado
                             WHEN 1 THEN 'Conectado'
                             ELSE 'Desconectado'
                        END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u    ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                ORDER BY b.Cmp_Fecha DESC, b.Pk_Id_Bitacora DESC;";

            return ctrlBitacoraDao.EjecutarConsulta(sSql);
        }

        //Consulta por fecha
        public DataTable ConsultarPorFecha(DateTime fecha)
        {
            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora AS id,
                        u.Cmp_Nombre_Usuario AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha AS fecha,
                        b.Cmp_Accion AS accion,
                        b.Cmp_Ip AS ip,
                        b.Cmp_Nombre_Pc AS equipo,
                        CASE b.Cmp_Login_Estado WHEN 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE DATE(b.Cmp_Fecha) = '{fecha:yyyy-MM-dd}'
                ORDER BY b.Cmp_Fecha DESC;";

            return ctrlBitacoraDao.EjecutarConsulta(sSql);
        }

        //Consulta por rango de fechas
        public DataTable ConsultarPorRango(DateTime inicio, DateTime fin)
        {
            DateTime finExclusivo = fin.Date.AddDays(1);

            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora AS id,
                        u.Cmp_Nombre_Usuario AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha AS fecha,
                        b.Cmp_Accion AS accion,
                        b.Cmp_Ip AS ip,
                        b.Cmp_Nombre_Pc AS equipo,
                        CASE b.Cmp_Login_Estado WHEN 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE b.Cmp_Fecha >= '{inicio:yyyy-MM-dd}'
                  AND b.Cmp_Fecha  < '{finExclusivo:yyyy-MM-dd}'
                ORDER BY b.Cmp_Fecha DESC;";

            return ctrlBitacoraDao.EjecutarConsulta(sSql);
        }

        //Consulta por usuario
        public DataTable ConsultarPorUsuario(int iIdUsuario)
        {
            string sSql = $@"
                SELECT  b.Pk_Id_Bitacora AS id,
                        u.Cmp_Nombre_Usuario AS usuario,
                        a.Cmp_Nombre_Aplicacion AS aplicacion,
                        b.Cmp_Fecha AS fecha,
                        b.Cmp_Accion AS accion,
                        b.Cmp_Ip AS ip,
                        b.Cmp_Nombre_Pc AS equipo,
                        CASE b.Cmp_Login_Estado WHEN 1 THEN 'Conectado' ELSE 'Desconectado' END AS estado
                FROM Tbl_Bitacora b
                LEFT JOIN Tbl_Usuario u ON u.Pk_Id_Usuario = b.Fk_Id_Usuario
                LEFT JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = b.Fk_Id_Aplicacion
                WHERE b.Fk_Id_Usuario = {iIdUsuario}
                ORDER BY b.Cmp_Fecha DESC;";

            return ctrlBitacoraDao.EjecutarConsulta(sSql);
        }

        //Desplegar los usuarios
        public DataTable ObtenerUsuarios()
        {
            string sSql = @"
                SELECT Pk_Id_Usuario, Cmp_Nombre_Usuario
                FROM Tbl_Usuario
                WHERE Cmp_Estado_Usuario <> 'Bloqueado';";

            return ctrlBitacoraDao.EjecutarConsulta(sSql);
        }

        //Insert de acciones
        public void InsertarBitacora(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstadoLogin)
        {
            string sIdApp = (iIdAplicacion == 0) ? "NULL" : iIdAplicacion.ToString();

            string sSql = $@"
                INSERT INTO Tbl_Bitacora
                (Fk_Id_Usuario, Fk_Id_Aplicacion, Cmp_Fecha, Cmp_Accion, Cmp_Ip, Cmp_Nombre_Pc, Cmp_Login_Estado)
                VALUES ({iIdUsuario}, {sIdApp}, '{FechaActual()}', '{sAccion}', '{ObtenerIp()}', '{ObtenerNombrePc()}', {(bEstadoLogin ? 1 : 0)});";

            ctrlBitacoraDao.EjecutarComando(sSql);
        }

        //Insert de inicio
        public void RegistrarInicioSesion(int iIdUsuario, int iIdAplicacion = 0)
        {
            Cls_UsuarioConectado.IniciarSesion(iIdUsuario, "Cmp_Nombre_Usuario");
            InsertarBitacora(iIdUsuario, iIdAplicacion, "Ingreso", Cls_UsuarioConectado.bLoginEstado);
        }

        //Insert de cierre
        public void RegistrarCierreSesion(int iIdUsuario, int iIdAplicacion = 0)
        {
            InsertarBitacora(iIdUsuario, iIdAplicacion, "Cierre de sesión", false);
            Cls_UsuarioConectado.CerrarSesion();
        }

    }
}
