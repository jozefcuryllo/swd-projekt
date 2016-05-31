using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja.Database {
    class Ustawienia {
        public readonly static String USTAWIENIA_TABLE_NAME = "ustawienia";
        public readonly static String USTAWIENIA_COLUMN_ID = "_id";
        public readonly static String USTAWIENIA_COLUMN_KLUCZ = "klucz";
        public readonly static String USTAWIENIA_COLUMN_WARTOSC = "wartosc";

        private int id;
        private String klucz;
        private String wartosc;

        public Ustawienia(int id, string klucz, string wartosc) {
            this.id = id;
            this.klucz = klucz;
            this.wartosc = wartosc;
        }

        public int Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        public string Klucz {
            get {
                return klucz;
            }

            set {
                klucz = value;
            }
        }

        public string Wartosc {
            get {
                return wartosc;
            }

            set {
                wartosc = value;
            }
        }
    }
}
