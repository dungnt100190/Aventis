using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaRelation
    {
        public int FaRelationId { get; set; }
        public int FaLeistungId1 { get; set; }
        public int FaLeistungId2 { get; set; }
        public int FaRelationTypCode { get; set; }
        public bool CascadeUpdate { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaRelationTs { get; set; }

        public FaLeistung FaLeistungId1Navigation { get; set; }
        public FaLeistung FaLeistungId2Navigation { get; set; }
    }
}
