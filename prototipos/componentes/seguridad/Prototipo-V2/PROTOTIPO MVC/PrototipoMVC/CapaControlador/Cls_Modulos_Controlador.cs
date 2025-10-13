using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_Modulos_Controlador
    {
        Cls_Modulo_Sentencias snm = new Cls_Modulo_Sentencias();

        public string[] ItemsModulos()
        {
            return snm.fun_LlenarComboModulos();
        }
        // Retorna toda la información de los módulos de la base de datos
        public DataTable ObtenerModulos()
        {
            return snm.Fun_ObtenerModulos();
        }
        // Método para buscar un módulo específico por su Id
        public DataRow BuscarModulo(int iPk_Id_Modulo)
        {
            return snm.BuscarModuloPorId(iPk_Id_Modulo);
        }
        // Método para eliminar un módulo por su Id
        public bool EliminarModulo(int iPk_Id_Modulo)
        {
            int filas = snm.EliminarModulo(iPk_Id_Modulo);
            return filas > 0;
        }
        // Método para insertar un nuevo módulo en la base de datos
        public bool InsertarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            int filas = snm.InsertarModulo(iPk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            return filas > 0;
        }
        // Método para modificar un módulo existente
        public bool ModificarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            int filas = snm.ModificarModulo(iPk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            return filas > 0;
        }
        // Método que verifica si un módulo está siendo utilizado
        public bool ModuloEnUso(int iPk_Id_Modulo)
        {
            return snm.ModuloEnUso(iPk_Id_Modulo);
        }

    }
}
