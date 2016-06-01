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

            sql = "SELECT * FROM " + Ustawienia.USTAWIENIA_TABLE_NAME + " WHERE " + Ustawienia.USTAWIENIA_COLUMN_KLUCZ + "=" + "'krok'";
            reader = myDataBbase.query(sql);
            while (reader.Read()) {
                textBox2.Text = (String)reader[Ustawienia.USTAWIENIA_COLUMN_WARTOSC];
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            textBox1.Text = "0.01";
            textBox2.Text = "0.25";
        }

        private void button1_Click(object sender, EventArgs e) {
            if (validate()) {
                MyDataBase myDataBase = new MyDataBase();
                SQLiteConnection conn = myDataBase.open();
                myDataBase.zmienUstawieniaTable("prog_wynikow", textBox1.Text.ToString());
                myDataBase.zmienUstawieniaTable("krok", textBox2.Text.ToString());
                myDataBase.close();
                this.Close();
            }

        }

        private Boolean validate() {
            double txt1 = 0.0d;
            double txt2 = 0.0d;

            try {
                txt1 = Double.Parse(textBox1.Text.ToString().Replace(".",","));
                txt2 = Double.Parse(textBox2.Text.ToString().Replace(".", ","));
            }
            catch (Exception) {
                MessageBox.Show("Wprowadzono niepoprawne wartości!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt1 < -0.01d || txt1 > 0.99d) {
                return false;
            }
            if (txt2 < 0.0d || txt2 > 1.0d) {
                return false;
            }
            if ((1.0d / txt2) % 1 != 0) {
                return false;
            }

            return true;
        }
    }
}
