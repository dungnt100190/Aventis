namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FaWeisung_BaPerson
    {
        public int FaWeisung_BaPersonID { get; set; }

        public int FaWeisungID { get; set; }

        public int BaPersonID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaWeisung_BaPersonTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaWeisung FaWeisung { get; set; }
    }
}
