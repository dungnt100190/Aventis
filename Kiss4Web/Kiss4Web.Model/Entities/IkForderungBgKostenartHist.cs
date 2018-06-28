using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkForderungBgKostenartHist
    {
        public IkForderungBgKostenartHist()
        {
            KbBuchung = new HashSet<KbBuchung>();
        }

        public int IkForderungBgKostenartHistId { get; set; }
        public int BgKostenartId { get; set; }
        public int? IkForderungPeriodischCode { get; set; }
        public bool IstAlbvBerechtigt { get; set; }
        public bool IstAlbvUeberMax { get; set; }
        public bool IstUnterstuetzungsfall { get; set; }
        public int? IkForderungEinmaligCode { get; set; }
        public int IkForderungsartFilterCode { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkForderungBgKostenartHistTs { get; set; }

        public BgKostenart BgKostenart { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
    }
}
