using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdeferienkuerzungenXuser
    {
        public int UserId { get; set; }
        public int Jahr { get; set; }
        public decimal FerienkuerzungStd { get; set; }
        public bool ManualEdit { get; set; }
        public byte[] BdeferienkuerzungenXuserTs { get; set; }
        public int? VerId { get; set; }

        public XUser User { get; set; }
    }
}
