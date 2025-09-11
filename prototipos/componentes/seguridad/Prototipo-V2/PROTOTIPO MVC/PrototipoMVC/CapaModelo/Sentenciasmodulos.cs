using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;


namespace CapaModelo
{
    public class SentenciasModulos
    {
        Conexion conexion = new Conexion();

        public string[] LlenarComboModulos()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT pk_id_modulo, nombre_modulo FROM tbl_MODULO";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString());
            }
            return lista.ToArray();
        }

        public DataTable ObtenerModulos()
        {
            string sql = "SELECT pk_id_modulo, nombre_modulo FROM tbl_MODULO";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataRow BuscarModuloPorId(int idModulo)
        {
            string sql = @"SELECT * FROM tbl_MODULO WHERE pk_id_modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", idModulo);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public int InsertarModulo(int id, string nombre, string descripcion, byte habilitado, byte inabilitado)
        {
            string sql = @"INSERT INTO tbl_MODULO (pk_id_modulo, nombre_modulo, descripcion_modulo, habilitado_modulo, inabilitado_modulo) 
                           VALUES (?, ?, ?, ?, ?)";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@habilitado", habilitado);
            cmd.Parameters.AddWithValue("@inabilitado", inabilitado);
            return cmd.ExecuteNonQuery();
        }

        public int EliminarModulo(int id)
        {
            string sql = @"DELETE FROM tbl_MODULO WHERE pk_id_modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }


        public int ModificarModulo(int id, string nombre, string descripcion, byte habilitado, byte inabilitado)
        {
            string sql = @"UPDATE tbl_MODULO 
                           SET nombre_modulo=?, descripcion_modulo=?, habilitado_modulo=?, inabilitado_modulo=? 
                           WHERE pk_id_modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@habilitado", habilitado);
            cmd.Parameters.AddWithValue("@inabilitado", inabilitado);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
    }
}
