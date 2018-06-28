using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjprozess
    {
        public int KaQjprozessId { get; set; }
        public int FaLeistungId { get; set; }
        public int? KompetenzDokId { get; set; }
        public int? ZwischenzeugnisDokId { get; set; }
        public int? LebenslaufDokId { get; set; }
        public int? StandortbestDokId { get; set; }
        public int? ProgrammBildungDokId { get; set; }
        public int? BeilageSemodokId { get; set; }
        public DateTime? ProgEnde { get; set; }
        public int? BeraterId { get; set; }
        public int? FallfuehrungId { get; set; }
        public string AndereStellen { get; set; }
        public int? ProgEndeGrund { get; set; }
        public int? ProgEndeCode { get; set; }
        public int? AbbruchCode { get; set; }
        public int? TermineStaoDokId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQjprozessTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
