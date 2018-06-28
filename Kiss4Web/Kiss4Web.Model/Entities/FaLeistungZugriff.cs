using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaLeistungZugriff
    {
        public int FaLeistungZugriffId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserId { get; set; }
        public bool DarfMutieren { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public byte[] FaLeistungZugriffTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
