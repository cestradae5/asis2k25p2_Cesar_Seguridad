using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// trabajado por Kenph Luna 9959-22-6326

namespace CapaModeloNavegador
{
    public class DAOGenerico
    {
        // guarda el resultado en un para no consultar INFORMATION_SCHEMA cada vez y mejorar rendimiento solo para traer si es auto_increment o no
        private Dictionary<string, bool> pkAutoCache = new Dictionary<string, bool>(); 

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

        // insertar datos
        public void InsertarDatos(string[] alias, object[] valores)
        {
            string tabla = alias[0]; // nombre de la tabla
            string pkCampo = alias[1]; // posicion primary key

            // consulta si la pk es autoincrementable o no
            string cacheKey = tabla + "." + pkCampo;
            bool pkAuto;
            if (!pkAutoCache.TryGetValue(cacheKey, out pkAuto))
            {
                pkAuto = sentencias.EsPKAutoInc(tabla, pkCampo);
                pkAutoCache[cacheKey] = pkAuto;
            }

            // define los campos a insertar (si PK es autoincrementable)
            string[] campos = pkAuto ? alias.Skip(2).ToArray() : alias.Skip(1).ToArray();

            // filtrar los valores según la PK, si es autoincrementable se ignora el primer valor
            object[] valoresFiltrados = pkAuto ? valores.Skip(1).ToArray() : valores;

            // valida que coincidan los valores enviados
            if (valoresFiltrados == null || valoresFiltrados.Length != campos.Length)
                throw new Exception(
                    $"InsertarDatos: el arreglo 'valores' debe tener {campos.Length} elementos (tiene {(valoresFiltrados == null ? 0 : valoresFiltrados.Length)}). " +
                    $"Si PK '{pkCampo}' no es autoincrement, se debe incluir su valor en 'valores'.");

            string sql = sentencias.Insertar(alias, pkAuto);

            using (OdbcConnection conn = con.conexion())
            {
                conn.Open();

                // inicio de transaccion
                // using (OdbcTransaction trans = conn.BeginTransaction())
                // {
                try
                {
                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        // se liga la transacción al comando
                        // cmd.Transaction = trans;

                        for (int i = 0; i < campos.Length; i++)
                        {
                            cmd.Parameters.Add("?", MapeadoTipoDatos(valoresFiltrados[i]))
                                          .Value = valoresFiltrados[i] ?? DBNull.Value; // asigna tipo de dato
                        }
                        cmd.ExecuteNonQuery(); // ejecuta el insert
                    }

                    // Bitacora.InsertarBitacora(conn, trans, idUsuario, aplicacion, "INS"); // inserta datos en bitacora

                    // trans.Commit(); // realiza commit si sale bien
                }
                catch
                {

                    // trans.Rollback(); // revertir en caso que haya error
                    throw; // lanza la excepción 
                }
                // }
            } //la conexión se cierra automáticamente
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
