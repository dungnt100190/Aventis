using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XprofileTag
    {
        public XprofileTag()
        {
            XprofileXprofileTag = new HashSet<XprofileXprofileTag>();
        }

        public int XprofileTagId { get; set; }
        public int? NameTid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XprofileTagTs { get; set; }

        public ICollection<XprofileXprofileTag> XprofileXprofileTag { get; set; }
    }
}
