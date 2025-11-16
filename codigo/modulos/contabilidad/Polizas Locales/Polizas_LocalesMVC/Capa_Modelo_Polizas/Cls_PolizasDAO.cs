using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//autor: Kenph Luna 9959-22-6326

namespace Capa_Modelo_Polizas
{
    public class Cls_PolizasDAO
    {
        private Cls_Conexion cConexion = new Cls_Conexion();
        private Cls_SentenciasSQL cSQL = new Cls_SentenciasSQL();

        // obtener siguiente ID segun mes y año
        public int ObtenerSiguienteIdEncabezado(DateTime dFecha)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(cSQL.sObtenerSiguienteIdEncabezado, cConn))
                {
                    cmd.Parameters.Add("p1", OdbcType.Date).Value = dFecha.Date;
                    object result = cmd.ExecuteScalar();

                    int nextId = (result != null && result != DBNull.Value)
                        ? Convert.ToInt32(result)
                        : 1;

                    return nextId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener siguiente ID: " + ex.Message);
            }
        }




        // insertar poliza completa de forma transaccional
        public int InsertarPoliza(DateTime dFecha, string sConcepto, List<(string sCodigoCuenta, bool bTipo, decimal dValor)> lDetalles)
        {
            using (OdbcConnection cConn = cConexion.AbrirConexion())
            using (OdbcTransaction cTrans = cConn.BeginTransaction())
            {
                try
                {
                    // Obtener siguiente ID por mes/año
                    int iIdGenerado = ObtenerSiguienteIdEncabezado(dFecha);

                    // Insertar encabezado
                    using (OdbcCommand cCmdEnc = new OdbcCommand(cSQL.sInsertarEncabezado, cConn, cTrans))
                    {
                        cCmdEnc.Parameters.Add("p1", OdbcType.Int).Value = iIdGenerado;
                        cCmdEnc.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cCmdEnc.Parameters.Add("p3", OdbcType.VarChar, 200).Value = sConcepto ?? string.Empty;
                        cCmdEnc.ExecuteNonQuery();
                    }

                    // Insertar detalles
                    foreach (var det in lDetalles)
                    {
                        using (OdbcCommand cCmdDet = new OdbcCommand(cSQL.sInsertarDetalle, cConn, cTrans))
                        {
                            cCmdDet.Parameters.Add("p1", OdbcType.Int).Value = iIdGenerado;
                            cCmdDet.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                            cCmdDet.Parameters.Add("p3", OdbcType.VarChar, 20).Value = det.sCodigoCuenta;
                            cCmdDet.Parameters.Add("p4", OdbcType.TinyInt).Value = det.bTipo ? 1 : 0;
                            cCmdDet.Parameters.Add("p5", OdbcType.Double).Value = Convert.ToDouble(det.dValor);
                            cCmdDet.ExecuteNonQuery();
                        }
                    }

                    // Actualizar total del encabezado
                    using (OdbcCommand cCmdTot = new OdbcCommand(cSQL.sActualizarTotalEncabezado, cConn, cTrans))
                    {
                        cCmdTot.Parameters.Add("p1", OdbcType.Int).Value = iIdGenerado;
                        cCmdTot.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cCmdTot.Parameters.Add("p3", OdbcType.Int).Value = iIdGenerado;
                        cCmdTot.Parameters.Add("p4", OdbcType.Date).Value = dFecha.Date;
                        cCmdTot.ExecuteNonQuery();
                    }

                    cTrans.Commit();
                    return iIdGenerado;
                }
                catch (Exception ex)
                {
                    cTrans.Rollback();
                    throw new Exception("Error al insertar póliza: " + ex.Message);
                }
            }
        }




        //actualizar poliza completa de forma transaccional
        public bool ActualizarPoliza(int iIdPoliza, DateTime dFecha, string sConcepto, List<(string sCodigoCuenta, bool bTipo, decimal dValor)> lDetalles)
        {
            using (OdbcConnection cConn = cConexion.AbrirConexion())
            using (OdbcTransaction cTrans = cConn.BeginTransaction())
            {
                try
                {
                    // Actualizar encabezado
                    using (OdbcCommand cCmdEnc = new OdbcCommand(cSQL.sActualizarEncabezado, cConn, cTrans))
                    {
                        cCmdEnc.Parameters.Add("p1", OdbcType.VarChar, 200).Value = sConcepto;
                        cCmdEnc.Parameters.Add("p2", OdbcType.Int).Value = iIdPoliza;
                        cCmdEnc.Parameters.Add("p3", OdbcType.Date).Value = dFecha.Date;
                        cCmdEnc.ExecuteNonQuery();
                    }

                    // Eliminar detalles previos
                    using (OdbcCommand cCmdDel = new OdbcCommand(cSQL.sEliminarDetallesDePoliza, cConn, cTrans))
                    {
                        cCmdDel.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                        cCmdDel.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cCmdDel.ExecuteNonQuery();
                    }

                    // Insertar nuevos detalles
                    foreach (var det in lDetalles)
                    {
                        using (OdbcCommand cCmdDet = new OdbcCommand(cSQL.sInsertarDetalle, cConn, cTrans))
                        {
                            cCmdDet.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                            cCmdDet.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                            cCmdDet.Parameters.Add("p3", OdbcType.VarChar, 20).Value = det.sCodigoCuenta;
                            cCmdDet.Parameters.Add("p4", OdbcType.TinyInt).Value = det.bTipo ? 1 : 0;
                            cCmdDet.Parameters.Add("p5", OdbcType.Double).Value = Convert.ToDouble(det.dValor);
                            cCmdDet.ExecuteNonQuery();
                        }
                    }

                    // Actualizar total
                    using (OdbcCommand cCmdTot = new OdbcCommand(cSQL.sActualizarTotalEncabezado, cConn, cTrans))
                    {
                        cCmdTot.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                        cCmdTot.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cCmdTot.Parameters.Add("p3", OdbcType.Int).Value = iIdPoliza;
                        cCmdTot.Parameters.Add("p4", OdbcType.Date).Value = dFecha.Date;
                        cCmdTot.ExecuteNonQuery();
                    }

                    cTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    cTrans.Rollback();
                    throw new Exception("Error al actualizar póliza: " + ex.Message);
                }
            }
        }


        //eliminar poliza
        public bool EliminarPoliza(int iIdPoliza, DateTime dFecha)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cCmd = new OdbcCommand(cSQL.sEliminarEncabezado, cConn))
                {
                    cCmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                    cCmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                    int iRows = cCmd.ExecuteNonQuery();
                    return iRows > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar póliza: " + ex.Message);
            }
        }

        // eliminar un detalle de poliza
        public bool EliminarDetalle(int iIdPoliza, DateTime dFecha, string sCodigoCuenta)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcTransaction cTrans = cConn.BeginTransaction())
                {
                    using (OdbcCommand cCmd = new OdbcCommand(cSQL.sEliminarDetalle, cConn, cTrans))
                    {
                        cCmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                        cCmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cCmd.Parameters.Add("p3", OdbcType.VarChar, 20).Value = sCodigoCuenta;
                        int iRows = cCmd.ExecuteNonQuery();

                        if (iRows > 0)
                        {
                            // actualizar total del encabezado
                            using (OdbcCommand cCmdTot = new OdbcCommand(cSQL.sActualizarTotalEncabezado, cConn, cTrans))
                            {
                                cCmdTot.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                                cCmdTot.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                                cCmdTot.Parameters.Add("p3", OdbcType.Int).Value = iIdPoliza;
                                cCmdTot.Parameters.Add("p4", OdbcType.Date).Value = dFecha.Date;
                                cCmdTot.ExecuteNonQuery();
                            }

                            cTrans.Commit();
                            return true;
                        }
                        else
                        {
                            cTrans.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar detalle: " + ex.Message);
            }
        }


        //consultar encabezados
        public DataTable ConsultarEncabezados()
        {
            DataTable dtDatos = new DataTable();
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcDataAdapter da = new OdbcDataAdapter(cSQL.sConsultarEncabezados, cConn))
                {
                    da.Fill(dtDatos);
                }

                return dtDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar encabezados: " + ex.Message);
            }
        }


        //consultar detalle
        public DataTable ConsultarDetalle(int iIdPoliza, DateTime dFecha)
        {
            DataTable dtDatos = new DataTable();
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cCmd = new OdbcCommand(cSQL.sConsultarDetalle, cConn))
                {
                    cCmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                    cCmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cCmd))
                    {
                        da.Fill(dtDatos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar detalle: " + ex.Message);
            }
            return dtDatos;
        }

        //consultar cuentas para el combo
        public DataTable ConsultarCuentasContables()
        {
            DataTable dtDatos = new DataTable();
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcDataAdapter da = new OdbcDataAdapter(cSQL.sConsultarCuentasContables, cConn))
                {
                    da.Fill(dtDatos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar catálogo de cuentas: " + ex.Message);
            }
            return dtDatos;
        }

        // Obtener total de cargos
        public decimal ObtenerTotalCargos(int iIdPoliza, DateTime dFecha)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cCmd = new OdbcCommand(cSQL.sObtenerTotalCargos, cConn))
                {
                    cCmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                    cCmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                    object oResult = cCmd.ExecuteScalar();
                    return Convert.ToDecimal(oResult);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de cargos: " + ex.Message);
            }
        }

        // Obtener total de abonos
        public decimal ObtenerTotalAbonos(int iIdPoliza, DateTime dFecha)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cCmd = new OdbcCommand(cSQL.sObtenerTotalAbonos, cConn))
                {
                    cCmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                    cCmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                    object oResult = cCmd.ExecuteScalar();
                    return Convert.ToDecimal(oResult);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de abonos: " + ex.Message);
            }
        }

        // obtener diferencial cargo menos abono
        public decimal ObtenerDiferencial(int iIdPoliza, DateTime dFecha)
        {
            decimal dCargos = ObtenerTotalCargos(iIdPoliza, dFecha);
            decimal dAbonos = ObtenerTotalAbonos(iIdPoliza, dFecha);
            return dCargos - dAbonos;
        }

        //metodo para actualizar saldos contables en linea
        public bool ActualizarSaldosContables()
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcTransaction cTrans = cConn.BeginTransaction())
                {
                    // reiniciar saldos actuales al valor inicial
                    using (OdbcCommand cmdReset = new OdbcCommand(cSQL.sResetearSaldos, cConn, cTrans))
                        cmdReset.ExecuteNonQuery();

                    // recalcular cargos, abonos y saldo actual por cuenta detalle
                    using (OdbcCommand cmdAct = new OdbcCommand(cSQL.sActualizarSaldos, cConn, cTrans))
                        cmdAct.ExecuteNonQuery();

                    //propagar jerarquicamente hasta no encontrar más cuentas madre
                    bool huboCambios = true;
                    int iteraciones = 0;

                    while (huboCambios && iteraciones < 50) 
                    {
                        huboCambios = false;
                        using (OdbcCommand cmdPropagar = new OdbcCommand(cSQL.sPropagarSaldosJerarquico, cConn, cTrans))
                        {
                            int filas = cmdPropagar.ExecuteNonQuery();
                            if (filas > 0) huboCambios = true;
                        }
                        iteraciones++;
                    }

                    //marcar pólizas activas como actualizadas 
                    using (OdbcCommand cmdMarcar = new OdbcCommand(cSQL.sMarcarPolizasActualizadas_EnLinea, cConn, cTrans))
                    {
                        cmdMarcar.ExecuteNonQuery();
                    }

                    //confirmar transacción
                    cTrans.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar saldos contables: " + ex.Message);
            }
        }

        public bool ActualizarSaldosPorPoliza(int iIdPoliza, DateTime dFecha)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcTransaction cTrans = cConn.BeginTransaction())
                {
                    // Recalcular solo las cuentas afectadas
                    using (OdbcCommand cmd = new OdbcCommand(cSQL.sActualizarSaldosPorPoliza, cConn, cTrans))
                    {
                        cmd.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                        cmd.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cmd.ExecuteNonQuery();
                    }

                    // Propagar jerárquicamente saldos a cuentas madre
                    bool huboCambios = true;
                    int iteraciones = 0;

                    while (huboCambios && iteraciones < 50)
                    {
                        huboCambios = false;
                        using (OdbcCommand cmdPropagar = new OdbcCommand(cSQL.sPropagarSaldosJerarquico, cConn, cTrans))
                        {
                            int filas = cmdPropagar.ExecuteNonQuery();
                            if (filas > 0) huboCambios = true;
                        }
                        iteraciones++;
                    }

                    // Marcar solo esa póliza como actualizada
                    using (OdbcCommand cmdMarcar = new OdbcCommand(cSQL.sMarcarPolizaActualizada, cConn, cTrans))
                    {
                        cmdMarcar.Parameters.Add("p1", OdbcType.Int).Value = iIdPoliza;
                        cmdMarcar.Parameters.Add("p2", OdbcType.Date).Value = dFecha.Date;
                        cmdMarcar.ExecuteNonQuery();
                    }

                    cTrans.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar saldos de la póliza: " + ex.Message);
            }
        }




        public bool ActualizarSaldosPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcTransaction cTrans = cConn.BeginTransaction())
                {
                    //reiniciar saldos 
                    using (OdbcCommand cmdReset = new OdbcCommand(cSQL.sResetearSaldos, cConn, cTrans))
                        cmdReset.ExecuteNonQuery();

                    //calcular saldos solo del rango de fechas 
                    using (OdbcCommand cmdAct = new OdbcCommand(cSQL.sActualizarSaldosPorRango, cConn, cTrans))
                    {
                        cmdAct.Parameters.Add("p1", OdbcType.Date).Value = fechaInicio.Date;
                        cmdAct.Parameters.Add("p2", OdbcType.Date).Value = fechaFin.Date;
                        cmdAct.ExecuteNonQuery();
                    }

                    //Propagar saldos
                    bool huboCambios = true;
                    int iteraciones = 0;

                    while (huboCambios && iteraciones < 50) // evita bucle infinito
                    {
                        huboCambios = false;
                        using (OdbcCommand cmdPropagar = new OdbcCommand(cSQL.sPropagarSaldosJerarquico, cConn, cTrans))
                        {
                            int filas = cmdPropagar.ExecuteNonQuery();
                            if (filas > 0) huboCambios = true;
                        }
                        iteraciones++;
                    }

                    //Marcar pólizas actualizadas 
                    using (OdbcCommand cmdUpd = new OdbcCommand(cSQL.sMarcarPolizasActualizadas, cConn, cTrans))
                    {
                        cmdUpd.Parameters.Add("p1", OdbcType.Date).Value = fechaInicio.Date;
                        cmdUpd.Parameters.Add("p2", OdbcType.Date).Value = fechaFin.Date;
                        cmdUpd.ExecuteNonQuery();
                    }

                    cTrans.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar saldos contables por rango: " + ex.Message);
            }
        }

        //para validacion de rangos entre fechas al actualizar saldos en batch
        public bool ExistePeriodoActivo(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(cSQL.sVerificarPeriodoActivo, cConn))
                {
                    cmd.Parameters.Add("p1", OdbcType.Date).Value = fechaInicio.Date;
                    cmd.Parameters.Add("p2", OdbcType.Date).Value = fechaFin.Date;

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result ?? 0) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar período activo: " + ex.Message);
            }
        }






        // cierres contables
        public int CerrarMesContable(DateTime fechaFin)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(cSQL.sCerrarMesContable, cConn))
                {
                    cmd.Parameters.Add("p1", OdbcType.Date).Value = fechaFin.Date;
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar mes contable: " + ex.Message);
            }
        }


        public int CerrarAnioContable(DateTime fechaFin)
        {
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcCommand cmd = new OdbcCommand(cSQL.sCerrarAnioContable, cConn))
                {
                    cmd.Parameters.Add("p1", OdbcType.Date).Value = fechaFin.Date;
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar año contable: " + ex.Message);
            }
        }

        //obtener periodo contable actual
        public DataTable ObtenerPeriodoActual()
        {
            DataTable dtPeriodo = new DataTable();
            try
            {
                using (OdbcConnection cConn = cConexion.AbrirConexion())
                using (OdbcDataAdapter da = new OdbcDataAdapter(cSQL.sObtenerPeriodoActual, cConn))
                {
                    da.Fill(dtPeriodo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener periodo contable actual: " + ex.Message);
            }
            return dtPeriodo;
        }


        // Creacrea y activa el período del mes actual si no existe, y desactiva los demás.
        public int AsegurarPeriodoActivo(DateTime hoy)
        {
            int idPeriodo = 0;
            int anio = hoy.Year;
            int mes = hoy.Month;
            DateTime ini = new DateTime(anio, mes, 1);
            DateTime fin = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));

            using (var cConn = cConexion.AbrirConexion())
            using (var trx = cConn.BeginTransaction())
            {
                try
                {
                    // Verificar si existe año y mes
                    using (var cmdSel = new OdbcCommand(cSQL.sSelectPeriodoPorMes, cConn, trx))
                    {
                        cmdSel.Parameters.Add("p1", OdbcType.Int).Value = anio;
                        cmdSel.Parameters.Add("p2", OdbcType.TinyInt).Value = mes;
                        var obj = cmdSel.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                            idPeriodo = Convert.ToInt32(obj);
                    }

                    // insertar si no existe
                    if (idPeriodo == 0)
                    {
                        using (var cmdIns = new OdbcCommand(cSQL.sInsertarPeriodo, cConn, trx))
                        {
                            cmdIns.Parameters.Add("p1", OdbcType.Int).Value = anio;
                            cmdIns.Parameters.Add("p2", OdbcType.TinyInt).Value = mes;
                            cmdIns.Parameters.Add("p3", OdbcType.Date).Value = ini;
                            cmdIns.Parameters.Add("p4", OdbcType.Date).Value = fin;
                            cmdIns.ExecuteNonQuery();
                        }

                        using (var cmdId = new OdbcCommand("SELECT LAST_INSERT_ID();", cConn, trx))
                            idPeriodo = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    // desactivar otros y activar este
                    using (var cmdOff = new OdbcCommand(cSQL.sDesactivarPeriodos, cConn, trx))
                        cmdOff.ExecuteNonQuery();

                    using (var cmdOn = new OdbcCommand(cSQL.sActivarPeriodo, cConn, trx))
                    {
                        cmdOn.Parameters.Add("p1", OdbcType.Int).Value = idPeriodo;
                        cmdOn.ExecuteNonQuery();
                    }

                    trx.Commit();
                    return idPeriodo;
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    throw new Exception("AsegurarPeriodoActivo(): " + ex.Message);
                }
            }
        }

        public bool CambiarModoOperacion(bool bModoEnLinea)
        {
            try
            {
                int idPeriodo = ObtenerIdPeriodoActivo();
                if (idPeriodo == 0)
                    idPeriodo = AsegurarPeriodoActivo(DateTime.Now);

                using (var cConn = cConexion.AbrirConexion())
                using (var cmd = new OdbcCommand(cSQL.sActualizarModoOperacionDiferente, cConn))
                {
                    cmd.Parameters.Add("p1", OdbcType.TinyInt).Value = bModoEnLinea ? 1 : 0;
                    cmd.Parameters.Add("p2", OdbcType.Int).Value = idPeriodo;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar modo de operación: " + ex.Message);
            }
        }


        public int ObtenerIdPeriodoActivo()
        {
            try
            {
                using (var cConn = cConexion.AbrirConexion())
                using (var cmd = new OdbcCommand(cSQL.sSelectPeriodoActivo, cConn))
                {
                    var o = cmd.ExecuteScalar();
                    return (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener período activo: " + ex.Message);
            }
        }



        // Obtener modo actual de operación
        public bool ObtenerModoOperacion()
        {
            try
            {
                using (var cConn = cConexion.AbrirConexion())
                using (var cmd = new OdbcCommand(cSQL.sObtenerModoOperacion, cConn))
                {
                    var o = cmd.ExecuteScalar();

                    // Si no hay período activo, crear uno
                    if (o == null || o == DBNull.Value)
                    {
                        AsegurarPeriodoActivo(DateTime.Now);
                        o = cmd.ExecuteScalar();
                    }

                    return Convert.ToInt32(o) == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener modo de operación: " + ex.Message);
            }
        }

    }
}
