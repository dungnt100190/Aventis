using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkForderung
    {
        public IkForderung()
        {
            IkForderungPosition = new HashSet<IkForderungPosition>();
            IkRatenplanForderung = new HashSet<IkRatenplanForderung>();
        }

        public int IkForderungId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? IkRechtstitelId { get; set; }
        public int? BaPersonId { get; set; }
        public int IkForderungPeriodischCode { get; set; }
        public DateTime DatumAnpassenAb { get; set; }
        public DateTime? DatumGueltigBis { get; set; }
        public decimal? Betrag { get; set; }
        public int? IkAnpassungsGrundCode { get; set; }
        public int? IkAnpassungsRegelCode { get; set; }
        public decimal? IndexStandBeiBerechnung { get; set; }
        public DateTime? IndexStandDatum { get; set; }
        public string Bemerkung { get; set; }
        public bool Sollgestellt { get; set; }
        public bool Albvberechtigt { get; set; }
        public bool Teuerungseinsprache { get; set; }
        public bool Unterstuetzungsfall { get; set; }
        public bool TeilAlbv { get; set; }
        public decimal? TeilAlbvbetrag { get; set; }
        public byte[] IkForderungTs { get; set; }
        public int? TmpAiForderungIdPeriodisch { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
        public ICollection<IkForderungPosition> IkForderungPosition { get; set; }
        public ICollection<IkRatenplanForderung> IkRatenplanForderung { get; set; }
    }
}
