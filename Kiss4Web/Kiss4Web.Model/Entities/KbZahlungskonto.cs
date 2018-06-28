using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbZahlungskonto
    {
        public KbZahlungskonto()
        {
            GvFonds = new HashSet<GvFonds>();
            KbBuchung = new HashSet<KbBuchung>();
            KbKonto = new HashSet<KbKonto>();
            KbZahlungskontoXorgUnit = new HashSet<KbZahlungskontoXorgUnit>();
            KbZahlungslauf = new HashSet<KbZahlungslauf>();
        }

        public int KbZahlungskontoId { get; set; }
        public string Name { get; set; }
        public string VertragNr { get; set; }
        public string KontoNr { get; set; }
        public int? BaBankId { get; set; }
        public int KbFinanzInstitutCode { get; set; }
        public byte[] KbDtazugangTs { get; set; }

        public BaBank BaBank { get; set; }
        public ICollection<GvFonds> GvFonds { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbKonto> KbKonto { get; set; }
        public ICollection<KbZahlungskontoXorgUnit> KbZahlungskontoXorgUnit { get; set; }
        public ICollection<KbZahlungslauf> KbZahlungslauf { get; set; }
    }
}
