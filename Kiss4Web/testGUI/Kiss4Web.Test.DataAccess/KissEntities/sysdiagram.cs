namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sysdiagram
    {
        [Key]
        [Column(Order = 0)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int principal_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int diagram_id { get; set; }

        public int? version { get; set; }

        public byte[] definition { get; set; }
    }
}
