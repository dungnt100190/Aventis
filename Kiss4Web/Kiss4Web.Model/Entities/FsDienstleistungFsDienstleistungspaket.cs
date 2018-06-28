using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FsDienstleistungFsDienstleistungspaket
    {
        public int FsDienstleistungFsDienstleistungspaketId { get; set; }
        public int FsDienstleistungId { get; set; }
        public int FsDienstleistungspaketId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FsDienstleistungFsDienstleistungspaketTs { get; set; }

        public FsDienstleistung FsDienstleistung { get; set; }
        public FsDienstleistungspaket FsDienstleistungspaket { get; set; }
    }
}
