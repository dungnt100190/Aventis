using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbForderungAuszahlung
    {
        public int KbForderungAuszahlungId { get; set; }
        public int KbBuchungIdAuszahlung { get; set; }
        public int KbBuchungIdForderung { get; set; }
        public int? KbOpAusgleichId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KbForderungAuszahlungTs { get; set; }

        public KbBuchung KbBuchungIdAuszahlungNavigation { get; set; }
        public KbBuchung KbBuchungIdForderungNavigation { get; set; }
        public KbOpAusgleich KbOpAusgleich { get; set; }
    }
}
