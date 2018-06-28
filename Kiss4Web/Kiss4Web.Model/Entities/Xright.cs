using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XRight : IEntity, IAuditableEntity
    {
        public XRight()
        {
            XuserGroupRight = new HashSet<XUserGroupRight>();
        }

        public int RightId { get; set; }
        public int XclassId { get; set; }
        public string ClassName { get; set; }
        public string RightName { get; set; }
        public string UserText { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XrightTs { get; set; }

        public XClass XClass { get; set; }
        public ICollection<XUserGroupRight> XuserGroupRight { get; set; }
        public int Id => RightId;
        public byte[] RowVersion => XrightTs;
    }
}