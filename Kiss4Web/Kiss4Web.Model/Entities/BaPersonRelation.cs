using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaPersonRelation
    {
        public int BaPersonRelationId { get; set; }
        public int BaPersonId1 { get; set; }
        public int BaPersonId2 { get; set; }
        public int? BaRelationId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BaPersonRelationTs { get; set; }

        public BaPerson BaPersonId1Navigation { get; set; }
        public BaPerson BaPersonId2Navigation { get; set; }
        public BaRelation BaRelation { get; set; }
    }
}
