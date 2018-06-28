using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XtypeConfig
    {
        public int XtypeConfigId { get; set; }
        public string LookupTypeName { get; set; }
        public string LookupTypeNamespace { get; set; }
        public string LookupTypeAssemblyName { get; set; }
        public string ConcreteStandardTypeName { get; set; }
        public string ConcreteStandardTypeNamespace { get; set; }
        public string ConcreteStandardTypeAssemblyName { get; set; }
        public string ConcreteCustomTypeName { get; set; }
        public string ConcreteCustomTypeNamespace { get; set; }
        public string ConcreteCustomTypeAssemblyName { get; set; }
        public int InstanceScopeCode { get; set; }
        public byte[] XtypeConfigTs { get; set; }
    }
}
