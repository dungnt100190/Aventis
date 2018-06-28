using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaKurs
    {
        public KaKurs()
        {
            KaKurserfassung = new HashSet<KaKurserfassung>();
        }

        public int KaKursId { get; set; }
        public string Name { get; set; }
        public int Nr { get; set; }
        public int? AnzLektionen { get; set; }
        public int? Plaetze { get; set; }
        public int SektionCode { get; set; }
        public bool? ClosedFlag { get; set; }
        public byte[] KaKursTs { get; set; }

        public ICollection<KaKurserfassung> KaKurserfassung { get; set; }
    }
}
