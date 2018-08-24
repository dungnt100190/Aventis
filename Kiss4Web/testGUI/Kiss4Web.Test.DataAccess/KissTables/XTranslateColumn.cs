namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTranslateColumn")]
    public partial class XTranslateColumn
    {
        public int XTranslateColumnID { get; set; }

        [Required]
        [StringLength(255)]
        public string TableName { get; set; }

        [Required]
        [StringLength(255)]
        public string ColumnName { get; set; }

        [Required]
        [StringLength(255)]
        public string TIDColumnName { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(255)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTranslateColumnTS { get; set; }
    }
}
