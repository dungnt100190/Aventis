using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaKopfquote
    {
        public int BaKopfquoteId { get; set; }
        public int? BaPersonId { get; set; }
        public DateTime RechnungDatum { get; set; }
        public decimal? Betrag { get; set; }
        public string Zeitspanne { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BaKopfquoteTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
