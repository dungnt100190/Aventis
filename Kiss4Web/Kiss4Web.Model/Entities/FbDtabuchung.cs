using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbDtabuchung
    {
        public int FbBuchungId { get; set; }
        public int FbDtajournalId { get; set; }
        public int Status { get; set; }
        public byte[] FbDtabuchungTs { get; set; }

        public FbBuchung FbBuchung { get; set; }
        public FbDtajournal FbDtajournal { get; set; }
    }
}
