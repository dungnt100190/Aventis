namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_BDESollStundenProJahr_XUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BDESollStundenProJahr_XUserID { get; set; }

        public int UserID { get; set; }

        public int Jahr { get; set; }

        [Column(TypeName = "money")]
        public decimal JanuarStd { get; set; }

        [Column(TypeName = "money")]
        public decimal FebruarStd { get; set; }

        [Column(TypeName = "money")]
        public decimal MaerzStd { get; set; }

        [Column(TypeName = "money")]
        public decimal AprilStd { get; set; }

        [Column(TypeName = "money")]
        public decimal MaiStd { get; set; }

        [Column(TypeName = "money")]
        public decimal JuniStd { get; set; }

        [Column(TypeName = "money")]
        public decimal JuliStd { get; set; }

        [Column(TypeName = "money")]
        public decimal AugustStd { get; set; }

        [Column(TypeName = "money")]
        public decimal SeptemberStd { get; set; }

        [Column(TypeName = "money")]
        public decimal OktoberStd { get; set; }

        [Column(TypeName = "money")]
        public decimal NovemberStd { get; set; }

        [Column(TypeName = "money")]
        public decimal DezemberStd { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalStd { get; set; }

        public bool ManualEdit { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
