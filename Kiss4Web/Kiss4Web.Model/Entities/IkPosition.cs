using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkPosition
    {
        public IkPosition()
        {
            IkForderungPosition = new HashSet<IkForderungPosition>();
            IkRatenplanForderung = new HashSet<IkRatenplanForderung>();
            KbBuchung = new HashSet<KbBuchung>();
        }

        public int IkPositionId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? IkRechtstitelId { get; set; }
        public bool? Einmalig { get; set; }
        public DateTime? Datum { get; set; }
        public int Monat { get; set; }
        public int Jahr { get; set; }
        public int? BaPersonId { get; set; }
        public decimal? TotalAliment { get; set; }
        public decimal? TotalAlimentSoll { get; set; }
        public decimal? BetragAlbv { get; set; }
        public decimal? BetragAlbvsoll { get; set; }
        public decimal? BetragKiZulage { get; set; }
        public decimal? BetragKiZulageSoll { get; set; }
        public decimal? BetragAlbvverrechnung { get; set; }
        public decimal? BetragEinmalig { get; set; }
        public decimal? BetragAuszahlung { get; set; }
        public int? IkForderungCode { get; set; }
        public decimal? IndexStandBeiBerechnung { get; set; }
        public DateTime? IndexStandDatum { get; set; }
        public bool? ErledigterMonat { get; set; }
        public bool? Unterstuetzungsfall { get; set; }
        public bool? Albvberechtigt { get; set; }
        public bool? BetragIstNegativ { get; set; }
        public string Bemerkung { get; set; }
        public byte[] IkPositionTs { get; set; }
        public int? TmpAiForderungIdEinmalig { get; set; }
        public int? TmpAiForderungId { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
        public ICollection<IkForderungPosition> IkForderungPosition { get; set; }
        public ICollection<IkRatenplanForderung> IkRatenplanForderung { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
    }
}
