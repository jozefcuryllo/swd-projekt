using Aplikacja.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja.Forms {
    public partial class TestFM : Form {

        List<Color> koloryFM;
        List<int> wzorcowe;
        List<int> ulozone;
        List<int> protanopia;
        List<int> deuteranopia;
        List<int> achromatyzm;

        public TestFM() {
            InitializeComponent();
            koloryFM = new List<Color>();
           // koloryFM.Add(Color.FromArgb(0x37, 0x81, 0xc1)); //1
            koloryFM.Add(Color.FromArgb(0x35, 0x83, 0xb4)); //2
            koloryFM.Add(Color.FromArgb(0x3b, 0x84, 0xa7)); //3
            koloryFM.Add(Color.FromArgb(0x39, 0x85, 0x9c)); //4  #3B8690 
            koloryFM.Add(Color.FromArgb(0x3b, 0x86, 0x90)); //5  #3583B4
            koloryFM.Add(Color.FromArgb(0x3f, 0x87, 0x82)); //6  #927099
            koloryFM.Add(Color.FromArgb(0x58, 0x84, 0x73)); //7  #6C8164
            koloryFM.Add(Color.FromArgb(0x6c, 0x81, 0x64)); //8  #3B84A7
            koloryFM.Add(Color.FromArgb(0x83, 0x7b, 0x5d)); //9  #9E6E6F
            koloryFM.Add(Color.FromArgb(0x90, 0x76, 0x60)); //10 #9F6D7C
            koloryFM.Add(Color.FromArgb(0x9e, 0x6e, 0x6f)); //11 #907660
            koloryFM.Add(Color.FromArgb(0x9f, 0x6d, 0x7c)); //12 #837B5D
            koloryFM.Add(Color.FromArgb(0x9c, 0x6d, 0x89)); //13 #698473
            koloryFM.Add(Color.FromArgb(0x92, 0x70, 0x99)); //14 #9C6D89
            koloryFM.Add(Color.FromArgb(0x8f, 0x6f, 0xa4)); //15
            koloryFM.Add(Color.FromArgb(0x80, 0x73, 0xb2)); //16

            ustawKolory();

            fMblok1.UlozonyKolor = Color.FromArgb(0x37, 0x81, 0xc1); 
        }

        private void fMdrag2_Click(object sender, EventArgs e) {

        }

        private void ustawKolory() {
            List<Color> lista = koloryFM;
            lista.shuffle();

            foreach (Color clr in lista) {
                colorPalette1.Add(clr);
            }
           
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            obliczFM();
        }

        private void obliczFM() {
            // lista poprawnie ułożonych kolorów
            wzorcowe = new List<int>();
            wzorcowe.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());
            foreach (Color c in koloryFM) {
                wzorcowe.Add(c.ToArgb());
            }

            // lista wskazująca protanopię
            protanopia = new List<int>();
            protanopia.Add(wzorcowe.ElementAt(0));
            protanopia.Add(wzorcowe.ElementAt(15));
            protanopia.Add(wzorcowe.ElementAt(1));
            protanopia.Add(wzorcowe.ElementAt(14));
            protanopia.Add(wzorcowe.ElementAt(2));
            protanopia.Add(wzorcowe.ElementAt(13));
            protanopia.Add(wzorcowe.ElementAt(3));
            protanopia.Add(wzorcowe.ElementAt(12));
            protanopia.Add(wzorcowe.ElementAt(4));
            protanopia.Add(wzorcowe.ElementAt(11));
            protanopia.Add(wzorcowe.ElementAt(5));
            protanopia.Add(wzorcowe.ElementAt(10));
            protanopia.Add(wzorcowe.ElementAt(6));
            protanopia.Add(wzorcowe.ElementAt(9));
            protanopia.Add(wzorcowe.ElementAt(7));
            protanopia.Add(wzorcowe.ElementAt(8));


            // lista wskazująca na deuteranopie
            deuteranopia = new List<int>();
            deuteranopia.Add(wzorcowe.ElementAt(0));
            deuteranopia.Add(wzorcowe.ElementAt(1));
            deuteranopia.Add(wzorcowe.ElementAt(15));
            deuteranopia.Add(wzorcowe.ElementAt(2));
            deuteranopia.Add(wzorcowe.ElementAt(14));
            deuteranopia.Add(wzorcowe.ElementAt(3));
            deuteranopia.Add(wzorcowe.ElementAt(13));
            deuteranopia.Add(wzorcowe.ElementAt(4));
            deuteranopia.Add(wzorcowe.ElementAt(5));
            deuteranopia.Add(wzorcowe.ElementAt(12));
            deuteranopia.Add(wzorcowe.ElementAt(11));
            deuteranopia.Add(wzorcowe.ElementAt(6));
            deuteranopia.Add(wzorcowe.ElementAt(10));
            deuteranopia.Add(wzorcowe.ElementAt(7));
            deuteranopia.Add(wzorcowe.ElementAt(9));
            deuteranopia.Add(wzorcowe.ElementAt(8));

            // lista wskazująca na achromatyzm
            achromatyzm = new List<int>();
            achromatyzm.Add(wzorcowe.ElementAt(0));
            achromatyzm.Add(wzorcowe.ElementAt(1));
            achromatyzm.Add(wzorcowe.ElementAt(2));
            achromatyzm.Add(wzorcowe.ElementAt(3));
            achromatyzm.Add(wzorcowe.ElementAt(4));
            achromatyzm.Add(wzorcowe.ElementAt(5));
            achromatyzm.Add(wzorcowe.ElementAt(15));
            achromatyzm.Add(wzorcowe.ElementAt(6));
            achromatyzm.Add(wzorcowe.ElementAt(14));
            achromatyzm.Add(wzorcowe.ElementAt(13));
            achromatyzm.Add(wzorcowe.ElementAt(7));
            achromatyzm.Add(wzorcowe.ElementAt(12));
            achromatyzm.Add(wzorcowe.ElementAt(11));
            achromatyzm.Add(wzorcowe.ElementAt(8));
            achromatyzm.Add(wzorcowe.ElementAt(10));
            achromatyzm.Add(wzorcowe.ElementAt(9));

            // lista kolorów ułożonych przez pacjenta
            ulozone = new List<int>();

            ulozone.Add(fMblok1.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok2.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok3.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok4.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok5.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok6.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok7.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok8.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok9.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok10.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok11.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok12.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok13.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok14.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok15.UlozonyKolor.ToArgb());
            ulozone.Add(fMblok16.UlozonyKolor.ToArgb());

            // do zapisania do bazy danych
            double alfa12 = Similarity.levenshtein(ulozone, wzorcowe);
            double alfa13 = Similarity.levenshtein(ulozone, protanopia);
            double alfa14 = Similarity.levenshtein(ulozone, deuteranopia);
            double alfa15 = Similarity.levenshtein(ulozone, achromatyzm);

            MyDataBase myDataBase = new MyDataBase();
            myDataBase.open();

            Wynik wynik1 = new Wynik();
            wynik1.IdTestu = 10001;
            wynik1.Data = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            wynik1.Type = "FM";
            wynik1.WynikTestu = alfa12;
            myDataBase.addWynik(wynik1);

            Wynik wynik2 = new Wynik();
            wynik2.IdTestu = 10002;
            wynik2.Data = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            wynik2.Type = "FM";
            wynik2.WynikTestu = alfa13;
            myDataBase.addWynik(wynik2);


            Wynik wynik3 = new Wynik();
            wynik3.IdTestu = 10003;
            wynik3.Data = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            wynik3.Type = "FM";
            wynik3.WynikTestu = alfa14;
            myDataBase.addWynik(wynik3);


            Wynik wynik4 = new Wynik();
            wynik4.IdTestu = 10004;
            wynik4.Data = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            wynik4.Type = "FM";
            wynik4.WynikTestu = alfa15;
            myDataBase.addWynik(wynik4);

            myDataBase.close();
            this.Close();
            MessageBox.Show("Po kliknięciu przycisku nastąpi generowanie wyników, które może zająć kilka minut.", "Generowanie pliku!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Results results = new Results();
            results.Show();
            


        }
    }
}
