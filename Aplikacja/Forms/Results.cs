﻿using Aplikacja.Database;
using Aplikacja.Forms;
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
        private double treshold = 0.0d;
        private double krok = 0.25d;
        String podsumowanie = "";

        public Results()
        {
            InitializeComponent();
            wyniki = new List<Wynik>();
            pobierzWyniki();
           

            String sql = "SELECT * FROM " + Ustawienia.USTAWIENIA_TABLE_NAME + " WHERE " + Ustawienia.USTAWIENIA_COLUMN_KLUCZ + "=" + "'prog_wynikow'";
            MyDataBase myDataBase = new MyDataBase();
            myDataBase.open();
            myDataBase.clearDiagnozy();

            SQLiteDataReader reader =  myDataBase.query(sql);
            while (reader.Read()) {
                String str = (String)reader[Ustawienia.USTAWIENIA_COLUMN_WARTOSC];
                str = str.Replace(".", ",");
                treshold = Convert.ToDouble(str);
            }

            sql = "SELECT * FROM " + Ustawienia.USTAWIENIA_TABLE_NAME + " WHERE " + Ustawienia.USTAWIENIA_COLUMN_KLUCZ + "=" + "'krok'";
            reader = myDataBase.query(sql);
            while (reader.Read()) {
                String str = (String)reader[Ustawienia.USTAWIENIA_COLUMN_WARTOSC];
                str = str.Replace(".", ",");
                krok = Convert.ToDouble(str);
            }
            myDataBase.close();

            analizuj();
        }

        private void analizuj(Boolean zapisDoPliku = false) {
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
                    case 10001:
                        krotka.Alfa12 = w.WynikTestu;
                        break;
                    case 10002:
                        krotka.Alfa13 = w.WynikTestu;
                        break;
                    case 10003:
                        krotka.Alfa14 = w.WynikTestu;
                        break;
                    case 10004:
                        krotka.Alfa15 = w.WynikTestu;
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

            Double Fu = FuzzyLogic.AND(zrobFu(krotka.Alfa1), FuzzyLogic.AND(zrobFu(krotka.Alfa2), FuzzyLogic.AND(zrobFu(krotka.Alfa3), FuzzyLogic.AND(zrobFu(krotka.Alfa4), FuzzyLogic.AND(zrobFu(krotka.Alfa5), FuzzyLogic.AND(zrobFu(krotka.Alfa12), FuzzyLogic.AND(zrobFu(krotka.Alfa13), FuzzyLogic.AND(zrobFu(krotka.Alfa14), zrobFu(krotka.Alfa15)))))))));
            
            generujCSV(null, true);

            Double delta = krok;

            MyDataBase myDataBase = new MyDataBase();
            SQLiteConnection conn = myDataBase.open();
            SQLiteTransaction t = conn.BeginTransaction();
            SQLiteCommand c = conn.CreateCommand();
            c.Transaction = t;

            // To trzeba zrobić jakoś inaczej, np. rekurencyjnie
            // szukamy ay, więc przechodzimy po wszystkich 
            for (krotka.Alfa6 = 0f; krotka.Alfa6 <= 1f; krotka.Alfa6 += delta) {
                for (krotka.Alfa7 = 0f; krotka.Alfa7 <= 1f; krotka.Alfa7 += delta) {
                    for (krotka.Alfa8 = 0f; krotka.Alfa8 <= 1f; krotka.Alfa8 += delta) {
                        for (krotka.Alfa9 = 0f; krotka.Alfa9 <= 1f; krotka.Alfa9 += delta) {
                            for (krotka.Alfa10 = 0f; krotka.Alfa10 <= 1f; krotka.Alfa10 += delta) {
                                for (krotka.Alfa11 = 0f; krotka.Alfa11 <= 1f; krotka.Alfa11 += delta) {
                                    for (krotka.Alfa16 = 0f; krotka.Alfa16 <= 1f; krotka.Alfa16 += delta) {
                                        // F1 = -alfa1 => alfa6 (monochromatyzm)
                                        krotka.F1 = FuzzyLogic.IMPLIES(FuzzyLogic.NOT(krotka.Alfa1), krotka.Alfa6);

                                        // F2 = -alfa2 => alfa7 (zaburzenia czerwonego/zielonego)
                                        krotka.F2 = FuzzyLogic.IMPLIES(FuzzyLogic.NOT(krotka.Alfa2), krotka.Alfa7);

                                        // F3 = -alfa3 => alfa8 v alfay9 (protanopia lub protanomalia)
                                        krotka.F3 = FuzzyLogic.IMPLIES(FuzzyLogic.NOT(krotka.Alfa3), FuzzyLogic.OR(krotka.Alfa8, krotka.Alfa9));

                                        // F4 = -alfa4 => alfa10 v alfa11 (Deuteranopia lub deuteranomalia)
                                        krotka.F4 = FuzzyLogic.IMPLIES(FuzzyLogic.NOT(krotka.Alfa4), FuzzyLogic.OR(krotka.Alfa10, krotka.Alfa11));

                                        // F5 = a5 => -a6 ^ -a7 ^ -a8 ^ -a9 ^ -a10 ^ -a11
                                        // Im więcej odpowiedzi było dobrych to tym bardziej pacjent jest zdrowy
                                        krotka.F5 = FuzzyLogic.IMPLIES(krotka.Alfa5, FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa6), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa7), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa8), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa9), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa10), FuzzyLogic.NOT(krotka.Alfa11)))))));

                                        krotka.F6 = FuzzyLogic.IMPLIES(FuzzyLogic.AND(FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa13), FuzzyLogic.NOT(krotka.Alfa14)), FuzzyLogic.NOT(krotka.Alfa15)), krotka.Alfa12);
                                        //krotka.F6 = 1;
                                        krotka.F7 = FuzzyLogic.IMPLIES(krotka.Alfa12, FuzzyLogic.AND(FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa6), FuzzyLogic.NOT(krotka.Alfa10)), FuzzyLogic.NOT(krotka.Alfa8)));
                                        //krotka.F7 = 1;
                                        krotka.F8 = FuzzyLogic.IMPLIES(krotka.Alfa13, krotka.Alfa8);

                                        krotka.F9 = FuzzyLogic.IMPLIES(krotka.Alfa14, krotka.Alfa10);

                                        krotka.F10 = FuzzyLogic.IMPLIES(krotka.Alfa15, krotka.Alfa6);

                                        krotka.F11 = FuzzyLogic.IMPLIES(FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa6), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa7), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa8), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa9), FuzzyLogic.AND(FuzzyLogic.NOT(krotka.Alfa10), FuzzyLogic.NOT(krotka.Alfa11)))))), krotka.Alfa16);

                                        krotka.F12 = FuzzyLogic.IMPLIES(FuzzyLogic.AND(krotka.Alfa5, krotka.Alfa12), krotka.Alfa16);

                                         
                                        // F = F1 ^ F2 ^ F3 ^ F4 ^ ...;
                                        krotka.F = FuzzyLogic.AND(krotka.F1, FuzzyLogic.AND(krotka.F2, FuzzyLogic.AND(krotka.F3, FuzzyLogic.AND(krotka.F4, FuzzyLogic.AND(krotka.F5, FuzzyLogic.AND(krotka.F6, FuzzyLogic.AND(krotka.F7, FuzzyLogic.AND(krotka.F8, FuzzyLogic.AND(krotka.F9, FuzzyLogic.AND(krotka.F10, FuzzyLogic.AND(krotka.F11, krotka.F12)))))))))));
                                        // Fu 
                                        krotka.Fu = Fu;
                                        // F ^ Fu
                                        krotka.Ffu = FuzzyLogic.AND(krotka.Fu, krotka.F);

                                        if (krotka.Ffu > treshold) {
                                            if (zapisDoPliku) {
                                                generujCSV(krotka, false);
                                            }
                                            zapiszDiagnoze(krotka, myDataBase, c, t);
                                        }
                                    }                  
                                }
                            }
                        }
                    }
                }
            }
            t.Commit();
            conn.Close();
            myDataBase.close();

            pokazWyniki();
        }

        private void pokazWyniki() {
            MyDataBase myDataBase = new MyDataBase();
            SQLiteConnection conn = myDataBase.open();

            String sql = "SELECT * FROM " + Diagnoza.DIAGNOZA_TABLE_NAME + " ORDER BY "
                + Diagnoza.DIAGNOZA_COLUMN_PRAWDOPODOBIENSTWO + " DESC";

            SQLiteDataReader reader = myDataBase.query(sql);
            while (reader.Read()) {
                Diagnoza diagnoza = new Diagnoza();
                diagnoza.Monochromatyzm = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_MONOCHROMATYZM];
                diagnoza.Czerwonyzielony = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_ZABURZENIA_CZERW_ZIEL];
                diagnoza.Protanopia = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PROTANOPIA];
                diagnoza.Protanomalia = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PROTANOMALIA];
                diagnoza.Deuteranopia = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_DEUTERANOPIA];
                diagnoza.Deuteranomalia = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_DEUTERANOMALIA];
                diagnoza.Zdrowy = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PACJENT_ZDROWY];
                diagnoza.Prawdopodobienstwo = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PRAWDOPODOBIENSTWO];

                makePodsumowanie(diagnoza);
            }
            myDataBase.close();

            textBox1.Text = podsumowanie;
        }

        private void pobierzWyniki() {
            MyDataBase myDataBase = new MyDataBase();
            SQLiteConnection connection = myDataBase.open();

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

        private void zapiszDiagnoze(Krotka k, MyDataBase myDataBase,  SQLiteCommand c, SQLiteTransaction t) {
            Diagnoza diagnoza = new Diagnoza();
            diagnoza.Monochromatyzm = k.Alfa6;
            diagnoza.Czerwonyzielony = k.Alfa7;
            diagnoza.Protanopia = k.Alfa8;
            diagnoza.Protanomalia = k.Alfa9;
            diagnoza.Deuteranopia = k.Alfa10;
            diagnoza.Deuteranomalia = k.Alfa11;
            diagnoza.Zdrowy = k.Alfa16;
            diagnoza.Prawdopodobienstwo = k.Ffu;

            SQLiteCommand comm = myDataBase.getSQLStringDiagnoza(diagnoza);
            c = comm;
            c.Transaction = t;
            c.ExecuteNonQuery();
        }

        private void generujCSV(Krotka k, Boolean isFirst) {
            String title = "a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15,a16,F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F,Fu,F^Fu";

            try {
                StreamWriter file = new StreamWriter("rezultat.csv", true);
                file.AutoFlush = true;
                if (isFirst) {
                    file.Close();
                    file = new StreamWriter("rezultat.csv", false);
                    file.WriteLine(title);

                    StringBuilder s = new StringBuilder();
                    s.Append("==============================================\r\n");
                    s.Append("Prawdopodobieństwo zaburzeń widzenia barwnego:\r\n");
                    s.Append("==============================================\r\n\r\n");
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
                    str.Append(k.Alfa12.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa13.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa14.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa15.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.Alfa16.ToString("0.00").Replace(",", "."));
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
                    str.Append(k.F6.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F7.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F8.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F9.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F10.ToString("0.00").Replace(",", "."));
                    str.Append(',');
                    str.Append(k.F11.ToString("0.00").Replace(",", "."));
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

        private double zrobFu(double wartosc) {
            if (wartosc >= 0.5) {
                return wartosc;
            }
            else
                return FuzzyLogic.NOT(wartosc);
        }

        private void makePodsumowanie(Diagnoza diagnoza) {
            StringBuilder s = new StringBuilder();
            s.Append("==============================================\r\n");
            s.Append("Prawdopodobieństwo poprawnej diagnozy: " + diagnoza.Prawdopodobienstwo.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Brak zaburzeń: " + diagnoza.Zdrowy.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Monochromatyzm: " + diagnoza.Monochromatyzm.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Zaburzenia czerwony/zielony: " + diagnoza.Czerwonyzielony.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Protanopia: " + diagnoza.Protanopia.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Protanomalia: " + diagnoza.Protanomalia.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Deuteranopia: " + diagnoza.Deuteranopia.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("Deuteranomalia: " + diagnoza.Deuteranomalia.ToString("P1").Replace(",", ".") + "\r\n");
            s.Append("==============================================\r\n");
            s.Append("\r\n");

            podsumowanie += s.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e) {
            analizuj(true);
            MessageBox.Show("Pomyślnie wygenerowano plik rezultat.csv", "Zakończono!", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button2_Click(object sender, EventArgs e) {
            Wykres wykres = new Wykres();
            wykres.Show();
        }
    }
}
