namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaSequenzen")]
    public partial class KaSequenzen
    {
        public int KaSequenzenID { get; set; }

        public int BaPersonID { get; set; }

        public int? SequenzCode { get; set; }

        public int? PraesenzCode { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaSequenzenTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
