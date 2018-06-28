using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaPendenzgruppeUser
    {
        public int FaPendenzgruppeUserId { get; set; }
        public int FaPendenzgruppeId { get; set; }
        public int UserId { get; set; }
        public byte[] FaPendenzgruppeUserTs { get; set; }

        public FaPendenzgruppe FaPendenzgruppe { get; set; }
        public XUser User { get; set; }
    }
}
