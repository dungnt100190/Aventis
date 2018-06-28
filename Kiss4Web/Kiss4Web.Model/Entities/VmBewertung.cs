using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmBewertung
    {
        public int VmBewertungId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Datum { get; set; }
        public int? VmMandatstypCode { get; set; }
        public string VmKriterienCodes { get; set; }
        public string VmKriterienListe { get; set; }
        public int? UserId { get; set; }
        public int VmFallgewichtungStichtagCode { get; set; }
        public int VmFallgewichtungJahr { get; set; }
        public int? VmMandatstypBewilligtCode { get; set; }
        public int? ProduktId { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmBewertungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
