using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Componente_Consultas
{
    // Nelson José Godinez Mendez 0901-22-3550 22/09/2025
    public class Sentencias
    {
        private readonly string _dsn;
        private readonly string _db;
        private readonly string _connStr;

        public Sentencias(string dsn, string db)
        {
            if (dsn == null) throw new ArgumentNullException(nameof(dsn));
            if (db == null) throw new ArgumentNullException(nameof(db));
            _dsn = dsn;
            _db = db;
            _connStr = "DSN=" + _dsn + ";DATABASE=" + _db + ";";
        }

        private OdbcConnection CreateConn()
        {
            return new OdbcConnection(_connStr);
        }

        // --------------------------------------------------------------------
        //  EJECUCIÓN DE CONSULTAS Y METADATOS
        // --------------------------------------------------------------------

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
            string sql = "SELECT table_name " +
                         "FROM INFORMATION_SCHEMA.TABLES " +
                         "WHERE table_schema=? " +
                         "ORDER BY table_name;";

            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", _db);
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
            string sql = "SELECT COLUMN_NAME, DATA_TYPE " +
                         "FROM INFORMATION_SCHEMA.COLUMNS " +
                         "WHERE TABLE_SCHEMA=? AND TABLE_NAME=? " +
                         "ORDER BY ORDINAL_POSITION;";

            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", _db);
                cmd.Parameters.AddWithValue("@p2", tabla);
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

        // --------------------------------------------------------------------
        //  CONSULTAS GUARDADAS EN BD (MySQL/MariaDB)
        //  Tabla recomendada:
        //  CREATE TABLE IF NOT EXISTS consultas_guardadas(
        //    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
        //    owner_id INT NULL,
        //    nombre VARCHAR(120) NOT NULL UNIQUE,
        //    sql_texto MEDIUMTEXT NOT NULL,
        //    descripcion VARCHAR(255) NULL,
        //    tabla VARCHAR(128) NULL,
        //    etiquetas VARCHAR(255) NULL,
        //    favorito TINYINT(1) NOT NULL DEFAULT 0,
        //    ejecuciones INT UNSIGNED NOT NULL DEFAULT 0,
        //    ultimo_run_at DATETIME NULL,
        //    creado_en DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
        //    actualizado_en DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
        //                         ON UPDATE CURRENT_TIMESTAMP
        //  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
        // --------------------------------------------------------------------

        /// <summary>
        /// Devuelve nombre -> SQL (ordenado por nombre)
        /// </summary>
        public List<KeyValuePair<string, string>> Db_ListarConsultasPlano()
        {
            var list = new List<KeyValuePair<string, string>>();
            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(
                "SELECT nombre, sql_texto " +
                "FROM consultas_guardadas " +
                "ORDER BY nombre;", cn))
            {
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string nombre = rd.IsDBNull(0) ? "" : rd.GetString(0);
                        string sql = rd.IsDBNull(1) ? "" : rd.GetString(1);
                        list.Add(new KeyValuePair<string, string>(nombre, sql));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Inserta o actualiza por nombre (upsert manual compatible ODBC).
        /// </summary>
        public void Db_GuardarConsulta(string nombre, string sql, string tabla, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("nombre requerido");
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentException("sql requerido");

            using (var cn = CreateConn())
            {
                cn.Open();

                // Intento UPDATE por nombre
                using (var up = new OdbcCommand(
                    "UPDATE consultas_guardadas " +
                    "SET sql_texto=?, tabla=?, descripcion=?, actualizado_en=NOW() " +
                    "WHERE nombre=?;", cn))
                {
                    up.Parameters.AddWithValue("@p1", sql);
                    up.Parameters.AddWithValue("@p2", (object)tabla ?? DBNull.Value);
                    up.Parameters.AddWithValue("@p3", (object)descripcion ?? DBNull.Value);
                    up.Parameters.AddWithValue("@p4", nombre);

                    int affected = up.ExecuteNonQuery();
                    if (affected > 0) return; // actualizado
                }

                // Si no existía -> INSERT
                using (var ins = new OdbcCommand(
                    "INSERT INTO consultas_guardadas " +
                    "(nombre, sql_texto, tabla, descripcion, creado_en, actualizado_en) " +
                    "VALUES (?,?,?,?,NOW(),NOW());", cn))
                {
                    ins.Parameters.AddWithValue("@p1", nombre);
                    ins.Parameters.AddWithValue("@p2", sql);
                    ins.Parameters.AddWithValue("@p3", (object)tabla ?? DBNull.Value);
                    ins.Parameters.AddWithValue("@p4", (object)descripcion ?? DBNull.Value);
                    ins.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina por nombre. Devuelve true si eliminó filas.
        /// </summary>
        public bool Db_EliminarConsulta(string nombre)
        {
            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(
                "DELETE FROM consultas_guardadas WHERE nombre=?;", cn))
            {
                cmd.Parameters.AddWithValue("@p1", nombre);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Incrementa contador de ejecuciones y fecha último run.
        /// Llamar tras ejecutar con éxito una consulta guardada.
        /// </summary>
        public void Db_IncrementarEjecucion(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return;

            using (var cn = CreateConn())
            using (var cmd = new OdbcCommand(
                "UPDATE consultas_guardadas " +
                "SET ejecuciones=COALESCE(ejecuciones,0)+1, " +
                "    ultimo_run_at=NOW(), actualizado_en=NOW() " +
                "WHERE nombre=?;", cn))
            {
                cmd.Parameters.AddWithValue("@p1", nombre);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // --------------------------------------------------------------------
        //  (API anterior basada en XML) —> ELIMINADA
        //  Ahora toda la persistencia se hace en DB con los métodos Db_*
        // --------------------------------------------------------------------
    }
}
