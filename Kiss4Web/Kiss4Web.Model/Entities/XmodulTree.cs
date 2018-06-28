using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XmodulTree
    {
        public XmodulTree()
        {
            InverseModul = new HashSet<XmodulTree>();
            XsearchControlTemplate = new HashSet<XsearchControlTemplate>();
        }

        public int ModulTreeId { get; set; }
        public int? ModulTreeIdParent { get; set; }
        public int ModulId { get; set; }
        public int SortKey { get; set; }
        public int XiconId { get; set; }
        public string Name { get; set; }
        public int? NameTid { get; set; }
        public string ClassName { get; set; }
        public string MaskName { get; set; }
        public string SqlPreExecute { get; set; }
        public int ModulTreeCode { get; set; }
        public string SqlInsertTreeItem { get; set; }
        public bool? Active { get; set; }
        public byte[] XmodulTreeTs { get; set; }

        public DynaMask MaskNameNavigation { get; set; }
        public XmodulTree Modul { get; set; }
        public Xicon Xicon { get; set; }
        public ICollection<XmodulTree> InverseModul { get; set; }
        public ICollection<XsearchControlTemplate> XsearchControlTemplate { get; set; }
    }
}
