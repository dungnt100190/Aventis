using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaBetriebKontakt
    {
        public KaBetriebKontakt()
        {
            BaAdresse = new HashSet<BaAdresse>();
            KaEinsatzplatz = new HashSet<KaEinsatzplatz>();
        }

        public int KaBetriebKontaktId { get; set; }
        public int? KaBetriebId { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Funktion { get; set; }
        public int? GeschlechtCode { get; set; }
        public bool? Aktiv { get; set; }
        public string Telefon { get; set; }
        public string TelefonMobil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Bemerkung { get; set; }
        public byte[] KaBetriebKontaktTs { get; set; }
        public bool UseZusatzadresse { get; set; }

        public KaBetrieb KaBetrieb { get; set; }
        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<KaEinsatzplatz> KaEinsatzplatz { get; set; }
    }
}
