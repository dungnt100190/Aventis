using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XuserBdeuserGroup
    {
        public int UserId { get; set; }
        public int BdeuserGroupId { get; set; }
        public byte[] XuserBdeuserGroupTs { get; set; }

        public BdeuserGroup BdeuserGroup { get; set; }
        public XUser User { get; set; }
    }
}
