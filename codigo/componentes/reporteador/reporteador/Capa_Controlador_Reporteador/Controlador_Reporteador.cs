using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Paula Leoanardo
using Capa_Modelo_Reporteador; //Paula Leonardo

namespace Capa_Controlador_Reporteador
{
 //Clase Publica
    public class Controlador_Reporteador
    {
        // Inicio de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025
        Sentencias_Reporteador sentencias = new Sentencias_Reporteador();

        public void GuardarReporte(string titulo, String ruta, DateTime fecha)
        {
            sentencias.InsertarReporte(titulo, ruta, fecha);
        }

        public void ModificarRuta(int id, String nuevaruta)
        {
            sentencias.ModificarRuta(id, nuevaruta);
        }
        // fin de código de: Paula Leonardo con carné: 0901-22-9580 en la fecha de: 11/09/2025

        // Inicio de código de Anderson Trigueros con carné: 0901-22-6961 en la fecha de 23/09/2025
        public void ModificarTitulo(int id, String tituloNuevo)
        {
            sentencias.ModificarTitulo(id, tituloNuevo);
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025

        //inicio de codigo Sergio Izeppi, Carne: 0901-22-8946 en la fecha 11/09/2025
        public void EliminarReporte(int id)
        {
            sentencias.EliminarReporte(id);
        }

        public DataTable ObtenerReportes()
        {
            return sentencias.ObtenerReporte();
        }
        //fin codigo Sergio

        //inicio codigo Sergio Izeppi 0901-22-8946 en la fecha 16/09/2025
        public int verificartitulo(string titulo)
        {
            int iResultado = sentencias.verificarExistencia(titulo);
            return iResultado;
        }
        //fin codigo Sergio
    }
}
