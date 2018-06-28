using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XMessage
    {
        public string MaskName { get; set; }
        public string MessageName { get; set; }
        public int? MessageTid { get; set; }
        public int? MessageCode { get; set; }
        public string Context { get; set; }
        public byte[] XmessageTs { get; set; }
    }
}
