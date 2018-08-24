namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XUser_UserGroup
    {
        public int XUser_UserGroupID { get; set; }

        public int UserID { get; set; }

        public int UserGroupID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XUser_UserGroupTS { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUserGroup XUserGroup { get; set; }
    }
}
