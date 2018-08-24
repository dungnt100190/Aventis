namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XPermissionValue")]
    public partial class XPermissionValue
    {
        [Key]
        public int PermissionValueID { get; set; }

        public int PermissionGroupID { get; set; }

        public int? PermissionCode { get; set; }

        public int? BgPositionsartID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XPermissionValueTS { get; set; }

        public virtual BgPositionsart BgPositionsart { get; set; }

        public virtual XPermissionGroup XPermissionGroup { get; set; }
    }
}
