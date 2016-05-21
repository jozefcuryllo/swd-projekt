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
        public static readonly String NAME_ID = "_id";
        public static readonly String NAME_IDTESTU = "idTestu";
        public static readonly String NAME_WYNIK = "wynik";
        public static readonly String NAME_TYPE = "type";
        public static readonly String NAME_DATA = "data";

        private int id;
        private int idTestu;
        private Double wynikTestu;
        private String type;
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

        public Double WynikTestu
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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
