using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FsReduktionMitarbeiter
    {
        public int FsReduktionMitarbeiterId { get; set; }
        public int FsReduktionId { get; set; }
        public int UserId { get; set; }
        public decimal OriginalReduktionZeit { get; set; }
        public decimal? AngepassteReduktionZeit { get; set; }
        public int Monat { get; set; }
        public int Jahr { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FsReduktionMitarbeiterTs { get; set; }

        public FsReduktion FsReduktion { get; set; }
        public XUser User { get; set; }
    }
}
