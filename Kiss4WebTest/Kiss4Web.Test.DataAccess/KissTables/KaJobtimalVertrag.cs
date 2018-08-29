namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaJobtimalVertrag")]
    public partial class KaJobtimalVertrag
    {
        public int KaJobtimalVertragID { get; set; }

        public int? KaVermittlungVorschlagID { get; set; }

        public DateTime? Datum { get; set; }

        public int KaJobtimalVertragTypCode { get; set; }

        public int? DocumentID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaJobtimalVertragTS { get; set; }

        public virtual KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
