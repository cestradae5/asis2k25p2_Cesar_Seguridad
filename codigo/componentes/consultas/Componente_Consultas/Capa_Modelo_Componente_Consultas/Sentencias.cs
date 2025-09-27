﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;

namespace Capa_Modelo_Componente_Consultas
{
    // Nelson José Godinez Mendez 0901-22-3550 22/09/2025
    public class ColumnaInfo
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; } 
    }

    public class UserQuery { public string Name { get; set; } public string Sql { get; set; } public override string ToString() => Name; }


    // Acceso a datos 
    public class Sentencias
    {
        private readonly string _db;
        private readonly Conexion _cx;

        public Sentencias(Conexion cx, string databaseName)
        {
            _cx = cx ?? throw new ArgumentNullException(nameof(cx));
            _db = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        }

        public List<string> ObtenerNombresTablas()
        {
            var tablas = new List<string>();
            const string sql = @"
                SELECT TABLE_NAME
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = ?
                ORDER BY TABLE_NAME;";

            var cn = _cx.Abrir();
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", _db);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) tablas.Add(rd.GetString(0));
                }
            }
            return tablas;
        }

        public List<ColumnaInfo> ObtenerColumnas(string tabla)
        {
            var cols = new List<ColumnaInfo>();
            const string sql = @"
                SELECT COLUMN_NAME, DATA_TYPE
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_SCHEMA=? AND TABLE_NAME=?
                ORDER BY ORDINAL_POSITION;";

            var cn = _cx.Abrir();
            using (var cmd = new OdbcCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@p1", _db);
                cmd.Parameters.AddWithValue("@p2", tabla);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cols.Add(new ColumnaInfo
                        {
                            Nombre = rd.GetString(0),
                            Tipo = rd.GetString(1)
                        });
                    }
                }
            }
            return cols;
        }
        // ----------------------------------------------------------------------------------------- //

        // Realizado por: Bryan Raul Ramirez Lopez 0901-21-8202 22/09/2025
        public DataTable ConsultarTablaOrdenada(string tabla, bool asc, List<ColumnaInfo> columnas)
        {
            if (columnas == null || columnas.Count == 0) return new DataTable();

            var selectCols = new List<string>(columnas.Count);
            foreach (var c in columnas)
            {
                if (string.Equals(c.Tipo, "time", StringComparison.OrdinalIgnoreCase))
                    selectCols.Add("CAST(`" + c.Nombre + "` AS CHAR(10)) AS `" + c.Nombre + "`");
                else
                    selectCols.Add("`" + c.Nombre + "`");
            }

            string order = asc ? "ASC" : "DESC";
            string firstCol = columnas[0].Nombre;
            string sql = "SELECT " + string.Join(", ", selectCols) +
                         " FROM `" + _db + "`.`" + tabla + "` ORDER BY `" + firstCol + "` " + order + ";";

            var cn = _cx.Abrir(); 
            using (var da = new OdbcDataAdapter())
            {
                da.SelectCommand = new OdbcCommand(sql, cn); 
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable EjecutarSelect(string sql)
        {
            var cn = _cx.Abrir(); 
            using (var da = new OdbcDataAdapter())
            {
                da.SelectCommand = new OdbcCommand(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
