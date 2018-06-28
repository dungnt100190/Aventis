using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistBdeferienkuerzungenXuser
    {
        public int UserId { get; set; }
        public int Jahr { get; set; }
        public decimal FerienkuerzungStd { get; set; }
        public bool ManualEdit { get; set; }
        public int VerId { get; set; }
        public int? VerIdDeleted { get; set; }
    }
}
