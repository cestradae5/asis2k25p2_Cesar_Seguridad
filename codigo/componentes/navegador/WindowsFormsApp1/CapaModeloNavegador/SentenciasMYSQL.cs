using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloNavegador
{
    public class SentenciasMYSQL
    {
        ConexionMYSQL con = new ConexionMYSQL();

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
    }
}
