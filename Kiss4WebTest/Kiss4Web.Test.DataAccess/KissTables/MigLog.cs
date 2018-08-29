namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MigLog")]
    public partial class MigLog
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Function { get; set; }

        [StringLength(100)]
        public string Table { get; set; }

        [StringLength(100)]
        public string Column { get; set; }

        [StringLength(30)]
        public string Time { get; set; }

        public int? Rows { get; set; }

        public int? Duration_ms { get; set; }

        [StringLength(200)]
        public string Prms { get; set; }

        [StringLength(1000)]
        public string Error { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] MigLogTS { get; set; }
    }
}
