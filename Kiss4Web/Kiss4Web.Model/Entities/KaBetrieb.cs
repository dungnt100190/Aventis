using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaBetrieb
    {
        public KaBetrieb()
        {
            BaAdresse = new HashSet<BaAdresse>();
            KaBetriebBesprechung = new HashSet<KaBetriebBesprechung>();
            KaBetriebDokument = new HashSet<KaBetriebDokument>();
            KaBetriebKontakt = new HashSet<KaBetriebKontakt>();
            KaEinsatzplatz = new HashSet<KaEinsatzplatz>();
        }

        public int KaBetriebId { get; set; }
        public string BetriebName { get; set; }
        public int? OrganisationTypCodeObsolete { get; set; }
        public int? DmgAdresseIdObsolete { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SprachCode { get; set; }
        public string Bemerkung { get; set; }
        public bool? Aktiv { get; set; }
        public string Homepage { get; set; }
        public string KontaktPersonObsolete { get; set; }
        public byte[] KaBetriebTs { get; set; }
        public int? TeilbetriebId { get; set; }
        public int? CharakterCode { get; set; }
        public bool? InAusbildungsverbund { get; set; }
        public int? MigrationKa { get; set; }

        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<KaBetriebBesprechung> KaBetriebBesprechung { get; set; }
        public ICollection<KaBetriebDokument> KaBetriebDokument { get; set; }
        public ICollection<KaBetriebKontakt> KaBetriebKontakt { get; set; }
        public ICollection<KaEinsatzplatz> KaEinsatzplatz { get; set; }
    }
}
