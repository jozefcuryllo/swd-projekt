using Aplikacja.Helpers;
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
        private List<Images> images;
        private int indexOfImage;
        private Images image;

        public TestIshihary()
        {
            InitializeComponent();
            images = new List<Images>();
            indexOfImage = 0;

            String sql = "SELECT * FROM \"" + Images.IMAGE_TABLE_NAME + "\" LIMIT 40";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            MyDataBase myDataBase = new MyDataBase();
            myDataBase.open();
            System.Data.SQLite.SQLiteDataReader sqlReader = myDataBase.query(sql);
            while (sqlReader.Read())
            {
                Images image = new Images();
                image.Id = int.Parse(sqlReader[Images.IMAGE_ID].ToString());
                image.Name = (String)sqlReader[Images.IMAGE_NAME].ToString();
                image.Type = (String)sqlReader[Images.IMAGE_TYPE].ToString();
                image.Value = (String)sqlReader[Images.IMAGE_VALUE].ToString();

                images.Add(image);
            }
            myDataBase.close();
            Shuffle.shuffle(images);
            setImage(images.First());
        }


        private void setImage(Images image) {

            try
            {
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Images\" + image.Name);
                this.image = image;
                this.indexOfImage++;
            }
            catch (Exception)
            {
                MessageBox.Show("Nie znaleziono obrazu!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wynik wynik = new Wynik();
           // wynik.Id = 0; // jest AUTOINCREMENT
            wynik.IdTestu = 0; // obecnie nieużywane
            wynik.Type = image.Type;
            wynik.WynikTestu = image.Value == textBox1.Text ? 1 : 0; // jeśli wartość wzorcowa jest równa podanej przez pacjenta to wynik = 1, inaczej = 0; 
            wynik.Data = DateTime.Today.ToShortDateString() +" "+ DateTime.Now.ToLongTimeString();

            MyDataBase myDataBase = new MyDataBase();
            myDataBase.open();
            myDataBase.addWynik(wynik);
            myDataBase.close();

            if (indexOfImage < images.Count) {
                setImage(images.ElementAt(indexOfImage));
            }
        }
    }
}
