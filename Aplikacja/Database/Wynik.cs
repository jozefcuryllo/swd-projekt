using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    class Wynik
    {
        public static readonly String NAME_TABLE = "wyniki";
        public static readonly String NAME_ID = "id";
        public static readonly String NAME_IDTESTU = "idTestu";
        public static readonly String NAME_WYNIK = "wynik";
        public static readonly String NAME_DATA = "data";

        private int id;
        private int idTestu;
        private float wynikTestu;
        private String data;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int IdTestu
        {
            get
            {
                return idTestu;
            }

            set
            {
                idTestu = value;
            }
        }

        public float WynikTestu
        {
            get
            {
                return wynikTestu;
            }

            set
            {
                wynikTestu = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }
}
