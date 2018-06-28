using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbTransfer
    {
        public int KbBuchungId { get; set; }
        public int KbZahlungslaufId { get; set; }
        public int KbTransferStatusCode { get; set; }
        public byte[] KbTransferTs { get; set; }

        public KbBuchung KbBuchung { get; set; }
        public KbZahlungslauf KbZahlungslauf { get; set; }
    }
}
