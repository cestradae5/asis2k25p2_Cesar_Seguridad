using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Paula Leonardo
using Capa_Modelo_Reporteador; //Paula Leonardo

namespace Capa_Controlador_Reporteador
{
    //Clase Publica
    public class Cls_Controlador_Reporteador
    {
        // ==========================
        // Variables globales
        // ==========================

        // Inicio de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025
        Cls_Sentencias_Reporteador sentencias = new Cls_Sentencias_Reporteador();
        // fin de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025


        // ==========================
        // Métodos de creación
        // ==========================

        // Inicio de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025
        public void GuardarReporte(string sTitulo, String sRuta, DateTime dFecha)
        {
            sentencias.InsertarReporte(sTitulo, sRuta, dFecha);
        }
        // fin de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025


        // ==========================
        // Métodos de modificación
        // ==========================

        // Inicio de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025
        public void ModificarRuta(int id, String sNuevaruta)
        {
            sentencias.ModificarRuta(id, sNuevaruta);
        }
        // fin de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de 23/09/2025
        public void ModificarTitulo(int id, String sTituloNuevo)
        {
            sentencias.ModificarTitulo(id, sTituloNuevo);
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025


        // ==========================
        // Métodos de eliminación
        // ==========================

        //inicio de codigo Sergio Izeppi, Carne: 0901-22-8946 en la fecha 11/09/2025
        public void EliminarReporte(int id)
        {
            sentencias.EliminarReporte(id);
        }
        //fin codigo Sergio


        // ==========================
        // Métodos de consulta
        // ==========================

        //inicio de codigo Sergio Izeppi, Carne: 0901-22-8946 en la fecha 11/09/2025
        public DataTable ObtenerReportes()
        {
            return sentencias.ObtenerReporte();
        }
        //fin codigo Sergio

        //inicio codigo Sergio Izeppi 0901-22-8946 en la fecha 16/09/2025
        public int verificartitulo(string sTitulo)
        {
            int iResultado = sentencias.verificarExistencia(sTitulo);
            return iResultado;
        }
        //fin codigo Sergio


        // ==========================
        // Métodos de aplicación
        // ==========================
        // Inicio de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 24/09/2025
        public string ConsultarReporteAplicacion(int idAplicacion)
        {
            return sentencias.consultaReporteAplicacion(idAplicacion);
        }
        // Fin de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 24/09/2025
    }
}

