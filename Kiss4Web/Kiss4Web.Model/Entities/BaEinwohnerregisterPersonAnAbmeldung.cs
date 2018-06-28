using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaEinwohnerregisterPersonAnAbmeldung
    {
        public int BaEinwohnerregisterPersonAnAbmeldungId { get; set; }
        public int BaPersonId { get; set; }
        public string FremdsystemId { get; set; }
        public int Status { get; set; }
        public DateTime Datum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaEinwohnerregisterPersonAnAbmeldungTs { get; set; }

        public BaPerson BaPerson { get; set; }
    }
}
