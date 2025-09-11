using System;
using System.Collections.Generic;
using CapaModelo;

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
                puesto_perfil = puesto,
                descripcion_perfil = descripcion,
                estado_perfil = estado,
                tipo_perfil = tipo
            };

            return daoPerfil.bInsertarPerfil(nuevoPerfil);
        }

        // Actualizar un perfil existente
        public bool bActualizarPerfil(int idPerfil, string puesto, string descripcion, bool estado, int tipo)
        {
            Cls_Perfiles perfilActualizado = new Cls_Perfiles
            {
                pk_id_perfil = idPerfil,
                puesto_perfil = puesto,
                descripcion_perfil = descripcion,
                estado_perfil = estado,
                tipo_perfil = tipo
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