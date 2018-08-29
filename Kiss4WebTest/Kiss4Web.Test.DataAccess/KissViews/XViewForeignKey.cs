namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XViewForeignKey
    {
        [Key]
        public string ForeignKeyName { get; set; }

        [StringLength(128)]
        public string PKTable { get; set; }

        [StringLength(500)]
        public string PKColumns { get; set; }

        [StringLength(128)]
        public string FKTable { get; set; }

        [StringLength(500)]
        public string FKColumns { get; set; }
    }
}
