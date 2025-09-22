using System;
using System.Collections.Generic;
using CapaModelo;
//Brandon Hernandez 0901-22-9663
namespace CapaControlador
{
    public class Cls_PerfilesControlador
    {
        private Cls_PerfilesDAO daoPerfil = new Cls_PerfilesDAO();

        // Obtener todos los perfiles
        public List<Cls_Perfiles> listObtenerTodosLosPerfiles()
        {
            return daoPerfil.lisObtenerPerfiles();
        }

        // Insertar un nuevo perfil
        public bool bInsertarPerfil(string puesto, string descripcion, bool estado, int tipo)
        {
            Cls_Perfiles nuevoPerfil = new Cls_Perfiles
            {
                Cmp_Puesto_Perfil = puesto,
                Cmp_Descripcion_Perfil = descripcion,
                Cmp_Estado_Perfil = estado,
                Cmp_Tipo_Perfil = tipo
            };

            return daoPerfil.bInsertarPerfil(nuevoPerfil);
        }

        // Actualizar un perfil existente
        public bool bActualizarPerfil(int idPerfil, string puesto, string descripcion, bool estado, int tipo)
        {
            Cls_Perfiles perfilActualizado = new Cls_Perfiles
            {
                Pk_Id_Perfil = idPerfil,
                Cmp_Puesto_Perfil = puesto,
                Cmp_Descripcion_Perfil = descripcion,
                Cmp_Estado_Perfil = estado,
                Cmp_Tipo_Perfil = tipo
            };

            return daoPerfil.bActualizarPerfil(perfilActualizado);
        }

        // Eliminar perfil por ID
        public bool bBorrarPerfil(int idPerfil)
        {
            return daoPerfil.bEliminarPerfil(idPerfil);
        }

        // Buscar perfil por ID
        public Cls_Perfiles BuscarPerfilPorId(int idPerfil)
        {
            return daoPerfil.ObtenerPerfilPorId(idPerfil);
        }
    }
}