using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Capa_Modelo_Componente_Consultas
{
    // Nelson José Godinez Mendez 0901-22-3550 22/09/2025
    public class Sentencias
    {
        private readonly string sDsn;
        private readonly string sDB;
        private readonly string sConexionSTR;
        private readonly string _filePathXml;

        public Sentencias(string dsn, string db)
        {
            if (dsn == null) throw new ArgumentNullException(nameof(dsn));
            if (db == null) throw new ArgumentNullException(nameof(db));

            sDsn = dsn;
            sDB = db;
            sConexionSTR = "DSN=" + sDsn + ";DATABASE=" + sDB + ";";
            _filePathXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "consultas.xml");
        }

        private OdbcConnection CreateConn()
        {
            return new OdbcConnection(sConexionSTR);
        }

        public DataTable EjecutarConsulta(string sql)
        {
            using (var cn = CreateConn())
            {
                using (var da = new OdbcDataAdapter(sql, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public List<string> ObtenerTablas()
        {
            string sql = "SELECT table_name FROM INFORMATION_SCHEMA.TABLES " +
                         "WHERE table_schema='" + sDB + "' ORDER BY table_name;";
            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cn.Open();
                var list = new List<string>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(r.GetString(0));
                }
                return list;
            }
        }

        public List<(string Name, string DataType)> ObtenerColumnasTipadas(string tabla)
        {
            string sql = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                         "WHERE TABLE_SCHEMA='" + sDB + "' AND TABLE_NAME='" + tabla + "' " +
                         "ORDER BY ORDINAL_POSITION;";
            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cn.Open();
                var list = new List<(string, string)>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add((r.GetString(0), r.GetString(1)));
                }
                return list;
            }
        }

        public List<string> ObtenerColumnas(string tabla)
        {
            var tipadas = ObtenerColumnasTipadas(tabla);
            var res = new List<string>(tipadas.Count);
            foreach (var t in tipadas) res.Add(t.Name);
            return res;
        }
        // ----------------------------------------------------------------------------------------- //

        // -------- Persistencias de consultas Realizado por: Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025

        private XDocument LoadXml()
        {
            if (!File.Exists(_filePathXml))
            {
                var docNew = new XDocument(new XElement("consultas"));
                docNew.Save(_filePathXml);
            }
            return XDocument.Load(_filePathXml);
        }

        public List<KeyValuePair<string, string>> ListarConsultasPlano()
        {
            var doc = LoadXml();
            var root = doc.Root ?? new XElement("consultas");
            return root.Elements("consulta")
                       .Select(x => new KeyValuePair<string, string>(
                           (string)x.Attribute("name") ?? "",
                           (string)x.Element("sql") ?? ""))
                       .ToList();
        }

        public void GuardarConsulta(string name, string sql)
        {
            var doc = LoadXml();
            var root = doc.Root ?? new XElement("consultas");

            var existing = root.Elements("consulta")
                               .FirstOrDefault(x => (string)x.Attribute("name") == name);
            if (existing != null) existing.Remove();

            root.Add(new XElement("consulta",
                        new XAttribute("name", name),
                        new XElement("sql", sql)));
            doc.Save(_filePathXml);
        }

        public bool EliminarConsulta(string name)
        {
            var doc = LoadXml();
            var root = doc.Root;
            if (root == null) return false;

            var el = root.Elements("consulta")
                         .FirstOrDefault(x => (string)x.Attribute("name") == name);
            if (el == null) return false;

            el.Remove();
            doc.Save(_filePathXml);
            return true;
        }
    }
}
