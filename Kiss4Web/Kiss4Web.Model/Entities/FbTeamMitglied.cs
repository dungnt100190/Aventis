using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbTeamMitglied
    {
        public int FbTeamId { get; set; }
        public int UserId { get; set; }
        public bool? StandardBereich { get; set; }
        public bool? DepotBereich { get; set; }
        public byte[] FbTeamMitgliedTs { get; set; }

        public FbTeam FbTeam { get; set; }
        public XUser User { get; set; }
    }
}
