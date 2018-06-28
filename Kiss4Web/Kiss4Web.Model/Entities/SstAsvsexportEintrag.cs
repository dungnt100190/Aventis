using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class SstAsvsexportEintrag
    {
        public int SstAsvsexportEintragId { get; set; }
        public int SstAsvsexportId { get; set; }
        public int WhAsvseintragId { get; set; }
        public int? AsvsexportCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public string Modified { get; set; }
        public byte[] SstAsvsexportEintragTs { get; set; }

        public SstAsvsexport SstAsvsexport { get; set; }
        public WhAsvseintrag WhAsvseintrag { get; set; }
    }
}
