using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Basis.ZH.Strassenverzeichnis
{
    public class BaStrasseHausDTO
    {
        //public int BaStrasseHausID { get; set; }
        public int BaStrasseID { get; set; }
        public string StrassenName{ get; set; }
        public int Hausnummer { get; set; }
        public string Suffix { get; set; }
        public string QuartierTeam { get; set; }
        public int PLZ{ get; set; }
        public int Kreis{ get; set; }
        public int Quartier{ get; set; }
        public int Zone{ get; set; }
        public int StatistischeZone{ get; set; }

        public int OrgUnitID_QT { get; set; }
        public string ParseError { get; set; }
    }
}
