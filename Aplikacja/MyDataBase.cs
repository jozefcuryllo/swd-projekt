using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    class MyDataBase
    {
        public static readonly String databaseName = "db.sqlite";
        SQLiteConnection m_dbConnection = null;

        public void create() {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\" + MyDataBase.databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
            }
        }

        public SQLiteConnection open() {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\" + MyDataBase.databaseName))
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;");
                m_dbConnection.Open();

                return m_dbConnection;
            }
            return null;
        }

        public void close() {
            if (m_dbConnection != null)
            {
                m_dbConnection.Close();
            }
            m_dbConnection = null;
        }

        public int nonQuery(String sql) {
            if (m_dbConnection != null) {
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            return -1;
        }

        public SQLiteDataReader query(String sql) {
            SQLiteDataReader reader = null;

            if (m_dbConnection != null) {
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                 reader = command.ExecuteReader();
            }

            return reader;
        }

        public int createSchema() {
            int result = -1;

            if (m_dbConnection != null)
            {
                String sql = "CREATE TABLE wyniki (id INT PRIMARY KEY, idTestu INT, wynik INT, data TEXT) "; 
                result = nonQuery(sql);
            }

            return result;
        }

        

    }
}
