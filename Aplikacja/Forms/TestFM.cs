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
            koloryFM.Add(Color.FromArgb(0x37, 0x85, 0x9c)); //2
            koloryFM.Add(Color.FromArgb(0x8f, 0x6f, 0xa4)); //3
            koloryFM.Add(Color.FromArgb(0x3b, 0x86, 0x90)); //4  #3B8690 
            koloryFM.Add(Color.FromArgb(0x35, 0x83, 0xb4)); //5  #3583B4
            koloryFM.Add(Color.FromArgb(0x92, 0x70, 0x99)); //6  #927099
            koloryFM.Add(Color.FromArgb(0x6c, 0x81, 0x64)); //7  #6C8164
            koloryFM.Add(Color.FromArgb(0x3b, 0x84, 0xa7)); //8  #3B84A7
            koloryFM.Add(Color.FromArgb(0x9e, 0x6e, 0x6f)); //9  #9E6E6F
            koloryFM.Add(Color.FromArgb(0x9f, 0x6d, 0x7c)); //10 #9F6D7C
            koloryFM.Add(Color.FromArgb(0x90, 0x76, 0x60)); //11 #907660
            koloryFM.Add(Color.FromArgb(0x83, 0x7b, 0x5d)); //12 #837B5D
            koloryFM.Add(Color.FromArgb(0x69, 0x84, 0x73)); //13 #698473
            koloryFM.Add(Color.FromArgb(0x9c, 0x6d, 0x89)); //14 #9C6D89
            koloryFM.Add(Color.FromArgb(0x3f, 0x87, 0x82)); //15
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
            foreach(Color c in koloryFM) {
                wzorcowe.Add(c.ToArgb());
            }
            wzorcowe.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb()); // 1)

            // lista wskazująca protanopię
            protanopia = new List<int>();
            protanopia.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());// 1
            protanopia.Add(Color.FromArgb(0x80, 0x73, 0xb2).ToArgb()); //16
            protanopia.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb()); //2
            protanopia.Add(Color.FromArgb(0x3f, 0x87, 0x82).ToArgb()); //15
            protanopia.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb()); //3
            protanopia.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb()); //14
            protanopia.Add(Color.FromArgb(0x3b, 0x86, 0x90).ToArgb()); //4
            protanopia.Add(Color.FromArgb(0x69, 0x84, 0x73).ToArgb()); //13 +
            protanopia.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb()); //5
            protanopia.Add(Color.FromArgb(0x83, 0x7b, 0x5d).ToArgb()); //12
            protanopia.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb()); //6
            protanopia.Add(Color.FromArgb(0x90, 0x76, 0x60).ToArgb()); //11
            protanopia.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb()); //7
            protanopia.Add(Color.FromArgb(0x9f, 0x6d, 0x7c).ToArgb()); //10
            protanopia.Add(Color.FromArgb(0x3b, 0x84, 0xa7).ToArgb()); //8
            protanopia.Add(Color.FromArgb(0x9e, 0x6e, 0x6f).ToArgb());// 9

            // lista wskazująca na deuteranopie
            deuteranopia = new List<int>();
            deuteranopia.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb()); //1
            deuteranopia.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb());// 2
            deuteranopia.Add(Color.FromArgb(0x80, 0x73, 0xb2).ToArgb()); //16
            deuteranopia.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb()); //3
            deuteranopia.Add(Color.FromArgb(0x3f, 0x87, 0x82).ToArgb());// 15
            deuteranopia.Add(Color.FromArgb(0x3b, 0x86, 0x90).ToArgb());// 4
            deuteranopia.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb()); //14
            deuteranopia.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb()); //5
            deuteranopia.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb()); //6
            deuteranopia.Add(Color.FromArgb(0x69, 0x84, 0x73).ToArgb()); //13 +
            deuteranopia.Add(Color.FromArgb(0x83, 0x7b, 0x5d).ToArgb()); //12
            deuteranopia.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb());// 7
            deuteranopia.Add(Color.FromArgb(0x90, 0x76, 0x60).ToArgb());// 11
            deuteranopia.Add(Color.FromArgb(0x3b, 0x84, 0xa7).ToArgb());// 8 +
            deuteranopia.Add(Color.FromArgb(0x9f, 0x6d, 0x7c).ToArgb());// 10
            deuteranopia.Add(Color.FromArgb(0x9e, 0x6e, 0x6f).ToArgb()); //9

            // lista wskazująca na achromatyzm
            achromatyzm = new List<int>();
            achromatyzm.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());// 1
            achromatyzm.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb());// 2
            achromatyzm.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb()); //3
            achromatyzm.Add(Color.FromArgb(0x3b, 0x86, 0x90).ToArgb());// 4
            achromatyzm.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb());// 5
            achromatyzm.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb());// 6
            achromatyzm.Add(Color.FromArgb(0x80, 0x73, 0xb2).ToArgb());// 16
            achromatyzm.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb());// 7
            achromatyzm.Add(Color.FromArgb(0x3f, 0x87, 0x82).ToArgb()); //15
            achromatyzm.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb()); //14
            achromatyzm.Add(Color.FromArgb(0x3b, 0x84, 0xa7).ToArgb()); //8
            achromatyzm.Add(Color.FromArgb(0x69, 0x84, 0x73).ToArgb()); //13
            achromatyzm.Add(Color.FromArgb(0x83, 0x7b, 0x5d).ToArgb()); //12
            achromatyzm.Add(Color.FromArgb(0x9e, 0x6e, 0x6f).ToArgb());// 9
            achromatyzm.Add(Color.FromArgb(0x90, 0x76, 0x60).ToArgb()); //11
            achromatyzm.Add(Color.FromArgb(0x9f, 0x6d, 0x7c).ToArgb()); //10



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
