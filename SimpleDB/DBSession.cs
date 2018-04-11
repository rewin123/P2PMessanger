using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SQLite;
using System.IO;
using System.Data;

namespace SimpleDB
{
    /// <summary>
    /// Класс сессии в базе данных
    /// </summary>
    public class DBSession
    {
        string db_name;
        private SQLiteConnection dbConn;
        SQLiteCommand dbCmd;

        public DBSession(string path_to_db)
        {
            this.db_name = path_to_db;

            if (!File.Exists(db_name))
                SQLiteConnection.CreateFile(db_name);

            dbConn = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            dbConn.Open();

            dbCmd = new SQLiteCommand();
            dbCmd.Connection = dbConn;
        }

        public int Cmd(string cmd_text)
        {
            dbCmd.CommandText = cmd_text;
            return dbCmd.ExecuteNonQuery();
        }

        public DataTable GetTable(string query_text)
        {
            dbCmd.CommandText = query_text;
            var rd = dbCmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Load(rd);
            return tb;
        }
    }
}
