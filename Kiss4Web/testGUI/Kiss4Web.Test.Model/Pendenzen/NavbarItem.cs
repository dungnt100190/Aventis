using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss4Web.Test.Model.Pendenzen
{
    public class NavbarItem
    {
        public int ItmMeineFaellig { get; set; }
        public int ItmMeineOffen { get; set; }
        public int ItmMeineInBearbeitung { get; set; }
        public int ItmMeineErstellt { get; set; }
        public int ItmMeineErhalten { get; set; }
        public int ItmMeineZuVisieren { get; set; }
        public int ItmVersandteFaellig { get; set; }
        public int ItmVersandteZuVisieren { get; set; }
        public int ItmVersandteAllgemein { get; set; }
        public int ItmVersandteOffen { get; set; }
    }
}
