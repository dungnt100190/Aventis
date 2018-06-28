using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaKurserfassung
    {
        public KaKurserfassung()
        {
            KaAbklaerungVertieft = new HashSet<KaAbklaerungVertieft>();
            KaIntegBildung = new HashSet<KaIntegBildung>();
        }

        public int KaKurserfassungId { get; set; }
        public int KursId { get; set; }
        public string KursNr { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public bool? SistiertFlag { get; set; }
        public byte[] KaKurserfassungTs { get; set; }

        public KaKurs Kurs { get; set; }
        public ICollection<KaAbklaerungVertieft> KaAbklaerungVertieft { get; set; }
        public ICollection<KaIntegBildung> KaIntegBildung { get; set; }
    }
}
