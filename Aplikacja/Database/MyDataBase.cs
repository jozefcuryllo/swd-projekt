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
        public static readonly String databaseName = "db2.sqlite";
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
            String sql = "CREATE TABLE " + Wynik.NAME_TABLE + " (" + Wynik.NAME_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + Wynik.NAME_IDTESTU + " INTEGER, " + Wynik.NAME_WYNIK + " REAL, " + Wynik.NAME_TYPE + " TEXT NOT NULL, " + Wynik.NAME_DATA + " TEXT) ";
            return nonQuery(sql);
        }

        public int addImagesTable() {
            String sql = "CREATE TABLE "+ Images.IMAGE_TABLE_NAME + " ( " + Images.IMAGE_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + Images.IMAGE_NAME + " TEXT NOT NULL, " + Images.IMAGE_TYPE + " TEXT NOT NULL, " + Images.IMAGE_VALUE + " TEXT, " + Images.IMAGE_WRONG_VALUE + " TEXT ) ";
            return nonQuery(sql);
        }

        public int addImagesRecords() {
            List<Images> ishihara = new List<Images>();

            ishihara.Add(new Images(1, "Ishihara-Plate-01-38.jpg", "12", null, "mono"));
            ishihara.Add(new Images(2, "Ishihara-Plate-02-38.jpg", "8", "3", "rg"));
            ishihara.Add(new Images(3, "Ishihara-Plate-03-38.jpg", "6","5", "rg"));
            ishihara.Add(new Images(4, "Ishihara-Plate-04-38.jpg", "29", "70", "rg"));
            ishihara.Add(new Images(5, "Ishihara-Plate-05-38.jpg", "57", "35", "rg"));
            ishihara.Add(new Images(6, "Ishihara-Plate-06-38.jpg", "5", "2", "rg"));
            ishihara.Add(new Images(7, "Ishihara-Plate-07-38.jpg", "3", "5", "rg"));
            ishihara.Add(new Images(8, "Ishihara-Plate-08-38.jpg", "15", "17", "rg"));
            ishihara.Add(new Images(9, "Ishihara-Plate-09-38.jpg", "74", "21", "rg"));
            ishihara.Add(new Images(10, "Ishihara-Plate-10-38.jpg", "2", null, "rg"));
            ishihara.Add(new Images(11, "Ishihara-Plate-11-38.jpg", "6", null, "rg"));
            ishihara.Add(new Images(12, "Ishihara-Plate-12-38.jpg", "97", null, "rg"));
            ishihara.Add(new Images(13, "Ishihara-Plate-13-38.jpg", "45", null, "rg"));
            ishihara.Add(new Images(14, "Ishihara-Plate-14-38.jpg", "5", null, "rg"));
            ishihara.Add(new Images(15, "Ishihara-Plate-15-38.jpg", "7", null, "rg"));
            ishihara.Add(new Images(16, "Ishihara-Plate-16-38.jpg", "16", null, "rg"));
            ishihara.Add(new Images(17, "Ishihara-Plate-17-38.jpg", "73", null, "rg"));
            ishihara.Add(new Images(18, "Ishihara-Plate-18-38.jpg", null, "5", "rg"));
            ishihara.Add(new Images(19, "Ishihara-Plate-19-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(20, "Ishihara-Plate-20-38.jpg", null, "45", "rg"));
            ishihara.Add(new Images(21, "Ishihara-Plate-21-38.jpg", null, "73", "rg"));
            ishihara.Add(new Images(22, "Ishihara-Plate-22-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(23, "Ishihara-Plate-23-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(24, "Ishihara-Plate-24-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(25, "Ishihara-Plate-25-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(26, "Ishihara-Plate-26-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(27, "Ishihara-Plate-27-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(28, "Ishihara-Plate-28-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(29, "Ishihara-Plate-29-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(30, "Ishihara-Plate-30-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(31, "Ishihara-Plate-31-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(32, "Ishihara-Plate-32-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(33, "Ishihara-Plate-33-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(34, "Ishihara-Plate-34-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(35, "Ishihara-Plate-35-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(36, "Ishihara-Plate-36-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(37, "Ishihara-Plate-37-38.jpg", null, "2", "rg"));
            ishihara.Add(new Images(38, "Ishihara-Plate-38-38.jpg", null, "2", "rg"));


            foreach (Images i in ishihara) {
                addImage(i);
            }

            return 0;
        }


        public int addImage(Images image) {
            String sql = "INSERT INTO " + Images.IMAGE_TABLE_NAME + " ( " + Images.IMAGE_NAME + ", " + Images.IMAGE_TYPE + ", " + Images.IMAGE_VALUE + ", " + Images.IMAGE_WRONG_VALUE + " ) VALUES (@param1, @param2, @param3, @param4)";

            if (m_dbConnection != null)
            {
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@param1", image.Name));
                command.Parameters.Add(new SQLiteParameter("@param2", image.Type));
                command.Parameters.Add(new SQLiteParameter("@param3", image.Value));
                command.Parameters.Add(new SQLiteParameter("@param4", image.WrongValue));
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
