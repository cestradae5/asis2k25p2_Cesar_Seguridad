//Inicio de código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025

using System;
using System.Collections.Generic;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    // Clase para registrar cambios de permisos en la bitácora
    public class Cls_Registrar_Permisos_Bitacora
    {
        // Instancias para insertar y consultar bitácora
        private readonly Cls_Sentencias_Bitacora gBitacora = new Cls_Sentencias_Bitacora();
        private readonly Cls_Consulta_Asignaciones_Bitacora consultaBitacora = new Cls_Consulta_Asignaciones_Bitacora();

        // Usuarios
        public void fun_CompararYRegistrar(
            int iIdUsuarioAccion,
            int iIdUsuario,
            int iIdModulo,
            int iIdAplicacion,
            string sNombreUsuario,
            string sNombreAplicacion,
            Cls_Permisos gPermisosActuales)
        {
            // Consultar permisos anteriores del usuario
            Cls_Permisos gPermisosAnteriores = consultaBitacora.fun_ConsultarPermisosAsignados(
                iIdUsuario, iIdModulo, iIdAplicacion);

            // Comparar y registrar cambios
            fun_RegistrarCambiosPermisos(
                "usuario",
                iIdUsuarioAccion,
                iIdAplicacion,
                sNombreUsuario,
                sNombreAplicacion,
                gPermisosAnteriores,
                gPermisosActuales);
        }

        //  Perfiles
        public void fun_CompararYRegistrarPerfil(
            int iIdUsuarioAccion,
            int iIdPerfil,
            int iIdModulo,
            int iIdAplicacion,
            string sNombrePerfil,
            string sNombreAplicacion,
            Cls_Permisos gPermisosActuales)
        {
            // Consultar permisos anteriores del perfil
            Cls_Permisos gPermisosAnteriores = consultaBitacora.fun_ConsultarPermisosPerfil(
                iIdPerfil, iIdModulo, iIdAplicacion);

            // Comparar y registrar cambios
            fun_RegistrarCambiosPermisos(
                "perfil",
                iIdUsuarioAccion,
                iIdAplicacion,
                sNombrePerfil,
                sNombreAplicacion,
                gPermisosAnteriores,
                gPermisosActuales);
        }

        // Registar los cambios de los permisos
        private void fun_RegistrarCambiosPermisos(
            string tipoEntidad,
            int iIdUsuarioAccion,
            int iIdAplicacion,
            string sNombreEntidad,
            string sNombreAplicacion,
            Cls_Permisos gPermisos_Anteriores,
            Cls_Permisos gPermisos_Actuales)
        {
            List<string> lstAgregados = new List<string>();
            List<string> lstRemovidos = new List<string>();

            // Comparar cada permiso
            if (gPermisos_Anteriores.bIngresar != gPermisos_Actuales.bIngresar)
                (gPermisos_Actuales.bIngresar ? lstAgregados : lstRemovidos).Add("Ingresar");

            if (gPermisos_Anteriores.bConsultar != gPermisos_Actuales.bConsultar)
                (gPermisos_Actuales.bConsultar ? lstAgregados : lstRemovidos).Add("Consultar");

            if (gPermisos_Anteriores.bModificar != gPermisos_Actuales.bModificar)
                (gPermisos_Actuales.bModificar ? lstAgregados : lstRemovidos).Add("Modificar");

            if (gPermisos_Anteriores.bEliminar != gPermisos_Actuales.bEliminar)
                (gPermisos_Actuales.bEliminar ? lstAgregados : lstRemovidos).Add("Eliminar");

            if (gPermisos_Anteriores.bImprimir != gPermisos_Actuales.bImprimir)
                (gPermisos_Actuales.bImprimir ? lstAgregados : lstRemovidos).Add("Imprimir");

            // Evita registros innecesarios
            if (lstAgregados.Count == 0 && lstRemovidos.Count == 0)
                return; // No registrar si no hubo cambios reales

            // Registrar permisos agregados
            if (lstAgregados.Count > 0)
            {
                string sMensaje = $"Al {tipoEntidad} '{sNombreEntidad}' se le asignaron permisos en la aplicación '{sNombreAplicacion}': {string.Join(", ", lstAgregados)}";
                sMensaje = sMensaje.Replace("'", "''");
                gBitacora.InsertarBitacora(iIdUsuarioAccion, iIdAplicacion, sMensaje, true);
            }

            // Registrar permisos removidos
            if (lstRemovidos.Count > 0)
            {
                string sMensaje = $"Al {tipoEntidad} '{sNombreEntidad}' se le removieron permisos en la aplicación '{sNombreAplicacion}': {string.Join(", ", lstRemovidos)}";
                sMensaje = sMensaje.Replace("'", "''");
                gBitacora.InsertarBitacora(iIdUsuarioAccion, iIdAplicacion, sMensaje, true);
            }
        }
        public void fun_CompararYRegistrarPerfilManual(
            int iIdUsuarioAccion,
            int iIdAplicacion,
            string sNombrePerfil,
            string sNombreAplicacion,
            Cls_Permisos gPermisosAnteriores,
            Cls_Permisos gPermisosActuales)
        {
            fun_RegistrarCambiosPermisos("perfil", iIdUsuarioAccion, iIdAplicacion,
                                         sNombrePerfil, sNombreAplicacion,
                                         gPermisosAnteriores, gPermisosActuales);
        }

        //Permisos de los perfiles

        // Método puente para que la vista no use el modelo
        public void fun_CompararYRegistrarPerfilManual_Puente(
            int iIdUsuarioAccion,
            int iIdAplicacion,
            string sNombrePerfil,
            string sNombreAplicacion,
            bool bIngresar,
            bool bConsultar,
            bool bModificar,
            bool bEliminar,
            bool bImprimir)
        {
            // Crear los objetos Cls_Permisos dentro del controlador
            Cls_Permisos gPermisosAnteriores = new Cls_Permisos(); // Permisos por defecto
            try
            {
                // Si tienes ID de perfil o aplicación, podrías usar otra consulta
                // Aquí lo dejamos vacío o puedes agregar lógica extra si lo deseas
            }
            catch (Exception)
            {
                // Si no se pueden obtener permisos anteriores, continúa con los nuevos
            }

            // Crear los permisos actuales con los datos enviados por la vista
            Cls_Permisos gPermisosActuales = new Cls_Permisos
            {
                bIngresar = bIngresar,
                bConsultar = bConsultar,
                bModificar = bModificar,
                bEliminar = bEliminar,
                bImprimir = bImprimir
            };

            // Reusar el método existente (ya implementado)
            fun_CompararYRegistrarPerfilManual(
                iIdUsuarioAccion,
                iIdAplicacion,
                sNombrePerfil,
                sNombreAplicacion,
                gPermisosAnteriores,
                gPermisosActuales
            );
        }







    }
}

//Fin del código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025
