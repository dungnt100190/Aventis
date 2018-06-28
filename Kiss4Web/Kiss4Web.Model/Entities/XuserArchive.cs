using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XuserArchive
    {
        public int UserId { get; set; }
        public int ArchiveId { get; set; }
        public byte[] XuserArchiveTs { get; set; }

        public Xarchive Archive { get; set; }
        public XUser User { get; set; }
    }
}
