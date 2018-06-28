using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAbklaerungVertieftProbeeinsatz
    {
        public int KaAbklaerungVertieftProbeeinsatzId { get; set; }
        public int KaAbklaerungVertieftId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaAbklaerungProzessschrittCode { get; set; }
        public int? DocumentIdProzessschritt { get; set; }
        public bool HatStattgefunden { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaAbklaerungVertieftProbeeinsatzTs { get; set; }

        public KaAbklaerungVertieft KaAbklaerungVertieft { get; set; }
    }
}
