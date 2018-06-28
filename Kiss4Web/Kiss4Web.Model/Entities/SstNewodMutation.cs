using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class SstNewodMutation
    {
        public int NewodMutationId { get; set; }
        public int NewodNummer { get; set; }
        public string Data { get; set; }
        public string Mutationsart { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime Imported { get; set; }
        public bool Processed { get; set; }
    }
}
