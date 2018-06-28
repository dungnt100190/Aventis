using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BdeuserGroupBdeleistungsart
    {
        public int BdeuserGroupId { get; set; }
        public int BdeleistungsartId { get; set; }
        public byte[] BdeuserGroupBdeleistungsartTs { get; set; }

        public Bdeleistungsart Bdeleistungsart { get; set; }
        public BdeuserGroup BdeuserGroup { get; set; }
    }
}
