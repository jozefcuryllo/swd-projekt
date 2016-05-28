using Aplikacja.Database;
using Aplikacja.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
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
            wyniki = new List<Wynik>();
            pobierzWyniki();
            analizuj();
        }

        private void analizuj() {
            Krotka krotka = new Krotka();

            // tablica 1 (monochromatyzm)
            krotka.Alfa1 = 0.0d;

            // tablice 2-21 (problem z czerwonym lub zielonym)
            krotka.Alfa2 = 0.0d;

            // tablice 22-25 (protanopia lub protanomalia)
            krotka.Alfa3 = 0.0d;

            // tablice 22-25 (deuteranopia lub deuteranomalia)
            krotka.Alfa4 = 0.0d;

            // wszystkie odpowiedzi poprawne 
            krotka.Alfa5 = 0.0d;

            foreach (Wynik w in wyniki) {
                switch (w.IdTestu) {
                    case 1:
                        krotka.Alfa1 += w.WynikTestu;
                        krotka.Alfa5 += w.WynikTestu;
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        krotka.Alfa2 += w.WynikTestu;
                        krotka.Alfa5 += w.WynikTestu;
                        break;
                    case 22:
                        if (w.WynikTestu == 6)
                        {
                            krotka.Alfa3 += 1.0d;
                        }
                        if (w.WynikTestu == 2) {
                            krotka.Alfa4 += 1.0d;
                        }
                        if (w.WynikTestu == 26) {
                            krotka.Alfa5 += 1.0d;
                        }
                        break;
                    case 23:
                        if (w.WynikTestu == 2)
                        {
                            krotka.Alfa3 += 1.0d;
                        }
                        if (w.WynikTestu == 4)
                        {
                            krotka.Alfa4 += 1.0d;
                        }
                        if (w.WynikTestu == 42)
                        {
                            krotka.Alfa5 += 1.0d;
                        }
                        break;
                    case 24:
                        if (w.WynikTestu == 5)
                        {
                            krotka.Alfa3 += 1.0d;
                        }
                        if (w.WynikTestu == 3)
                        {
                            krotka.Alfa4 += 1.0d;
                        }
                        if (w.WynikTestu == 35)
                        {
                            krotka.Alfa5 += 1.0d;
                        }
                        break;
                    case 25:
                        if (w.WynikTestu == 6)
                        {
                            krotka.Alfa3 += 1.0d;
                        }
                        if (w.WynikTestu == 9)
                        {
                            krotka.Alfa4 += 1.0d;
                        }
                        if (w.WynikTestu == 96)
                        {
                            krotka.Alfa5 += 1.0d;
                        }
                        break;
                }
            }

            // Zmieniamy wartości alf na [0, 1]
            krotka.Alfa1 = krotka.Alfa1 / 1f;
            krotka.Alfa2 = krotka.Alfa2 / 20f;
            krotka.Alfa3 = krotka.Alfa3 / 4f;
            krotka.Alfa4 = krotka.Alfa4 / 4f;
            krotka.Alfa5 = krotka.Alfa5 / 26f;

            // Wyznaczamy Fu 
            //Double Fu = FuzzyLogic.AND(krotka.Alfa1, FuzzyLogic.AND(krotka.Alfa2, FuzzyLogic.AND(krotka.Alfa3, FuzzyLogic.AND(krotka.Alfa4, krotka.Alfa5))));
            Double Fu = 0.8;
            generujCSV(null, true);

            Double delta = 0.5f;

            // To trzeba zrobić jakoś inaczej, np. rekurencyjnie
            for (krotka.Alfa1 = 0f; krotka.Alfa1 <= 1f; krotka.Alfa1 += delta) {
                for (krotka.Alfa2 = 0f; krotka.Alfa2 <= 1f; krotka.Alfa2 += delta) {
                    for (krotka.Alfa3 = 0f; krotka.Alfa3 <= 1f; krotka.Alfa3 += delta) {
                        for (krotka.Alfa4 = 0f; krotka.Alfa4 <= 1f; krotka.Alfa4 += delta) {
                            for (krotka.Alfa5 = 0f; krotka.Alfa5 <= 1f; krotka.Alfa5 += delta) {
                                for (krotka.Alfa6 = 0f; krotka.Alfa6 <= 1f; krotka.Alfa6 += delta) {
                                    for (krotka.Alfa7 = 0f; krotka.Alfa7 <= 1f; krotka.Alfa7 += delta) {
                                        for (krotka.Alfa8 = 0f; krotka.Alfa8 <= 1f; krotka.Alfa8 += delta) {
                                            for (krotka.Alfa9 = 0f; krotka.Alfa9 <= 1f; krotka.Alfa9 += delta) {
                                                for (krotka.Alfa10 = 0f; krotka.Alfa10 <= 1f; krotka.Alfa10 += delta) {
                                                    for (krotka.Alfa11 = 0f; krotka.Alfa11 <= 1f; krotka.Alfa11 += delta) {
                                                        // F1 = alfa1 => alfa6 (monochromatyzm)
                                                        krotka.F1 = FuzzyLogic.IMPLIES(krotka.Alfa1, krotka.Alfa6);

                                                        // F2 = alfa2 => alfa7 (zaburzenia czerwonego/zielonego)
                                                        krotka.F2 = FuzzyLogic.IMPLIES(krotka.Alfa2, krotka.Alfa7);

                                                        // F3 = alfa3 => alfa8 v alfay9 (protanopia lub protanomalia)
                                                        krotka.F3 = FuzzyLogic.IMPLIES(krotka.Alfa3, FuzzyLogic.OR(krotka.Alfa8, krotka.Alfa9));

                                                        // F4 = alfa4 => alfa10 v alfa11 (Deuteranopia lub deuteranomalia)
                                                        krotka.F4 = FuzzyLogic.IMPLIES(krotka.Alfa4, FuzzyLogic.OR(krotka.Alfa10, krotka.Alfa11));

                                                        // F5 = a5 => -a6 ^ -a7 ^ -a8 ^ -a9 ^ -a10 ^ -a11
                                                        // Im więcej odpowiedzi było dobrych to tym bardziej pacjent jest zdrowy
                                                        krotka.F5 = FuzzyLogic.IMPLIES(krotka.Alfa5, FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa6), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa7), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa8), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa9), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa10), FuzzyLogic.NOT(krotka.Alfa11)))))));

                                                        // F = F1 ^ F2 ^ F3 ^ F4;
                                                        krotka.F = FuzzyLogic.AND(krotka.F1, FuzzyLogic.AND(krotka.F2, FuzzyLogic.AND(krotka.F3, FuzzyLogic.AND(krotka.F4, krotka.F5))));

                                                        // Fu 
                                                        krotka.Fu = Fu;

                                                        // F ^ Fu
                                                        krotka.Ffu = FuzzyLogic.AND(krotka.Fu, krotka.F);

                                                        generujCSV(krotka, false);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pobierzWyniki() {
            MyDataBase myDataBase = new MyDataBase();
            System.Data.SQLite.SQLiteConnection connection = myDataBase.open();

            String sql = "SELECT * FROM " + Wynik.NAME_TABLE;
            SQLiteDataReader reader = myDataBase.query(sql);

           
                try
                {
                    while (reader.Read())
                    {
                        Wynik wynik = new Wynik();
                        wynik.Id = Convert.ToInt32(reader[Wynik.NAME_ID]);
                        wynik.IdTestu = Convert.ToInt32(reader[Wynik.NAME_IDTESTU]);
                        wynik.Type = (String)reader[Wynik.NAME_TYPE];
                        wynik.WynikTestu = (Double)reader[Wynik.NAME_WYNIK];
                        wynik.Data = (String)reader[Wynik.NAME_DATA];

                        wyniki.Add(wynik);
                    }
                 }
                catch {
                    MessageBox.Show("Zapisane dane zostały uszkodzone. Spróbuj ponownie!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            myDataBase.close();
        }

        private void generujCSV(Krotka k, Boolean isFirst) {
            String title = "a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,F1,F2,F3,F4,F5,F,Fu,F^Fu";
            try {
                StreamWriter file = new StreamWriter("rezultat.csv", true);
                file.AutoFlush = true;
                if (isFirst) {
                    file.Close();
                    file = new StreamWriter("rezultat.csv", false);
                    file.WriteLine(title);
                }
                else {
                    StringBuilder str = new StringBuilder();
                    str.Append(k.Alfa1.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa2.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa3.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa4.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa5.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa6.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa7.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa8.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa9.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa10.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa11.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F1.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F2.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F3.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F4.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F5.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Fu.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Ffu.ToString("0.00").Replace(",", "."));
                    file.WriteLine(str.ToString());
                }


                file.Close();
            }
            catch {
                MessageBox.Show("Błąd zapisu do pliku. Sprobuj ponownie!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


    }
}
