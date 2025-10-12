//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_BitacoraControlador
    {
        private readonly Cls_SentenciasBitacora ctrlSentencias = new Cls_SentenciasBitacora();

        //Consultas
        public DataTable MostrarBitacora() => ctrlSentencias.Listar();
        public DataTable BuscarPorFecha(DateTime fecha) => ctrlSentencias.ConsultarPorFecha(fecha);
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin) => ctrlSentencias.ConsultarPorRango(inicio, fin);
        public DataTable BuscarPorUsuario(int iIdUsuario) => ctrlSentencias.ConsultarPorUsuario(iIdUsuario);
        public DataTable ObtenerUsuarios() => ctrlSentencias.ObtenerUsuarios();

        //Registros
        public void RegistrarAccion(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstado)
        {
            ctrlSentencias.InsertarBitacora(iIdUsuario, iIdAplicacion, sAccion, bEstado);
        }

        public void RegistrarInicioSesion(int iIdUsuario)
        {
            Cls_UsuarioConectado.IniciarSesion(iIdUsuario, "UsuarioActual", Cls_UsuarioConectado.iIdPerfil);
            ctrlSentencias.RegistrarInicioSesion(iIdUsuario, 0);
        }

        public void RegistrarCierreSesion(int iIdUsuario)
        {
            ctrlSentencias.RegistrarCierreSesion(iIdUsuario, 0);
            Cls_UsuarioConectado.CerrarSesion();
        }

        //Datos generales de bitácora (para exportar o imprimir desde Vista)
        public DataTable ObtenerBitacora()
        {
            return ctrlSentencias.Listar();
        }
    }
}
