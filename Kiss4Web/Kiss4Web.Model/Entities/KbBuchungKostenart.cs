using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbBuchungKostenart
    {
        public KbBuchungKostenart()
        {
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
            KbWveinzelpostenFehler = new HashSet<KbWveinzelpostenFehler>();
        }

        public int KbBuchungKostenartId { get; set; }
        public int KbKostenstelleId { get; set; }
        public int? NrmKontoCode { get; set; }
        public decimal Betrag { get; set; }
        public byte[] KbBuchungKostenartTs { get; set; }
        public int KbBuchungId { get; set; }
        public string KontoNr { get; set; }
        public int? BgKostenartId { get; set; }
        public string Buchungstext { get; set; }
        public int? BgPositionId { get; set; }
        public int? BaPersonId { get; set; }
        public int? PositionImBeleg { get; set; }
        public int? KbForderungArtCode { get; set; }
        public DateTime? VerwPeriodeVon { get; set; }
        public DateTime? VerwPeriodeBis { get; set; }
        public int? BgSplittingArtCode { get; set; }
        public bool Weiterverrechenbar { get; set; }
        public bool Quoting { get; set; }
        public int? GvAuszahlungPositionId { get; set; }

        public BaPerson BaPerson { get; set; }
        public BgKostenart BgKostenart { get; set; }
        public BgPosition BgPosition { get; set; }
        public GvAuszahlungPosition GvAuszahlungPosition { get; set; }
        public KbBuchung KbBuchung { get; set; }
        public KbKostenstelle KbKostenstelle { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
        public ICollection<KbWveinzelpostenFehler> KbWveinzelpostenFehler { get; set; }
    }
}
