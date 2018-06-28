using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bdezeitrechner
    {
        public int BdezeitrechnerId { get; set; }
        public int UserId { get; set; }
        public DateTime Datum { get; set; }
        public DateTime ZeitVon { get; set; }
        public DateTime? ZeitBis { get; set; }
        public DateTime? Verbucht { get; set; }
        public byte[] BdezeitrechnerTs { get; set; }

        public XUser User { get; set; }
    }
}
