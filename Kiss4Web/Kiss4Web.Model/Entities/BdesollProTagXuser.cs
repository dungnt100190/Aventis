using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdesollProTagXuser
    {
        public int BdesollProTagXuserId { get; set; }
        public int UserId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public decimal SollStundenProTag { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdesollProTagXuserTs { get; set; }

        public XUser User { get; set; }
    }
}
