using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAssistenz
    {
        public int KaAssistenzId { get; set; }
        public int FaLeistungId { get; set; }
        public bool Abgemeldet { get; set; }
        public bool NichtErschienen { get; set; }
        public bool GespraechStattgefunden { get; set; }
        public bool Programmbeginn { get; set; }
        public string Einsatzplatz { get; set; }
        public string Stufe { get; set; }
        public bool Personalien { get; set; }
        public bool Vereinbarung { get; set; }
        public bool Zielvereinbarung { get; set; }
        public bool Schlussbericht { get; set; }
        public bool Testat { get; set; }
        public string Bemerkungen { get; set; }
        public int? KaAssistenzprojektAustrittsgrundCode { get; set; }
        public DateTime? Austrittsdatum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaAssistenzTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
