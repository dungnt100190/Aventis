using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbBelegKreis
    {
        public KbBelegKreis()
        {
            KbBuchung = new HashSet<KbBuchung>();
            KbFreieBelegNummer = new HashSet<KbFreieBelegNummer>();
        }

        public int KbBelegKreisId { get; set; }
        public int KbPeriodeId { get; set; }
        public int KbBelegKreisCode { get; set; }
        public string KontoNr { get; set; }
        public int? NaechsteBelegNr { get; set; }
        public int? BelegNrVon { get; set; }
        public int? BelegNrBis { get; set; }
        public byte[] KbBelegKreisTs { get; set; }

        public KbKonto K { get; set; }
        public KbPeriode KbPeriode { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbFreieBelegNummer> KbFreieBelegNummer { get; set; }
    }
}
