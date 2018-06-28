using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaPhase
    {
        public FaPhase()
        {
            DynaValue = new HashSet<DynaValue>();
        }

        public int FaPhaseId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? FsDienstleistungspaketIdZugewiesen { get; set; }
        public int? FsDienstleistungspaketIdBedarf { get; set; }
        public int FaPhaseCode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? AbschlussGrundCode { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaPhaseTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public FsDienstleistungspaket FsDienstleistungspaketIdBedarfNavigation { get; set; }
        public FsDienstleistungspaket FsDienstleistungspaketIdZugewiesenNavigation { get; set; }
        public XUser User { get; set; }
        public ICollection<DynaValue> DynaValue { get; set; }
    }
}
