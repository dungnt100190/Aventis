using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkRatenplan
    {
        public IkRatenplan()
        {
            IkRatenplanForderung = new HashSet<IkRatenplanForderung>();
        }

        public int IkRatenplanId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? IkRatenplanVereinbarungCode { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime? VereinbarungVom { get; set; }
        public decimal GesamtBetrag { get; set; }
        public decimal BetragProMonat { get; set; }
        public decimal LetzterProMonat { get; set; }
        public string Bemerkung { get; set; }
        public byte[] IkRatenplanTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public ICollection<IkRatenplanForderung> IkRatenplanForderung { get; set; }
    }
}
