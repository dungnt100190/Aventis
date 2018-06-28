using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XhyperlinkContextHyperlink
    {
        public XhyperlinkContextHyperlink()
        {
            InverseParent = new HashSet<XhyperlinkContextHyperlink>();
        }

        public int XhyperlinkContextHyperlinkId { get; set; }
        public int? ParentId { get; set; }
        public int? SortKey { get; set; }
        public string FolderName { get; set; }
        public int XhyperlinkContextId { get; set; }
        public int? XhyperlinkId { get; set; }
        public int? UserProfileCode { get; set; }
        public byte[] XhyperlinkContextHyperlinkTs { get; set; }

        public XhyperlinkContextHyperlink Parent { get; set; }
        public Xhyperlink Xhyperlink { get; set; }
        public XhyperlinkContext XhyperlinkContext { get; set; }
        public ICollection<XhyperlinkContextHyperlink> InverseParent { get; set; }
    }
}
