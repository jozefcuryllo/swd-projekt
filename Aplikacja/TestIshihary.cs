using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    public partial class TestIshihary : Form
    {
       
        public TestIshihary()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            try {
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Images\1.png");
            }
            catch(Exception e)
            {
                MessageBox.Show("Nie znaleziono obrazu!");
            }
        }


    }
}
