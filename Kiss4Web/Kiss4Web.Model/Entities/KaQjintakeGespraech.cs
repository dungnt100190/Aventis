using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjintakeGespraech
    {
        public int KaQjintakeGespraechId { get; set; }
        public int KaQjintakeId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaQjIntakePraesenzCode { get; set; }
        public int? KaQjIntakeEntscheidCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaQjintakeGespraechTs { get; set; }

        public KaQjintake KaQjintake { get; set; }
    }
}
