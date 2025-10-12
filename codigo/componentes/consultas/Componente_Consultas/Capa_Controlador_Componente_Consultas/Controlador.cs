using Capa_Modelo_Componente_Consultas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Capa_Controlador_Consultas
{
    public interface IConsultasRepo
    {
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> Listar(); // nombre -> SQL
        void Guardar(string sNombre, string sSql);
        bool Eliminar(string sNombre);
    }
}

// Juan Carlos Sandoval Quej 0901-22-4170 22/09/2025
public class Controlador
    {
        // Referencia al modelo (clase Sentencias) que se encarga de hablar con la base de datos
        private readonly Sentencias _m;
        // Nombre de la base de datos con la que vamos a trabajar
        private readonly string _db;

        // Caché de columnas (nombre y tipo) por tabla
        private readonly Dictionary<string, List<(string Name, string DataType)>> _colsCache =
            new Dictionary<string, List<(string Name, string DataType)>>(StringComparer.OrdinalIgnoreCase);

        // Tablas que NO deben mostrarse al usuario en el combo de "Nombre de tabla"
        private static readonly HashSet<string> _tablasOcultas =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "consultas_guardadas" // agrega aquí otras que quieras ocultar
            };

        // Constructor: recibe un DSN (ODBC) y el nombre de la BD
        public Controlador(string dsn, string db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            _db = db;
            _m = new Sentencias(dsn, db);
        }

        //  EJECUCIÓN Y METADATOS

        public DataTable EjecutarConsulta(string sql)
        {
            return _m.EjecutarConsulta(sql);
        }
        public DataTable EjecutarConsulta(string sql, string nombreConsultaGuardada)
        {
            var dt = _m.EjecutarConsulta(sql);
            if (!string.IsNullOrWhiteSpace(nombreConsultaGuardada))
            {
                try { _m.Db_IncrementarEjecucion(nombreConsultaGuardada); } catch { /* noop */ }
            }
            return dt;
        }

        public List<string> ObtenerTablas()
        {
            var tablas = _m.ObtenerTablas() ?? new List<string>();
            tablas.RemoveAll(t => _tablasOcultas.Contains(t));
            return tablas;
        }

        public List<string> ObtenerColumnas(string tabla)
        {
            return _m.ObtenerColumnas(tabla);
        }

        public List<(string Name, string DataType)> ObtenerColumnasTipadas(string tabla)
        {
            List<(string, string)> list;
            if (!_colsCache.TryGetValue(tabla, out list))
            {
                list = _m.ObtenerColumnasTipadas(tabla);
                _colsCache[tabla] = list;
            }
            return list;
        }
        //  CONSULTAS GUARDADAS (BD)

        /// Devuelve nombre -> SQL (ordenado) desde la tabla consultas_guardadas. 
        public List<KeyValuePair<string, string>> ListarConsultasPlano()
        {
            return _m.Db_ListarConsultasPlano();
        }

        /// Inserta/actualiza una consulta guardada por nombre. 
        public void GuardarConsulta(string nombre, string sql)
        {
            _m.Db_GuardarConsulta(nombre, sql, null, null);
        }

        /// Inserta/actualiza con tabla/descripcion opcionales. 
        public void GuardarConsulta(string nombre, string sql, string tabla, string descripcion)
        {
            _m.Db_GuardarConsulta(nombre, sql, tabla, descripcion);
        }

        /// Elimina por nombre.
        public bool EliminarConsulta(string nombre)
        {
            return _m.Db_EliminarConsulta(nombre);
        }

        /// Marca ejecución de una consulta guardada (contador/fecha). 
        public void MarcarEjecucionConsulta(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre))
                _m.Db_IncrementarEjecucion(nombre);
        }
        //  CONSTRUCCIÓN / REESCRITURA SQL

        // Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025
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

        // Diego Fernando Saquil Gramajo 0901-22-4103 09/22/2025
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

                var mb = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+BETWEEN\s+(?<v1>[^ ]+)\s+AND\s+(?<v2>[^ ]+)",
                                     RegexOptions.IgnoreCase);
                if (mb.Success)
                {
                    res.Add((con ?? "", mb.Groups["col"].Value, "BETWEEN",
                             mb.Groups["v1"].Value, mb.Groups["v2"].Value));
                    con = "AND";
                    continue;
                }

                var mnull = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+(IS\s+NOT\s+NULL|IS\s+NULL)",
                                        RegexOptions.IgnoreCase);
                if (mnull.Success)
                {
                    res.Add((con ?? "", mnull.Groups["col"].Value,
                             mnull.Groups[1].Value.ToUpperInvariant(), "", ""));
                    con = "AND";
                    continue;
                }

                var ml = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s+LIKE\s+(?<v1>.+)$",
                                     RegexOptions.IgnoreCase);
                if (ml.Success)
                {
                    res.Add((con ?? "", ml.Groups["col"].Value, "LIKE",
                             ml.Groups["v1"].Value, ""));
                    con = "AND";
                    continue;
                }

                var mop = Regex.Match(t, @"`?(?<col>[^`\s]+)`?\s*(?<op>=|<>|>=|<=|>|<)\s*(?<v1>.+)$",
                                      RegexOptions.IgnoreCase);
                if (mop.Success)
                {
                    res.Add((con ?? "", mop.Groups["col"].Value, mop.Groups["op"].Value,
                             mop.Groups["v1"].Value, ""));
                    con = "AND";
                    continue;
                }
            }

            return res;
        }
    }

