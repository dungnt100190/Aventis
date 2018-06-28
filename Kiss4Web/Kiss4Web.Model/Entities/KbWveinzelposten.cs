using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbWveinzelposten
    {
        public KbWveinzelposten()
        {
            InverseStorniertKbWveinzelposten = new HashSet<KbWveinzelposten>();
        }

        public int KbWveinzelpostenId { get; set; }
        public int? StorniertKbWveinzelpostenId { get; set; }
        public int KbWvlaufId { get; set; }
        public int BaPersonId { get; set; }
        public int BaWvcodeId { get; set; }
        public int BaWvcode { get; set; }
        public int KbBuchungKostenartId { get; set; }
        public int KbKostenstelleId { get; set; }
        public int? BgKostenartId { get; set; }
        public int BgSplittingArtCode { get; set; }
        public decimal Betrag { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }
        public bool SplittingDurchWvlaufDatumBis { get; set; }
        public int KbWveinzelpostenStatusCode { get; set; }
        public bool Fakturiert { get; set; }
        public bool Ungueltig { get; set; }
        public string Buchungstext { get; set; }
        public string HeimatkantonNr { get; set; }
        public string WohnKantonNr { get; set; }
        public string KantonKuerzel { get; set; }
        public bool? Auslandschweizer { get; set; }
        public string Bemerkungen { get; set; }
        public byte[] KbWveinzelpositionTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaWvcode BaWvcodeNavigation { get; set; }
        public BgKostenart BgKostenart { get; set; }
        public KbBuchungKostenart KbBuchungKostenart { get; set; }
        public KbKostenstelle KbKostenstelle { get; set; }
        public KbWvlauf KbWvlauf { get; set; }
        public KbWveinzelposten StorniertKbWveinzelposten { get; set; }
        public ICollection<KbWveinzelposten> InverseStorniertKbWveinzelposten { get; set; }
    }
}
