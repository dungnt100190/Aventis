using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistoryVersion
    {
        public int VerId { get; set; }
        public DateTime VersionDate { get; set; }
        public string HostName { get; set; }
        public string SystemUser { get; set; }
        public string AppName { get; set; }
        public string DbUser { get; set; }
        public int SessionId { get; set; }
        public string AppUser { get; set; }
        public string UserAction { get; set; }
    }
}
