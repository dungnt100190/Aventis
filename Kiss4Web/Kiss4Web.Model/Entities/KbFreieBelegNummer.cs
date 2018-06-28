using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbFreieBelegNummer
    {
        public int KbBelegKreisId { get; set; }
        public int BelegNr { get; set; }
        public byte[] KbFreieBelegNummerTs { get; set; }

        public KbBelegKreis KbBelegKreis { get; set; }
    }
}
