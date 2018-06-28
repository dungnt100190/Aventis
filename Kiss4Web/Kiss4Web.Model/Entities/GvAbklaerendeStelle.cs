using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvAbklaerendeStelle
    {
        public int GvAbklaerendeStelleId { get; set; }
        public int GvGesuchId { get; set; }
        public int? BaZahlungswegId { get; set; }
        public string BeantragendeStelle { get; set; }
        public string Kontaktperson { get; set; }
        public string Strasse { get; set; }
        public string HausNr { get; set; }
        public string Zusatz { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Kanton { get; set; }
        public string Postfach { get; set; }
        public bool PostfachOhneNr { get; set; }
        public string Region { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Bemerkungen { get; set; }
        public string MitteilungZeile1 { get; set; }
        public string MitteilungZeile2 { get; set; }
        public string MitteilungZeile3 { get; set; }
        public string MitteilungZeile4 { get; set; }
        public string Zahlungsinstruktion { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvAbklaerendeStelleTs { get; set; }

        public BaZahlungsweg BaZahlungsweg { get; set; }
        public GvGesuch GvGesuch { get; set; }
    }
}
