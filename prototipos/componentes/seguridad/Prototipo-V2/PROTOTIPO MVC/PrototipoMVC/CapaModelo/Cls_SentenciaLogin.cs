// Pablo Jose Quiroa Martínez - 0901-22-2929
using System;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_SentenciaLogin
    {
        private Cls_Conexion gClsConexion = new Cls_Conexion();

        
        // MÉTODO: Validar Login
        
        public OdbcDataReader fun_ValidarLogin(string sUsuario)
        {
            try
            {
                OdbcConnection oConexion = gClsConexion.conexion();
                string sSql = @"
                    SELECT 
                        Pk_Id_Usuario, 
                        Cmp_Nombre_Usuario, 
                        Cmp_Contrasena_Usuario, 
                        Cmp_Intentos_Fallidos_Usuario, 
                        Cmp_Estado_Usuario
                    FROM Tbl_Usuario
                    WHERE LOWER(Cmp_Nombre_Usuario) = LOWER(?);";

                OdbcCommand oCmd = new OdbcCommand(sSql, oConexion);
                oCmd.Parameters.AddWithValue("?", sUsuario);

                OdbcDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                    return oReader;
                else
                {
                    oReader.Close();
                    oConexion.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en fun_ValidarLogin: " + ex.Message);
                return null;
            }
        }

     
        // MÉTODO: Actualizar Intentos
      
        public void fun_ActualizarIntentos(int iIdUsuario, int iIntentos)
        {
            try
            {
                using (OdbcConnection oConexion = gClsConexion.conexion())
                {
                    string sSql = @"
                        UPDATE Tbl_Usuario 
                        SET Cmp_Contador_Intentos_Fallidos_Usuario = ? 
                        WHERE Pk_Id_Usuario = ?;";

                    OdbcCommand oCmd = new OdbcCommand(sSql, oConexion);
                    oCmd.Parameters.AddWithValue("?", iIntentos);
                    oCmd.Parameters.AddWithValue("?", iIdUsuario);
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en fun_ActualizarIntentos: " + ex.Message);
            }
        }

       
        // MÉTODO: Bloquear Usuario
        
        public void fun_BloquearUsuario(int iIdUsuario, string sMotivo)
        {
            try
            {
                using (OdbcConnection oConexion = gClsConexion.conexion())
                {
                    // Actualizar estado
                    string sSqlEstado = @"
                        UPDATE Tbl_Usuario 
                        SET Cmp_Estado_Usuario = 'Bloqueado' 
                        WHERE Pk_Id_Usuario = ?;";

                    OdbcCommand oCmdEstado = new OdbcCommand(sSqlEstado, oConexion);
                    oCmdEstado.Parameters.AddWithValue("?", iIdUsuario);
                    oCmdEstado.ExecuteNonQuery();

                    // Registrar bloqueo
                    string sSqlBloqueo = @"
                        INSERT INTO Tbl_Bloqueo_Usuario
                        (Fk_Id_Usuario, Cmp_Fecha_Inicio_Bloqueo_Usuario, Cmp_Motivo_Bloqueo_Usuario)
                        VALUES (?, NOW(), ?);";

                    OdbcCommand oCmdBloqueo = new OdbcCommand(sSqlBloqueo, oConexion);
                    oCmdBloqueo.Parameters.AddWithValue("?", iIdUsuario);
                    oCmdBloqueo.Parameters.AddWithValue("?", sMotivo);
                    oCmdBloqueo.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en fun_BloquearUsuario: " + ex.Message);
            }
        }
    }
}

// Pablo Jose Quiroa Martínez - 0901-22-2929 12/10/2025