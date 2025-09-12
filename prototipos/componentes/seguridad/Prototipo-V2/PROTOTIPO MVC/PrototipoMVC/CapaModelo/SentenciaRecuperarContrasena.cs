using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaModelo
{
        public class SentenciaRecuperarContrasena
    {
        Conexion conexion = new Conexion();


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Verificar si el token es valido
        public OdbcDataReader validarToken(int idUsuario, string token) {

            string sql = @" SELECT * FROM tbl_TOKEN_RESTAURAR_CONTRASENA
                            WHERE fk_id_usuario = ? AND token_restaurar_contrasena = ?
                            AND utilizado_token_restaurar_contrasena = 0
                            AND expiracion_token_restaurar_contrasena >= NOW()";

            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@fk_id_usuario", idUsuario);
            cmd.Parameters.AddWithValue("@token", token);

            return cmd.ExecuteReader();
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Actualizar la contraseña del usuario
        public int ActualizarContrasena(int idUsuario, string nuevaContrasena)
        {
            string sql = "UPDATE tbl_USUARIO SET contrasena_usuario = ?, " +
                         "ultimo_cambio_contrasena_usuario = NOW(), pidio_cambio_contrasena_usuario = 0 " +
                         "WHERE pk_id_usuario = ?";

            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@contrasena", nuevaContrasena);
            cmd.Parameters.AddWithValue("@id", idUsuario);

            return cmd.ExecuteNonQuery();
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Marcar token como usado
        public int MarcarTokenUsado(int idToken)
        {
            string sql = "UPDATE tbl_TOKEN_RESTAURAR_CONTRASENA SET " +
                         "utilizado_token_restaurar_contrasena = 1, " +
                         "fecha_utilizado_restaurar_contrasena = NOW() " +
                         "WHERE pk_id_token_restaurar_contrasena = ?";

            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@idToken", idToken);

            return cmd.ExecuteNonQuery();
        }

    }
}
