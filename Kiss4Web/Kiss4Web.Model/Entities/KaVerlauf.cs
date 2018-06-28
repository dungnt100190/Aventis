using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVerlauf
    {
        public int KaVerlaufId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaAllgemKontaktartCode { get; set; }
        public string Kontaktperson { get; set; }
        public string Stichwort { get; set; }
        public string KaAllgemThemaCodes { get; set; }
        public string InhaltRtf { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaVerlaufTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
