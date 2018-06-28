using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XdbserverVersion
    {
        public int XdbserverVersionId { get; set; }
        public string ServerVersion { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public byte[] XdbserverVersionTs { get; set; }
    }
}
