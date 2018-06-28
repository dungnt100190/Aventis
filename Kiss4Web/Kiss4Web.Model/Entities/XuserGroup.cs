using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XUserGroup : IEntity, IAuditableEntity
    {
        public XUserGroup()
        {
            XuserGroupRight = new HashSet<XUserGroupRight>();
            XUserUserGroup = new HashSet<XUserUserGroup>();
        }

        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public int? UserGroupNameTid { get; set; }
        public bool OnlyAdminVisible { get; set; }
        public string Description { get; set; }
        public int? DescriptionTid { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XuserGroupTs { get; set; }

        public ICollection<XUserGroupRight> XuserGroupRight { get; set; }
        public ICollection<XUserUserGroup> XUserUserGroup { get; set; }
        public int Id => UserGroupId;
        public byte[] RowVersion => XuserGroupTs;
    }
}