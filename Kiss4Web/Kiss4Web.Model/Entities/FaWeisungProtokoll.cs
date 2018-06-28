using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaWeisungProtokoll
    {
        public int FaWeisungProtokollId { get; set; }
        public int FaWeisungId { get; set; }
        public string Aktion { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? Termin { get; set; }
        public string Verantwortlich { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaWeisungProtokollTs { get; set; }

        public FaWeisung FaWeisung { get; set; }
    }
}
