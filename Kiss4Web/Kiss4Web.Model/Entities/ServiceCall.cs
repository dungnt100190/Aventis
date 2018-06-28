using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class ServiceCall
    {
        public int ServiceCallId { get; set; }
        public int? UserId { get; set; }
        public string MachineName { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string ServiceParam { get; set; }
        public string Info { get; set; }
        public DateTime? ServiceStart { get; set; }
        public DateTime? ServiceEnd { get; set; }
        public int? ServiceResultTypeCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] ServiceCallTs { get; set; }

        public XUser User { get; set; }
    }
}
