using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkBetreibungAusgleich
    {
        public int IkBetreibungAusgleichId { get; set; }
        public int IkBetreibungId { get; set; }
        public int AusgleichBuchungId { get; set; }
        public decimal Betrag { get; set; }
        public byte[] IkBetreibungAusgleichTs { get; set; }

        public KbBuchung AusgleichBuchung { get; set; }
        public IkBetreibung IkBetreibung { get; set; }
    }
}
