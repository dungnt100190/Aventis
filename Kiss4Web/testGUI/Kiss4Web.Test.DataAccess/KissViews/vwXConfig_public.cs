namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vwXConfig_public
    {
        public int? XNamespaceExtensionID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string KeyPath { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool System { get; set; }

        public DateTime? DatumVon { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ValueCode { get; set; }

        [StringLength(100)]
        public string LOVName { get; set; }

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
    }
}
