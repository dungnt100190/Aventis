using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgPositionsartBuchungstext
    {
        public int BgPositionsartBuchungstextId { get; set; }
        public int BgPositionsartId { get; set; }
        public int? BgPositionsartIdUseText { get; set; }
        public string Buchungstext { get; set; }
        public bool Standardwert { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BgPositionsartBuchungstextTs { get; set; }

        public BgPositionsart BgPositionsart { get; set; }
        public BgPositionsart BgPositionsartIdUseTextNavigation { get; set; }
    }
}
