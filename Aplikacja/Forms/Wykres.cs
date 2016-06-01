using Aplikacja.Database;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
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
    public partial class Wykres : Form {

        PlotModel myModel;
        double a1 = 0;
        double a2 = 0;
        double a3 = 0;
        double a4 = 0;
        double a5 = 0;
        double a6 = 0;
        double a7 = 0;

        public Wykres() {
            InitializeComponent();

            myModel = new PlotModel { Title = "Prawdopodobieństwo poszczególnych diagnoz" };
            List<String> a = new List<string>();
            a.Add("Monochromatyzm");
            a.Add("Protanopia");
            a.Add("Protanomalia");
            a.Add("Deuteranopia");
            a.Add("Deuteranomalia");
            a.Add("Zaburzenia czerwony/zielony");
            a.Add("Brak wady");
            plot1.Model = myModel;
            CategoryAxis ca = new CategoryAxis();
            ca.ItemsSource = a;
            myModel.Axes.Add( ca );

            zrobWykres();
        }

        private void zrobWykres() {
            ColumnSeries seria1 = new ColumnSeries();
            myModel.Series.Add(seria1);

            policzDoWykresu();


            seria1.Items.Add(new ColumnItem(a1 * 100));
            seria1.Items.Add(new ColumnItem(a2 * 100));
            seria1.Items.Add(new ColumnItem(a3 * 100));
            seria1.Items.Add(new ColumnItem(a4 * 100));
            seria1.Items.Add(new ColumnItem(a5 * 100));
            seria1.Items.Add(new ColumnItem(a6 * 100));
            seria1.Items.Add(new ColumnItem(a7 * 100));

        }

        private void policzDoWykresu() {
            String sql = "SELECT * FROM " + Diagnoza.DIAGNOZA_TABLE_NAME;
            MyDataBase myDataBase = new MyDataBase();
            myDataBase.open();
            int licznik = 0;
            SQLiteDataReader reader = myDataBase.query(sql);
            while (reader.Read()) {
                double prawd = (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PRAWDOPODOBIENSTWO];
                a1 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_MONOCHROMATYZM] * prawd;
                a2 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PROTANOPIA] * prawd;
                a3 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PROTANOMALIA] * prawd;
                a4 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_DEUTERANOPIA] * prawd;
                a5 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_DEUTERANOMALIA] * prawd;
                a6 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_ZABURZENIA_CZERW_ZIEL] * prawd;
                a7 += (Double)reader[Diagnoza.DIAGNOZA_COLUMN_PACJENT_ZDROWY] * prawd;
                licznik++;
            }

            a1 /= licznik;
            a2 /= licznik;
            a3 /= licznik;
            a4 /= licznik;
            a5 /= licznik;
            a6 /= licznik;
            a7 /= licznik;


        }
    }
}
