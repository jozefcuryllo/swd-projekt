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
            // pierwszy kolor jest już ułożony poprawnie, więc go nie bierzemy pod uwagę
            //koloryFM.Add(Color.FromArgb(0x37, 0x81, 0xc1));
            koloryFM.Add(Color.FromArgb(0x37, 0x85, 0x9c));
            koloryFM.Add(Color.FromArgb(0x8f, 0x6f, 0xa4));
            koloryFM.Add(Color.FromArgb(0x35, 0x83, 0xb4));
            koloryFM.Add(Color.FromArgb(0x92, 0x70, 0x99));
            koloryFM.Add(Color.FromArgb(0x6c, 0x81, 0x64));
            koloryFM.Add(Color.FromArgb(0x3b, 0x84, 0xa7));
            koloryFM.Add(Color.FromArgb(0x9e, 0x6e, 0x6f));
            koloryFM.Add(Color.FromArgb(0x9f, 0x6d, 0x7c));
            koloryFM.Add(Color.FromArgb(0x90, 0x76, 0x60));
            koloryFM.Add(Color.FromArgb(0x83, 0x7b, 0x5d));
            koloryFM.Add(Color.FromArgb(0x69, 0x84, 0x73));
            koloryFM.Add(Color.FromArgb(0x9c, 0x6d, 0x89));
            koloryFM.Add(Color.FromArgb(0x3f, 0x87, 0x82));
            koloryFM.Add(Color.FromArgb(0x80, 0x73, 0xb2));

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

            // lista wskazująca protanopię
            protanopia = new List<int>();
            protanopia.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());
            protanopia.Add(Color.FromArgb(0x80, 0x73, 0xb2).ToArgb());
            protanopia.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb());
            protanopia.Add(Color.FromArgb(0x3f, 0x87, 0x82).ToArgb());
            protanopia.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb());
            protanopia.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb());
            protanopia.Add(Color.FromArgb(0x3b, 0x86, 0x90).ToArgb());
            protanopia.Add(Color.FromArgb(0x96, 0x84, 0x73).ToArgb());
            protanopia.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb());
            protanopia.Add(Color.FromArgb(0x83, 0x7b, 0x5d).ToArgb());
            protanopia.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb());
            protanopia.Add(Color.FromArgb(0x90, 0x76, 0x60).ToArgb());
            protanopia.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb());
            protanopia.Add(Color.FromArgb(0x9f, 0x6d, 0x7c).ToArgb());
            protanopia.Add(Color.FromArgb(0x3b, 0x84, 0xa7).ToArgb());
            protanopia.Add(Color.FromArgb(0x9e, 0x6e, 0x6f).ToArgb());

            // lista wskazująca na deuteranopie
            deuteranopia.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x80, 0x73, 0xb2).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x3f, 0x87, 0x82).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x3b, 0x86, 0x90).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x9c, 0x6d, 0x89).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x83, 0x7b, 0x5d).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x90, 0x76, 0x60).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x3b, 0xb4, 0xa7).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x9f, 0x6d, 0x7c).ToArgb());
            deuteranopia.Add(Color.FromArgb(0x9e, 0x6e, 0x6f).ToArgb());

            // lista wskazująca na achromatyzm
            achromatyzm.Add(Color.FromArgb(0x37, 0x81, 0xc1).ToArgb());
            achromatyzm.Add(Color.FromArgb(0x37, 0x85, 0x9c).ToArgb());
            achromatyzm.Add(Color.FromArgb(0x8f, 0x6f, 0xa4).ToArgb());
            achromatyzm.Add(Color.FromArgb(0x35, 0x83, 0xb4).ToArgb());
            achromatyzm.Add(Color.FromArgb(0x92, 0x70, 0x99).ToArgb());
            achromatyzm.Add(Color.FromArgb(0x6c, 0x81, 0x64).ToArgb());
           // achromatyzm.Add(Color.FromArgb(0x, 0x, 0x).ToArgb());

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

            double alfa12 = Similarity.levenshtein(wzorcowe, ulozone);
            double alfa13 = Similarity.levenshtein(ulozone, protanopia);
            double alfa14 = Similarity.levenshtein(ulozone, deuteranopia);
            double alfa15 = Similarity.levenshtein(ulozone, achromatyzm);


        }
    }
}
