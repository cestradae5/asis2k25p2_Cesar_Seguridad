using System;
using System.Data;
using System.Collections.Generic;
using Capa_modelo;
using Capa_Controlador_Polizas;

namespace Capa_controlador
{
    public class Cls_Depreciacion_Controlador
    {
        private Cls_Activo_FijoDAO dao = new Cls_Activo_FijoDAO();
        private Cls_CuentaContableDAO cuentaDAO = new Cls_CuentaContableDAO();

        // Métodos para cuentas contables...
        public List<string> ObtenerCuentasActivo()
        {
            try
            {
                var cuentas = new List<string>();
                DataTable dt = cuentaDAO.ObtenerCuentasActivo();

                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["Pk_Codigo_Cuenta"].ToString();
                    string nombre = row["Cmp_CtaNombre"].ToString();
                    cuentas.Add($"{codigo} - {nombre}");
                }

                return cuentas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de activo: {ex.Message}");
            }
        }

        public List<string> ObtenerCuentasDepreciacion()
        {
            try
            {
                var cuentas = new List<string>();
                DataTable dt = cuentaDAO.ObtenerCuentasDepreciacion();

                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["Pk_Codigo_Cuenta"].ToString();
                    string nombre = row["Cmp_CtaNombre"].ToString();
                    cuentas.Add($"{codigo} - {nombre}");
                }

                return cuentas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de depreciación: {ex.Message}");
            }
        }

        public List<string> ObtenerCuentasGastoDepreciacion()
        {
            try
            {
                var cuentas = new List<string>();
                DataTable dt = cuentaDAO.ObtenerCuentasGastoDepreciacion();

                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["Pk_Codigo_Cuenta"].ToString();
                    string nombre = row["Cmp_CtaNombre"].ToString();
                    cuentas.Add($"{codigo} - {nombre}");
                }

                return cuentas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas de gasto: {ex.Message}");
            }
        }

        public bool GuardarNuevoActivo(
    string nombre, string descripcion, string grupo,
    DateTime fechaAdquisicion, decimal valorAdquisicion,
    decimal valorResidual, int vidaUtil, string cuentaActivo,
    string cuentaDepreciacion, string cuentaGasto, bool estadoActivo)
        {
            try
            {
                // Validaciones...
                if (string.IsNullOrEmpty(nombre?.Trim()))
                    throw new Exception("El nombre del activo es requerido");

                if (string.IsNullOrEmpty(grupo?.Trim()))
                    throw new Exception("El grupo del activo es requerido");

                if (valorAdquisicion <= 0)
                    throw new Exception("El costo debe ser mayor a cero");

                if (valorResidual < 0)
                    throw new Exception("El valor residual no puede ser negativo");

                if (valorResidual >= valorAdquisicion)
                    throw new Exception("El valor residual no puede ser mayor o igual al costo");

                if (vidaUtil <= 0)
                    throw new Exception("La vida útil debe ser mayor a cero");

                return dao.pro_GuardarNuevoActivo(
                    nombre.Trim(), descripcion?.Trim() ?? "", grupo.Trim(),
                    fechaAdquisicion, valorAdquisicion, valorResidual,
                    vidaUtil, cuentaActivo, cuentaDepreciacion, cuentaGasto, estadoActivo
                );
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar activo: {ex.Message}");
            }
        }

        // MÉTODOS PARA DEPRECIACIÓN
        public DataTable ObtenerActivosParaCombo()
        {
            try
            {
                return dao.ObtenerActivosParaCombo();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener activos: {ex.Message}");
            }
        }

        // SOLO UN MÉTODO ObtenerDatosActivo - ELIMINA LOS DUPLICADOS
        public string[] ObtenerDatosActivo(int idActivo)
        {
            try
            {
                Console.WriteLine($"Controlador: Obteniendo datos para activo {idActivo}");
                string[] resultado = dao.ObtenerDatosActivoParaVista(idActivo);
                Console.WriteLine($"Controlador: Datos obtenidos - {resultado?.Length} elementos");
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Controlador: Error - {ex.Message}");
                throw new Exception($"Error al obtener datos del activo: {ex.Message}");
            }
        }

        public DataTable CalcularDepreciacionLineal(int idActivo)
        {
            try
            {
                return dao.CalcularDepreciacionLineal(idActivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en cálculo de depreciación: {ex.Message}");
            }
        }

        public bool GuardarCalculoDepreciacion(int idActivo)
        {
            try
            {
                return dao.GuardarCalculoDepreciacion(idActivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar cálculo: {ex.Message}");
            }
        }

        public decimal ObtenerDepreciacionTotal(int idActivo)
        {
            try
            {
                return dao.ObtenerDepreciacionTotal(idActivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener depreciación total: {ex.Message}");
            }
        }

        public DataTable ObtenerDepreciacionesExistentes(int idActivo)
        {
            try
            {
                return dao.ObtenerDepreciacionesExistentes(idActivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener depreciaciones existentes: {ex.Message}");
            }
        }

        public DataTable BuscarActivos(string criterio)
        {
            try
            {
                return dao.BuscarActivos(criterio);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar activos: {ex.Message}");
            }
        }
        //Apartado para la poliza
        private Cls_envio_poliza_depreciacion polizaService = new Cls_envio_poliza_depreciacion();

        // Método actualizado en la clase Cls_Depreciacion_Controlador
        public bool EnviarPolizaDepreciacion(int idActivo, DateTime fecha, decimal depreciacionAnual)
        {
            try
            {
                Console.WriteLine($"=== CONTROLADOR: ENVIANDO PÓLIZA ===");

                // Este método debe estar implementado en tu controlador
                var polizaService = new Cls_envio_poliza_depreciacion();

                // **ACTUALIZACIÓN: Usar el método mejorado que sigue las instrucciones**
                bool resultado = polizaService.EnviarPolizaDepreciacion(idActivo, fecha, depreciacionAnual);

                if (resultado)
                {
                    Console.WriteLine($" Póliza enviada correctamente desde controlador");
                }
                else
                {
                    Console.WriteLine($" Error al enviar póliza desde controlador");
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error en controlador al enviar póliza: {ex.Message}");
                throw new Exception($"Error al enviar póliza: {ex.Message}");
            }
        }

        public object ObtenerActivoCompleto(int idActivo)
        {
            try
            {
                // Este método debe devolver un objeto anónimo o específico, no del modelo
                var activo = dao.fun_ObtenerDatosActivo(idActivo);
                if (activo != null)
                {
                    return new
                    {
                        sCuentaGastoDepreciacion = activo.sCuentaGastoDepreciacion,
                        sCuentaDepreciacionAcumulada = activo.sCuentaDepreciacionAcumulada
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener activo completo: {ex.Message}");
            }
        }
        public (string cuentaGasto, string cuentaDepreciacion) ObtenerCuentasContablesActivo(int idActivo)
        {
            try
            {
                // Usa el DAO para obtener las cuentas contables del activo
                var activo = dao.fun_ObtenerDatosActivo(idActivo);
                if (activo != null)
                {
                    return (activo.sCuentaGastoDepreciacion, activo.sCuentaDepreciacionAcumulada);
                }

                // Valores por defecto si no se encuentra el activo
                return ("6.1.5", "1.6.1");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener cuentas contables del activo: {ex.Message}");
            }
        }

    }
}