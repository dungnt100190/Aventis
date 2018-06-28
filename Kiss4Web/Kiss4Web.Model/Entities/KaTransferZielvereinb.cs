using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaTransferZielvereinb
    {
        public int KaTransferZielvereinbId { get; set; }
        public int FaLeistungId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public DateTime? FeinzielDat { get; set; }
        public string Feinziel { get; set; }
        public string ErreichenBis { get; set; }
        public string ProzessAuftrag { get; set; }
        public string Ergebnis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaTransferZielvereinbTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
