using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xicon
    {
        public Xicon()
        {
            XmodulTree = new HashSet<XmodulTree>();
        }

        public int XiconId { get; set; }
        public string Name { get; set; }
        public byte[] Icon { get; set; }
        public byte[] XiconTs { get; set; }

        public ICollection<XmodulTree> XmodulTree { get; set; }
    }
}
