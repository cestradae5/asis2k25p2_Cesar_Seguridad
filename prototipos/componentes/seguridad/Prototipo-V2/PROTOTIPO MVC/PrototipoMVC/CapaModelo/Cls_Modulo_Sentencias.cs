using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    // Clase que contiene las sentencias SQL y la interacción directa con la base de datos
    public class Cls_Modulo_Sentencias
    {
        // Instancia de la clase de conexión a la base de datos
        Cls_Conexion conexion = new Cls_Conexion();

        // Método que obtiene los módulos en un formato "Id - Nombre"
        // Para llenar combos o listas en la interfaz
        public string[] LlenarComboModulos()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Combina el Id y el Nombre del módulo
                lista.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString());
            }
            return lista.ToArray();
        }

        // Método que obtiene todos los módulos 
        public DataTable ObtenerModulos()
        {
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Método que busca un módulo por su Id
        // Retorna el primer DataRow encontrado o null si no existe
        public DataRow BuscarModuloPorId(int Pk_Id_Modulo)
        {
            string sql = @"SELECT * FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@Pk_Id_Modulo", Pk_Id_Modulo);
            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null; // Retorna el primer registro o null
        }

        // Método para insertar un nuevo módulo
        // Retorna la cantidad de filas afectadas
        public int InsertarModulo(int Pk_Id_Modulo, string Cmp_Nombre_Modulo, string Cmp_Descripcion_Modulo, byte Cmp_Estado_Modulo)
        {
            string sql = @"INSERT INTO Tbl_Modulo 
                   (Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo) 
                   VALUES (?, ?, ?, ?)";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {
                // Agrega los parámetros y sus valores
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = Pk_Id_Modulo;
                cmd.Parameters.Add("Cmp_Nombre_Modulo", OdbcType.VarChar, 50).Value = Cmp_Nombre_Modulo;
                cmd.Parameters.Add("Cmp_Descripcion_Modulo", OdbcType.VarChar, 50).Value = Cmp_Descripcion_Modulo;
                cmd.Parameters.Add("Cmp_Estado_Modulo", OdbcType.Bit).Value = Cmp_Estado_Modulo == 1; // true si 1, false si 0

                return cmd.ExecuteNonQuery(); // Ejecuta la inserción
            }
        }

        // Método para eliminar un módulo por su Id
        // Retorna la cantidad de filas afectadas
        public int EliminarModulo(int Pk_Id_Modulo)
        {
            string sql = @"DELETE FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@Pk_Id_Modulo", Pk_Id_Modulo);
            return cmd.ExecuteNonQuery();
        }

        // Método para modificar un módulo existente
        // Retorna la cantidad de filas afectadas
        public int ModificarModulo(int Pk_Id_Modulo, string Cmp_Nombre_Modulo, string Cmp_Descripcion_Modulo, byte Cmp_Estado_Modulo)
        {
            string sql = @"UPDATE Tbl_Modulo 
                   SET Cmp_Nombre_Modulo=?, Cmp_Descripcion_Modulo=?, Cmp_Estado_Modulo=? 
                   WHERE Pk_Id_Modulo = ?";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {

                cmd.Parameters.Add("Cmp_Nombre_Modulo", OdbcType.VarChar, 50).Value = Cmp_Nombre_Modulo;
                cmd.Parameters.Add("Cmp_Descripcion_Modulo", OdbcType.VarChar, 50).Value = Cmp_Descripcion_Modulo;
                cmd.Parameters.Add("Cmp_Estado_Modulo", OdbcType.Bit).Value = Cmp_Estado_Modulo == 1; // true si 1, false si 0
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = Pk_Id_Modulo;

                return cmd.ExecuteNonQuery(); // Ejecuta la actualización
            }
        }

        // Método que verifica si un módulo está en uso en asignaciones
        // Retorna true si se encuentra al menos una asignación
        public bool ModuloEnUso(int Fk_Id_Modulo)
        {
            string sql = @"SELECT COUNT(*) FROM Tbl_Asignacion_Modulo_Aplicacion 
                   WHERE Fk_Id_Modulo = ?";
            using (OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion()))
            {
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = Fk_Id_Modulo;
                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Obtiene el conteo
                return count > 0; // true si el módulo está en uso
            }
        }
    }
}