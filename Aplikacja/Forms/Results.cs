using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    public partial class Results : Form
    {

        private List<Wynik> wyniki;

        public Results()
        {
            InitializeComponent();
            pobierzWyniki();
            analizuj();
        }

        private void analizuj() {
            
        }

        private void pobierzWyniki() {
            MyDataBase myDataBase = new MyDataBase();
            System.Data.SQLite.SQLiteConnection connection = myDataBase.open();

            String sql = "SELECT * FROM " + Wynik.NAME_TABLE;
            SQLiteDataReader reader = myDataBase.query(sql);

            while (reader.Read())
            {
                Wynik wynik = new Wynik();
                wynik.Id = (int)reader[Wynik.NAME_ID];
                wynik.IdTestu = (int)reader[Wynik.NAME_IDTESTU];
                wynik.Type = (String)reader[Wynik.NAME_TYPE];
                wynik.WynikTestu = (float)reader[Wynik.NAME_WYNIK];
                wynik.Data = (String)reader[Wynik.NAME_DATA];

                wyniki.Add(wynik);
            }

            myDataBase.close();
        }


    }
}
