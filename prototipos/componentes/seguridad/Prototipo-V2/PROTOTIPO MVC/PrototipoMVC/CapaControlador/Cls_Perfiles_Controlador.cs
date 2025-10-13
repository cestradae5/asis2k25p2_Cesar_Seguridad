using System;
using System.Collections.Generic;
using Capa_Modelo_Seguridad;
//Brandon Hernandez 0901-22-9663
namespace Capa_Controlador_Seguridad
{
    public class Cls_Perfiles_Controlador
    {
        private Cls_PerfilesDAO daoPerfil = new Cls_PerfilesDAO();

        // Obtener todos los perfiles
        public List<Cls_Perfiles> listObtenerTodosLosPerfiles()
        {
            return daoPerfil.lisObtenerPerfiles();
        }

        // Insertar un nuevo perfil
        public bool bInsertarPerfil(string sPuesto, string sDescripcion, bool bEstado, int iTipo)
        {
            Cls_Perfiles nuevoPerfil = new Cls_Perfiles
            {
                sCmp_Puesto_Perfil = sPuesto,
                sCmp_Descripcion_Perfil = sDescripcion,
                bCmp_Estado_Perfil = bEstado,
                iCmp_Tipo_Perfil = iTipo
            };

            return daoPerfil.bInsertarPerfil(nuevoPerfil);
        }

        // Actualizar un perfil existente
        public bool bActualizarPerfil(int iIdPerfil, string sPuesto, string sDescripcion, bool bEstado, int iTipo)
        {
            Cls_Perfiles perfilActualizado = new Cls_Perfiles
            {
                iPk_Id_Perfil = iIdPerfil,
                sCmp_Puesto_Perfil = sPuesto,
                sCmp_Descripcion_Perfil = sDescripcion,
                bCmp_Estado_Perfil = bEstado,
                iCmp_Tipo_Perfil = iTipo
            };

            return daoPerfil.bActualizarPerfil(perfilActualizado);
        }

        // Eliminar perfil por ID
        public bool bBorrarPerfil(int iIdPerfil, out string sMensajeError)
        {
            // Declarar la variable out antes de llamar al método
            return daoPerfil.bEliminarPerfil(iIdPerfil, out sMensajeError);
        }
        // Buscar perfil por ID
        public Cls_Perfiles BuscarPerfilPorId(int iIdPerfil)
        {
            return daoPerfil.ObtenerPerfilPorId(iIdPerfil);
        }
    }
}