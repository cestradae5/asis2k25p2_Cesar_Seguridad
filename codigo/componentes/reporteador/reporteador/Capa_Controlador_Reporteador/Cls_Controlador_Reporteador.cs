using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Barbara Saldaña --> 26/09/2025
using System.Data; //Paula Leonardo
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using Capa_Modelo_Reporteador;
using System.IO;
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
        public void ModificarRuta(int id, string sNuevaRuta)
        {
            sentencias.ModificarRuta(id, sNuevaRuta);
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
        // ==========================
        // Métodos de Crystal Reports
        // ==========================

        // Inicio de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha: 13/10/2025
        public ReportDocument CargarReporte(string ruta)
        {
            try
            {
                if (!File.Exists(ruta))
                    throw new FileNotFoundException("El archivo del reporte no existe: " + ruta);

                // Crear el documento Crystal Report
                ReportDocument reporte = new ReportDocument();
                reporte.Load(ruta);

                // Obtener la configuración de conexión del modelo
                Cls_ConexionCrystal conexion = new Cls_ConexionCrystal();
                ConnectionInfo connectionInfo = conexion.ObtenerConexionCrystal();

                // Aplicar la conexión
                AplicarConexionCrystal(reporte, connectionInfo);

                return reporte;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el reporte: " + ex.Message);
            }
        }

        // ================================================================
        // MÉTODO PRIVADO: Aplica la conexión a todas las tablas del reporte
        // ================================================================
        private void AplicarConexionCrystal(ReportDocument reporte, ConnectionInfo connection)
        {
            try
            {
                // Conectar tablas del reporte principal
                foreach (CrystalDecisions.CrystalReports.Engine.Table tabla in reporte.Database.Tables)
                {
                    TableLogOnInfo logon = tabla.LogOnInfo;
                    logon.ConnectionInfo = connection;
                    tabla.ApplyLogOnInfo(logon);
                }

                // Conectar tablas de subreportes (si existen)
                foreach (ReportDocument subreporte in reporte.Subreports)
                {
                    foreach (CrystalDecisions.CrystalReports.Engine.Table tabla in subreporte.Database.Tables)
                    {
                        TableLogOnInfo logon = tabla.LogOnInfo;
                        logon.ConnectionInfo = connection;
                        tabla.ApplyLogOnInfo(logon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al aplicar la conexión Crystal: " + ex.Message);
            }
        }

        // Fin de código de: Gerber Asturias con carné: 0901-22-11992 en la fecha: 13/10/2025

    }
}

