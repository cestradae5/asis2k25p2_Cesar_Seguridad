using System.Data;
using Capa_Modelo_Seguridad;
// Nombre: Danilo Mazariegos Codigo:0901-19-25059
namespace Capa_Controlador_Seguridad
{
    public class Cls_Modulos_Controlador
    {
        private readonly Cls_Modulo_Sentencias snm = new Cls_Modulo_Sentencias();

        // Retorna la lista de módulos en formato "Id - Nombre"
        public string[] ItemsModulos()
        {
            return snm.fun_LlenarComboModulos();
        }

        // Retorna toda la información de los módulos de la base de datos
        public DataTable ObtenerModulos()
        {
            return snm.Fun_ObtenerModulos();
        }

        // Busca un módulo por Id
        public DataRow BuscarModulo(int iPk_Id_Modulo)
        {
            return snm.BuscarModuloPorId(iPk_Id_Modulo);
        }

        // Elimina un módulo por Id
        public bool EliminarModulo(int iPk_Id_Modulo)
        {
            int filas = snm.EliminarModulo(iPk_Id_Modulo);
            return filas > 0;
        }

        // Inserta un nuevo módulo
        public bool InsertarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            int filas = snm.InsertarModulo(iPk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            return filas > 0;
        }

        // Modifica un módulo existente
        public bool ModificarModulo(int iPk_Id_Modulo, string sCmp_Nombre_Modulo, string sCmp_Descripcion_Modulo, byte btCmp_Estado_Modulo)
        {
            int filas = snm.ModificarModulo(iPk_Id_Modulo, sCmp_Nombre_Modulo, sCmp_Descripcion_Modulo, btCmp_Estado_Modulo);
            return filas > 0;
        }

        // Verifica si el módulo está siendo usado en asignaciones
        public bool ModuloEnUso(int iPk_Id_Modulo)
        {
            return snm.ModuloEnUso(iPk_Id_Modulo);
        }
    }
}
