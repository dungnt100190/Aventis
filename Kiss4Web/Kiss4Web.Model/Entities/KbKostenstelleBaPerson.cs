using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbKostenstelleBaPerson
    {
        public int KbKostenstelleBaPersonId { get; set; }
        public int BaPersonId { get; set; }
        public int KbKostenstelleId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KbKostenstelleBaPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public KbKostenstelle KbKostenstelle { get; set; }
    }
}
