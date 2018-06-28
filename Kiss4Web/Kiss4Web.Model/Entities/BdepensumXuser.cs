using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdepensumXuser
    {
        public int BdepensumXuserId { get; set; }
        public int UserId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int PensumProzent { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdepensumXuserTs { get; set; }

        public XUser User { get; set; }
    }
}
