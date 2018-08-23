namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJVereinbarung")]
    public partial class KaQJVereinbarung
    {
        public int KaQJVereinbarungID { get; set; }

        public int FaLeistungID { get; set; }

        public bool? Vereinbarung { get; set; }

        public DateTime? ErstelltAm { get; set; }

        public int? DauerCode { get; set; }

        public bool? Erfuellt { get; set; }

        public string GrundZiel { get; set; }

        public string Abmachungen { get; set; }

        public int? VereinbarungDokID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQJVereinbarungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
