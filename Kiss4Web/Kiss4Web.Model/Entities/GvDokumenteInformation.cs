using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvDokumenteInformation
    {
        public int GvDokumenteInformationId { get; set; }
        public int BaPersonId { get; set; }
        public string Information { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvDokumenteInformationTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
