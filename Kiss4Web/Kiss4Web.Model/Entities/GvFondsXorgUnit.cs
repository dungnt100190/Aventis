using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvFondsXorgUnit
    {
        public int GvFondsXorgUnitId { get; set; }
        public int GvFondsId { get; set; }
        public int OrgUnitId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvFondsXorgUnitTs { get; set; }

        public GvFonds GvFonds { get; set; }
        public XOrgUnit OrgUnit { get; set; }
    }
}
