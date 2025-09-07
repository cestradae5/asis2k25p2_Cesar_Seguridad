using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;

namespace CapaModelo
{
    /* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 * */
    public class SentenciasPerfiles
    {
        Conexion conexion = new Conexion();

        // Método para Combo Perfiles
        public string[] LlenarComboPerfiles()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT pk_id_perfil, puesto_perfil FROM tbl_PERFIL";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString());
            }
            return lista.ToArray();
        }

        // Método para Combo Tipos
        public string[] LlenarComboTipos()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT DISTINCT tipo_perfil FROM tbl_PERFIL";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader.GetValue(0).ToString());
            }
            return lista.ToArray();
        }

        // Métodos originales (opcional, para búsquedas y CRUD)
        public DataTable ObtenerPerfiles()
        {
            string sql = "SELECT pk_id_perfil, puesto_perfil FROM tbl_PERFIL";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerTipos()
        {
            string sql = "SELECT DISTINCT tipo_perfil FROM tbl_PERFIL";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ... Métodos de Insertar, Modificar, y Buscar siguen igual ...
    

// Buscar un perfil por ID
public DataRow BuscarPerfilPorId(int idPerfil)
        {
            string sql = @"SELECT * FROM tbl_PERFIL WHERE pk_id_perfil = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", idPerfil);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Insertar nuevo perfil
        public int InsertarPerfil(int id, string puesto, string descripcion, bool habilitado, bool inabilitado, int tipo)
        {
            string sql = @"INSERT INTO tbl_PERFIL (pk_id_perfil, puesto_perfil, descripcion_perfil, habilitado_perfil, inabilitado_perfil, tipo_perfil)
                           VALUES (?, ?, ?, ?, ?, ?)";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@puesto", puesto);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@habilitado", habilitado);
            cmd.Parameters.AddWithValue("@inabilitado", inabilitado);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            return cmd.ExecuteNonQuery();
        }

        // Modificar perfil existente
        public int ModificarPerfil(int id, string puesto, string descripcion, bool habilitado, bool inabilitado, int tipo)
        {
            string sql = @"UPDATE tbl_PERFIL 
                           SET puesto_perfil=?, descripcion_perfil=?, habilitado_perfil=?, inabilitado_perfil=?, tipo_perfil=? 
                           WHERE pk_id_perfil = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@puesto", puesto);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@habilitado", habilitado);
            cmd.Parameters.AddWithValue("@inabilitado", inabilitado);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
    }
}
