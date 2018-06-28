using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaBank
    {
        public BaBank()
        {
            BaZahlungsweg = new HashSet<BaZahlungsweg>();
            FbDtazugang = new HashSet<FbDtazugang>();
            FbZahlungsweg = new HashSet<FbZahlungsweg>();
            KbBuchung = new HashSet<KbBuchung>();
            KbZahlungskonto = new HashSet<KbZahlungskonto>();
        }

        public int BaBankId { get; set; }
        public int? LandCode { get; set; }
        public string Name { get; set; }
        public string Zusatz { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string ClearingNr { get; set; }
        public string ClearingNrNeu { get; set; }
        public int FilialeNr { get; set; }
        public string HauptsitzBcl { get; set; }
        public string PckontoNr { get; set; }
        public DateTime GueltigAb { get; set; }
        public bool SicUpdated { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaBankTs { get; set; }

        public BaLand LandCodeNavigation { get; set; }
        public ICollection<BaZahlungsweg> BaZahlungsweg { get; set; }
        public ICollection<FbDtazugang> FbDtazugang { get; set; }
        public ICollection<FbZahlungsweg> FbZahlungsweg { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbZahlungskonto> KbZahlungskonto { get; set; }
    }
}
