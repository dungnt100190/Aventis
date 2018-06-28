using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaPlz
    {
        public int BaPlzid { get; set; }
        public int Plz { get; set; }
        public int? Plz6 { get; set; }
        public int? Plzsuffix { get; set; }
        public string Name { get; set; }
        public int? NameTid { get; set; }
        public string Kanton { get; set; }
        public int SortKey { get; set; }
        public int Bfscode { get; set; }
        public int? Onrp { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public bool System { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaPlzts { get; set; }
    }
}
