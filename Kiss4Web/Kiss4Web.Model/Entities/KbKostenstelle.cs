using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbKostenstelle
    {
        public KbKostenstelle()
        {
            BgFinanzplanBaPersonKbKostenstelle = new HashSet<BgFinanzplanBaPerson>();
            BgFinanzplanBaPersonKbKostenstelleIdKvgNavigation = new HashSet<BgFinanzplanBaPerson>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
            KbKostenstelleBaPerson = new HashSet<KbKostenstelleBaPerson>();
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
        }

        public int KbKostenstelleId { get; set; }
        public string Nr { get; set; }
        public string Name { get; set; }
        public decimal? Vorsaldo { get; set; }
        public bool Aktiv { get; set; }
        public int? ModulId { get; set; }
        public byte[] KbKostenstelleTs { get; set; }

        public XModul Modul { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPersonKbKostenstelle { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPersonKbKostenstelleIdKvgNavigation { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
        public ICollection<KbKostenstelleBaPerson> KbKostenstelleBaPerson { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
    }
}
