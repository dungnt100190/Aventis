namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XOrgUnit_User
    {
        public int XOrgUnit_UserID { get; set; }

        public int OrgUnitID { get; set; }

        public int UserID { get; set; }

        public int OrgUnitMemberCode { get; set; }

        public bool MayInsert { get; set; }

        public bool MayUpdate { get; set; }

        public bool MayDelete { get; set; }

        public int? VerID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XOrgUnit_UserTS { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
