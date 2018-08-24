namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAllgemein")]
    public partial class KaAllgemein
    {
        public int KaAllgemeinID { get; set; }

        public int FaLeistungID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaAllgemeinTS { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
