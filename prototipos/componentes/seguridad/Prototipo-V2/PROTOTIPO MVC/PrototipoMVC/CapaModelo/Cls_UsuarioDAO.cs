// Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_UsuarioDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT Pk_Id_Usuario, Fk_Id_Empleado, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario,
                   Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario, 
                   Cmp_FechaCreacion_Usuario, Cmp_Ultimo_Cambio_Contrasenea,
                   Cmp_Pidio_Cambio_Contrasenea
            FROM Tbl_Usuario";

        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Usuario
                (Fk_Id_Empleado, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario,
                 Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario,
                 Cmp_FechaCreacion_Usuario, Cmp_Ultimo_Cambio_Contrasenea,
                 Cmp_Pidio_Cambio_Contrasenea)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE Tbl_Usuario SET
                Fk_Id_Empleado = ?,
                Cmp_Nombre_Usuario = ?,
                Cmp_Contrasena_Usuario = ?,
                Cmp_Intentos_Fallidos_Usuario = ?,
                Cmp_Estado_Usuario = ?,
                Cmp_FechaCreacion_Usuario = ?,
                Cmp_Ultimo_Cambio_Contrasenea = ?,
                Cmp_Pidio_Cambio_Contrasenea = ?
            WHERE Pk_Id_Usuario = ?";

        private static readonly string SQL_DELETE = "DELETE FROM Tbl_Usuario WHERE Pk_Id_Usuario = ?";

        private static readonly string SQL_QUERY = @"
            SELECT Pk_Id_Usuario, Fk_Id_Empleado, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario,
                   Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario, 
                   Cmp_FechaCreacion_Usuario, Cmp_Ultimo_Cambio_Contrasenea,
                   Cmp_Pidio_Cambio_Contrasenea
            FROM Tbl_Usuario
            WHERE Pk_Id_Usuario = ?";

        public List<Cls_Usuario> fun_ObtenerUsuarios()
        {
            List<Cls_Usuario> lista = new List<Cls_Usuario>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn);
                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cls_Usuario usr = new Cls_Usuario
                    {
                        iPkIdUsuario = reader.GetInt32(0),
                        iFkIdEmpleado = reader.GetInt32(1),
                        sNombreUsuario = reader.GetString(2),
                        sContrasenaUsuario = reader.GetString(3),
                        iContadorIntentosFallidos = reader.GetInt32(4),
                        bEstadoUsuario = reader.GetBoolean(5),
                        dFechaCreacion = reader.GetDateTime(6),
                        dUltimoCambioContrasena = reader.GetDateTime(7),
                        bPidioCambioContrasena = reader.GetBoolean(8)
                    };
                    lista.Add(usr);
                }
            }
            return lista;
        }

        public int InsertarUsuario(Cls_Usuario usr)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                cmd.Parameters.AddWithValue("@Fk_Id_Empleado", usr.iFkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Usuario", usr.sNombreUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Contrasena_Usuario", usr.sContrasenaUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Intentos_Fallidos_Usuario", usr.iContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Usuario", usr.bEstadoUsuario);
                cmd.Parameters.AddWithValue("@Cmp_FechaCreacion_Usuario", usr.dFechaCreacion);
                cmd.Parameters.AddWithValue("@Cmp_Ultimo_Cambio_Contrasenea", usr.dUltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@Cmp_Pidio_Cambio_Contrasenea", usr.bPidioCambioContrasena);

                return cmd.ExecuteNonQuery();
            }
        }

        public int ActualizarUsuario(Cls_Usuario usr)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Fk_Id_Empleado", usr.iFkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Usuario", usr.sNombreUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Contrasena_Usuario", usr.sContrasenaUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Intentos_Fallidos_Usuario", usr.iContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Usuario", usr.bEstadoUsuario);
                cmd.Parameters.AddWithValue("@Cmp_FechaCreacion_Usuario", usr.dFechaCreacion);
                cmd.Parameters.AddWithValue("@Cmp_Ultimo_Cambio_Contrasenea", usr.dUltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@Cmp_Pidio_Cambio_Contrasenea", usr.bPidioCambioContrasena);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", usr.iPkIdUsuario);

                return cmd.ExecuteNonQuery();
            }
        }

        public int BorrarUsuario(int iIdUsuario)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", iIdUsuario);
                return cmd.ExecuteNonQuery();
            }
        }

        public Cls_Usuario Query(int iIdUsuario)
        {
            Cls_Usuario usr = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", iIdUsuario);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usr = new Cls_Usuario
                    {
                        iPkIdUsuario = reader.GetInt32(0),
                        iFkIdEmpleado = reader.GetInt32(1),
                        sNombreUsuario = reader.GetString(2),
                        sContrasenaUsuario = reader.GetString(3),
                        iContadorIntentosFallidos = reader.GetInt32(4),
                        bEstadoUsuario = reader.GetBoolean(5),
                        dFechaCreacion = reader.GetDateTime(6),
                        dUltimoCambioContrasena = reader.GetDateTime(7),
                        bPidioCambioContrasena = reader.GetBoolean(8)
                    };
                }
            }
            return usr;
        }
        public int ObtenerIdPerfilDeUsuario(int iIdUsuario)
        {
            int idPerfil = 0;
            string sql = "SELECT Fk_Id_Perfil FROM Tbl_Usuario_Perfil WHERE Fk_Id_Usuario = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Fk_Id_Usuario", iIdUsuario);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    idPerfil = Convert.ToInt32(result);
                }
            }
            return idPerfil;
        }
    }
}

// Pablo Quiroa 0901-22-2929