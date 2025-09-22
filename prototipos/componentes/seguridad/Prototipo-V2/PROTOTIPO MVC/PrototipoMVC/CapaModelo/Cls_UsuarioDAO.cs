// Jose Quiroa Martínez - DAO para Tbl_Usuario
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_UsuarioDAO
    {
        private Conexion conexion = new Conexion();

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

        public List<Cls_Usuario> ObtenerUsuarios()
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
                        PkIdUsuario = reader.GetInt32(0),
                        FkIdEmpleado = reader.GetInt32(1),
                        NombreUsuario = reader.GetString(2),
                        ContrasenaUsuario = reader.GetString(3),
                        ContadorIntentosFallidos = reader.GetInt32(4),
                        EstadoUsuario = reader.GetBoolean(5),
                        FechaCreacion = reader.GetDateTime(6),
                        UltimoCambioContrasena = reader.GetDateTime(7),
                        PidioCambioContrasena = reader.GetBoolean(8)
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

                cmd.Parameters.AddWithValue("@Fk_Id_Empleado", usr.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Usuario", usr.NombreUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Contrasena_Usuario", usr.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Intentos_Fallidos_Usuario", usr.ContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Usuario", usr.EstadoUsuario);
                cmd.Parameters.AddWithValue("@Cmp_FechaCreacion_Usuario", usr.FechaCreacion);
                cmd.Parameters.AddWithValue("@Cmp_Ultimo_Cambio_Contrasenea", usr.UltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@Cmp_Pidio_Cambio_Contrasenea", usr.PidioCambioContrasena);

                return cmd.ExecuteNonQuery();
            }
        }

        public int ActualizarUsuario(Cls_Usuario usr)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Fk_Id_Empleado", usr.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Usuario", usr.NombreUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Contrasena_Usuario", usr.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@Cmp_Intentos_Fallidos_Usuario", usr.ContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Usuario", usr.EstadoUsuario);
                cmd.Parameters.AddWithValue("@Cmp_FechaCreacion_Usuario", usr.FechaCreacion);
                cmd.Parameters.AddWithValue("@Cmp_Ultimo_Cambio_Contrasenea", usr.UltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@Cmp_Pidio_Cambio_Contrasenea", usr.PidioCambioContrasena);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", usr.PkIdUsuario);

                return cmd.ExecuteNonQuery();
            }
        }

        public int BorrarUsuario(int idUsuario)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", idUsuario);
                return cmd.ExecuteNonQuery();
            }
        }

        public Cls_Usuario Query(int idUsuario)
        {
            Cls_Usuario usr = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Usuario", idUsuario);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usr = new Cls_Usuario
                    {
                        PkIdUsuario = reader.GetInt32(0),
                        FkIdEmpleado = reader.GetInt32(1),
                        NombreUsuario = reader.GetString(2),
                        ContrasenaUsuario = reader.GetString(3),
                        ContadorIntentosFallidos = reader.GetInt32(4),
                        EstadoUsuario = reader.GetBoolean(5),
                        FechaCreacion = reader.GetDateTime(6),
                        UltimoCambioContrasena = reader.GetDateTime(7),
                        PidioCambioContrasena = reader.GetBoolean(8)
                    };
                }
            }
            return usr;
        }
    }
}
