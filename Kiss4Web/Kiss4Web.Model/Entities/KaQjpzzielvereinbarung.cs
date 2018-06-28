using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjpzzielvereinbarung
    {
        public int KaQjpzzielvereinbarungId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? ZielDatum { get; set; }
        public string VereinbartesZiel { get; set; }
        public string ErreichenBis { get; set; }
        public string KriterienPruefen { get; set; }
        public int? BeurteilungId { get; set; }
        public DateTime? DatumBeurteilung { get; set; }
        public int? ZielvereinbarungDokId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQjpzzielvereinbarungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
