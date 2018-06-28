using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XnamespaceExtension
    {
        public XnamespaceExtension()
        {
            Xconfig = new HashSet<XConfig>();
        }

        public int XnamespaceExtensionId { get; set; }
        public string NamespaceExtension { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XnamespaceExtensionTs { get; set; }

        public ICollection<XConfig> Xconfig { get; set; }
    }
}