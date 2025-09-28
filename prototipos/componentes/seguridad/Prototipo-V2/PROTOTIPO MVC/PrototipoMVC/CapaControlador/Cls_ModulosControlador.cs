using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_ModulosControlador
    {
        Cls_Modulo_Sentencias snm = new Cls_Modulo_Sentencias();

        public string[] ItemsModulos()
        {
            return snm.LlenarComboModulos();
        }
        // Retorna toda la información de los módulos de la base de datos
        public DataTable ObtenerModulos()
        {
            return snm.ObtenerModulos();
        }
        // Método para buscar un módulo específico por su Id
        public DataRow BuscarModulo(int Pk_Id_Modulo)
        {
            return snm.BuscarModuloPorId(Pk_Id_Modulo);
        }
        // Método para eliminar un módulo por su Id
        public bool EliminarModulo(int Pk_Id_Modulo)
        {
            int filas = snm.EliminarModulo(Pk_Id_Modulo);
            return filas > 0;
        }
        // Método para insertar un nuevo módulo en la base de datos
        public bool InsertarModulo(int Pk_Id_Modulo, string Cmp_Nombre_Modulo, string Cmp_Descripcion_Modulo, byte Cmp_Estado_Modulo)
        {
            int filas = snm.InsertarModulo(Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo);
            return filas > 0;
        }
        // Método para modificar un módulo existente
        public bool ModificarModulo(int Pk_Id_Modulo, string Cmp_Nombre_Modulo, string Cmp_Descripcion_Modulo, byte Cmp_Estado_Modulo)
        {
            int filas = snm.ModificarModulo(Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo);
            return filas > 0;
        }
        // Método que verifica si un módulo está siendo utilizado
        public bool ModuloEnUso(int Pk_Id_Modulo)
        {
            return snm.ModuloEnUso(Pk_Id_Modulo);
        }

    }
}
