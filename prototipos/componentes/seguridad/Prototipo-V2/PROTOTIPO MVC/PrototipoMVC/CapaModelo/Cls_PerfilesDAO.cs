// Brandon Alexander Hernandez Salguero 0901-22-9663
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
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
        private Conexion conexion = new Conexion();

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
                        pk_id_perfil = reader.GetInt32(0),
                        puesto_perfil = reader.IsDBNull(1) ? null : reader.GetString(1),
                        descripcion_perfil = reader.IsDBNull(2) ? null : reader.GetString(2),
                        estado_perfil = reader.GetBoolean(3),
                        tipo_perfil = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
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
                cmd.Parameters.AddWithValue("@Cmp_Puesto_Perfil", perfil.puesto_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Perfil", perfil.descripcion_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Perfil", perfil.estado_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Tipo_Perfil", perfil.tipo_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bActualizarPerfil(Cls_Perfiles perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);
                cmd.Parameters.AddWithValue("@Cmp_Puesto_Perfil", perfil.puesto_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Perfil", perfil.descripcion_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Perfil", perfil.estado_perfil);
                cmd.Parameters.AddWithValue("@Cmp_Tipo_Perfil", perfil.tipo_perfil);
                cmd.Parameters.AddWithValue("@Pk_Id_Perfil", perfil.pk_id_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bEliminarPerfil(int pk_id_perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Perfil", pk_id_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Cls_Perfiles ObtenerPerfilPorId(int pk_id_perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Perfil", pk_id_perfil);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Cls_Perfiles()
                    {
                        pk_id_perfil = reader.GetInt32(0),
                        puesto_perfil = reader.IsDBNull(1) ? null : reader.GetString(1),
                        descripcion_perfil = reader.IsDBNull(2) ? null : reader.GetString(2),
                        estado_perfil = reader.GetBoolean(3),
                        tipo_perfil = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                    };
                }
            }
            return null;
        }
    }
}
