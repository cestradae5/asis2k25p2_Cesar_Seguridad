using System;
using System.Collections.Generic;
using System.Data.Odbc;
//Brandon Alexander Hernandez Salguero 0901-22-9663
namespace CapaModelo
{
    public class Cls_PerfilesDAO
    {
        // Sentencias SQL adaptadas a la tabla 'tbl_perfil'
        private static readonly string SQL_SELECT = @"
            SELECT pk_id_perfil, puesto_perfil, descripcion_perfil, estado_perfil, tipo_perfil
            FROM tbl_PERFIL";

        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_PERFIL 
                (puesto_perfil, descripcion_perfil, estado_perfil, tipo_perfil)
            VALUES (?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE tbl_PERFIL SET
                puesto_perfil = ?, 
                descripcion_perfil = ?, 
                estado_perfil = ?, 
                tipo_perfil = ?
            WHERE pk_id_perfil = ?";

        private static readonly string SQL_DELETE = "DELETE FROM tbl_PERFIL WHERE pk_id_perfil = ?";

        private static readonly string SQL_QUERY = @"
            SELECT pk_id_perfil, puesto_perfil, descripcion_perfil, estado_perfil, tipo_perfil
            FROM tbl_PERFIL 
            WHERE pk_id_perfil = ?";

        // Clase de conexión (ajusta el método si tu clase se llama diferente)
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
                cmd.Parameters.AddWithValue("@puesto_perfil", perfil.puesto_perfil);
                cmd.Parameters.AddWithValue("@descripcion_perfil", perfil.descripcion_perfil);
                cmd.Parameters.AddWithValue("@estado_perfil", perfil.estado_perfil);
                cmd.Parameters.AddWithValue("@tipo_perfil", perfil.tipo_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bActualizarPerfil(Cls_Perfiles perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);
                cmd.Parameters.AddWithValue("@puesto_perfil", perfil.puesto_perfil);
                cmd.Parameters.AddWithValue("@descripcion_perfil", perfil.descripcion_perfil);
                cmd.Parameters.AddWithValue("@estado_perfil", perfil.estado_perfil);
                cmd.Parameters.AddWithValue("@tipo_perfil", perfil.tipo_perfil);
                cmd.Parameters.AddWithValue("@pk_id_perfil", perfil.pk_id_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool bEliminarPerfil(int pk_id_perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@pk_id_perfil", pk_id_perfil);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Cls_Perfiles ObtenerPerfilPorId(int pk_id_perfil)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@pk_id_perfil", pk_id_perfil);
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
