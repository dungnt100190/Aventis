using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbZahlungseingang
    {
        public KbZahlungseingang()
        {
            KbBuchung = new HashSet<KbBuchung>();
        }

        public int KbZahlungseingangId { get; set; }
        public DateTime Datum { get; set; }
        public int? BaPersonId { get; set; }
        public int? BaInstitutionId { get; set; }
        public string Debitor { get; set; }
        public string KontoNr { get; set; }
        public decimal? Betrag { get; set; }
        public string Mitteilung1 { get; set; }
        public string Mitteilung2 { get; set; }
        public string Mitteilung3 { get; set; }
        public string Mitteilung4 { get; set; }
        public string Bemerkung { get; set; }
        public bool Ausgeglichen { get; set; }
        public bool Freigegeben { get; set; }
        public int? ZugeteiltUserId { get; set; }
        public int? ErstelltUserId { get; set; }
        public DateTime? ErstelltDatum { get; set; }
        public int? MutiertUserId { get; set; }
        public DateTime? MutiertDatum { get; set; }
        public byte[] KbZahlungseingangTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public XUser ErstelltUser { get; set; }
        public XUser MutiertUser { get; set; }
        public XUser ZugeteiltUser { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
    }
}
