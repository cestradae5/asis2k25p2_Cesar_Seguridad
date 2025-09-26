using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Modulo_Sentencias
    {
        Cls_Conexion conexion = new Cls_Conexion();

        public string[] LlenarComboModulos()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";
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
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataRow BuscarModuloPorId(int idModulo)
        {
            string sql = @"SELECT * FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", idModulo);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public int InsertarModulo(int id, string nombre, string descripcion, byte estado)
        {
            string sql = @"INSERT INTO Tbl_Modulo 
                   (Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo) 
                   VALUES (?, ?, ?, ?)";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {
                cmd.Parameters.Add("id", OdbcType.Int).Value = id;
                cmd.Parameters.Add("nombre", OdbcType.VarChar, 50).Value = nombre;
                cmd.Parameters.Add("descripcion", OdbcType.VarChar, 50).Value = descripcion;
                cmd.Parameters.Add("estado", OdbcType.Bit).Value = estado == 1; // true si 1, false si 0

                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarModulo(int id)
        {
            string sql = @"DELETE FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public int ModificarModulo(int id, string nombre, string descripcion, byte estado)
        {
            string sql = @"UPDATE Tbl_Modulo 
                   SET Cmp_Nombre_Modulo=?, Cmp_Descripcion_Modulo=?, Cmp_Estado_Modulo=? 
                   WHERE Pk_Id_Modulo = ?";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {
                // El orden debe coincidir con los '?'
                cmd.Parameters.Add("nombre", OdbcType.VarChar, 50).Value = nombre;
                cmd.Parameters.Add("descripcion", OdbcType.VarChar, 50).Value = descripcion;
                cmd.Parameters.Add("estado", OdbcType.Bit).Value = estado == 1; // true si 1, false si 0
                cmd.Parameters.Add("id", OdbcType.Int).Value = id;

                return cmd.ExecuteNonQuery();
            }
        }

        public bool ModuloEnUso(int idModulo)
        {
            string sql = @"SELECT COUNT(*) FROM Tbl_Asignacion_Modulo_Aplicacion 
                   WHERE Fk_Id_Modulo = ?";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {
                cmd.Parameters.Add("id", OdbcType.Int).Value = idModulo;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // true si el módulo está en uso
            }
        }
    }
}
