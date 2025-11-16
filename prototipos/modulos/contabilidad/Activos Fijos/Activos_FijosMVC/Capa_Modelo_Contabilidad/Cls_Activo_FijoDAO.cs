using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Contabilidad
{
    public class Cls_Activo_FijoDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();
        //consulta de activo fijo que estan abilitados
        private static readonly string SQL_SELECT_ACTIVOS = @"
            SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Costo_Adquisicion, 
                   Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado
            FROM Tbl_ActivosFijos
            WHERE Cmp_Estado = 1";
        //Inserta la depreciacion en la tabla
        private static readonly string SQL_INSERT_DEP = @"
            INSERT INTO Tbl_DepreciacionActivos
                (Fk_Activo_ID, Cmp_Anio, Cmp_Valor_En_Libros, 
                 Cmp_Depreciacion_Anual, Cmp_Depreciacion_Acumulada)
            VALUES (?, ?, ?, ?, ?)";

        // ===============================================================
        // FUNCIÓN: fun_ObtenerActivos
        // ===============================================================
        public DataTable fun_ObtenerActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(SQL_SELECT_ACTIVOS, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener activos: {ex.Message}");
            }
            return dt;
        }

        // ===============================================================
        // FUNCIÓN: fun_ObtenerDatosActivo
        // ===============================================================
        public Cls_Activo_Fijo fun_ObtenerDatosActivo(int iIdActivo)
        {
            Cls_Activo_Fijo activo = null;

            string sql = @"
                SELECT Pk_Activo_ID, Cmp_Nombre_Activo, Cmp_Descripcion,
                       Cmp_Fecha_Adquisicion, Cmp_Costo_Adquisicion, 
                       Cmp_Valor_Residual, Cmp_Vida_Util, Cmp_Estado,
                       Cmp_CtaActivo, Cmp_CtaDepreciacion
                FROM Tbl_ActivosFijos 
                WHERE Pk_Activo_ID = ? AND Cmp_Estado = 1";

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcCommand cmd = new OdbcCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Pk_Activo_ID", iIdActivo);
                    OdbcDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        activo = new Cls_Activo_Fijo
                        {
                            iPkActivoId = reader.GetInt32(0),
                            sNombreActivo = reader.GetString(1),
                            sDescripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            dFechaAdquisicion = reader.GetDateTime(3),
                            dCostoAdquisicion = reader.GetDecimal(4),
                            dValorResidual = reader.GetDecimal(5),
                            iVidaUtil = reader.GetInt32(6),
                            bEstadoActivo = reader.GetInt32(7) == 1, // Conversión TINYINT to bool
                            sCuentaActivo = reader.IsDBNull(8) ? "" : reader.GetString(8),
                            sCuentaDepreciacion = reader.IsDBNull(9) ? "" : reader.GetString(9)
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

        // ===============================================================
        // PROCEDIMIENTO: pro_GuardarDepreciacion
        // ===============================================================
        public int pro_GuardarDepreciacion(int idActivo, int anio, decimal valorLibros, decimal depAnual, decimal depAcumulada)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    OdbcCommand cmd = new OdbcCommand(SQL_INSERT_DEP, conn);
                    cmd.Parameters.AddWithValue("@Fk_Activo_ID", idActivo);
                    cmd.Parameters.AddWithValue("@Cmp_Anio", anio);
                    cmd.Parameters.AddWithValue("@Cmp_Valor_En_Libros", valorLibros);
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
        // En Cls_Activo_FijoDAO.cs - Agregar este método
        public int GuardarAsientoDepreciacion(int idActivo, int anio, decimal depAnual, string concepto)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    // 1. Insertar encabezado de póliza
                    string sqlEncabezado = @"
                INSERT INTO Tbl_EncabezadoPoliza 
                (Pk_Fecha_Poliza, Cmp_Concepto_Poliza, Cmp_Valor_Poliza, Cmp_Estado_Poliza)
                VALUES (CURDATE(), ?, ?, 1)";

                    OdbcCommand cmdEncabezado = new OdbcCommand(sqlEncabezado, conn);
                    cmdEncabezado.Parameters.AddWithValue("@Concepto", concepto);
                    cmdEncabezado.Parameters.AddWithValue("@Valor", depAnual);
                    cmdEncabezado.ExecuteNonQuery();

                    // Obtener el ID del encabezado recién insertado
                    string sqlLastId = "SELECT LAST_INSERT_ID()";
                    OdbcCommand cmdLastId = new OdbcCommand(sqlLastId, conn);
                    int idPoliza = Convert.ToInt32(cmdLastId.ExecuteScalar());

                    // Obtener las cuentas del activo
                    Cls_Activo_Fijo activo = fun_ObtenerDatosActivo(idActivo);
                    if (activo == null) throw new Exception("Activo no encontrado");

                    // 2. Insertar detalle de póliza (ASIENTO CONTABLE)
                    string sqlDetalle = @"
                INSERT INTO Tbl_DetallePoliza 
                (PkFk_EncCodigo_Poliza, PkFk_Codigo_Cuenta, Cmp_Tipo_Poliza, Cmp_Valor_Poliza)
                VALUES (?, ?, ?, ?)";

                    // PARTIDA 1: CARGO a Gastos de Depreciación
                    OdbcCommand cmdDetalle1 = new OdbcCommand(sqlDetalle, conn);
                    cmdDetalle1.Parameters.AddWithValue("@IdPoliza", idPoliza);
                    cmdDetalle1.Parameters.AddWithValue("@Cuenta", "5.1.1"); // Depreciación del Ejercicio
                    cmdDetalle1.Parameters.AddWithValue("@Tipo", 1); // 1 = CARGO
                    cmdDetalle1.Parameters.AddWithValue("@Valor", depAnual);
                    cmdDetalle1.ExecuteNonQuery();

                    // PARTIDA 2: ABONO a Depreciación Acumulada
                    OdbcCommand cmdDetalle2 = new OdbcCommand(sqlDetalle, conn);
                    cmdDetalle2.Parameters.AddWithValue("@IdPoliza", idPoliza);
                    cmdDetalle2.Parameters.AddWithValue("@Cuenta", activo.sCuentaDepreciacion);
                    cmdDetalle2.Parameters.AddWithValue("@Tipo", 0); // 0 = ABONO
                    cmdDetalle2.Parameters.AddWithValue("@Valor", depAnual);
                    cmdDetalle2.ExecuteNonQuery();

                    return idPoliza;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar asiento contable: {ex.Message}");
            }
        }
    }
}