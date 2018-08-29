namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XViewIndex")]
    public partial class XViewIndex
    {
        [StringLength(128)]
        public string IndexName { get; set; }

        [Key]
        public string TableName { get; set; }

        public bool? PrimaryKey { get; set; }

        public bool? Unique { get; set; }

        public bool? Clustered { get; set; }

        [StringLength(500)]
        public string Keys { get; set; }
    }
}
