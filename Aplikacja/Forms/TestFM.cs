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

            fMblok1.ulozonyKolor = Color.FromArgb(0x37, 0x81, 0xc1); 
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
    }
}
