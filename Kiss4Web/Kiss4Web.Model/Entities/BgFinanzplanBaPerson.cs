using System;

namespace Kiss4Web.Model
{
    public partial class BgFinanzplanBaPerson
    {
        public int BgFinanzplanId { get; set; }
        public int BaPersonId { get; set; }
        public bool? IstUnterstuetzt { get; set; }
        public int? BaZahlungswegId { get; set; }
        public string ReferenzNummer { get; set; }
        public int? KbKostenstelleId { get; set; }
        public int? KbKostenstelleIdKvg { get; set; }
        public int ShNrmVerrechnungsbasisId { get; set; }
        public string PrsNummerKanton { get; set; }
        public string PrsNummerHeimat { get; set; }
        public DateTime? NrmVerrechnungVon { get; set; }
        public DateTime? NrmVerrechnungBis { get; set; }
        public int? NrmVerrechnungsAnteilCode { get; set; }
        public bool IstAuslandCh { get; set; }
        public DateTime? AuslandChVon { get; set; }
        public DateTime? AuslandChBis { get; set; }
        public DateTime? AuslandChMeldungAm { get; set; }
        public string AuslandChReferenzNrBund { get; set; }
        public int? BurgergemeindeId { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BgFinanzplanBaPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaZahlungsweg BaZahlungsweg { get; set; }
        public BgFinanzplan BgFinanzplan { get; set; }
        public BaGemeinde Burgergemeinde { get; set; }
        public KbKostenstelle KbKostenstelle { get; set; }
        public KbKostenstelle KbKostenstelleIdKvgNavigation { get; set; }
    }
}