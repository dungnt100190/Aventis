using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaZeitlichePlanung
    {
        public int FaZeitlichePlanungId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Phase1Ende { get; set; }
        public DateTime? Phase1SitAnalyse { get; set; }
        public string Phase1Bemerkungen { get; set; }
        public DateTime? Phase2Beginn { get; set; }
        public DateTime? Phase2Ende { get; set; }
        public DateTime? Phase2SitAnalyse { get; set; }
        public string Phase2Bemerkungen { get; set; }
        public DateTime? Phase3Beginn { get; set; }
        public DateTime? Phase3SitAnalyse { get; set; }
        public string Phase3Bemerkungen { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaZeitlichePlanungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
