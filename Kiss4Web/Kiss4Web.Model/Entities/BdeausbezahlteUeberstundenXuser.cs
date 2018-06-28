using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdeausbezahlteUeberstundenXuser
    {
        public int BdeausbezahlteUeberstundenXuserId { get; set; }
        public int UserId { get; set; }
        public int Jahr { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public decimal AusbezahlteStd { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdeausbezahlteUeberstundenXuserTs { get; set; }

        public XUser User { get; set; }
    }
}
