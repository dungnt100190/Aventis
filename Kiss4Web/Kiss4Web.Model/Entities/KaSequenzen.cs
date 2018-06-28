using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaSequenzen
    {
        public int KaSequenzenId { get; set; }
        public int BaPersonId { get; set; }
        public int? SequenzCode { get; set; }
        public int? PraesenzCode { get; set; }
        public bool? SichtbarSdflag { get; set; }
        public byte[] KaSequenzenTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
