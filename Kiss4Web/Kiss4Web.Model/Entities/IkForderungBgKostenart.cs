using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkForderungBgKostenart
    {
        public int IkForderungBgKostenartId { get; set; }
        public int BgKostenartIdAuszahlung { get; set; }
        public int BgKostenartIdForderung { get; set; }
        public int? IkForderungEinmaligCode { get; set; }
        public int? IkForderungPeriodischCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkForderungBgKostenartTs { get; set; }

        public BgKostenart BgKostenartIdAuszahlungNavigation { get; set; }
        public BgKostenart BgKostenartIdForderungNavigation { get; set; }
    }
}
