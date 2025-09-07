using System.Data;
using CapaModelo;

namespace CapaControlador
{
    public class Controlador
    {
        private readonly Sentencias sn = new Sentencias();

        // Genérico: llena una tabla por nombre
        public DataTable llenarTbl(string tabla)
        {
            var da = sn.llenarTbl(tabla);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Específico: obtiene la bitácora con joins
        public DataTable ObtenerBitacora()
        {
            return sn.ObtenerBitacora();
        }
    }
}
