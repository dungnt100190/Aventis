using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbWvlauf
    {
        public KbWvlauf()
        {
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
            KbWveinzelpostenFehler = new HashSet<KbWveinzelpostenFehler>();
        }

        public int KbWvlaufId { get; set; }
        public int UserId { get; set; }
        public int KbPeriodeId { get; set; }
        public DateTime DatumBisWvlauf { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime? EndDatum { get; set; }
        public bool Testlauf { get; set; }
        public byte[] KbWvlaufTs { get; set; }

        public KbPeriode KbPeriode { get; set; }
        public XUser User { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
        public ICollection<KbWveinzelpostenFehler> KbWveinzelpostenFehler { get; set; }
    }
}
