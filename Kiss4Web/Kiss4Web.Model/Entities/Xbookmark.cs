using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xbookmark
    {
        public string BookmarkName { get; set; }
        public int? BookmarkNameTid { get; set; }
        public string Category { get; set; }
        public int? CategoryTid { get; set; }
        public int? BookmarkCode { get; set; }
        public string Sql { get; set; }
        public string Description { get; set; }
        public int? DescriptionTid { get; set; }
        public string TableName { get; set; }
        public int? ModulId { get; set; }
        public bool AlwaysVisible { get; set; }
        public bool System { get; set; }
        public byte[] XbookmarkTs { get; set; }

        public XModul Modul { get; set; }
    }
}
