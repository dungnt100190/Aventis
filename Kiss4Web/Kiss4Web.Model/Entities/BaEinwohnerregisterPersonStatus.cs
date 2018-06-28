using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaEinwohnerregisterPersonStatus
    {
        public int BaEinwohnerregisterPersonStatusId { get; set; }
        public int BaPersonId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaEinwohnerregisterPersonStatusTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
