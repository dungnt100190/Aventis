using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdeuserGroup
    {
        public BdeuserGroup()
        {
            BdeuserGroupBdeleistungsart = new HashSet<BdeuserGroupBdeleistungsart>();
            XuserBdeuserGroup = new HashSet<XuserBdeuserGroup>();
        }

        public int BdeuserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public int? UserGroupNameTid { get; set; }
        public string Beschreibung { get; set; }
        public byte[] BdeuserGroupTs { get; set; }

        public ICollection<BdeuserGroupBdeleistungsart> BdeuserGroupBdeleistungsart { get; set; }
        public ICollection<XuserBdeuserGroup> XuserBdeuserGroup { get; set; }
    }
}
