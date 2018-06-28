using System;
using System.Collections.Generic;
using Kiss4Web.Model.Fibu;

namespace Kiss4Web.Model
{
    public partial class FbPeriode
    {
        public FbPeriode()
        {
            FbBuchung = new HashSet<FbBuchung>();
            FbKonto = new HashSet<FbKonto>();
        }

        public int FbPeriodeId { get; set; }
        public int BaPersonId { get; set; }
        public DateTime PeriodeVon { get; set; }
        public DateTime PeriodeBis { get; set; }
        public FbPeriodeStatus PeriodeStatusCode { get; set; }
        public int? FbTeamId { get; set; }
        public int? JournalablageortCode { get; set; }
        public byte[] FbPeriodeTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FbTeam FbTeam { get; set; }
        public ICollection<FbBuchung> FbBuchung { get; set; }
        public ICollection<FbKonto> FbKonto { get; set; }
    }
}