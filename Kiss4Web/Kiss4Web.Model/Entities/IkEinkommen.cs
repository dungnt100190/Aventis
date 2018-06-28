using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkEinkommen
    {
        public int IkEinkommenId { get; set; }
        public int IkRechtstitelId { get; set; }
        public int BaPersonId { get; set; }
        public int IkEinkommenTypCode { get; set; }
        public DateTime GueltigVon { get; set; }
        public DateTime? GueltigBis { get; set; }
        public decimal Betrag { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkEinkommenTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
    }
}
