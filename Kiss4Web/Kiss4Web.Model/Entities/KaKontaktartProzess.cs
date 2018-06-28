using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaKontaktartProzess
    {
        public int KaKontaktartProzessId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime Datum { get; set; }
        public int KaKontaktartProzessCode { get; set; }
        public int? KaKontaktartProzessStatusCode { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaKontaktartProzessTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
