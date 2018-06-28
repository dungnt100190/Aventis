using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgAuszahlungPersonTermin
    {
        public int BgAuszahlungPersonTerminId { get; set; }
        public int BgAuszahlungPersonId { get; set; }
        public DateTime Datum { get; set; }
        public byte[] BgAuszahlungPersonTerminTs { get; set; }

        public BgAuszahlungPerson BgAuszahlungPerson { get; set; }
    }
}
