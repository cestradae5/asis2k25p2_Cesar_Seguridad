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
                string sql = sentencias.Insertar(alias); // genera INSERT
                string[] campos = alias.Skip(2).ToArray(); // ignora tabla y pk

                using (OdbcConnection conn = con.conexion())
                {
                    conn.Open(); // se abre conexion

                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        for (int i = 0; i < campos.Length; i++)
                        {
                            cmd.Parameters.Add("?", MapeadoTipoDatos(valores[i])).Value = valores[i] ?? DBNull.Value; // asigna valores
                        }

                        cmd.ExecuteNonQuery();
                    }
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
                {
                    conn.Open(); // se abre conexion

                    using (OdbcDataAdapter da = new OdbcDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);  // llena el datatable con los registros obtenidos
                        return dt;
                    }
                } // conn se cierra automáticamente
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al consultar datos de " + alias[0] + ": " + ex.Message, ex);
            }
        }

        // seccion de actualizar datos (update)
        public void ActualizarDatos(string[] alias, object[] valores, object pkValor)
        {
            try
            {
                string sql = sentencias.Actualizar(alias); // obtiene la sentencia sql de update
                string[] campos = alias.Skip(2).ToArray(); // ignora tabla y pk

                using (OdbcConnection conn = con.conexion())
                {
                    conn.Open();

                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        // valores para SET
                        for (int i = 0; i < campos.Length; i++)
                        {
                            cmd.Parameters.Add("?", MapeadoTipoDatos(valores[i])).Value = valores[i] ?? DBNull.Value; // asigna valores
                        }

                        // valor de la PK para el WHERE
                        cmd.Parameters.Add("?", MapeadoTipoDatos(pkValor)).Value = pkValor ?? DBNull.Value;

                        cmd.ExecuteNonQuery();
                    }
                } // la conexion se cierra automáticamente
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
                string sql = sentencias.Eliminar(alias); // obtiene la sentencia sql de delete

                using (OdbcConnection conn = con.conexion()) 
                {
                    conn.Open(); // se abre conexion

                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        cmd.Parameters.Add("?", MapeadoTipoDatos(pkValor)).Value = pkValor ?? DBNull.Value; // asigna valor de la pk

                        cmd.ExecuteNonQuery();
                    }
                } // la conexion se cierra automáticamente
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al eliminar datos de " + alias[0] + ": " + ex.Message, ex);
            }
        }
    }
}
