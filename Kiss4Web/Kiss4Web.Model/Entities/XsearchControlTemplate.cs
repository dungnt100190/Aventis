using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XsearchControlTemplate
    {
        public XsearchControlTemplate()
        {
            InverseParentXsearchControlTemplate = new HashSet<XsearchControlTemplate>();
            XsearchControlTemplateField = new HashSet<XsearchControlTemplateField>();
        }

        public int XsearchControlTemplateId { get; set; }
        public string ClassName { get; set; }
        public int UserId { get; set; }
        public int? ModulTreeId { get; set; }
        public string Name { get; set; }
        public int? ParentXsearchControlTemplateId { get; set; }
        public int SortKey { get; set; }
        public string ColLayout { get; set; }
        public bool SearchImmediately { get; set; }

        public XmodulTree ModulTree { get; set; }
        public XsearchControlTemplate ParentXsearchControlTemplate { get; set; }
        public XUser User { get; set; }
        public ICollection<XsearchControlTemplate> InverseParentXsearchControlTemplate { get; set; }
        public ICollection<XsearchControlTemplateField> XsearchControlTemplateField { get; set; }
    }
}
