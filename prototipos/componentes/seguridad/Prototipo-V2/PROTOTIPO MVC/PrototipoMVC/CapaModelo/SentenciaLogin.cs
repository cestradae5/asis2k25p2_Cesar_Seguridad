using System; //0901-22-2929 Pablo Jose Quiroa Martinez
using System.Data.Odbc;

namespace CapaModelo
{
    public class SentenciaLogin
    {
        Conexion conexion = new Conexion();

        
        public OdbcDataReader validarLogin(string usuario)
        {
            try
            {
                OdbcConnection con = conexion.conexion();
                string sql = "SELECT pk_id_usuario, nombre_usuario, contrasena_usuario, contador_intentos_fallidos_usuario, estado_usuario " +
                             "FROM tbl_usuario WHERE nombre_usuario = ?;";

                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                OdbcDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    return reader; 
                else
                {
                    reader.Close();
                    con.Close();
                    return null; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error validarLogin: " + ex.Message);
                return null;
            }
        }

        // Actualizar contador de intentos fallidos
        public void actualizarIntentos(int idUsuario, int intentos)
        {
            try
            {
                using (OdbcConnection con = conexion.conexion())
                {
                    string sql = "UPDATE tbl_usuario SET contador_intentos_fallidos_usuario = ? WHERE pk_id_usuario = ?;";
                    OdbcCommand cmd = new OdbcCommand(sql, con);
                    cmd.Parameters.AddWithValue("@intentos", intentos);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error actualizarIntentos: " + ex.Message);
            }
        }

        // Bloquear usuario
        public void bloquearUsuario(int idUsuario, string motivo)
        {
            try
            {
                using (OdbcConnection con = conexion.conexion())
                {
             
                    string sql = "UPDATE tbl_usuario SET estado_usuario = 'Bloqueado' WHERE pk_id_usuario = ?;";
                    OdbcCommand cmd = new OdbcCommand(sql, con);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();

                 
                    string sqlBloqueo = "INSERT INTO tbl_bloqueo_usuario (fk_id_usuario, fecha_inicio_bloqueo_usuario, motivo_bloqueo_usuario) " +
                                         "VALUES (?, NOW(), ?);";
                    OdbcCommand cmdBloqueo = new OdbcCommand(sqlBloqueo, con);
                    cmdBloqueo.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdBloqueo.Parameters.AddWithValue("@motivo", motivo);
                    cmdBloqueo.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error bloquearUsuario: " + ex.Message);
            }
        }
    }
}


