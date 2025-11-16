using System;
using System.Collections.Generic;
using System.Data;
using Capa_Modelo_Contabilidad;

namespace Capa_Controlador_Contabilidad
{
    public class Cls_Depreciacion_Controlador
    {
        // Instancia del DAO (modelo)
        private Cls_Activo_FijoDAO dao = new Cls_Activo_FijoDAO();

        // Clases DTO para la vista 
        public class ActivoFijoDTO
        {
            public decimal dCostoAdquisicion { get; set; }
            public decimal dValorResidual { get; set; }
            public int iVidaUtil { get; set; }
            public string sNombreActivo { get; set; }
        }

        public class DepreciacionDTO
        {
            public int iAño { get; set; }
            public decimal dValorEnLibros { get; set; }
            public decimal dDepreciacionAnual { get; set; }
            public decimal dDepreciacionAcumulada { get; set; }
        }

        // Carga todos los activos para llenar el ComboBox
        public DataTable CargarActivos()
        {
            try
            {
                DataTable dt = dao.fun_ObtenerActivos();

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("No hay activos fijos disponibles para depreciar.");
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar activos: {ex.Message}");
            }
        }

        // Obtiene la información de un activo (costo, residual, vida útil)
        public ActivoFijoDTO ObtenerDatosActivo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del activo debe ser mayor a cero.");
            }

            Cls_Activo_Fijo activo = dao.fun_ObtenerDatosActivo(id);

            if (activo == null)
            {
                throw new Exception($"No se encontró el activo con ID: {id}");
            }

            // Validaciones
            if (activo.dCostoAdquisicion <= 0)
            {
                throw new Exception("El costo de adquisición debe ser mayor a cero.");
            }

            if (activo.dValorResidual < 0)
            {
                throw new Exception("El valor residual no puede ser negativo.");
            }

            if (activo.dValorResidual >= activo.dCostoAdquisicion)
            {
                throw new Exception("El valor residual no puede ser mayor o igual al costo de adquisición.");
            }

            if (activo.iVidaUtil <= 0)
            {
                throw new Exception("La vida útil debe ser mayor a cero.");
            }

            // Convertir a DTO
            return new ActivoFijoDTO
            {
                dCostoAdquisicion = activo.dCostoAdquisicion,
                dValorResidual = activo.dValorResidual,
                iVidaUtil = activo.iVidaUtil,
                sNombreActivo = activo.sNombreActivo
            };
        }       

        // Método para validar si un activo puede ser seleccionado
        public bool ValidarSeleccionActivo(object selectedValue)
        {
            if (selectedValue == null)
            {
                throw new Exception("Debe seleccionar un activo fijo.");
            }

            if (!int.TryParse(selectedValue.ToString(), out int idActivo) || idActivo <= 0)
            {
                throw new Exception("El ID del activo seleccionado no es válido.");
            }

            return true;
        }
        public (List<DepreciacionDTO> resultados, decimal depreciacionAnual) CalcularDepreciacionLineaRecta(int idActivo)
        {
            try
            {
                Cls_Activo_Fijo activo = dao.fun_ObtenerDatosActivo(idActivo);

                if (activo == null)
                    throw new Exception("Activo no encontrado.");

                // Validaciones
                if (activo.dCostoAdquisicion <= activo.dValorResidual)
                    throw new Exception("El costo de adquisición debe ser mayor al valor residual.");

                decimal depAnual = (activo.dCostoAdquisicion - activo.dValorResidual) / activo.iVidaUtil;
                decimal valorLibros = activo.dCostoAdquisicion;
                decimal depAcumulada = 0;
                var resultados = new List<DepreciacionDTO>();

                for (int i = 1; i <= activo.iVidaUtil; i++)
                {
                    valorLibros -= depAnual;
                    depAcumulada += depAnual;

                    if (valorLibros < activo.dValorResidual)
                    {
                        valorLibros = activo.dValorResidual;
                    }

                    // Guardar cálculo de depreciación
                    dao.pro_GuardarDepreciacion(activo.iPkActivoId, i, valorLibros, depAnual, depAcumulada);

                    // ✅ NUEVO: Guardar asiento contable por cada año
                    string concepto = $"Depreciación anual {i} - {activo.sNombreActivo}";
                    dao.GuardarAsientoDepreciacion(activo.iPkActivoId, i, depAnual, concepto);

                    resultados.Add(new DepreciacionDTO
                    {
                        iAño = i,
                        dValorEnLibros = valorLibros,
                        dDepreciacionAnual = depAnual,
                        dDepreciacionAcumulada = depAcumulada
                    });
                }

                return (resultados, depAnual);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en cálculo de depreciación: {ex.Message}");
            }
        }
    }
}