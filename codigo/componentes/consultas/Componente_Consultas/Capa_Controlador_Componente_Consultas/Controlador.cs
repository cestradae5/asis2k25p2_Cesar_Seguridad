using Capa_Modelo_Componente_Consultas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Capa_Controlador_Consultas
{
    //Juan Carlos Sandoval Quej 0901-22-4170 22/09/2025
    public class Controlador
    {
        // Referencia al modelo (clase Sentencias) que se encarga de hablar con la base de datos
        private readonly Sentencias _m;
        // Nombre de la base de datos con la que vamos a trabajar
        private readonly string _db;
        // Caché para guardar las columnas de cada tabla con su nombre y tipo de dato
        // Esto evita tener que consultar a la base de datos cada vez
        private readonly Dictionary<string, List<(string Name, string DataType)>> _colsCache =
        private readonly Dictionary<string, List<(string Name, string DataType)>> scolsCache =
            new Dictionary<string, List<(string Name, string DataType)>>(StringComparer.OrdinalIgnoreCase);

        // Constructor: recibe un DSN (nombre de la conexión ODBC) y el nombre de la base de datos
        public Controlador(string dsn, string db)
        {
            // Si no se pasa nombre de base de datos, lanza un error
            if (db == null) throw new ArgumentNullException(nameof(db));
            _db = db; // guarda el nombre de la BD
            _m = new Sentencias(dsn, db); // crea un objeto Sentencias con DSN y BD
        }

        public DataTable EjecutarConsulta(string sql) { return _m.EjecutarConsulta(sql); }
        public List<string> ObtenerTablas() { return _m.ObtenerTablas(); }
        public List<string> ObtenerColumnas(string tabla) { return _m.ObtenerColumnas(tabla); }
        public List<KeyValuePair<string, string>> ListarConsultasPlano() { return _m.ListarConsultasPlano(); }
        public void GuardarConsulta(string name, string sql) { _m.GuardarConsulta(name, sql); }
        public bool EliminarConsulta(string name) { return _m.EliminarConsulta(name); }

        public List<(string Name, string DataType)> ObtenerColumnasTipadas(string tabla)
        {
            List<(string, string)> list;
            if (!scolsCache.TryGetValue(tabla, out list))
            {
                list = _m.ObtenerColumnasTipadas(tabla);
                scolsCache[tabla] = list;
            }
            return list;
        }
        //Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025
        // Construcción SQL
        public string ConstruirSql(string tabla, bool addWhere, IList<string> whereParts, IList<string> groupOrderParts)
        {
            if (string.IsNullOrWhiteSpace(tabla)) return string.Empty;

            var sb = new StringBuilder();
            sb.Append("SELECT * FROM `").Append(tabla).Append('`');

            if (addWhere && whereParts != null && whereParts.Count > 0)
            {
                sb.Append(" WHERE ").Append(string.Join(" ", whereParts));
            }

            if (groupOrderParts != null && groupOrderParts.Count > 0)
            {
                string group = null;
                string order = null;
                for (int i = groupOrderParts.Count - 1; i >= 0; i--)
                {
                    var p = groupOrderParts[i];
                    if (group == null && p.StartsWith("GROUP BY", StringComparison.OrdinalIgnoreCase)) group = p;
                    if (order == null && p.StartsWith("ORDER BY", StringComparison.OrdinalIgnoreCase)) order = p;
                    if (group != null && order != null) break;
                }
                if (group != null) sb.Append(' ').Append(group);
                if (order != null) sb.Append(' ').Append(order);
            }

            sb.Append(';');
            return sb.ToString();
        }

        public string ReescribirSelectSeguroSiHayTime(string db, string tabla, string sql)
        {
            if (string.IsNullOrWhiteSpace(sql) || string.IsNullOrWhiteSpace(tabla)) return sql;

            var m = Regex.Match(sql, @"^\s*SELECT\s+\*\s+FROM\s+`?" + Regex.Escape(tabla) + @"`?",
                                RegexOptions.IgnoreCase);
            if (!m.Success) return sql;

            var cols = ObtenerColumnasTipadas(tabla);
            var sb = new StringBuilder();

            for (int i = 0; i < cols.Count; i++)
            {
                var c = cols[i];
                var type = (c.DataType ?? "").ToLowerInvariant();

                if (type.Contains("time"))
                    sb.Append("TIME_FORMAT(`").Append(c.Name).Append("`, '%H:%i:%s') AS `").Append(c.Name).Append('`');
                else if (type.Contains("date"))
                    sb.Append("DATE_FORMAT(`").Append(c.Name).Append("`, '%Y-%m-%d %H:%i:%s') AS `").Append(c.Name).Append('`');
                else
                    sb.Append('`').Append(c.Name).Append('`');

                if (i < cols.Count - 1) sb.Append(", ");
            }

            return Regex.Replace(sql, @"SELECT\s+\*\s+FROM",
                                 "SELECT " + sb.ToString() + " FROM",
                                 RegexOptions.IgnoreCase);
        }
        //Diego Fernando Saquil Gramajo 0901-22-4103 09/22/2025
        // Parser WHERE -> tuplas
        public IEnumerable<(string Conector, string Campo, string Operador, string Valor1, string Valor2)> ParsearWhere(string sql)
        {
            var res = new List<(string, string, string, string, string)>();
            var m = Regex.Match(sql, @"WHERE\s+(?<expr>.+?)(?:GROUP\s+BY|ORDER\s+BY|;|$)",
                                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!m.Success) return res;

            string expr = m.Groups["expr"].Value;

            var tokens = Regex.Split(expr, @"\s+(AND|OR)\s+", RegexOptions.IgnoreCase);
            string con = null;

            foreach (var raw in tokens)
            {
                var t = (raw ?? "").Trim();
                if (string.Equals(t, "AND", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(t, "OR", StringComparison.OrdinalIgnoreCase))
                {
                    con = t.ToUpperInvariant();
                    continue;
                }
                if (t.Length == 0) continue;

                var mb = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+BETWEEN\s+(?<v1>[^ ]+)\s+AND\s+(?<v2>[^ ]+)", RegexOptions.IgnoreCase);
                if (mb.Success)
                {
                    res.Add((con ?? "", mb.Groups["col"].Value, "BETWEEN",
                            mb.Groups["v1"].Value, mb.Groups["v2"].Value));
                    con = "AND";
                    continue;
                }

                var mnull = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+(IS\s+NOT\s+NULL|IS\s+NULL)", RegexOptions.IgnoreCase);
                if (mnull.Success)
                {
                    res.Add((con ?? "", mnull.Groups["col"].Value, mnull.Groups[1].Value.ToUpperInvariant(), "", ""));
                    con = "AND";
                    continue;
                }

                var ml = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+LIKE\s+(?<v1>.+)$", RegexOptions.IgnoreCase);
                if (ml.Success)
                {
                    res.Add((con ?? "", ml.Groups["col"].Value, "LIKE", ml.Groups["v1"].Value, ""));
                    con = "AND";
                    continue;
                }

                var mop = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s*(?<op>=|<>|>=|<=|>|<)\s*(?<v1>.+)$", RegexOptions.IgnoreCase);
                if (mop.Success)
                {
                    res.Add((con ?? "", mop.Groups["col"].Value, mop.Groups["op"].Value, mop.Groups["v1"].Value, ""));
                    con = "AND";
                    continue;
                }
            }

            return res;
        }
    }
}
