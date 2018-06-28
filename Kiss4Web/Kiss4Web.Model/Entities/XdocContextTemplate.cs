using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XdocContextTemplate
    {
        public XdocContextTemplate()
        {
            InverseParent = new HashSet<XdocContextTemplate>();
        }

        public int XdocContextTemplateId { get; set; }
        public int? ParentId { get; set; }
        public int? ParentPosition { get; set; }
        public string FolderName { get; set; }
        public int? DocContextId { get; set; }
        public int? DocTemplateId { get; set; }
        public byte[] XdocContextTemplateTs { get; set; }
        public int? ModulId { get; set; }

        public XdocContext DocContext { get; set; }
        public XDocTemplate DocTemplate { get; set; }
        public XModul Modul { get; set; }
        public XdocContextTemplate Parent { get; set; }
        public ICollection<XdocContextTemplate> InverseParent { get; set; }
    }
}
