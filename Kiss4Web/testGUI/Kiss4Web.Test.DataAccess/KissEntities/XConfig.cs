namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XConfig")]
    public partial class XConfig
    {
        public int XConfigID { get; set; }

        public int? XNamespaceExtensionID { get; set; }

        [Required]
        [StringLength(500)]
        public string KeyPath { get; set; }

        public int? KeyPathTID { get; set; }

        public bool System { get; set; }

        public DateTime? DatumVon { get; set; }

        public int ValueCode { get; set; }

        [StringLength(100)]
        public string LOVName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? DescriptionTID { get; set; }

        public bool? ValueBit { get; set; }

        public bool? OriginalValueBit { get; set; }

        public DateTime? ValueDateTime { get; set; }

        public DateTime? OriginalValueDateTime { get; set; }

        public decimal? ValueDecimal { get; set; }

        public decimal? OriginalValueDecimal { get; set; }

        public int? ValueInt { get; set; }

        public int? OriginalValueInt { get; set; }

        [Column(TypeName = "money")]
        public decimal? ValueMoney { get; set; }

        [Column(TypeName = "money")]
        public decimal? OriginalValueMoney { get; set; }

        public string ValueVarchar { get; set; }

        public string OriginalValueVarchar { get; set; }

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
        public byte[] XConfigTS { get; set; }

        public virtual XNamespaceExtension XNamespaceExtension { get; set; }
    }
}
