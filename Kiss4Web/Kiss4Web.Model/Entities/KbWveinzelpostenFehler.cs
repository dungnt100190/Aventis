using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbWveinzelpostenFehler
    {
        public int KbWveinzelpostenFehlerId { get; set; }
        public int KbWvlaufId { get; set; }
        public int KbBuchungKostenartId { get; set; }
        public int BaPersonId { get; set; }
        public string Wvfehlermeldung { get; set; }
        public byte[] KbWveinzelpostenFehlerTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public KbBuchungKostenart KbBuchungKostenart { get; set; }
        public KbWvlauf KbWvlauf { get; set; }
    }
}
