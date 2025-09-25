using System.Data;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_ModulosControlador
    {
        Cls_Modulo_Sentencias snm = new Cls_Modulo_Sentencias();

        public string[] ItemsModulos()
        {
            return snm.LlenarComboModulos();
        }

        public DataTable ObtenerModulos()
        {
            return snm.ObtenerModulos();
        }

        public DataRow BuscarModulo(int idModulo)
        {
            return snm.BuscarModuloPorId(idModulo);
        }

        public bool EliminarModulo(int id)
        {
            int filas = snm.EliminarModulo(id);
            return filas > 0;
        }

        public bool InsertarModulo(int id, string nombre, string descripcion, byte estado)
        {
            int filas = snm.InsertarModulo(id, nombre, descripcion, estado);
            return filas > 0;
        }

        public bool ModificarModulo(int id, string nombre, string descripcion, byte estado)
        {
            int filas = snm.ModificarModulo(id, nombre, descripcion, estado);
            return filas > 0;
        }

        public bool ModuloEnUso(int id)
        {
            return snm.ModuloEnUso(id);
        }

    }
}
