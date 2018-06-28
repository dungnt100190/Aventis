using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xrule
    {
        public Xrule()
        {
            XclassRule = new HashSet<XclassRule>();
        }

        public int XruleId { get; set; }
        public int RuleCode { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public string CsCode { get; set; }
        public bool PublicRule { get; set; }
        public bool TemplateRule { get; set; }
        public int? ModulId { get; set; }
        public int? DefaultSortKey { get; set; }
        public byte[] XruleTs { get; set; }

        public XModul Modul { get; set; }
        public ICollection<XclassRule> XclassRule { get; set; }
    }
}
