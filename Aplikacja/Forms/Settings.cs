using Aplikacja.Database;
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

namespace Aplikacja.Forms {
    public partial class Settings : Form {
        public Settings() {
            InitializeComponent();

            String sql = "SELECT * FROM " + Ustawienia.USTAWIENIA_TABLE_NAME + " WHERE " + Ustawienia.USTAWIENIA_COLUMN_KLUCZ + "=" + "'prog_wynikow'";
            MyDataBase myDataBbase = new MyDataBase();
            SQLiteConnection conn = myDataBbase.open();
            SQLiteDataReader reader = myDataBbase.query(sql);
            while (reader.Read()) {
                textBox1.Text = (String)reader[Ustawienia.USTAWIENIA_COLUMN_WARTOSC];
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            textBox1.Text = "0.01";
        }

        private void button1_Click(object sender, EventArgs e) {
            MyDataBase myDataBase = new MyDataBase();
            SQLiteConnection conn = myDataBase.open();
            myDataBase.zmienUstawieniaTable("prog_wynikow", textBox1.Text.ToString());
            myDataBase.close();
            this.Close();

        }
    }
}
