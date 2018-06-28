using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbTeam
    {
        public FbTeam()
        {
            FbDtazugang = new HashSet<FbDtazugang>();
            FbPeriode = new HashSet<FbPeriode>();
            FbTeamMitglied = new HashSet<FbTeamMitglied>();
        }

        public int FbTeamId { get; set; }
        public string Name { get; set; }
        public byte[] FbTeamTs { get; set; }

        public ICollection<FbDtazugang> FbDtazugang { get; set; }
        public ICollection<FbPeriode> FbPeriode { get; set; }
        public ICollection<FbTeamMitglied> FbTeamMitglied { get; set; }
    }
}
