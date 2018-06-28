using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkAnzeige
    {
        public int IkAnzeigeId { get; set; }
        public int FaLeistungId { get; set; }
        public int IkAnzeigeTypCode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? IkAnzeigeEroeffnungGrundCode { get; set; }
        public string EroeffnungGrund { get; set; }
        public int? IkAnzeigeAbschlussGrundCode { get; set; }
        public string Bemerkung { get; set; }
        public byte[] IkAnzeigeTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
