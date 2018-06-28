using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbDtazugang
    {
        public FbDtazugang()
        {
            FbDtajournal = new HashSet<FbDtajournal>();
            FbKonto = new HashSet<FbKonto>();
        }

        public int FbDtazugangId { get; set; }
        public string Name { get; set; }
        public string VertragNr { get; set; }
        public string KontoNr { get; set; }
        public int? BaBankId { get; set; }
        public int? FbTeamId { get; set; }
        public int KbFinanzInstitutCode { get; set; }
        public byte[] FbDtazugangTs { get; set; }

        public BaBank BaBank { get; set; }
        public FbTeam FbTeam { get; set; }
        public ICollection<FbDtajournal> FbDtajournal { get; set; }
        public ICollection<FbKonto> FbKonto { get; set; }
    }
}
