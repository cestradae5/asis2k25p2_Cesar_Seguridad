using System; //0901-22-2929 Pablo Jose Quiroa Martinez
using System.Data.Odbc;

namespace CapaModelo
{
    public class SentenciaLogin
    {
        Conexion conexion = new Conexion();

        // Validar login
        public OdbcDataReader validarLogin(string usuario)
        {
            try
            {
                OdbcConnection con = conexion.conexion();
                string sql = @"
                    SELECT Pk_Id_Usuario, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario, Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario
                    FROM Tbl_Usuario
                    WHERE LOWER(Cmp_Nombre_Usuario) = LOWER(?);";


                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("?", usuario);

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
                    string sql = @"UPDATE Tbl_Usuario 
                                   SET Cmp_Contador_Intentos_Fallidos_Usuario = ? 
                                   WHERE Pk_Id_Usuario = ?;";
                    OdbcCommand cmd = new OdbcCommand(sql, con);
                    cmd.Parameters.AddWithValue("?", intentos);
                    cmd.Parameters.AddWithValue("?", idUsuario);
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
                    // Actualizar estado del usuario
                    string sql = @"UPDATE Tbl_Usuario 
                                   SET Cmp_Estado_Usuario = 'Bloqueado' 
                                   WHERE Pk_Id_Usuario = ?;";
                    OdbcCommand cmd = new OdbcCommand(sql, con);
                    cmd.Parameters.AddWithValue("?", idUsuario);
                    cmd.ExecuteNonQuery();

                    // Registrar bloqueo en la tabla de bloqueos
                    string sqlBloqueo = @"INSERT INTO Tbl_Bloqueo_Usuario
                                          (Fk_Id_Usuario, Cmp_Fecha_Inicio_Bloqueo_Usuario, Cmp_Motivo_Bloqueo_Usuario)
                                          VALUES (?, NOW(), ?);";
                    OdbcCommand cmdBloqueo = new OdbcCommand(sqlBloqueo, con);
                    cmdBloqueo.Parameters.AddWithValue("?", idUsuario);
                    cmdBloqueo.Parameters.AddWithValue("?", motivo);
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
