using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_modelo
{
    public class Cls_CuentaContableDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        public DataTable ObtenerCuentasActivo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    // QUITAR Cmp_Estado = 1 porque NO EXISTE en Tbl_Catalogo_Cuentas
                    string sql = @"SELECT Pk_Codigo_Cuenta, Cmp_CtaNombre 
                                   FROM Tbl_Catalogo_Cuentas 
                                   WHERE Pk_Codigo_Cuenta LIKE '1.5%'
                                   ORDER BY Pk_Codigo_Cuenta";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de activo: {ex.Message}");
            }
            return dt;
        }

        public DataTable ObtenerCuentasDepreciacion()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    // QUITAR Cmp_Estado = 1
                    string sql = @"SELECT Pk_Codigo_Cuenta, Cmp_CtaNombre 
                                   FROM Tbl_Catalogo_Cuentas 
                                   WHERE Pk_Codigo_Cuenta LIKE '1.6%'
                                   ORDER BY Pk_Codigo_Cuenta";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de depreciación: {ex.Message}");
            }
            return dt;
        }

        public DataTable ObtenerCuentasGastoDepreciacion()
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    // QUITAR Cmp_Estado = 1
                    string sql = @"SELECT Pk_Codigo_Cuenta, Cmp_CtaNombre 
                                   FROM Tbl_Catalogo_Cuentas 
                                   WHERE Pk_Codigo_Cuenta = '6.1.5'
                                   ORDER BY Pk_Codigo_Cuenta";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de gasto: {ex.Message}");
            }
            return dt;
        }
    }
}