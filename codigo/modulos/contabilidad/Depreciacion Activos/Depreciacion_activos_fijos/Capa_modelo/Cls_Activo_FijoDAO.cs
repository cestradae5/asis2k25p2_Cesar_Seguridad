using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;

namespace Capa_modelo
{
    public class Cls_Activo_FijoDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string sSQL_SELECT_ACTIVOS = @"
            SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Grupo_Activo,
                   Cmp_Costo_Adquisicion, Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado
            FROM Tbl_ActivosFijos
            WHERE Cmp_Estado = 1";

        private static readonly string sSQL_SELECT_ACTIVO_COMPLETO = @"
            SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Grupo_Activo,
                   Cmp_Fecha_Adquisicion, Cmp_Costo_Adquisicion, 
                   Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado,
                   Cmp_CtaActivo, Cmp_CtaDepreciacion, Cmp_CtaGastoDepreciacion
            FROM Tbl_ActivosFijos 
            WHERE Pk_Activo_ID = ? AND Cmp_Estado = 1";

        private static readonly string sSQL_INSERT_ACTIVO = @"
    INSERT INTO Tbl_ActivosFijos 
    (Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Grupo_Activo, Cmp_Fecha_Adquisicion,
     Cmp_Costo_Adquisicion, Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado,
     Cmp_CtaActivo, Cmp_CtaDepreciacion, Cmp_CtaGastoDepreciacion)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        private static readonly string sSQL_INSERT_DEP = @"
            INSERT INTO Tbl_DepreciacionActivos
            (Fk_Activo_ID, Cmp_Anio, Cmp_Valor_En_Libros, 
             Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada)
            VALUES (?, ?, ?, ?, ?)";


        public DataTable fun_ObtenerActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(sSQL_SELECT_ACTIVOS, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener activos: {ex.Message}");
            }
            return dt;
        }


        public Cls_Activo_Fijo fun_ObtenerDatosActivo(int iIdActivo)
        {
            Cls_Activo_Fijo activo = null;

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcCommand cmd = new OdbcCommand(sSQL_SELECT_ACTIVO_COMPLETO, conn);
                    cmd.Parameters.AddWithValue("@Pk_Activo_ID", iIdActivo);
                    OdbcDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        activo = new Cls_Activo_Fijo
                        {
                            iPkActivoId = reader.GetInt32(0),
                            sNombreActivo = reader.GetString(1),
                            sDescripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            sGrupoActivo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            dFechaAdquisicion = reader.GetDateTime(4),
                            dCostoAdquisicion = reader.GetDecimal(5),
                            dValorResidual = reader.GetDecimal(6),
                            iVidaUtil = reader.GetInt32(7),
                            bEstadoActivo = reader.GetInt32(8) == 1,
                            sCuentaActivo = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            sCuentaDepreciacionAcumulada = reader.IsDBNull(10) ? "" : reader.GetString(10),
                            sCuentaGastoDepreciacion = reader.IsDBNull(11) ? "" : reader.GetString(11)
                        };
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos del activo: {ex.Message}");
            }
            return activo;
        }
        private bool ValidarCuentaExistente(OdbcConnection conn, string codigoCuenta)
        {
            try
            {
                // QUITAR Cmp_Estado = 1 porque no existe
                string sql = "SELECT COUNT(*) FROM Tbl_Catalogo_Cuentas WHERE Pk_Codigo_Cuenta = ?";
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", codigoCuenta);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"Cuenta {codigoCuenta} existe: {count > 0}");
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validando cuenta {codigoCuenta}: {ex.Message}");
                return false;
            }
        }

        public bool pro_GuardarNuevoActivo(string sNombre, string sDescripcion, string sGrupo,
     DateTime dFechaAdquisicion, decimal deCosto, decimal deValorResidual,
     int iVidaUtil, string sCuentaActivo, string sCuentaDepreciacion, string sCuentaGasto, bool estadoActivo)
        {
            OdbcConnection conn = null;
            try
            {
                Console.WriteLine("=== INICIANDO INSERT DIRECTO SQL ===");

                conn = conexion.conexion();
                Console.WriteLine($"✅ Conexión abierta: {conn.State}");

                // CONSTRUIR SQL CON VALORES LITERALES (para diagnóstico)
                string sqlDirecto = $@"
            INSERT INTO Tbl_ActivosFijos 
            (Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Grupo_Activo, Cmp_Fecha_Adquisicion,
             Cmp_Costo_Adquisicion, Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado,
             Cmp_CtaActivo, Cmp_CtaDepreciacion, Cmp_CtaGastoDepreciacion)
            VALUES (
                '{sNombre?.Replace("'", "''")}',
                '{sDescripcion?.Replace("'", "''")}',
                '{sGrupo?.Replace("'", "''")}',
                '{dFechaAdquisicion:yyyy-MM-dd}',
                {deCosto},
                {deValorResidual},
                {iVidaUtil},
                {(estadoActivo ? 1 : 0)},
                '{sCuentaActivo?.Replace("'", "''")}',
                '{sCuentaDepreciacion?.Replace("'", "''")}',
                '{sCuentaGasto?.Replace("'", "''")}'
            )";

                Console.WriteLine("SQL generado:");
                Console.WriteLine(sqlDirecto);

                OdbcCommand cmd = new OdbcCommand(sqlDirecto, conn);

                Console.WriteLine("Ejecutando INSERT directo...");
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine($"✅ INSERT directo exitoso. Filas afectadas: {result}");

                return result > 0;
            }
            catch (OdbcException odbcEx)
            {
                Console.WriteLine($"🔴 ERROR ODBC DIRECTO: {odbcEx.Message}");
                if (odbcEx.Errors != null && odbcEx.Errors.Count > 0)
                {
                    foreach (OdbcError error in odbcEx.Errors)
                    {
                        Console.WriteLine($"   🔴 Native: {error.NativeError}, State: {error.SQLState}");
                    }
                }
                throw new Exception($"Error ODBC: {odbcEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
                throw;
            }
            finally
            {
                conexion.desconexion(conn);
            }
        }

        // Método auxiliar para validar cuentas
        private bool ValidarCuentaConConsulta(OdbcConnection conn, string codigoCuenta)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Tbl_Catalogo_Cuentas WHERE Pk_Codigo_Cuenta = ?";
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", codigoCuenta);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"   Cuenta {codigoCuenta}: {(count > 0 ? "EXISTE" : "NO EXISTE")}");
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ❌ Error validando cuenta {codigoCuenta}: {ex.Message}");
                return false;
            }
        }


        public string ProbarConexionYTablas()
        {
            OdbcConnection conn = null;
            try
            {
                conn = conexion.conexion();
                string resultado = $"Conexión: {conn.State}\n";

                // Verificar si la tabla existe
                string checkTableSQL = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'bd_pruebaContabilidad' AND table_name = 'Tbl_ActivosFijos'";
                OdbcCommand cmdTable = new OdbcCommand(checkTableSQL, conn);
                object tableCount = cmdTable.ExecuteScalar();
                resultado += $"Tabla Tbl_ActivosFijos existe: {Convert.ToInt32(tableCount) > 0}\n";

                // Verificar si hay cuentas contables
                string checkCuentasSQL = "SELECT COUNT(*) FROM Tbl_Catalogo_Cuentas";
                OdbcCommand cmdCuentas = new OdbcCommand(checkCuentasSQL, conn);
                object cuentasCount = cmdCuentas.ExecuteScalar();
                resultado += $"Cuentas contables: {cuentasCount}\n";

                return resultado;
            }
            catch (Exception ex)
            {
                return $"Error en prueba: {ex.Message}";
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public int pro_GuardarDepreciacion(int iIdActivo, int iAnio, decimal deValorLibros,
                                         decimal depAnual, decimal depAcumulada)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcCommand cmd = new OdbcCommand(sSQL_INSERT_DEP, conn);
                    cmd.Parameters.AddWithValue("@Fk_Activo_ID", iIdActivo);
                    cmd.Parameters.AddWithValue("@Cmp_Anio", iAnio);
                    cmd.Parameters.AddWithValue("@Cmp_Valor_En_Libros", deValorLibros);
                    cmd.Parameters.AddWithValue("@Cmp_Depreciacion_Anual", depAnual);
                    cmd.Parameters.AddWithValue("@Cmp_Depreciacion_Acumulada", depAcumulada);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar depreciación: {ex.Message}");
            }
        }

        public int EliminarDepreciacionesPrevias(int iIdActivo)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sqlDelete = "DELETE FROM Tbl_DepreciacionActivos WHERE Fk_Activo_ID = ?";
                    OdbcCommand cmd = new OdbcCommand(sqlDelete, conn);
                    cmd.Parameters.AddWithValue("@Fk_Activo_ID", iIdActivo);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar depreciaciones previas: {ex.Message}");
            }
        }
        public string ProbarDSNCompleto()
        {
            StringBuilder resultado = new StringBuilder();
            OdbcConnection conn = null;

            try
            {
                resultado.AppendLine("=== DIAGNÓSTICO COMPLETO DSN ===");

                // 1. Probar conexión básica
                conn = conexion.conexion();
                resultado.AppendLine($"✅ Conexión ODBC: {conn.State}");
                resultado.AppendLine($"🔗 Cadena conexión: {conn.ConnectionString}");
                resultado.AppendLine($"⏱️  Timeout: {conn.ConnectionTimeout}");

                // 2. Probar consulta simple
                OdbcCommand cmdTest = new OdbcCommand("SELECT 1 as Test", conn);
                object testResult = cmdTest.ExecuteScalar();
                resultado.AppendLine($"✅ Consulta básica: {testResult}");

                // 3. Verificar tablas específicas
                string[] tablas = { "Tbl_ActivosFijos", "Tbl_Catalogo_Cuentas", "Tbl_DepreciacionActivos" };

                foreach (string tabla in tablas)
                {
                    try
                    {
                        OdbcCommand cmd = new OdbcCommand($"SELECT COUNT(*) FROM {tabla}", conn);
                        object count = cmd.ExecuteScalar();
                        resultado.AppendLine($"✅ Tabla {tabla}: {count} registros");
                    }
                    catch (Exception ex)
                    {
                        resultado.AppendLine($"❌ Tabla {tabla}: ERROR - {ex.Message}");
                    }
                }

                // 4. Verificar claves foráneas específicas
                resultado.AppendLine("\n🔍 VERIFICANDO CLAVES FORÁNEAS:");
                string[] cuentas = { "1.5.1", "1.6.1", "6.1.5" };

                foreach (string cuenta in cuentas)
                {
                    try
                    {
                        OdbcCommand cmd = new OdbcCommand(
                            "SELECT Cmp_CtaNombre FROM Tbl_Catalogo_Cuentas WHERE Pk_Codigo_Cuenta = ?",
                            conn);
                        cmd.Parameters.AddWithValue("?", cuenta);
                        object nombre = cmd.ExecuteScalar();
                        resultado.AppendLine($"✅ Cuenta {cuenta}: {(nombre ?? "NO ENCONTRADA")}");
                    }
                    catch (Exception ex)
                    {
                        resultado.AppendLine($"❌ Cuenta {cuenta}: ERROR - {ex.Message}");
                    }
                }

                return resultado.ToString();
            }
            catch (Exception ex)
            {
                resultado.AppendLine($"❌ ERROR GENERAL: {ex.Message}");
                resultado.AppendLine($"📋 Tipo: {ex.GetType().FullName}");
                if (ex.InnerException != null)
                {
                    resultado.AppendLine($"🔍 Inner: {ex.InnerException.Message}");
                }
                return resultado.ToString();
            }
            finally
            {
                conexion.desconexion(conn);
            }
        }
        public List<Cls_Activo_Fijo> ObtenerTodosLosActivos()
        {
            List<Cls_Activo_Fijo> listaActivos = new List<Cls_Activo_Fijo>();

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Grupo_Activo,
                          Cmp_Fecha_Adquisicion, Cmp_Costo_Adquisicion, Cmp_Valor_Residual, 
                          Cmp_Vida_Util, Cmp_Estado, Cmp_CtaActivo, Cmp_CtaDepreciacion, Cmp_CtaGastoDepreciacion
                          FROM Tbl_ActivosFijos WHERE Cmp_Estado = 1";

                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    OdbcDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cls_Activo_Fijo activo = new Cls_Activo_Fijo
                        {
                            iPkActivoId = reader.GetInt32(0),
                            sNombreActivo = reader.GetString(1),
                            sDescripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            sGrupoActivo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            dFechaAdquisicion = reader.GetDateTime(4),
                            dCostoAdquisicion = reader.GetDecimal(5),
                            dValorResidual = reader.GetDecimal(6),
                            iVidaUtil = reader.GetInt32(7),
                            bEstadoActivo = reader.GetInt32(8) == 1,
                            sCuentaActivo = reader.IsDBNull(9) ? "" : reader.GetString(9),
                            sCuentaDepreciacionAcumulada = reader.IsDBNull(10) ? "" : reader.GetString(10),
                            sCuentaGastoDepreciacion = reader.IsDBNull(11) ? "" : reader.GetString(11)
                        };
                        listaActivos.Add(activo);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener lista de activos: {ex.Message}");
            }

            return listaActivos;
        }

        public bool GuardarCalculoDepreciacion(List<Cls_Depreciacion_Activo> depreciaciones, int idActivo)
        {
            OdbcConnection conn = null;
            OdbcTransaction transaction = null;

            try
            {
                conn = conexion.conexion();
                transaction = conn.BeginTransaction();

                // Primero eliminar cálculos previos para este activo
                string sqlDelete = "DELETE FROM Tbl_DepreciacionActivos WHERE Fk_Activo_ID = ?";
                OdbcCommand cmdDelete = new OdbcCommand(sqlDelete, conn, transaction);
                cmdDelete.Parameters.AddWithValue("@Fk_Activo_ID", idActivo);
                cmdDelete.ExecuteNonQuery();

                // Insertar nuevos cálculos
                string sqlInsert = @"INSERT INTO Tbl_DepreciacionActivos 
                           (Fk_Activo_ID, Cmp_Anio, Cmp_Valor_En_Libros, 
                            Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada)
                           VALUES (?, ?, ?, ?, ?)";

                foreach (var dep in depreciaciones)
                {
                    OdbcCommand cmdInsert = new OdbcCommand(sqlInsert, conn, transaction);
                    cmdInsert.Parameters.AddWithValue("@Fk_Activo_ID", idActivo);
                    cmdInsert.Parameters.AddWithValue("@Cmp_Anio", dep.iAnio);
                    cmdInsert.Parameters.AddWithValue("@Cmp_Valor_En_Libros", dep.dValorEnLibros);
                    cmdInsert.Parameters.AddWithValue("@Cmp_Depreciacion_Anual", dep.dDepreciacionAnual);
                    cmdInsert.Parameters.AddWithValue("@Cmp_Depreciacion_Acumulada", dep.dDepreciacionAcumulada);

                    cmdInsert.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Error al guardar cálculo de depreciación: {ex.Message}");
            }
            finally
            {
                conexion.desconexion(conn);
            }
        }

        public List<Cls_Depreciacion_Activo> ObtenerDepreciacionesActivo(int idActivo)
        {
            List<Cls_Depreciacion_Activo> depreciaciones = new List<Cls_Depreciacion_Activo>();

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Cmp_Anio, Cmp_Valor_En_Libros, Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada
                          FROM Tbl_DepreciacionActivos 
                          WHERE Fk_Activo_ID = ? 
                          ORDER BY Cmp_Anio";

                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Fk_Activo_ID", idActivo);
                    OdbcDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cls_Depreciacion_Activo dep = new Cls_Depreciacion_Activo
                        {
                            iAnio = reader.GetInt32(0),
                            dValorEnLibros = reader.GetDecimal(1),
                            dDepreciacionAnual = reader.GetDecimal(2),
                            dDepreciacionAcumulada = reader.GetDecimal(3)
                        };
                        depreciaciones.Add(dep);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener depreciaciones del activo: {ex.Message}");
            }

            return depreciaciones;
        }
        public DataTable ObtenerActivosParaCombo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Pk_Activo_ID, Cmp_Nombre_Activo 
                          FROM Tbl_ActivosFijos 
                          WHERE Cmp_Estado = 1 
                          ORDER BY Cmp_Nombre_Activo";

                    OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                    da.Fill(dt);

                    // Agregar una fila vacía al inicio
                    DataRow emptyRow = dt.NewRow();
                    emptyRow["Pk_Activo_ID"] = 0;
                    emptyRow["Cmp_Nombre_Activo"] = "-- Seleccione un activo --";
                    dt.Rows.InsertAt(emptyRow, 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener activos para combo: {ex.Message}");
            }
            return dt;
        }

        public string[] ObtenerDatosActivoParaVista(int idActivo)
        {
            try
            {
                Console.WriteLine($"DAO: Buscando activo ID {idActivo}");

                if (idActivo == 0)
                {
                    Console.WriteLine("DAO: ID activo es 0, retornando valores por defecto");
                    return new string[] { "---", "---", "---", "---", "---" };
                }

                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Cmp_Nombre_Activo, Cmp_Grupo_Activo, Cmp_Costo_Adquisicion,
                  Cmp_Valor_Residual, Cmp_Vida_Util
                  FROM Tbl_ActivosFijos 
                  WHERE Pk_Activo_ID = ? AND Cmp_Estado = 1";

                    Console.WriteLine($"DAO: Ejecutando SQL: {sql}");

                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", idActivo);

                    OdbcDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        string grupo = reader.GetString(1);
                        decimal costo = reader.GetDecimal(2);

                        Console.WriteLine($"DAO: Datos encontrados - Nombre: {nombre}, Grupo: {grupo}, Costo: {costo}");

                        string[] resultado = new string[]
                        {
                    nombre, // Nombre
                    grupo, // Grupo
                    costo.ToString("C2"), // Costo
                    reader.GetDecimal(3).ToString("C2"), // Valor Residual
                    reader.GetInt32(4).ToString() // Vida Útil
                        };

                        reader.Close();
                        return resultado;
                    }
                    else
                    {
                        Console.WriteLine($"DAO: No se encontró el activo ID {idActivo}");
                        reader.Close();
                        return new string[] { "---", "---", "---", "---", "---" };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DAO: Error - {ex.Message}");
                throw new Exception($"Error al obtener datos del activo: {ex.Message}");
            }
        }

        public DataTable CalcularDepreciacionLineal(int idActivo)
        {
            DataTable dt = new DataTable();
            try
            {
                Console.WriteLine($"=== INICIANDO CÁLCULO DE DEPRECIACIÓN PARA ACTIVO {idActivo} ===");

                // Obtener datos del activo
                Cls_Activo_Fijo activo = fun_ObtenerDatosActivo(idActivo);
                if (activo == null)
                    throw new Exception("Activo no encontrado en la base de datos");

                Console.WriteLine($"Datos del activo:");
                Console.WriteLine($"  Costo: {activo.dCostoAdquisicion}");
                Console.WriteLine($"  Valor Residual: {activo.dValorResidual}");
                Console.WriteLine($"  Vida Útil: {activo.iVidaUtil} años");

                // Validaciones
                if (activo.dCostoAdquisicion <= 0)
                    throw new Exception("El costo de adquisición debe ser mayor a cero");

                if (activo.iVidaUtil <= 0)
                    throw new Exception("La vida útil debe ser mayor a cero");

                if (activo.dValorResidual < 0)
                    throw new Exception("El valor residual no puede ser negativo");

                if (activo.dValorResidual >= activo.dCostoAdquisicion)
                    throw new Exception("El valor residual no puede ser mayor o igual al costo de adquisición");

                // Configurar DataTable
                dt.Columns.Add("Año", typeof(int));
                dt.Columns.Add("ValorEnLibros", typeof(string));
                dt.Columns.Add("DepreciacionAnual", typeof(string));
                dt.Columns.Add("DepreciacionAcumulada", typeof(string));

                // Cálculo de depreciación lineal
                decimal costo = activo.dCostoAdquisicion;
                decimal valorResidual = activo.dValorResidual;
                int vidaUtil = activo.iVidaUtil;

                // Fórmula: (Costo - Valor Residual) / Vida Útil
                decimal depreciacionAnual = (costo - valorResidual) / vidaUtil;
                decimal depreciacionAcumulada = 0;
                decimal valorEnLibros = costo;

                Console.WriteLine($"Depreciación anual calculada: {depreciacionAnual:C2}");

                for (int anio = 1; anio <= vidaUtil; anio++)
                {
                    depreciacionAcumulada = depreciacionAnual * anio;
                    valorEnLibros = costo - depreciacionAcumulada;

                    // Ajuste para el último año para evitar errores de redondeo
                    if (anio == vidaUtil)
                    {
                        valorEnLibros = valorResidual;
                        depreciacionAcumulada = costo - valorResidual;
                    }

                    // Asegurarnos de que no haya valores negativos
                    if (valorEnLibros < valorResidual)
                        valorEnLibros = valorResidual;

                    dt.Rows.Add(
                        anio,
                        valorEnLibros.ToString("C2"),
                        depreciacionAnual.ToString("C2"),
                        depreciacionAcumulada.ToString("C2")
                    );

                    Console.WriteLine($"Año {anio}: Valor Libros={valorEnLibros:C2}, Dep.Anual={depreciacionAnual:C2}, Dep.Acumulada={depreciacionAcumulada:C2}");
                }

                Console.WriteLine($"=== CÁLCULO COMPLETADO - {vidaUtil} años calculados ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR en cálculo: {ex.Message}");
                throw new Exception($"Error en cálculo de depreciación: {ex.Message}");
            }
            return dt;
        }

        public bool GuardarCalculoDepreciacion(int idActivo)
        {
            OdbcConnection conn = null;
            OdbcTransaction transaction = null;

            try
            {
                Console.WriteLine($"=== INICIANDO GUARDADO DE DEPRECIACIÓN PARA ACTIVO {idActivo} ===");

                conn = conexion.conexion();
                transaction = conn.BeginTransaction();

                // Primero eliminar cálculos previos
                string sqlDelete = "DELETE FROM Tbl_DepreciacionActivos WHERE Fk_Activo_ID = ?";
                OdbcCommand cmdDelete = new OdbcCommand(sqlDelete, conn, transaction);
                cmdDelete.Parameters.AddWithValue("?", idActivo);
                int filasEliminadas = cmdDelete.ExecuteNonQuery();

                Console.WriteLine($"Registros anteriores eliminados: {filasEliminadas}");

                // Obtener datos del activo y calcular depreciación
                Cls_Activo_Fijo activo = fun_ObtenerDatosActivo(idActivo);
                if (activo == null)
                    throw new Exception("Activo no encontrado");

                decimal costo = activo.dCostoAdquisicion;
                decimal valorResidual = activo.dValorResidual;
                int vidaUtil = activo.iVidaUtil;
                decimal depreciacionAnual = (costo - valorResidual) / vidaUtil;
                decimal depreciacionAcumulada = 0;
                decimal valorEnLibros = costo;

                Console.WriteLine($"Datos para guardar - Costo: {costo}, Residual: {valorResidual}, Vida Útil: {vidaUtil}, Dep.Anual: {depreciacionAnual}");

                // Insertar nuevos cálculos
                string sqlInsert = @"INSERT INTO Tbl_DepreciacionActivos 
                           (Fk_Activo_ID, Cmp_Anio, Cmp_Valor_En_Libros, 
                            Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada)
                           VALUES (?, ?, ?, ?, ?)";

                int registrosInsertados = 0;

                for (int anio = 1; anio <= vidaUtil; anio++)
                {
                    depreciacionAcumulada = depreciacionAnual * anio;
                    valorEnLibros = costo - depreciacionAcumulada;

                    // Ajuste para el último año
                    if (anio == vidaUtil)
                    {
                        valorEnLibros = valorResidual;
                        depreciacionAcumulada = costo - valorResidual;
                    }

                    // Asegurar que no haya valores negativos
                    if (valorEnLibros < valorResidual)
                        valorEnLibros = valorResidual;

                    OdbcCommand cmdInsert = new OdbcCommand(sqlInsert, conn, transaction);
                    cmdInsert.Parameters.AddWithValue("?", idActivo);
                    cmdInsert.Parameters.AddWithValue("?", anio);
                    cmdInsert.Parameters.AddWithValue("?", Math.Round(valorEnLibros, 2));
                    cmdInsert.Parameters.AddWithValue("?", Math.Round(depreciacionAnual, 2));
                    cmdInsert.Parameters.AddWithValue("?", Math.Round(depreciacionAcumulada, 2));

                    int resultado = cmdInsert.ExecuteNonQuery();
                    if (resultado > 0)
                        registrosInsertados++;

                    Console.WriteLine($"Año {anio} guardado: V.Libros={valorEnLibros:C2}, Dep.Anual={depreciacionAnual:C2}, Dep.Acum={depreciacionAcumulada:C2}");
                }

                transaction.Commit();
                Console.WriteLine($"=== GUARDADO EXITOSO - {registrosInsertados} registros insertados ===");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al guardar: {ex.Message}");
                transaction?.Rollback();
                throw new Exception($"Error al guardar cálculo de depreciación: {ex.Message}");
            }
            finally
            {
                conexion.desconexion(conn);
            }
        }

        public decimal ObtenerDepreciacionTotal(int idActivo)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT MAX(Cmp_Depreciacion_Acumulada) 
                          FROM Tbl_DepreciacionActivos 
                          WHERE Fk_Activo_ID = ?";

                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    cmd.Parameters.AddWithValue("?", idActivo);

                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener depreciación total: {ex.Message}");
            }
        }

        public DataTable ObtenerDepreciacionesExistentes(int idActivo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Cmp_Anio, Cmp_Valor_En_Libros, 
                          Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada
                          FROM Tbl_DepreciacionActivos 
                          WHERE Fk_Activo_ID = ? 
                          ORDER BY Cmp_Anio";

                    OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("?", idActivo);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // **CORRECCIÓN: Crear columnas con los nombres REALES de la tabla**
                dt.Columns.Add("Cmp_Anio", typeof(int));
                dt.Columns.Add("Cmp_Valor_En_Libros", typeof(string));
                dt.Columns.Add("Cmp_Depreciacion_Anual", typeof(string));
                dt.Columns.Add("Cmp_Depreciacion_Acumulada", typeof(string));

                Console.WriteLine($"Error al obtener depreciaciones: {ex.Message}");
            }
            return dt;
        }
        public DataTable BuscarActivos(string criterio)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string sql = @"SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Grupo_Activo, 
                          Cmp_Costo_Adquisicion, Cmp_Valor_Residual, Cmp_Vida_Util,
                          Cmp_Fecha_Adquisicion
                          FROM Tbl_ActivosFijos 
                          WHERE Cmp_Estado = 1";

                    // Si hay criterio de búsqueda, agregar filtro
                    if (!string.IsNullOrEmpty(criterio))
                    {
                        sql += " AND (Cmp_Nombre_Activo LIKE ? OR Cmp_Grupo_Activo LIKE ?)";
                    }

                    sql += " ORDER BY Cmp_Nombre_Activo";

                    OdbcCommand cmd = new OdbcCommand(sql, conn);

                    if (!string.IsNullOrEmpty(criterio))
                    {
                        string likeCriterio = $"%{criterio}%";
                        cmd.Parameters.AddWithValue("?", likeCriterio);
                        cmd.Parameters.AddWithValue("?", likeCriterio);
                    }

                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en búsqueda de activos: {ex.Message}");
            }
            return dt;
        }
    }
}