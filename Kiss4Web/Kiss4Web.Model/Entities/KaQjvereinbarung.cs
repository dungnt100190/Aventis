using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjvereinbarung
    {
        public int KaQjvereinbarungId { get; set; }
        public int FaLeistungId { get; set; }
        public bool? Vereinbarung { get; set; }
        public DateTime? ErstelltAm { get; set; }
        public int? DauerCode { get; set; }
        public bool? Erfuellt { get; set; }
        public string GrundZiel { get; set; }
        public string Abmachungen { get; set; }
        public int? VereinbarungDokId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQjvereinbarungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
