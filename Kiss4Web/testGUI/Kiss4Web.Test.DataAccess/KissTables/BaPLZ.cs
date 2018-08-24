namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaPLZ")]
    public partial class BaPLZ
    {
        public int BaPLZID { get; set; }

        public int PLZ { get; set; }

        public int? PLZ6 { get; set; }

        public int? PLZSuffix { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? NameTID { get; set; }

        [Required]
        [StringLength(2)]
        public string Kanton { get; set; }

        public int SortKey { get; set; }

        public int BFSCode { get; set; }

        public int? ONRP { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool System { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPLZTS { get; set; }
    }
}
