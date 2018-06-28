using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjpzbericht
    {
        public int KaQjpzberichtId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaQjpzberichtTypCode { get; set; }
        public int? DocumentId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaQjpzberichtTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
