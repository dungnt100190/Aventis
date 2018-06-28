using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FsDienstleistung
    {
        public FsDienstleistung()
        {
            FsDienstleistungFsDienstleistungspaket = new HashSet<FsDienstleistungFsDienstleistungspaket>();
        }

        public int FsDienstleistungId { get; set; }
        public string Name { get; set; }
        public decimal StandardAufwand { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FsDienstleistungTs { get; set; }

        public ICollection<FsDienstleistungFsDienstleistungspaket> FsDienstleistungFsDienstleistungspaket { get; set; }
    }
}
