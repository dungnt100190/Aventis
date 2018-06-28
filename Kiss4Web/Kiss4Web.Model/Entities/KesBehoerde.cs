using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesBehoerde
    {
        public KesBehoerde()
        {
            KesMassnahmeUebernahmeVonKesBehoerde = new HashSet<KesMassnahme>();
            KesMassnahmeUebertragungAnKesBehoerde = new HashSet<KesMassnahme>();
            KesMassnahmeZustaendigKesBehoerde = new HashSet<KesMassnahme>();
        }

        public int KesBehoerdeId { get; set; }
        public string Kesbid { get; set; }
        public string Kanton { get; set; }
        public string Kesbname { get; set; }
        public bool IsActive { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesBehoerdeTs { get; set; }

        public ICollection<KesMassnahme> KesMassnahmeUebernahmeVonKesBehoerde { get; set; }
        public ICollection<KesMassnahme> KesMassnahmeUebertragungAnKesBehoerde { get; set; }
        public ICollection<KesMassnahme> KesMassnahmeZustaendigKesBehoerde { get; set; }
    }
}
