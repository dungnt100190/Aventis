using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbOpAusgleich
    {
        public KbOpAusgleich()
        {
            KbForderungAuszahlung = new HashSet<KbForderungAuszahlung>();
        }

        public int KbOpAusgleichId { get; set; }
        public int OpBuchungId { get; set; }
        public int AusgleichBuchungId { get; set; }
        public decimal Betrag { get; set; }
        public byte[] KbOpAusgleichTs { get; set; }
        public int? MigAiZahlungVsForderungId { get; set; }

        public KbBuchung AusgleichBuchung { get; set; }
        public KbBuchung OpBuchung { get; set; }
        public ICollection<KbForderungAuszahlung> KbForderungAuszahlung { get; set; }
    }
}
