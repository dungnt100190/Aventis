using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAusbildung
    {
        public int KaAusbildungId { get; set; }
        public int FaLeistungId { get; set; }
        public string Andere { get; set; }
        public int? KaAusbildungVorbildungCode { get; set; }
        public int? KaBecoErlernterBerufCode { get; set; }
        public int? KaVermittlBiBerufsbilCode { get; set; }
        public int? KaVermittlBiBerufserfCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaAusbildungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
