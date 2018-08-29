namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaArbeitsrapport")]
    public partial class KaArbeitsrapport
    {
        public int KaArbeitsrapportID { get; set; }

        public int BaPersonID { get; set; }

        public int KaEinsatzID { get; set; }

        public DateTime? Datum { get; set; }

        public int? AM_AnwCode { get; set; }

        public float? AM_Std { get; set; }

        public string AM_Bemerkung { get; set; }

        public int? PM_AnwCode { get; set; }

        public float? PM_Std { get; set; }

        public string PM_Bemerkung { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaArbeitsrapportTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
