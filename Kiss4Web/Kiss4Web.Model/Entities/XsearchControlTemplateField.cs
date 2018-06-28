using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XsearchControlTemplateField
    {
        public int XsearchControlTemplateFieldId { get; set; }
        public int XsearchControlTemplateId { get; set; }
        public string ControlName { get; set; }
        public string ControlType { get; set; }
        public string Value { get; set; }

        public XsearchControlTemplate XsearchControlTemplate { get; set; }
    }
}
