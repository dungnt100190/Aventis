using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FsReduktion
    {
        public FsReduktion()
        {
            FsReduktionMitarbeiter = new HashSet<FsReduktionMitarbeiter>();
        }

        public int FsReduktionId { get; set; }
        public int? BdeleistungsartId { get; set; }
        public string Name { get; set; }
        public decimal StandardAufwand { get; set; }
        public bool AbhaengigVonBg { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FsReduktionTs { get; set; }

        public Bdeleistungsart Bdeleistungsart { get; set; }
        public ICollection<FsReduktionMitarbeiter> FsReduktionMitarbeiter { get; set; }
    }
}
