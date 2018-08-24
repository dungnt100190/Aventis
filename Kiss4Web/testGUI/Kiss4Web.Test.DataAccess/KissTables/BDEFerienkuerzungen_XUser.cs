namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BDEFerienkuerzungen_XUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Jahr { get; set; }

        [Column(TypeName = "money")]
        public decimal FerienkuerzungStd { get; set; }

        public bool ManualEdit { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BDEFerienkuerzungen_XUserTS { get; set; }

        public int? VerID { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
