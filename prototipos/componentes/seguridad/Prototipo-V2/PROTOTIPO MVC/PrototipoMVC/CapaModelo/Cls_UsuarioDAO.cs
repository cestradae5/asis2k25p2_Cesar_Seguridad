// Jose Quiroa Martínez - DAO para tbl_USUARIO
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_UsuarioDAO
    {
        private Conexion conexion = new Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT pk_id_usuario, fk_id_empleado, nombre_usuario, contrasena_usuario,
                   contador_intentos_fallidos_usuario, estado_usuario, 
                   fecha_creacion_usuario, ultimo_cambio_contrasena_usuario,
                   pidio_cambio_contrasena_usuario
            FROM tbl_USUARIO";

        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_USUARIO
                (fk_id_empleado, nombre_usuario, contrasena_usuario,
                 contador_intentos_fallidos_usuario, estado_usuario,
                 fecha_creacion_usuario, ultimo_cambio_contrasena_usuario,
                 pidio_cambio_contrasena_usuario)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE tbl_USUARIO SET
                fk_id_empleado = ?,
                nombre_usuario = ?,
                contrasena_usuario = ?,
                contador_intentos_fallidos_usuario = ?,
                estado_usuario = ?,
                fecha_creacion_usuario = ?,
                ultimo_cambio_contrasena_usuario = ?,
                pidio_cambio_contrasena_usuario = ?
            WHERE pk_id_usuario = ?";

        private static readonly string SQL_DELETE = "DELETE FROM tbl_USUARIO WHERE pk_id_usuario = ?";

        private static readonly string SQL_QUERY = @"
            SELECT pk_id_usuario, fk_id_empleado, nombre_usuario, contrasena_usuario,
                   contador_intentos_fallidos_usuario, estado_usuario, 
                   fecha_creacion_usuario, ultimo_cambio_contrasena_usuario,
                   pidio_cambio_contrasena_usuario
            FROM tbl_USUARIO
            WHERE pk_id_usuario = ?";

        
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

                cmd.Parameters.AddWithValue("@fk_id_empleado", usr.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@nombre_usuario", usr.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena_usuario", usr.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@contador_intentos", usr.ContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@estado_usuario", usr.EstadoUsuario);
                cmd.Parameters.AddWithValue("@fecha_creacion", usr.FechaCreacion);
                cmd.Parameters.AddWithValue("@ultimo_cambio", usr.UltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@pidio_cambio", usr.PidioCambioContrasena);

                return cmd.ExecuteNonQuery();
            }
        }

        
        public int ActualizarUsuario(Cls_Usuario usr)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@fk_id_empleado", usr.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@nombre_usuario", usr.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena_usuario", usr.ContrasenaUsuario);
                cmd.Parameters.AddWithValue("@contador_intentos", usr.ContadorIntentosFallidos);
                cmd.Parameters.AddWithValue("@estado_usuario", usr.EstadoUsuario);
                cmd.Parameters.AddWithValue("@fecha_creacion", usr.FechaCreacion);
                cmd.Parameters.AddWithValue("@ultimo_cambio", usr.UltimoCambioContrasena);
                cmd.Parameters.AddWithValue("@pidio_cambio", usr.PidioCambioContrasena);
                cmd.Parameters.AddWithValue("@pk_id_usuario", usr.PkIdUsuario);

                return cmd.ExecuteNonQuery();
            }
        }

    
        public int BorrarUsuario(int idUsuario)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@pk_id_usuario", idUsuario);
                return cmd.ExecuteNonQuery();
            }
        }

        
        public Cls_Usuario Query(int idUsuario)
        {
            Cls_Usuario usr = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@pk_id_usuario", idUsuario);

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

