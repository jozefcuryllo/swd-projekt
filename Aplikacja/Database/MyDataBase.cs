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
                open();
                addWynikiTable();
                addImagesTable();
                addImagesRecords();
                close();
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

        public int addWynikiTable() {
            String sql = "CREATE TABLE " + Wynik.NAME_TABLE + " (" + Wynik.NAME_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, \"" + Wynik.NAME_IDTESTU + "\" INTEGER, \"" + Wynik.NAME_WYNIK + "\" REAL, \"" + Wynik.NAME_TYPE + "\" TEXT NOT NULL, \"" + Wynik.NAME_DATA + "\" TEXT) ";
            return nonQuery(sql);
        }

        public int addImagesTable() {
            String sql = "CREATE TABLE "+ Images.IMAGE_TABLE_NAME + " ( \"" + Images.IMAGE_ID + "\" INTEGER PRIMARY KEY AUTOINCREMENT, \"" + Images.IMAGE_NAME + "\" TEXT NOT NULL, \"" + Images.IMAGE_TYPE + "\" TEXT NOT NULL, \"" + Images.IMAGE_VALUE + "\" TEXT )";
            return nonQuery(sql);
        }

        public int addImagesRecords() {
            List<Images> ishihara = new List<Images>();

            ishihara.Add(new Images(1, "1.png", "10", "czerwony"));

            foreach (Images i in ishihara) {
                addImage(i);
            }

            return 0;
        }


        public int addImage(Images image) {
            String sql = "INSERT INTO " + Images.IMAGE_TABLE_NAME + " ( " + Images.IMAGE_NAME + ", " + Images.IMAGE_TYPE + ", " + Images.IMAGE_VALUE + " ) VALUES (@param1, @param2, @param3)";

            if (m_dbConnection != null)
            {
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@param1", image.Name));
                command.Parameters.Add(new SQLiteParameter("@param2", image.Type));
                command.Parameters.Add(new SQLiteParameter("@param3", image.Value));
                return command.ExecuteNonQuery();
            }
            return -1;
        }

        public int addWynik(Wynik wynik)
        {
            String sql = "INSERT INTO " + Wynik.NAME_TABLE + " ( "+Wynik.NAME_IDTESTU + ", " + Wynik.NAME_WYNIK + ", " + Wynik.NAME_TYPE + ", " + Wynik.NAME_DATA + " ) VALUES (@param1, @param2, @param3, @param4)";

            if (m_dbConnection != null)
            {
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@param1", wynik.IdTestu));
                command.Parameters.Add(new SQLiteParameter("@param2", wynik.WynikTestu));
                command.Parameters.Add(new SQLiteParameter("@param3", wynik.Type));
                command.Parameters.Add(new SQLiteParameter("@param4", wynik.Data));
                return command.ExecuteNonQuery();
            }
            return -1;
        }

    }
}
