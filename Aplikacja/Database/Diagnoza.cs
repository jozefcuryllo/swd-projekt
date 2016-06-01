using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja.Database {
    class Diagnoza {
        public static readonly String DIAGNOZA_TABLE_NAME = "diagnoza";
        public static readonly String DIAGNOZA_COLUMN_ID = "_id";
        public static readonly String DIAGNOZA_COLUMN_MONOCHROMATYZM = "mono";
        public static readonly String DIAGNOZA_COLUMN_ZABURZENIA_CZERW_ZIEL = "redgreen";
        public static readonly String DIAGNOZA_COLUMN_PROTANOPIA = "protanopia";
        public static readonly String DIAGNOZA_COLUMN_PROTANOMALIA = "protanomalia";
        public static readonly String DIAGNOZA_COLUMN_DEUTERANOPIA = "deuteranopia";
        public static readonly String DIAGNOZA_COLUMN_DEUTERANOMALIA = "deuteranomalia";
        public static readonly String DIAGNOZA_COLUMN_PACJENT_ZDROWY = "zdrowy";
        public static readonly String DIAGNOZA_COLUMN_PRAWDOPODOBIENSTWO = "prawd";

        private int id;
        private double monochromatyzm;
        private double czerwonyzielony;
        private double protanopia;
        private double protanomalia;
        private double deuteranopia;
        private double deuteranomalia;
        private double zdrowy;
        private double prawdopodobienstwo;

        public int Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        public double Monochromatyzm {
            get {
                return monochromatyzm;
            }

            set {
                monochromatyzm = value;
            }
        }

        public double Czerwonyzielony {
            get {
                return czerwonyzielony;
            }

            set {
                czerwonyzielony = value;
            }
        }

        public double Protanopia {
            get {
                return protanopia;
            }

            set {
                protanopia = value;
            }
        }

        public double Protanomalia {
            get {
                return protanomalia;
            }

            set {
                protanomalia = value;
            }
        }

        public double Deuteranopia {
            get {
                return deuteranopia;
            }

            set {
                deuteranopia = value;
            }
        }

        public double Deuteranomalia {
            get {
                return deuteranomalia;
            }

            set {
                deuteranomalia = value;
            }
        }

        public double Zdrowy {
            get {
                return zdrowy;
            }

            set {
                zdrowy = value;
            }
        }

        public double Prawdopodobienstwo {
            get {
                return prawdopodobienstwo;
            }

            set {
                prawdopodobienstwo = value;
            }
        }
    }
}
