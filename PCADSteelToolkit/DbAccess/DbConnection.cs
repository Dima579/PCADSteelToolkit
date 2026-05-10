using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using IntelliCAD.ApplicationServices;

namespace PCADSteelToolkit.DbAccess
{
    public class DbConnection
    {
        private readonly string _connectionString;
        public DbConnection()
        {
            string basePath = Path.GetDirectoryName(typeof(DbConnection).Assembly.Location);

            string dbOrigin = Path.Combine(basePath, "Data", "BlueBookDB_sqlite3.db");

            _connectionString = $"Data Source={dbOrigin};Mode=ReadOnly";

            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
        }

        public IDbConnection InitialiseConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
