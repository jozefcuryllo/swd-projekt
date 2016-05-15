using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    class Images
    {
        // Nazwa tabeli
        public static readonly String IMAGE_TABLE_NAME = "images";

        // ID rekordu
        public static readonly String IMAGE_ID = "_id";

        // Nazwa pliku wraz z roszerzeniem
        public static readonly String IMAGE_NAME = "name";

        // Poprawna wartość liczby/tekstu pokazanego na teście Ishihary
        public static readonly String IMAGE_VALUE = "value";

        // Badana cecha wzroku (np. "czerwony" jako zdolność do rozpoznawania barwy czerwonej)
        public static readonly String IMAGE_TYPE = "type";

        private int id;

        private String name;

        private String value;

        private String type;

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

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

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

        public Images() {
        }

        public Images(int id, String name, String value, String type) {
            this.Id = id;
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }
    
    }
}
