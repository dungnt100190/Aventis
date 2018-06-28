using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbBuchungCode
    {
        public int FbBuchungCodeId { get; set; }
        public string Code { get; set; }
        public int? BaPersonId { get; set; }
        public int? SollKtoNr { get; set; }
        public int? HabenKtoNr { get; set; }
        public decimal? Betrag { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public byte[] FbBuchungCodeTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public XUser User { get; set; }
    }
}
