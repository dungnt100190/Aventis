using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAkzuweiser
    {
        public int KaAkzuweiserId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Erfassung { get; set; }
        public int? AnmeldungCode { get; set; }
        public int? InstitutionId { get; set; }
        public int? BeraterId { get; set; }
        public bool? SichtbarSdflag { get; set; }
        public byte[] KaAkzuweiserTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
