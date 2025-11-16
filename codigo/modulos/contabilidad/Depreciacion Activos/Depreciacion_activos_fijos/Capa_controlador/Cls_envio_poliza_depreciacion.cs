using System;
using System.Collections.Generic;
using Capa_Controlador_Polizas;

namespace Capa_controlador
{
    public class Cls_envio_poliza_depreciacion
    {
        private Cls_PolizaControlador polizaCtrl = new Cls_PolizaControlador();

        public bool EnviarPolizaDepreciacion(int idActivo, DateTime fecha, decimal depreciacionAnual)
        {
            try
            {
                Console.WriteLine($"=== ENVIANDO PÓLIZA DE DEPRECIACIÓN ===");
                Console.WriteLine($"Activo ID: {idActivo}");
                Console.WriteLine($"Fecha: {fecha:yyyy-MM-dd}");
                Console.WriteLine($"Depreciación Anual: {depreciacionAnual:C}");

                // Obtener datos del activo a través del controlador de depreciación
                var controladorDepreciacion = new Cls_Depreciacion_Controlador();

                // Obtener nombre del activo usando el método existente
                string[] datosActivo = controladorDepreciacion.ObtenerDatosActivo(idActivo);

                if (datosActivo == null || datosActivo.Length < 1)
                {
                    throw new Exception("No se pudieron obtener los datos del activo.");
                }

                string nombreActivo = datosActivo[0];

                // Obtener cuentas contables usando el método específico
                var cuentas = controladorDepreciacion.ObtenerCuentasContablesActivo(idActivo);
                string cuentaGasto = cuentas.cuentaGasto;
                string cuentaDepreciacion = cuentas.cuentaDepreciacion;

                // **ACTUALIZACIÓN SEGÚN INSTRUCCIONES: Obtener siguiente ID**
                int nuevoId = polizaCtrl.ObtenerSiguienteIdEncabezado(fecha);
                Console.WriteLine($"Siguiente ID obtenido: {nuevoId}");

                // Preparar concepto según instrucciones
                string concepto = $"Depreciación Anual - {nombreActivo} - {fecha:yyyy}";

                // **ACTUALIZACIÓN: Preparar detalles según formato de instrucciones**
                var detalles = new List<(string sCodigoCuenta, bool bTipo, decimal dValor)>
                {
                    // CARGO: Gasto por Depreciación (true = 1 = cargo)
                    (cuentaGasto, true, depreciacionAnual),
                    
                    // ABONO: Depreciación Acumulada (false = 0 = abono)  
                    (cuentaDepreciacion, false, depreciacionAnual)
                };

                Console.WriteLine($"Cuenta Gasto: {cuentaGasto}");
                Console.WriteLine($"Cuenta Depreciación: {cuentaDepreciacion}");
                Console.WriteLine($"Concepto: {concepto}");
                Console.WriteLine($"Detalles: {detalles.Count} registros");

                // **ENVÍO DE PÓLIZA SEGÚN INSTRUCCIONES**
                bool resultado = polizaCtrl.InsertarPoliza(fecha, concepto, detalles);

                if (resultado)
                {
                    Console.WriteLine($"✅ Póliza {nuevoId} enviada exitosamente");
                    return true;
                }
                else
                {
                    Console.WriteLine($"❌ Error al enviar póliza");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en póliza: {ex.Message}");
                throw new Exception($"Error al enviar póliza: {ex.Message}");
            }
        }

        // **NUEVO MÉTODO: Envío de póliza con parámetros directos (sobrecarga)**
        public bool EnviarPolizaDepreciacion(DateTime fecha, string concepto,
                                           string cuentaGasto, string cuentaDepreciacion,
                                           decimal depreciacionAnual)
        {
            try
            {
                // Obtener siguiente ID según instrucciones
                int nuevoId = polizaCtrl.ObtenerSiguienteIdEncabezado(fecha);
                Console.WriteLine($"Siguiente ID para {fecha:yyyy-MM-dd}: {nuevoId}");

                var detalles = new List<(string sCodigoCuenta, bool bTipo, decimal dValor)>
                {
                    (cuentaGasto, true, depreciacionAnual),    // Cargo
                    (cuentaDepreciacion, false, depreciacionAnual)  // Abono
                };

                Console.WriteLine($"Enviando póliza directa - Concepto: {concepto}");

                return polizaCtrl.InsertarPoliza(fecha, concepto, detalles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en póliza directa: {ex.Message}");
                throw new Exception($"Error al enviar póliza: {ex.Message}");
            }
        }

        // **NUEVO MÉTODO: Versión simplificada para uso rápido**
        public bool EnviarPolizaDepreciacionSimple(int idActivo, decimal depreciacionAnual)
        {
            try
            {
                DateTime fechaPoliza = DateTime.Now;
                var controladorDepreciacion = new Cls_Depreciacion_Controlador();

                string[] datosActivo = controladorDepreciacion.ObtenerDatosActivo(idActivo);
                if (datosActivo == null || datosActivo.Length < 1)
                    return false;

                string nombreActivo = datosActivo[0];
                var cuentas = controladorDepreciacion.ObtenerCuentasContablesActivo(idActivo);

                return EnviarPolizaDepreciacion(
                    fechaPoliza,
                    $"Depreciación - {nombreActivo}",
                    cuentas.cuentaGasto,
                    cuentas.cuentaDepreciacion,
                    depreciacionAnual
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en póliza simple: {ex.Message}");
                return false;
            }
        }
    }
}