namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQEEPQZielvereinb")]
    public partial class KaQEEPQZielvereinb
    {
        public int KaQEEPQZielvereinbID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? FeinzielDat { get; set; }

        public string Feinziel { get; set; }

        [StringLength(100)]
        public string ErreichenBis { get; set; }

        public string MessungZielerreichung { get; set; }

        public string Ergebnis { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQEEPQZielvereinbTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
