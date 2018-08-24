namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XUserGroup_Right
    {
        [Key]
        public int UserGroup_RightID { get; set; }

        public int UserGroupID { get; set; }

        public int? RightID { get; set; }

        public int? XClassID { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        [StringLength(100)]
        public string QueryName { get; set; }

        [StringLength(100)]
        public string MaskName { get; set; }

        public bool MayInsert { get; set; }

        public bool MayUpdate { get; set; }

        public bool MayDelete { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XUserGroup_RightTS { get; set; }

        public virtual DynaMask DynaMask { get; set; }

        public virtual XClass XClass { get; set; }

        public virtual XQuery XQuery { get; set; }

        public virtual XRight XRight { get; set; }

        public virtual XUserGroup XUserGroup { get; set; }
    }
}
