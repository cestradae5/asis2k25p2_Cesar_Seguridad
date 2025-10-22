using System;
using System.Collections.Generic;

//Brandon Hernandez 0901-22-9663
namespace Capa_Controlador_Seguridad
{
    // DTO para la vista
    public class PerfilDTO
    {
        public int Id { get; set; }
        public string Puesto { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Tipo { get; set; }
    }

    public class Cls_Perfiles_Controlador
    {
        private Capa_Modelo_Seguridad.Cls_PerfilesDAO daoPerfil = new Capa_Modelo_Seguridad.Cls_PerfilesDAO();

        // Obtener todos los perfiles como DTO
        public List<PerfilDTO> listObtenerTodosLosPerfiles()
        {
            var perfilesModelo = daoPerfil.lisObtenerPerfiles();
            var listaDTO = new List<PerfilDTO>();
            foreach (var modelo in perfilesModelo)
            {
                listaDTO.Add(new PerfilDTO
                {
                    Id = modelo.iPk_Id_Perfil,
                    Puesto = modelo.sCmp_Puesto_Perfil,
                    Descripcion = modelo.sCmp_Descripcion_Perfil,
                    Estado = modelo.bCmp_Estado_Perfil,
                    Tipo = modelo.iCmp_Tipo_Perfil
                });
            }
            return listaDTO;
        }

        // Validación de datos de perfil
        public bool ValidarPerfil(string sPuesto, string sDescripcion, int iTipo, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(sPuesto) || string.IsNullOrWhiteSpace(sDescripcion))
            {
                mensaje = "Complete todos los campos antes de continuar.";
                return false;
            }
            if (iTipo == -1)
            {
                mensaje = "Seleccione un tipo de perfil válido.";
                return false;
            }
            mensaje = "";
            return true;
        }

        // Insertar un nuevo perfil con validación
        public bool bInsertarPerfil(string sPuesto, string sDescripcion, bool bEstado, int iTipo, out string mensaje)
        {
            if (!ValidarPerfil(sPuesto, sDescripcion, iTipo, out mensaje))
                return false;

            var nuevoPerfil = new Capa_Modelo_Seguridad.Cls_Perfiles
            {
                sCmp_Puesto_Perfil = sPuesto,
                sCmp_Descripcion_Perfil = sDescripcion,
                bCmp_Estado_Perfil = bEstado,
                iCmp_Tipo_Perfil = iTipo
            };

            bool exito = daoPerfil.bInsertarPerfil(nuevoPerfil);
            if (!exito)
                mensaje = "Error al guardar perfil en la base de datos.";
            return exito;
        }

        // Actualizar un perfil existente con validación
        public bool bActualizarPerfil(int iIdPerfil, string sPuesto, string sDescripcion, bool bEstado, int iTipo, out string mensaje)
        {
            if (iIdPerfil <= 0)
            {
                mensaje = "El ID del perfil no es válido.";
                return false;
            }
            if (!ValidarPerfil(sPuesto, sDescripcion, iTipo, out mensaje))
                return false;

            var perfilActualizado = new Capa_Modelo_Seguridad.Cls_Perfiles
            {
                iPk_Id_Perfil = iIdPerfil,
                sCmp_Puesto_Perfil = sPuesto,
                sCmp_Descripcion_Perfil = sDescripcion,
                bCmp_Estado_Perfil = bEstado,
                iCmp_Tipo_Perfil = iTipo
            };

            bool exito = daoPerfil.bActualizarPerfil(perfilActualizado);
            if (!exito)
                mensaje = "Error al modificar perfil en la base de datos.";
            return exito;
        }

        // Eliminar perfil por ID
        public bool bBorrarPerfil(int iIdPerfil, out string sMensajeError)
        {
            return daoPerfil.bEliminarPerfil(iIdPerfil, out sMensajeError);
        }

        // Buscar perfil por ID y devolver DTO
        public PerfilDTO BuscarPerfilPorId(int iIdPerfil)
        {
            var perfil = daoPerfil.ObtenerPerfilPorId(iIdPerfil);
            if (perfil == null) return null;
            return new PerfilDTO
            {
                Id = perfil.iPk_Id_Perfil,
                Puesto = perfil.sCmp_Puesto_Perfil,
                Descripcion = perfil.sCmp_Descripcion_Perfil,
                Estado = perfil.bCmp_Estado_Perfil,
                Tipo = perfil.iCmp_Tipo_Perfil
            };
        }
    }
}
