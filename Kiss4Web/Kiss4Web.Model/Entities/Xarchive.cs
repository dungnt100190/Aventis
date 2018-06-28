using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xarchive
    {
        public Xarchive()
        {
            FaLeistungArchiv = new HashSet<FaLeistungArchiv>();
            XuserArchive = new HashSet<XuserArchive>();
        }

        public int ArchiveId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SortKey { get; set; }
        public string Remark { get; set; }
        public byte[] XarchiveTs { get; set; }

        public ICollection<FaLeistungArchiv> FaLeistungArchiv { get; set; }
        public ICollection<XuserArchive> XuserArchive { get; set; }
    }
}
