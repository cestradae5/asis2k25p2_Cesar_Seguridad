using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModeloNavegador
{
    public class DAOGenerico
    {
        SentenciasMYSQL sentencias = new SentenciasMYSQL();
        ConexionMYSQL con = new ConexionMYSQL();

        //Conexion  de la base de datos aqui
        //Mapeado de base de datos, para conocer que tipo de dato es según el atributo (int, string, bool, datetime, decimal)
        private OdbcType MapeadoTipoDatos(object valor)
        {
            if (valor is int || valor is short || valor is long) return OdbcType.Int;
            if (valor is DateTime) return OdbcType.DateTime;
            if (valor is bool) return OdbcType.Bit;
            if (valor is decimal || valor is double || valor is float) return OdbcType.Decimal;
            return OdbcType.VarChar; // por defecto retorna varchar
        }

        // seccion para insertar
        public void InsertarDatos(string[] alias, object[] valores)
        {
            try
            {
                string sql = sentencias.Insertar(alias); // obtiene la sentencia sql de insert
                string[] campos = alias.Skip(2).ToArray(); // posicion de los demas campos

                using (OdbcConnection conn = con.conexion())
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    for (int i = 0; i < campos.Length; i++)
                    {
                        var p = cmd.Parameters.Add("p" + i, MapeadoTipoDatos(valores[i])); // proporciona los valores de los campos en el mismo orden que los "?" del value
                        p.Value = valores[i] ?? DBNull.Value;
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al insertar datos en " + alias[0] + ": " + ex.Message, ex);
            }
        }

        // seccion para consultar registros
        public DataTable ConsultarDatos(string[] alias)
        {
            try
            {
                string sql = sentencias.Consultar(alias);

                using (OdbcConnection conn = con.conexion())
                using (OdbcDataAdapter da = new OdbcDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);  // llena el datatable con los registros obtenidos
                    return dt;
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al consultar datos de " + alias[0] + ": " + ex.Message, ex);
            }
        }

        // secion de actualizar datos (update)
        public void ActualizarDatos(string[] alias, object[] valores, object pkValor)
        {
            try
            {
                string sql = sentencias.Actualizar(alias); //obtiene la sentencia sql de update
                string[] campos = alias.Skip(2).ToArray(); //posicion de los demas campos

                using (OdbcConnection conn = con.conexion())
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    // proporciona los valores de los campos en el mismo orden que los "?" del SET
                    for (int i = 0; i < campos.Length; i++)
                    {
                        var p = cmd.Parameters.Add("p" + i, MapeadoTipoDatos(valores[i]));
                        p.Value = valores[i] ?? DBNull.Value;
                    }

                    // proprociona el el valor de la PK para el WHERE = "?"
                    var pkParam = cmd.Parameters.Add("pk", MapeadoTipoDatos(pkValor));
                    pkParam.Value = pkValor ?? DBNull.Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al actualizar datos en " + alias[0] + ": " + ex.Message, ex);
            }
        }

        // seccion para eliminar registros
        public void EliminarDatos(string[] alias, object pkValor)
        {
            try
            {
                string sql = sentencias.Eliminar(alias);  // sentencia de sql para eliminar

                using (OdbcConnection conn = con.conexion())
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    var pkParam = cmd.Parameters.Add("pk", MapeadoTipoDatos(pkValor));  //obtiene pk para buscar registro y elimnarlo
                    pkParam.Value = pkValor ?? DBNull.Value;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al eliminar datos de " + alias[0] + ": " + ex.Message, ex);
            }
        }
    }
}
