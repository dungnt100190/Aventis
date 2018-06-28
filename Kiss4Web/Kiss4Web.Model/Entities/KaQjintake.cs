using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjintake
    {
        public KaQjintake()
        {
            KaQjintakeGespraech = new HashSet<KaQjintakeGespraech>();
        }

        public int KaQjintakeId { get; set; }
        public int FaLeistungId { get; set; }
        public int? ZuweiserId { get; set; }
        public int? ZuteilungCode { get; set; }
        public int? WerkstattCode { get; set; }
        public bool ExternFlag { get; set; }
        public string Eintritt { get; set; }
        public int? WartelisteCode { get; set; }
        public int? KaQjIntakeSpracheCodeHauptsprache { get; set; }
        public int? KaQjIntakeSpracheCodeErstsprache { get; set; }
        public string Bemerkung { get; set; }
        public bool SichtbarSdflag { get; set; }
        public bool? AbgemeldetAlvflag { get; set; }
        public bool? NichtErschFlag { get; set; }
        public bool? GesprStattgefFlag { get; set; }
        public int? DocumentIdIntakegespraech { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaQjintakeTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public ICollection<KaQjintakeGespraech> KaQjintakeGespraech { get; set; }
    }
}
