using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;                   
using System.Text.RegularExpressions; 
using Capa_Modelo_Componente_Consultas;

namespace Capa_Controlador_Consultas
{
    //Juan Carlos Sandoval Quej 0901-22-4170 22/09/2025
    public class Controlador : IDisposable
    {
        private readonly string _dsn;
        private readonly string _db;
        private readonly string _filePathXml;

        private readonly object _ioLock = new object();


        public Controlador(string dsn, string db)
        {
            if (string.IsNullOrWhiteSpace(dsn)) throw new ArgumentException("dsn");
            if (string.IsNullOrWhiteSpace(db)) throw new ArgumentException("db");

            _dsn = dsn;
            _db = db;

            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "consultas");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            _filePathXml = Path.Combine(dir, "user_queries.xml");
            if (!File.Exists(_filePathXml))
            {
                var doc = new XDocument(new XElement("consultas"));
                doc.Save(_filePathXml);
            }
        }
        //Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025
        private OdbcConnection GetConn()
        {
            // Se puede agregar más parámetros si DSN lo requiere
            return new OdbcConnection(string.Format("Dsn={0};Database={1}", _dsn, _db));
        }

        public bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (var cx = GetConn())
                {
                    cx.Open();
                }
                mensaje = "Conexión exitosa.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
        //Diego Fernando Saquil Gramajo 0901-22-4103 09/22/2025
        public IEnumerable<string> ObtenerTablas()
        {
            var tablas = new List<string>();
            using (var cx = GetConn())
            {
                cx.Open();
                using (var cmd = cx.CreateCommand())
                {
                    cmd.CommandText = "SHOW TABLES;";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            tablas.Add(Convert.ToString(rd[0]));
                    }
                }
            }
            return tablas;
        }

        public IEnumerable<string> ObtenerColumnas(string tabla)
        {
            var cols = new List<string>();
            if (string.IsNullOrEmpty(tabla)) return cols;

            using (var cx = GetConn())
            {
                cx.Open();
                using (var cmd = cx.CreateCommand())
                {
                    cmd.CommandText = $"SHOW COLUMNS FROM `{tabla}`;";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            cols.Add(Convert.ToString(rd["Field"]));
                    }
                }
            }
            return cols;
        }

        public DataTable EjecutarConsulta(string sql)
        {
            var dt = new DataTable();
            using (var cx = GetConn())
            using (var da = new OdbcDataAdapter(sql, cx))
            {
                da.Fill(dt);
            }
            return dt;
        }

        // ------- Persistencia XML ------- Juan Carlos SAndoval Quej 0901-22-4170 22/09/2025
        // <consultas><consulta name="..."><sql>...</sql></consulta></consultas>

        public IEnumerable<UserQuery> ListarConsultas()
        {
            lock (_ioLock)
            {
                var doc = XDocument.Load(_filePathXml);
                var root = doc.Root ?? new XElement("consultas");
                return root.Elements("consulta")
                           .Select(x => new UserQuery
                           {
                               Name = (string)x.Attribute("name") ?? "",
                               Sql = (string)(x.Element("sql") ?? new XElement("sql"))
                           })
                           .ToList();
            }
        }

        public void GuardarConsulta(UserQuery uq)
        {
            if (uq == null) throw new ArgumentNullException("uq");
            GuardarConsulta(uq.Name, uq.Sql);
        }

        public void GuardarConsulta(string name, string sql)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name");
            if (sql == null) sql = "";

            lock (_ioLock)
            {
                var doc = XDocument.Load(_filePathXml);
                var root = doc.Root ?? new XElement("consultas");

                var existente = root.Elements("consulta")
                                    .FirstOrDefault(x => (string)x.Attribute("name") == name);
                if (existente != null) existente.Remove();

                var nodo = new XElement("consulta",
                    new XAttribute("name", name),
                    new XElement("sql", sql)
                );

                root.Add(nodo);
                doc.Save(_filePathXml);
            }
        }

        public bool EditarConsulta(string name, string newName, string newSql)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name");
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("newName");
            if (newSql == null) newSql = "";

            lock (_ioLock)
            {
                var doc = XDocument.Load(_filePathXml);
                var root = doc.Root ?? new XElement("consultas");

                var existente = root.Elements("consulta")
                                    .FirstOrDefault(x => (string)x.Attribute("name") == name);
                if (existente == null) return false;

                existente.SetAttributeValue("name", newName);
                var sqlNode = existente.Element("sql");
                if (sqlNode == null) { sqlNode = new XElement("sql"); existente.Add(sqlNode); }
                sqlNode.Value = newSql;

                doc.Save(_filePathXml);
                return true;
            }
        }

        //Diego Fernando Saquil Gramajo 0901-22-4103 22/09/2025
        public bool EliminarConsulta(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            lock (_ioLock)
            {
                var doc = XDocument.Load(_filePathXml);
                var root = doc.Root ?? new XElement("consultas");

                var existente = root.Elements("consulta")
                                    .FirstOrDefault(x => (string)x.Attribute("name") == name);
                if (existente == null) return false;

                existente.Remove();
                doc.Save(_filePathXml);
                return true;
            }
        }


        /// Devuelve las consultas como KeyValuePair(nombre, sql) — útil para DataSource en la vista. Nelson Jose Godinez Mendez 0901-22-3550 22/09/2025
        public List<KeyValuePair<string, string>> ListarConsultasPlano()
        {
            var list = new List<KeyValuePair<string, string>>();

            // Usa tu método existente que lee del XML
            foreach (var uq in ListarConsultas())   // IEnumerable<UserQuery>
            {
                var name = uq.Name ?? "";
                var sql = uq.Sql ?? "";
                list.Add(new KeyValuePair<string, string>(name, sql));
            }
            return list;
        }


        /// Construye SQL desde el estado de la UI (listas de WHERE y GROUP/ORDER). Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025
        public string ConstruirSql(string tabla, bool incluirWhere, IList<string> partesWhere, IList<string> partesGroupOrder)
        {
            if (string.IsNullOrWhiteSpace(tabla))
                throw new ArgumentException("Selecciona una tabla.", nameof(tabla));

            var sb = new StringBuilder();
            sb.Append($"SELECT * FROM `{tabla}`");

            if (incluirWhere && partesWhere != null && partesWhere.Count > 0)
                sb.Append(" WHERE " + string.Join(" ", partesWhere));

            if (partesGroupOrder != null)
            {
                var group = partesGroupOrder.LastOrDefault(x => x.StartsWith("GROUP BY", StringComparison.OrdinalIgnoreCase));
                var order = partesGroupOrder.LastOrDefault(x => x.StartsWith("ORDER BY", StringComparison.OrdinalIgnoreCase));
                if (group != null) sb.Append(" " + group);
                if (order != null) sb.Append(" " + order);
            }

            sb.Append(";");
            return sb.ToString();
        }

      
        /// Reescribe SELECT * para castear TIME a CHAR y evitar el error ODBC. Diego Fernando Saquil Gramajo 0901-22-4103  22/09/2025
       
        public string ReescribirSelectSeguroSiHayTime(string baseDeDatos, string tabla, string sql)
        {
            if (string.IsNullOrEmpty(tabla) || string.IsNullOrEmpty(sql)) return sql;

            var prefix = $"SELECT * FROM `{tabla}`";
            if (!sql.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) return sql;

            var meta = EjecutarConsulta(
                "SELECT COLUMN_NAME, DATA_TYPE " +
                "FROM information_schema.columns " +
                $"WHERE table_schema = '{baseDeDatos}' AND table_name = '{tabla}' " +
                "ORDER BY ORDINAL_POSITION;");

            var cols = new List<string>();
            foreach (DataRow r in meta.Rows)
            {
                var name = Convert.ToString(r["COLUMN_NAME"]);
                var type = Convert.ToString(r["DATA_TYPE"])?.ToLowerInvariant();
                cols.Add(type == "time" ? $"CAST(`{name}` AS CHAR) AS `{name}`" : $"`{name}`");
            }
            var selectCols = cols.Count > 0 ? string.Join(", ", cols) : "*";
            return sql.Replace(prefix, $"SELECT {selectCols} FROM `{tabla}`");
        }

        
        /// Parser simple del WHERE → tuplas (Conector, Campo, Operador, Valor1, Valor2). Nelson Jose Godinez Mendez 0901-22-3550 22/09/2025
       
        public List<(string Conector, string Campo, string Operador, string Valor1, string Valor2)> ParsearWhere(string sql)
        {
            var list = new List<(string, string, string, string, string)>();
            if (string.IsNullOrWhiteSpace(sql)) return list;

            var mWhere = Regex.Match(sql, @"WHERE\s+(?<w>.+?)(GROUP\s+BY|ORDER\s+BY|;|$)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!mWhere.Success) return list;

            string where = mWhere.Groups["w"].Value.Trim();

            var condRx = new Regex(
                @"`(?<campo>[^`]+)`\s*(?<op>=|<>|>=|<=|>|<|LIKE)\s*(?<v1>'[^']*'|[0-9]+(?:\.[0-9]+)?)"
              + @"|`(?<campoB>[^`]+)`\s*BETWEEN\s*(?<b1>'[^']*'|[0-9]+(?:\.[0-9]+)?)\s*AND\s*(?<b2>'[^']*'|[0-9]+(?:\.[0-9]+)?)",
                RegexOptions.IgnoreCase);

            int prevEnd = 0;
            foreach (Match m in condRx.Matches(where))
            {
                // Conector AND/OR previo a la condición actual
                string connector = null;
                string betweenText = where.Substring(prevEnd, m.Index - prevEnd);
                var mConn = Regex.Match(betweenText, @"\b(AND|OR)\b", RegexOptions.IgnoreCase);
                if (mConn.Success) connector = mConn.Groups[1].Value.ToUpperInvariant();
                prevEnd = m.Index + m.Length;

                if (m.Groups["op"].Success)
                {
                    var campo = m.Groups["campo"].Value;
                    var op = m.Groups["op"].Value.ToUpperInvariant();
                    var v1 = m.Groups["v1"].Value;
                    list.Add((connector, campo, op, v1, null));
                }
                else
                {
                    var campo = m.Groups["campoB"].Value;
                    var v1 = m.Groups["b1"].Value;
                    var v2 = m.Groups["b2"].Value;
                    list.Add((connector, campo, "BETWEEN", v1, v2));
                }
            }
            return list;
        }

        public void Dispose() { }
    }

    //Nelson Jose Godinez Mendez 0901-22-3550 22/09/2025
    public sealed class UserQuery
    {
        public string Name { get; set; }
        public string Sql { get; set; }
        public override string ToString() => Name;
    }
}
