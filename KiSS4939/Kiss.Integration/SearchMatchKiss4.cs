using System.Collections;
using KiSS4.Main;

namespace Kiss.Integration
{
    public class SearchMatchKiss4
    {
        public int? BaPersonID { get; set; }

        public string Beschreibung { get; set; }

        public int? FaFallID { get; set; }

        public int? FaLeistungID { get; set; }

        public int ID { get; set; }

        public string JumpToPath { get; set; }

        public IDictionary ParmDictionary { get; set; }

        public int? ModulID { get; set; }

        public int Typ { get; set; }
    }
}