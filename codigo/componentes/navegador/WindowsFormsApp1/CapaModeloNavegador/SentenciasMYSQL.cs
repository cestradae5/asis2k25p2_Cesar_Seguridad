using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Navegador
{
    public class Cls_SentenciasMYSQL
    {
        // llenado de tabla Hecho por Fernando Jose Cahuex Gonzalez 0901-22-14979
        Cls_ConexionMYSQL con = new Cls_ConexionMYSQL();
        public DataTable LlenarTabla(string tabla, string[] campos)
        {
            DataTable dt = new DataTable();
            try
            {
                string columnas = string.Join(",", campos); // para poder usar todos los campos de la tabla sin necesidad de escribirlos uno por uno y guarrdarlos en el array campos xd
                string sql = $"SELECT {columnas} FROM {tabla};"; // consulta SQL para seleccionar todos los registros de la tabla especificada

                OdbcConnection conn = con.conexion();
                OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                da.Fill(dt);
                con.desconexion(conn);
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        //kenph luna
        // aqui se insertarán las instrucciones SQL genericas
        public string Insertar(string[] SAlias)
        {
            // por compatibilidad PK es autoinc
            return Insertar(SAlias, true); // llama a la nueva sobrecarga con pkAutoIncrement true
        }

        // nueva sobrecarga de Insertar que recibe si la pk es autoincrement o no
        public string Insertar(string[] SAlias, bool pkAutoIncrement)
        {
            string tabla = SAlias[0];
            string[] campos = pkAutoIncrement ? SAlias.Skip(2).ToArray() : SAlias.Skip(1).ToArray(); // si es autoinc ignora pk, si no, la incluye
            string columnas = string.Join(",", campos); 
            string parametros = string.Join(",", campos.Select(c => "?")); 

            return $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})"; // sentencia sql de insertar
        }

        // aqui se consultarán los registros con select segun la tabla que le enviemos
        public string Consultar(string[] SAlias)
        {
            string tabla = SAlias[0];
            return $"SELECT * FROM {tabla}";
        }
        
        //seccion de actualizar datos 
        public string Actualizar(string[] SAlias)
        {
            string tabla = SAlias[0];
            string pkCampo = SAlias[1];  // posición pk (llave primaria)
            string[] campos = SAlias.Skip(2).ToArray(); //los atributos y campos a actualizar

            string set = string.Join(",", campos.Select(c => $"{c}=?")); // genera el set para el update

            return $"UPDATE {tabla} SET {set} WHERE {pkCampo}=?"; // retorna la sentencia sql de update
        }

        // aqui se elimina el registro usando la pk para localizar el dato
        public string Eliminar(string[] SAlias)
        {
            string tabla = SAlias[0];
            string pkCampo = SAlias[1];

            return $"DELETE FROM {tabla} WHERE {pkCampo}=?"; // retorna la sentencia sql de delete
        }

        public bool EsPKAutoInc(string tabla, string pkCampo)
        {
            // devuelve true si la columna pkCampo en tabla tiene auto_increment
            using (OdbcConnection conn = con.conexion())
            {
                conn.Open();

                // consulta para verificar si la columna es auto_increment
                string sql = @"
                SELECT EXTRA FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_SCHEMA = DATABASE()
                AND TABLE_NAME = ?
                AND COLUMN_NAME = ?; "; 

                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.Add("?", OdbcType.VarChar).Value = tabla;
                    cmd.Parameters.Add("?", OdbcType.VarChar).Value = pkCampo; 

                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return false;

                    string extra = result.ToString().ToLowerInvariant(); 
                    return extra.Contains("auto_increment"); // verifica si contiene auto_increment
                }
            }
        }


        // Obtencion de valores Hecho por Fernando Jose Cahuex GOnzalez 0901-22-14979
        public List<string> ObtenerValoresColumna(string tabla, string columna)
        {
            List<string> valores = new List<string>();
            try
            {
                using (OdbcConnection conn = con.conexion())
                {
                    conn.Open();
                    string sql = $"SELECT DISTINCT {columna} FROM {tabla}";
                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            valores.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (OdbcException)
            {
                Console.WriteLine("Error al obtener valores de columna");
            }
            return valores;
        }

    }
}
