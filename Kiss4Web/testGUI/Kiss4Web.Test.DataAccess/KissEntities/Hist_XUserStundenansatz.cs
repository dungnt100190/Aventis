namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_XUserStundenansatz
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int XUserStundenansatzID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart3 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart4 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart5 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart6 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart7 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart8 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart9 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart10 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart11 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart12 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart13 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart14 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart15 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart16 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart17 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart18 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart19 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lohnart20 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
