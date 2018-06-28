using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvAuszahlungPositionValuta
    {
        public int GvAuszahlungPositionValutaId { get; set; }
        public int GvAuszahlungPositionId { get; set; }
        public DateTime Datum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvAuszahlungPositionValutaTs { get; set; }

        public GvAuszahlungPosition GvAuszahlungPosition { get; set; }
    }
}
