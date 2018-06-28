using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbBuchungskreis
    {
        public int FbBuchungskreisId { get; set; }
        public int FbBuchungskreisCode { get; set; }
        public int BaPersonId { get; set; }
        public DateTime? BuchungsDatum { get; set; }
        public int SollKtoNr { get; set; }
        public int HabenKtoNr { get; set; }
        public decimal? Betrag { get; set; }
        public string Text { get; set; }
        public byte[] FbBuchungskreisTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
