using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaExterneBildungZahlung
    {
        public int KaExterneBildungZahlungId { get; set; }
        public int? KaExterneBildungId { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Betrag { get; set; }
        public string Zweck { get; set; }
        public byte[] KaExterneBildungZahlungTs { get; set; }

        public KaExterneBildung KaExterneBildung { get; set; }
    }
}
