namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDEFerienanspruch_XUser
    {
        public int BDEFerienanspruch_XUserID { get; set; }

        public int UserID { get; set; }

        public int Jahr { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Column(TypeName = "money")]
        public decimal FerienanspruchStdProJahr { get; set; }

        public bool ManualEdit { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEFerienanspruch_XUserTS { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
