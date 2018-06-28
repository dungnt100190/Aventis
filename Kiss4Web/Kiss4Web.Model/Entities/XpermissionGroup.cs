using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XpermissionGroup
    {
        public XpermissionGroup()
        {
            XpermissionValue = new HashSet<XpermissionValue>();
            XuserGrantPermGroup = new HashSet<XUser>();
            XuserPermissionGroup = new HashSet<XUser>();
        }

        public int PermissionGroupId { get; set; }
        public string PermissionGroupName { get; set; }
        public string Description { get; set; }
        public byte[] XpermissionGroupTs { get; set; }
        public int? Kompetenzstufe { get; set; }

        public ICollection<XpermissionValue> XpermissionValue { get; set; }
        public ICollection<XUser> XuserGrantPermGroup { get; set; }
        public ICollection<XUser> XuserPermissionGroup { get; set; }
    }
}
