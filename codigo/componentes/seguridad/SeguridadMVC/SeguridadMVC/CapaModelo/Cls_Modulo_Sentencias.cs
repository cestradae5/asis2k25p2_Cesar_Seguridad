using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
// Nombre: Danilo Mazariegos Codigo:0901-19-25059
namespace Capa_Modelo_Seguridad
{
    // Clase que contiene las sentencias SQL y la interacción directa con la base de datos
    public class Cls_Modulo_Sentencias
    {
        // Instancia de la clase de conexión a la base de datos
        Cls_Conexion conexion = new Cls_Conexion();

        // Método que obtiene los módulos en un formato "Id - Nombre"
        // Para llenar combos o listas en la interfaz
        public string[] fun_LlenarComboModulos()
        {
            List<string> lista = new List<string>();
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Combina el Id y el Nombre del módulo
                        lista.Add(reader.GetValue(0).ToString() + " - " + reader.GetValue(1).ToString());
                    }
                }
                conexion.desconexion(conn);
            }
            return lista.ToArray();
        }

        // Método que obtiene todos los módulos 
        public DataTable Fun_ObtenerModulos()
        {
            string sql = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";

            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.desconexion(conn);
                return dt;
            }
        }

        // Método que busca un módulo por su Id
        // Retorna el primer DataRow encontrado o null si no existe
        public DataRow BuscarModuloPorId(int iPk_Id_Modulo)
        {
            string sql = @"SELECT * FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = iPk_Id_Modulo;
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.desconexion(conn);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        // Método para insertar un nuevo módulo
        // Retorna la cantidad de filas afectadas
        public int InsertarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            string sql = @"INSERT INTO Tbl_Modulo 
                           (Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo) 
                           VALUES (?, ?, ?, ?)";
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = iPk_Id_Modulo;
                cmd.Parameters.Add("Cmp_Nombre_Modulo", OdbcType.VarChar, 50).Value = sCmp_Nombre_Modulo;
                cmd.Parameters.Add("Cmp_Descripcion_Modulo", OdbcType.VarChar, 255).Value = sCmp_Descripcion_Modulo;
                cmd.Parameters.Add("Cmp_Estado_Modulo", OdbcType.Bit).Value = (btCmp_Estado_Modulo == 1);

                int result = cmd.ExecuteNonQuery();
                conexion.desconexion(conn);
                return result;
            }
        }

        // Método para eliminar un módulo por su Id
        // Retorna la cantidad de filas afectadas
        public int EliminarModulo(int iPk_Id_Modulo)
        {
            string sql = @"DELETE FROM Tbl_Modulo WHERE Pk_Id_Modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = iPk_Id_Modulo;
                int result = cmd.ExecuteNonQuery();
                conexion.desconexion(conn);
                return result;
            }
        }

        // Método para modificar un módulo existente
        // Retorna la cantidad de filas afectadas
        public int ModificarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            string sql = @"UPDATE Tbl_Modulo 
                           SET Cmp_Nombre_Modulo=?, Cmp_Descripcion_Modulo=?, Cmp_Estado_Modulo=? 
                           WHERE Pk_Id_Modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add("Cmp_Nombre_Modulo", OdbcType.VarChar, 50).Value = sCmp_Nombre_Modulo;
                cmd.Parameters.Add("Cmp_Descripcion_Modulo", OdbcType.VarChar, 255).Value = sCmp_Descripcion_Modulo;
                cmd.Parameters.Add("Cmp_Estado_Modulo", OdbcType.Bit).Value = (btCmp_Estado_Modulo == 1);
                cmd.Parameters.Add("Pk_Id_Modulo", OdbcType.Int).Value = iPk_Id_Modulo;

                int result = cmd.ExecuteNonQuery();
                conexion.desconexion(conn);
                return result;
            }
        }

        // Método que verifica si un módulo está en uso en asignaciones
        // Retorna true si se encuentra al menos una asignación
        public bool ModuloEnUso(int iFk_Id_Modulo)
        {
            string sql = @"SELECT COUNT(*) FROM Tbl_Asignacion_Modulo_Aplicacion 
                           WHERE Fk_Id_Modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add("Fk_Id_Modulo", OdbcType.Int).Value = iFk_Id_Modulo;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.desconexion(conn);
                return count > 0;
            }
        }
    }
}
