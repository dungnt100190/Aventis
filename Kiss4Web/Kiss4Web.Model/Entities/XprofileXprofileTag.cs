using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XprofileXprofileTag
    {
        public int XprofileXprofileTagId { get; set; }
        public int XprofileId { get; set; }
        public int XprofileTagId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XprofileXprofileTagTs { get; set; }

        public Xprofile Xprofile { get; set; }
        public XprofileTag XprofileTag { get; set; }
    }
}
