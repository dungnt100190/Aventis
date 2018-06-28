using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMassnahmeKesArtikel
    {
        public int KesMassnahmeKesArtikelId { get; set; }
        public int KesMassnahmeId { get; set; }
        public int KesArtikelId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesMassnahmeKesArtikelTs { get; set; }

        public KesArtikel KesArtikel { get; set; }
        public KesMassnahme KesMassnahme { get; set; }
    }
}
