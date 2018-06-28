using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class MigLog
    {
        public int Id { get; set; }
        public string Function { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public string Time { get; set; }
        public int? Rows { get; set; }
        public int? DurationMs { get; set; }
        public string Prms { get; set; }
        public string Error { get; set; }
        public byte[] MigLogTs { get; set; }
    }
}
