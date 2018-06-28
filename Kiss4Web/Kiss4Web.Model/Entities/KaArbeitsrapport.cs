using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaArbeitsrapport
    {
        public int KaArbeitsrapportId { get; set; }
        public int BaPersonId { get; set; }
        public int KaEinsatzId { get; set; }
        public DateTime? Datum { get; set; }
        public int? AmAnwCode { get; set; }
        public float? AmStd { get; set; }
        public string AmBemerkung { get; set; }
        public int? PmAnwCode { get; set; }
        public float? PmStd { get; set; }
        public string PmBemerkung { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaArbeitsrapportTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
