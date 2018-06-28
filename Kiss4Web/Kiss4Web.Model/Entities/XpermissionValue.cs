using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XpermissionValue
    {
        public int PermissionValueId { get; set; }
        public int PermissionGroupId { get; set; }
        public int? PermissionCode { get; set; }
        public int? BgPositionsartId { get; set; }
        public byte[] XpermissionValueTs { get; set; }

        public BgPositionsart BgPositionsart { get; set; }
        public XpermissionGroup PermissionGroup { get; set; }
    }
}
