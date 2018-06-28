using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class BookmarkMetadata
    {
        public string BookmarkDefinitionName { get; set; }
        public int? ColumnCount { get; set; }
        public IEnumerable<dynamic> Data { get; set; }
        public int? LovCode { get; set; }
        public string Name { get; set; }
        public BookmarkStart Start { get; set; }
        public BookmarkType? Type { get; set; }
    }
}