using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FsDienstleistungspaket
    {
        public FsDienstleistungspaket()
        {
            FaPhaseFsDienstleistungspaketIdBedarfNavigation = new HashSet<FaPhase>();
            FaPhaseFsDienstleistungspaketIdZugewiesenNavigation = new HashSet<FaPhase>();
            FsDienstleistungFsDienstleistungspaket = new HashSet<FsDienstleistungFsDienstleistungspaket>();
        }

        public int FsDienstleistungspaketId { get; set; }
        public string Name { get; set; }
        public decimal? MaximaleLaufzeit { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FsDienstleistungspaketTs { get; set; }

        public ICollection<FaPhase> FaPhaseFsDienstleistungspaketIdBedarfNavigation { get; set; }
        public ICollection<FaPhase> FaPhaseFsDienstleistungspaketIdZugewiesenNavigation { get; set; }
        public ICollection<FsDienstleistungFsDienstleistungspaket> FsDienstleistungFsDienstleistungspaket { get; set; }
    }
}
