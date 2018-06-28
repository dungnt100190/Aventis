using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVermittlungVorschlag
    {
        public KaVermittlungVorschlag()
        {
            KaJobtimalVertrag = new HashSet<KaJobtimalVertrag>();
            KaVermittlungEinsatz = new HashSet<KaVermittlungEinsatz>();
            KaVermittlungSizwischenbericht = new HashSet<KaVermittlungSizwischenbericht>();
        }

        public int KaVermittlungVorschlagId { get; set; }
        public int? KaEinsatzplatzId { get; set; }
        public int? FaLeistungId { get; set; }
        public DateTime? Vorschlag { get; set; }
        public DateTime? DossierGesendet { get; set; }
        public DateTime? Vorstellungsgespraech { get; set; }
        public DateTime? SchnuppernVon { get; set; }
        public DateTime? SchnuppernBis { get; set; }
        public DateTime? VorschlagResultatDatum { get; set; }
        public int? VorschlagResultat { get; set; }
        public DateTime? VorschlagErfasst { get; set; }
        public int? VorschlagAblehnungsgrundBicode { get; set; }
        public int? VorschlagAblehnungsgrundBipcode { get; set; }
        public int? VorschlagAblehnungsgrundSicode { get; set; }
        public string VorschlagBemerkungen { get; set; }
        public bool? SichtbarSdflag { get; set; }
        public byte[] KaVermittlungVorschlagTs { get; set; }
        public int? MigrationKa { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public KaEinsatzplatz KaEinsatzplatz { get; set; }
        public ICollection<KaJobtimalVertrag> KaJobtimalVertrag { get; set; }
        public ICollection<KaVermittlungEinsatz> KaVermittlungEinsatz { get; set; }
        public ICollection<KaVermittlungSizwischenbericht> KaVermittlungSizwischenbericht { get; set; }
    }
}
