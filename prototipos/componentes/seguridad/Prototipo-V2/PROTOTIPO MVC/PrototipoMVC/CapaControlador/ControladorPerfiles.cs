using System;
using System.Data;
using CapaModelo;

namespace CapaControlador
{
    /* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 * */
    public class ControladorPerfiles
    {
        SentenciasPerfiles snp = new SentenciasPerfiles();

        // Métodos para Combo inteligente
        public string[] ItemsPerfiles()
        {
            return snp.LlenarComboPerfiles();
        }

        public string[] ItemsTipos()
        {
            return snp.LlenarComboTipos();
        }

        // Métodos originales (si necesitas DataTable)
        public DataTable ObtenerPerfiles()
        {
            return snp.ObtenerPerfiles();
        }

        public DataTable ObtenerTipos()
        {
            return snp.ObtenerTipos();
        }



        // Buscar perfil por ID
        public DataRow BuscarPerfil(int idPerfil)
        {
            return snp.BuscarPerfilPorId(idPerfil); // ya devuelve DataRow
        }

        // Insertar nuevo perfil
        public bool InsertarPerfil(int id, string puesto, string descripcion, bool habilitado, bool inabilitado, int tipo)
        {
            int filas = snp.InsertarPerfil(id, puesto, descripcion, habilitado, inabilitado, tipo);
            return filas > 0;
        }

        // Modificar perfil existente
        public bool ModificarPerfil(int id, string puesto, string descripcion, bool habilitado, bool inabilitado, int tipo)
        {
            int filas = snp.ModificarPerfil(id, puesto, descripcion, habilitado, inabilitado, tipo);
            return filas > 0;
        }
    }
}
