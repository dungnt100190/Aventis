using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class SstNewodMapping
    {
        public int NewodMappingId { get; set; }
        public string Attribut { get; set; }
        public string KissWert { get; set; }
        public string NewodWert { get; set; }
        public string KissBedeutung { get; set; }
        public string NewodBedeutung { get; set; }
        public string NewodAttribut { get; set; }
    }
}
