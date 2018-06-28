using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaLeistungBewertung
    {
        public int FaBewertungId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Termin { get; set; }
        public DateTime? Datum { get; set; }
        public int? FaBewertungCode { get; set; }
        public string FaKriterienCodes { get; set; }
        public int? UserId { get; set; }
        public byte[] FaLeistungBewertungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
