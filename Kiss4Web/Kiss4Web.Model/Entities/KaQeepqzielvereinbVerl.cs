using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQeepqzielvereinbVerl
    {
        public int KaQeepqzielvereinbVerlId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? FeinzielDat { get; set; }
        public string Feinziel { get; set; }
        public string ErreichenBis { get; set; }
        public string MessungZielerreichung { get; set; }
        public string Ergebnis { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQeepqzielvereinbVerlTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
