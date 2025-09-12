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

        // aqui se insertarán las instrucciones SQL genericas
        public string Insertar(string[] alias)
        {
            string tabla = alias[0]; //posicion tabla
            string[] campos = alias.Skip(2).ToArray(); // ignora tabla y pk
            string columnas = string.Join(",", campos);
            string parametros = string.Join(",", campos.Select(c => "?"));

            return $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})";
        }

        // aqui se consultarán los registros con select segun la tabla que le enviemos
        public string Consultar(string[] alias)
        {
            string tabla = alias[0];
            return $"SELECT * FROM {tabla}";
        }
        
        //seccion de actualizar datos 
        public string Actualizar(string[] alias)
        {
            string tabla = alias[0];
            string pkCampo = alias[1];  // posición pk (llave primaria)
            string[] campos = alias.Skip(2).ToArray(); //los atributos y campos a actualizar

            string set = string.Join(",", campos.Select(c => $"{c}=?")); // genera el set para el update

            return $"UPDATE {tabla} SET {set} WHERE {pkCampo}=?"; // retorna la sentencia sql de update
        }

        // aqui se elimina el registro usando la pk para localizar el dato
        public string Eliminar(string[] alias)
        {
            string tabla = alias[0];
            string pkCampo = alias[1];

            return $"DELETE FROM {tabla} WHERE {pkCampo}=?"; // retorna la sentencia sql de delete
        }

    }
}
