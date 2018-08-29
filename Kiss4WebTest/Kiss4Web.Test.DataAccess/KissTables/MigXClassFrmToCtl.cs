namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MigXClassFrmToCtl")]
    public partial class MigXClassFrmToCtl
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string FormName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string ControlName { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsFormClassItemInKiSS5 { get; set; }
    }
}
