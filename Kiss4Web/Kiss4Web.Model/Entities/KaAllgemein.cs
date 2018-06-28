using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAllgemein
    {
        public int KaAllgemeinId { get; set; }
        public int FaLeistungId { get; set; }
        public byte[] KaAllgemeinTs { get; set; }
        public bool? SichtbarSdflag { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
