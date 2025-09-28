// Brandon Alexander Hernandez Salguero 0901-22-9663
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_PerfilesDAO
    {
        // Sentencias SQL adaptadas a la tabla 'Tbl_Perfil'
        private static readonly string SQL_SELECT = @"
            SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil, Cmp_Descripcion_Perfil, 
                   Cmp_Estado_Perfil, Cmp_Tipo_Perfil
            FROM Tbl_Perfil";

        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Perfil 
                (Cmp_Puesto_Perfil, Cmp_Descripcion_Perfil, Cmp_Estado_Perfil, Cmp_Tipo_Perfil)
            VALUES (?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE Tbl_Perfil SET
                Cmp_Puesto_Perfil = ?, 
                Cmp_Descripcion_Perfil = ?, 
                Cmp_Estado_Perfil = ?, 
                Cmp_Tipo_Perfil = ?
            WHERE Pk_Id_Perfil = ?";

        private static readonly string SQL_DELETE = "DELETE FROM Tbl_Perfil WHERE Pk_Id_Perfil = ?";

        private static readonly string SQL_QUERY = @"
            SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil, Cmp_Descripcion_Perfil, 
                   Cmp_Estado_Perfil, Cmp_Tipo_Perfil
            FROM Tbl_Perfil 
            WHERE Pk_Id_Perfil = ?";

        // Clase de conexión
        private Cls_Conexion conexion = new Cls_Conexion();

        public List<Cls_Perfiles> lisObtenerPerfiles()
        {
            List<Cls_Perfiles> lista = new List<Cls_Perfiles>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn);
                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cls_Perfiles perfil = new Cls_Perfiles()
                    {
                        Pk_Id_Perfil = reader.GetInt32(0),
                        Cmp_Puesto_Perfil = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Cmp_Descripcion_Perfil = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Cmp_Estado_Perfil = reader.GetBoolean(3),
                        Cmp_Tipo_Perfil = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                    };
                    lista.Add(perfil);
                }
            }
            return lista;
        }

        public bool bInsertarPerfil(Cls_Perfiles perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);
                cmd.Parameters.AddWithValue("@Cmp_Puesto_Perfil", perfil.Cmp_Puesto_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Perfil", perfil.Cmp_Descripcion_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Perfil", perfil.Cmp_Estado_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Tipo_Perfil", perfil.Cmp_Tipo_Perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bActualizarPerfil(Cls_Perfiles perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);
                cmd.Parameters.AddWithValue("@Cmp_Puesto_Perfil", perfil.Cmp_Puesto_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Perfil", perfil.Cmp_Descripcion_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Perfil", perfil.Cmp_Estado_Perfil);
                cmd.Parameters.AddWithValue("@Cmp_Tipo_Perfil", perfil.Cmp_Tipo_Perfil);
                cmd.Parameters.AddWithValue("@Pk_Id_Perfil", perfil.Pk_Id_Perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bEliminarPerfil(int pk_Id_Perfil, out string mensajeError)
        {
            mensajeError = "";
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                    cmd.Parameters.AddWithValue("@Pk_Id_Perfil", pk_Id_Perfil);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (OdbcException ex)
            {
                // Detectar error de llave foránea (MySQL y ODBC suelen tener este texto)
                if (ex.Message.Contains("a foreign key constraint fails"))
                {
                    mensajeError = "No es posible eliminar el perfil porque está vinculado a uno o más usuarios.";
                }
                else
                {
                    mensajeError = "Error al eliminar el perfil: " + ex.Message;
                }
                return false;
            }
        }

        public Cls_Perfiles ObtenerPerfilPorId(int pk_Id_Perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Perfil", pk_Id_Perfil);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Cls_Perfiles()
                    {
                        Pk_Id_Perfil = reader.GetInt32(0),
                        Cmp_Puesto_Perfil = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Cmp_Descripcion_Perfil = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Cmp_Estado_Perfil = reader.GetBoolean(3),
                        Cmp_Tipo_Perfil = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                    };
                }
            }
            return null;
        }
    }
}