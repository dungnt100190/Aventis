using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bfslovcode
    {
        public string Lovname { get; set; }
        public int Code { get; set; }
        public string Text { get; set; }
        public int? TextTid { get; set; }
        public string KurzText { get; set; }
        public int? KurzTextTid { get; set; }
        public string Filter { get; set; }
        public int? SortKey { get; set; }
        public byte[] BfslovcodeTs { get; set; }

        public Bfslov LovnameNavigation { get; set; }
    }
}
