using System;
using System.Data;
using System.Windows.Forms;
using Capa_Modelo_Seguridad;

// Nombre: Danilo Mazariegos Codigo:0901-19-25059
namespace Capa_Controlador_Seguridad
{
    public class Cls_Modulos_Controlador
    {
        private readonly Cls_Modulo_Sentencias snm = new Cls_Modulo_Sentencias();
        private readonly Cls_BitacoraControlador ctrlBitacora = new Cls_BitacoraControlador(); // Para registrar acciones en la bitácora

       
        public class OperationResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public bool ConfirmedByUser { get; set; } = true;
            public ModuloDTO Modulo { get; set; }
        }

        public class ModuloDTO
        {
            public int Pk_Id_Modulo { get; set; }
            public string Cmp_Nombre_Modulo { get; set; }
            public string Cmp_Descripcion_Modulo { get; set; }
            public byte Cmp_Estado_Modulo { get; set; }
        }

        // Consultas básicas a modelo
        public string[] ItemsModulos()
        {
            return snm.fun_LlenarComboModulos();
        }

        public DataTable ObtenerModulos()
        {
            return snm.Fun_ObtenerModulos();
        }

        public DataRow BuscarModulo(int iPk_Id_Modulo)
        {
            return snm.BuscarModuloPorId(iPk_Id_Modulo);
        }

        // Validaciones
        public OperationResult GuardarModulo(string idText, string nombre, string descripcion, bool habilitado)
        {
            if (string.IsNullOrWhiteSpace(idText) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
                return new OperationResult { Success = false, Message = "Debe ingresar Id, Nombre y Descripción." };

            if (!int.TryParse(idText, out int id))
                return new OperationResult { Success = false, Message = "El Id debe ser un número." };

            var existente = snm.BuscarModuloPorId(id);
            if (existente != null)
                return new OperationResult { Success = false, Message = "Ya existe un módulo con este Id. Use el botón Modificar para actualizarlo." };

            byte estado = habilitado ? (byte)1 : (byte)0;
            int filas = snm.InsertarModulo(id, nombre, descripcion, estado);
            bool ok = filas > 0;

            if (ok)
            {
                // Bitácora (acción 1 = insertar; ajusta si manejas otro catálogo de acciones)
                ctrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, 1, $"Guardó el módulo: {nombre}", true);
                return new OperationResult { Success = true, Message = "Módulo guardado correctamente." };
            }
            else
            {
                return new OperationResult { Success = false, Message = "Error al guardar el módulo." };
            }
        }

        public OperationResult ModificarModulo(string idText, string nombre, string descripcion, bool habilitado)
        {
            if (string.IsNullOrWhiteSpace(idText) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
                return new OperationResult { Success = false, Message = "Debe ingresar Id, Nombre y Descripción." };

            if (!int.TryParse(idText, out int id))
                return new OperationResult { Success = false, Message = "El Id debe ser un número." };

            var existente = snm.BuscarModuloPorId(id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No existe un módulo con este Id. Use Guardar para crear uno nuevo." };

            // Confirmación al usuario (UI mínima desde controlador para centralizar la decisión; retorna bandera)
            var respuesta = MessageBox.Show(
                "¿Desea actualizar la información de este módulo?",
                "Confirmar modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (respuesta == DialogResult.No)
                return new OperationResult { Success = false, ConfirmedByUser = false, Message = "Modificación cancelada por el usuario." };

            byte estado = habilitado ? (byte)1 : (byte)0;
            int filas = snm.ModificarModulo(id, nombre, descripcion, estado);
            bool ok = filas > 0;

            if (ok)
            {
                ctrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, 1, $"Modificó el módulo: {nombre}", true);
                return new OperationResult { Success = true, Message = "Módulo modificado correctamente." };
            }
            else
            {
                return new OperationResult { Success = false, Message = "Error al modificar el módulo." };
            }
        }

        public OperationResult EliminarModulo(string idText, string nombreParaBitacora)
        {
            if (string.IsNullOrWhiteSpace(idText))
                return new OperationResult { Success = false, Message = "Ingrese el Id del módulo a eliminar." };

            if (!int.TryParse(idText, out int id))
                return new OperationResult { Success = false, Message = "El Id debe ser un número." };

            if (snm.ModuloEnUso(id))
                return new OperationResult { Success = false, Message = "No se puede eliminar el módulo porque está siendo utilizado en una aplicación." };

            int filas = snm.EliminarModulo(id);
            bool ok = filas > 0;

            if (ok)
            {
                ctrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, 1, $"Eliminó el módulo: {nombreParaBitacora}", true);
                return new OperationResult { Success = true, Message = "Módulo eliminado correctamente." };
            }
            else
            {
                return new OperationResult { Success = false, Message = "Error al eliminar módulo." };
            }
        }

        public OperationResult BuscarModuloDesdeCombo(string seleccionado)
        {
            if (string.IsNullOrWhiteSpace(seleccionado))
                return new OperationResult { Success = false, Message = "Seleccione un módulo para buscar." };

            // Espera el formato "Id - Nombre"
            var partes = seleccionado.Split('-');
            if (partes.Length == 0 || !int.TryParse(partes[0].Trim(), out int id))
                return new OperationResult { Success = false, Message = "Formato de selección inválido." };

            var dr = snm.BuscarModuloPorId(id);
            if (dr == null)
                return new OperationResult { Success = false, Message = "Módulo no encontrado." };

            var dto = DataRowToDto(dr);

            return new OperationResult
            {
                Success = true,
                Message = "Módulo encontrado.",
                Modulo = dto
            };
        }

        // --------- Utilitario ---------
        private static ModuloDTO DataRowToDto(DataRow dr)
        {
            return new ModuloDTO
            {
                Pk_Id_Modulo = Convert.ToInt32(dr["Pk_Id_Modulo"]),
                Cmp_Nombre_Modulo = Convert.ToString(dr["Cmp_Nombre_Modulo"]),
                Cmp_Descripcion_Modulo = Convert.ToString(dr["Cmp_Descripcion_Modulo"]),
                Cmp_Estado_Modulo = Convert.ToByte(Convert.ToBoolean(dr["Cmp_Estado_Modulo"]) ? 1 : 0)
            };
        }
    }
}
