namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AyKostenart")]
    public partial class AyKostenart
    {
        [Key]
        [Column(Order = 0)]
        public int BgKostenartID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModulID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string KontoNr { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Quoting { get; set; }

        public int? BgSplittingArtCode { get; set; }

        public int? BaWVZeileCode { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgKostenartTS { get; set; }
    }
}
